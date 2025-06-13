import os
import json
from flask import Flask, request, jsonify, send_from_directory, send_file
from flask_cors import CORS
import requests
import time

from dotenv import load_dotenv
import re

def parse_pseudo_xml(script: str):
    """
    解析伪XML结构文本，返回结构化列表，每项为：
    {
        "type": "tag"|"text"|"endtag",
        "tag": 标签名（如有）,
        "content": 内容,
        "indent": 缩进空格数,
        "raw": 原始行
    }
    """
    lines = script.splitlines()
    result = []
    tag_re = re.compile(r'^(\s*)<([\w\s]+)>(.*)$')
    end_tag_re = re.compile(r'^(\s*)<end\s+([\w\s]+)>(.*)$')
    for line in lines:
        m = tag_re.match(line)
        m_end = end_tag_re.match(line)
        if m:
            indent = len(m.group(1))
            tag = m.group(2).strip()
            content = m.group(3).strip()
            result.append({
                "type": "tag",
                "tag": tag,
                "content": content,
                "indent": indent,
                "raw": line
            })
        elif m_end:
            indent = len(m_end.group(1))
            tag = "end " + m_end.group(2).strip()
            content = m_end.group(3).strip()
            result.append({
                "type": "endtag",
                "tag": tag,
                "content": content,
                "indent": indent,
                "raw": line
            })
        else:
            # 普通文本或空行
            indent = len(line) - len(line.lstrip(' '))
            result.append({
                "type": "text",
                "tag": None,
                "content": line.strip(),
                "indent": indent,
                "raw": line
            })
    return result

# 加载 .env 环境变量
load_dotenv()

app = Flask(__name__)
CORS(app)

UPLOAD_FOLDER = os.path.join(os.path.dirname(__file__), 'uploads')
os.makedirs(UPLOAD_FOLDER, exist_ok=True)

@app.route('/upload', methods=['POST'])
def upload_json():
    """
    接收前端上传的JSON文件，解析m_Script字段，按行返回。
    支持xml_mode参数，若为1则用伪XML解析。
    """
    file = request.files.get('file')
    if not file:
        return jsonify({'error': '未收到文件'}), 400
    filename = file.filename
    save_path = os.path.join(UPLOAD_FOLDER, filename)
    file.save(save_path)
    xml_mode = request.form.get('xml_mode', '0')
    try:
        with open(save_path, 'r', encoding='utf-8') as f:
            data = json.load(f)
        m_script = data.get('m_Script', '')
        if xml_mode == '1' and m_script:
            parsed = parse_pseudo_xml(m_script)
            lines = [item['content'] for item in parsed]
        else:
            lines = m_script.split('\r\n') if m_script else []
        return jsonify({
            'filename': filename,
            'lines': lines
        })
    except Exception as e:
        return jsonify({'error': f'解析JSON失败: {str(e)}'}), 500

@app.route('/save', methods=['POST'])
def save_json():
    """
    接收前端翻译后的行，组装成新的JSON文件，保存并返回下载链接。
    支持XML模式下结构重组，保留原始标签和缩进。
    """
    req = request.get_json()
    filename = req.get('filename')
    lines = req.get('lines')
    xml_mode = req.get('xml_mode', '0')  # 兼容前端后续扩展
    if not filename or lines is None:
        return jsonify({'error': '缺少参数'}), 400
    src_path = os.path.join(UPLOAD_FOLDER, filename)
    if not os.path.exists(src_path):
        return jsonify({'error': '原文件不存在'}), 404
    try:
        with open(src_path, 'r', encoding='utf-8') as f:
            data = json.load(f)
        m_script = data.get('m_Script', '')
        # 判断是否为XML模式（兼容前端未传xml_mode时，自动识别结构）
        is_xml_mode = False
        if xml_mode == '1':
            is_xml_mode = True
        else:
            # 简单判断：如果原始m_Script中大量以<开头的行，自动判定为伪XML
            if m_script and sum(1 for l in m_script.splitlines() if l.strip().startswith('<')) > 3:
                is_xml_mode = True
        if is_xml_mode and m_script:
            # 重新解析原始结构
            parsed = parse_pseudo_xml(m_script)
            # 用翻译内容替换每一项的 content，重组 raw 行
            new_lines = []
            for i, item in enumerate(parsed):
                new_content = lines[i] if i < len(lines) else item['content']
                # 替换原始行中的内容部分
                if item['type'] == 'tag':
                    prefix = ' ' * item['indent'] + f"<{item['tag']}>"
                    raw = prefix + (f"{new_content}" if new_content else "")
                elif item['type'] == 'endtag':
                    prefix = ' ' * item['indent'] + f"<{item['tag']}>"
                    raw = prefix + (f"{new_content}" if new_content else "")
                else:
                    raw = ' ' * item['indent'] + (f"{new_content}" if new_content else "")
                new_lines.append(raw)
            data['m_Script'] = '\r\n'.join(new_lines)
        else:
            data['m_Script'] = '\r\n'.join(lines)
        out_name = filename  # 保存文件名与原始文件名一致
        out_path = os.path.join(UPLOAD_FOLDER, out_name)
        with open(out_path, 'w', encoding='utf-8') as f:
            json.dump(data, f, ensure_ascii=False, indent=2)
        return jsonify({'download': f'/download/{out_name}'})
    except Exception as e:
        return jsonify({'error': f'保存失败: {str(e)}'}), 500

@app.route('/download/<filename>', methods=['GET'])
def download_file(filename):
    """
    提供翻译后JSON文件的下载。
    """
    return send_from_directory(UPLOAD_FOLDER, filename, as_attachment=True)

@app.route('/gpt_translate', methods=['POST'])
def gpt_translate():
    """
    单行外文转中文，调用GPT接口
    """
    req = request.get_json()
    text = req.get('text', '').strip()
    if not text:
        return jsonify({'error': '缺少待翻译内容'}), 400

    # GPT API参数（从环境变量读取）
    api_url = os.getenv("OPENAI_API_URL", "")
    api_key = os.getenv("OPENAI_API_KEY", "")
    model_name = "gpt-4.1"

    if not api_url or not api_key:
        return jsonify({'error': '未配置OPENAI_API_URL或OPENAI_API_KEY环境变量'}), 500

    prompt = (
        "你是一个历史政治类游戏的文本汉化助手。请将下列外语内容翻译为简明中文，保留所有格式、符号、标签、引号、特殊字符，不要翻译或更改任何标签、尖括号、引号、换行、缩进。"
        "翻译结果不要有多余解释，只返回翻译后的文本：\n"
        "需要翻译的内容如下: \n" + text
    )
    headers = {
        "Authorization": f"Bearer {api_key}",
        "Content-Type": "application/json"
    }
    data = {
        "model": model_name,
        "messages": [
            {"role": "user", "content": prompt}
        ],
        "temperature": 0.3
    }
    try:
        for attempt in range(3):
            resp = requests.post(api_url, headers=headers, json=data, timeout=60)
            if resp.status_code == 401 or resp.status_code == 403:
                return jsonify({'error': 'API鉴权失败'}), 500
            resp.raise_for_status()
            result = resp.json()
            if "choices" in result and result["choices"]:
                content = result["choices"][0]["message"].get("content", "")
                return jsonify({'result': content.strip()})
            time.sleep(2)
        return jsonify({'error': 'GPT接口无响应'}), 500
    except Exception as e:
        return jsonify({'error': f'GPT请求失败: {str(e)}'}), 500

@app.route('/', methods=['GET'])
def index():
    """
    访问根路径时返回前端页面 index.html
    """
    return send_file(os.path.join(os.path.dirname(__file__), 'index.html'))

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000, debug=True)
