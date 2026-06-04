using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class ModifyButtonScript : MonoBehaviour
{
	public OkoshkoScript okno1;

	public int num;

	public SpriteRenderer focus_sprite;

	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public void ChangeText(int num, bool activated)
	{
		okno1.needAutoText = true;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		if (GlobalScript.inst.gameState.data[21] < 1981)
		{
			if (GlobalScript.inst.gameState.empires[0].power > GlobalScript.inst.gameState.empires[1].power)
			{
				num4++;
			}
			else
			{
				num3++;
			}
			if (GlobalScript.inst.gameState.empires[0].power > GlobalScript.inst.gameState.influencePRC)
			{
				num4++;
			}
			else
			{
				num3++;
			}
			if (GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[1].power)
			{
				num4++;
			}
			else
			{
				num3++;
			}
			if (GlobalScript.inst.gameState.OAR)
			{
				num3++;
			}
			if (GlobalScript.inst.gameState.allcountries[15].cw)
			{
				num4++;
			}
			if (GlobalScript.inst.gameState.allcountries[1].isASEAN)
			{
				num4++;
			}
			if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
			{
				num4++;
			}
			if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
			{
				num4++;
			}
			if (GlobalScript.inst.gameState.resultOfEvents[46] == 2)
			{
				num3++;
			}
			if (GlobalScript.inst.gameState.ingamewars[5].is_going)
			{
				num3++;
			}
			if (GlobalScript.inst.gameState.allcountries[84].Gosstroy == 0)
			{
				num3++;
			}
			else
			{
				num4++;
			}
			if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 3 || GlobalScript.inst.gameState.allcountries[8].Vyshi)
			{
				num4++;
			}
			else
			{
				num3++;
			}
		}
		else
		{
			if (GlobalScript.inst.gameState.empires[0].now_leader == 0)
			{
				num3 += 7;
			}
			if (a.empires[0].power > a.empires[1].power)
			{
				num4++;
			}
			else
			{
				num3++;
			}
			if (a.empires[0].power > a.influencePRC)
			{
				num4++;
			}
			else
			{
				num3++;
			}
			if (a.allcountries[1].Gosstroy == 3)
			{
				num4++;
			}
			else
			{
				num3++;
			}
			if (a.allcountries[85].isNATO)
			{
				num4++;
			}
			else
			{
				num3++;
			}
			if (a.allcountries[92].isNATO)
			{
				num4++;
			}
			else
			{
				num3++;
			}
			if (a.allcountries[21].isNATO)
			{
				num4++;
			}
			else
			{
				num3++;
			}
			if (a.allcountries[84].isNATO)
			{
				num4++;
			}
			else
			{
				num3++;
			}
			if (a.allcountries[1].isSEV)
			{
				num4--;
			}
			else
			{
				num3++;
			}
			if (a.allcountries[1].isOVD)
			{
				num4--;
			}
			else
			{
				num3++;
			}
			if (a.allcountries[15].cw)
			{
				num4++;
			}
			if (a.empires[1].now_leader == 3)
			{
				num4++;
			}
			if (a.allcountries[51].isASEAN)
			{
				num4++;
			}
			if (GlobalScript.inst.gameState.ingamewars[5].is_going)
			{
				num3++;
			}
			if (a.resultOfEvents[67] == 3)
			{
				num3++;
			}
			if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
			{
				num4++;
			}
		}
		int[] array = new int[4];
		if (a.resultOfEvents[384] == 1)
		{
			array[0]++;
		}
		if (a.data[49] > a.data[48])
		{
			array[0] += 2;
		}
		if (a.resultOfEvents[49] == 1)
		{
			array[0]++;
		}
		if (a.resultOfEvents[50] == 3)
		{
			array[0]--;
		}
		if (a.resultOfEvents[67] == 3)
		{
			array[0]--;
		}
		if (a.allcountries[4].Gosstroy == 1)
		{
			array[0]--;
		}
		if (a.allcountries[45].Gosstroy == 2)
		{
			array[0]++;
		}
		if (a.allcountries[8].Gosstroy == 1)
		{
			array[0]++;
		}
		if (a.allcountries[1].isOVD)
		{
			array[0]++;
		}
		if (a.allcountries[1].isSEV)
		{
			array[0]++;
		}
		if (a.empires[1].power > a.empires[0].power)
		{
			array[0]++;
		}
		if (a.empires[1].power > a.data[7])
		{
			array[0]++;
		}
		if (a.modifies[16].active)
		{
			array[0]++;
		}
		if (a.resultOfEvents[384] == 2)
		{
			array[1]++;
		}
		if (a.data[132] == 2)
		{
			array[1]++;
		}
		if (a.allcountries[51].dev > 0)
		{
			array[1]++;
		}
		if (a.allcountries[1].isSEATO)
		{
			array[1]++;
		}
		if (a.allcountries[1].isASEAN)
		{
			array[1]++;
		}
		if (a.resultOfEvents[50] == 4 || a.resultOfEvents[52] == 2)
		{
			array[1]++;
		}
		if (a.allcountries[1].okb)
		{
			array[1]++;
		}
		if (a.allcountries[8].Vyshi && a.allcountries[8].Gosstroy == 0)
		{
			array[1]++;
		}
		if (!a.allcountries[12].proprc && a.allcountries[12].Gosstroy == 0)
		{
			array[1]++;
		}
		if (a.empires[0].power > a.empires[1].power)
		{
			array[1]++;
		}
		if (a.empires[0].power > a.data[7])
		{
			array[1]++;
		}
		if (a.modifies[17].active)
		{
			array[1]++;
		}
		if (a.resultOfEvents[46] == 2)
		{
			array[1]--;
		}
		if (a.influencePRC > a.empires[0].power && a.influencePRC > a.empires[1].power)
		{
			array[2]++;
		}
		if (a.resultOfEvents[384] == 3)
		{
			array[2]++;
		}
		if (a.allcountries[15].cw)
		{
			array[2]++;
		}
		if (a.allcountries[8].Gosstroy == 3)
		{
			array[2]++;
		}
		if (a.modifies[3].active)
		{
			array[2]++;
		}
		if (a.allcountries[86].SubGosstroy == 15)
		{
			array[2]++;
		}
		if (a.allcountries[87].Gosstroy == 2)
		{
			array[2]++;
		}
		if (a.allcountries[11].proprc)
		{
			array[2]++;
		}
		if (a.allcountries[23].proprc)
		{
			array[2]++;
		}
		if (a.empires[0].relations < 500)
		{
			array[2]++;
		}
		if (a.allcountries[1].isSEV || a.allcountries[1].isASEAN)
		{
			array[2]--;
		}
		if (a.allcountries[1].econ && a.allcountries[1].okb)
		{
			array[2]++;
		}
		if (a.allcountries[4].Gosstroy == 2)
		{
			array[3]++;
		}
		if (a.resultOfEvents[384] == 0 && a.event_done[384])
		{
			array[3]++;
		}
		if (a.allcountries[8].Gosstroy == 0 && a.allcountries[8].SubGosstroy == 9)
		{
			array[3]++;
		}
		if (!a.allcountries[1].okb && !a.allcountries[1].isOVD && !a.allcountries[1].isSEATO)
		{
			array[3]++;
		}
		if (a.ingamewars[5].is_going)
		{
			array[3]++;
		}
		if (a.allcountries[51].SubGosstroy == 12)
		{
			array[3]++;
		}
		if (a.allcountries[85].SubGosstroy == 6)
		{
			array[3]++;
		}
		if (a.allcountries[87].SubGosstroy == 6)
		{
			array[3]++;
		}
		if (a.allcountries[86].SubGosstroy == 6)
		{
			array[3]++;
		}
		if (a.allcountries[30].Gosstroy == 3)
		{
			array[3]++;
		}
		if (a.ingamewars[3].is_going)
		{
			array[3]++;
		}
		if (a.allcountries[1].Gosstroy == 2)
		{
			array[3]++;
		}
		for (int i = 0; i < a.allcountries.Length; i++)
		{
			if (a.allcountries[i].okb)
			{
				num2++;
			}
		}
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		bool flag = false;
		bool flag2 = false;
		if (GlobalScript.inst.gameState.empires[0].now_leader == 1)
		{
			num9++;
		}
		if (a.data[65] > 0)
		{
			flag2 = true;
		}
		if (GlobalScript.inst.gameState.BritLost)
		{
			flag = true;
		}
		if (a.resultOfEvents[46] != 2 && a.resultOfEvents[67] != 3 && !a.ingamewars[5].is_going)
		{
			num9++;
		}
		int num10 = 0;
		if (a.allcountries[21].Gosstroy == 2 || a.allcountries[21].Gosstroy == 1)
		{
			num10++;
		}
		if (a.allcountries[85].Gosstroy == 2 || a.allcountries[85].Gosstroy == 1)
		{
			num10++;
		}
		if (a.allcountries[86].Gosstroy == 2 || a.allcountries[86].Gosstroy == 1)
		{
			num10++;
		}
		if (a.allcountries[87].Gosstroy == 2 || a.allcountries[87].Gosstroy == 1)
		{
			num10++;
		}
		if (num10 > 1)
		{
			num9++;
		}
		if (a.allcountries[92].based)
		{
			num5 += num9;
			if (flag2)
			{
				num5++;
			}
			if (flag)
			{
				num5++;
			}
		}
		else
		{
			if (flag2)
			{
				num5++;
			}
			if (flag)
			{
				num5++;
			}
		}
		if (a.allcountries[92].based)
		{
			if (a.allcountries[92].based)
			{
				num7++;
			}
			if (flag2)
			{
				num7++;
			}
			if (flag)
			{
				num7++;
			}
		}
		num6 = ((!flag2 && !flag) ? 10 : 0);
		if (flag2 || flag)
		{
			num8 += 2;
		}
		if (a.allcountries[92].based)
		{
			num8++;
		}
		float num11 = GlobalScript.inst.gameState.data[143];
		if (GlobalScript.inst.gameState.modifies[58].active && !GlobalScript.inst.gameState.modifies[16].active && GlobalScript.inst.gameState.data[153] <= 0)
		{
			num11 -= 15f;
		}
		if (GlobalScript.inst.gameState.allcountries[14].proprc)
		{
			num11 -= 1f;
		}
		if (GlobalScript.inst.gameState.allcountries[8].proprc)
		{
			num11 -= 1f;
		}
		if (GlobalScript.inst.gameState.allcountries[35].proprc)
		{
			num11 -= 1f;
		}
		if (GlobalScript.inst.gameState.allcountries[40].proprc)
		{
			num11 -= 1f;
		}
		if (GlobalScript.inst.gameState.allcountries[30].proprc)
		{
			num11 -= 1f;
		}
		if (GlobalScript.inst.gameState.allcountries[83].proprc)
		{
			num11 -= 1f;
		}
		if (num11 < 10f)
		{
			num11 = 10f;
		}
		float num12 = num11 * 7.7f * (GlobalScript.inst.gameState.OilEat - GlobalScript.inst.gameState.OilProd) / 10000f;
		int num13 = 0;
		int num14 = 0;
		if (GlobalScript.inst.gameState.data[143] - 50 > 0)
		{
			num13 -= (GlobalScript.inst.gameState.data[143] - 10) / 3;
			num14 += (GlobalScript.inst.gameState.data[143] - 10) / 3;
		}
		else if (GlobalScript.inst.gameState.data[143] - 20 > 0 && GlobalScript.inst.gameState.data[143] - 50 <= 0)
		{
			num13 += (GlobalScript.inst.gameState.data[143] - 10) / 3;
			num14 += (GlobalScript.inst.gameState.data[143] - 10) / 3;
		}
		else if (GlobalScript.inst.gameState.data[21] < 1980)
		{
			num13 += (GlobalScript.inst.gameState.data[143] - 10) / 2;
			num14 -= (GlobalScript.inst.gameState.data[143] - 10) / 2;
		}
		else
		{
			num13 += GlobalScript.inst.gameState.data[143] - 10;
			num14 -= (GlobalScript.inst.gameState.data[143] - 10) * 2;
		}
		string text = "";
		switch (num)
		{
		case 59:
			text = BuildEconomyModifyText(GlobalScript.inst.old_modify_desc[num], GlobalScript.inst.gameState.data[16]);
			break;
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 48:
		case 49:
		case 50:
		case 51:
		case 52:
		case 53:
		case 54:
		case 55:
		case 56:
		case 57:
		case 58:
		case 60:
		case 61:
		case 62:
			text = string.Format(GlobalScript.inst.old_modify_desc[num], (float)(num2 * 2) / 10f, (num2 < 7) ? 1 : ((num2 < 14) ? 2 : 3), (float)num2 / 10f, (a.data[133] == 1 || a.data[133] == 2) ? GlobalScript.inst.new_events_text[1309] : GlobalScript.inst.new_events_text[1308], (a.data[54] > 39 && !a.modifies[17].active && a.allcountries[21].Torg) ? GlobalScript.inst.new_events_text[1310] : GlobalScript.inst.new_events_text[1311], (a.allcountries[21].Torg && !GlobalScript.inst.gameState.allcountries[1].isSEATO && !a.allcountries[1].okb && !a.allcountries[1].isOVD && (a.allcountries[1].Gosstroy == 2 || a.allcountries[1].Gosstroy == 3)) ? GlobalScript.inst.new_events_text[1310] : GlobalScript.inst.new_events_text[1311], (a.allcountries[21].Torg && a.data[52] < 36 && !a.modifies[16].active) ? GlobalScript.inst.new_events_text[1310] : GlobalScript.inst.new_events_text[1311], (a.allcountries[21].Torg && a.allcountries[1].okb && a.data[7] >= 500) ? GlobalScript.inst.new_events_text[1310] : GlobalScript.inst.new_events_text[1311], a.data[143], (float)a.data[146] / 10f, a.allcountries[1].isOVD ? a.allcountries[7].name : a.allcountries[51].name, GlobalScript.inst.gameState.empires[1].leaders[6].support, GlobalScript.inst.gameState.empires[1].leaders[4].support, GlobalScript.inst.gameState.empires[1].leaders[5].support, GlobalScript.inst.gameState.empires[1].leaders[1].support, (GlobalScript.inst.gameState.empires[1].now_leader == 0) ? GlobalScript.inst.new_events_text[1607] : null, (GlobalScript.inst.gameState.empires[1].now_leader == 0) ? GlobalScript.inst.gameState.empires[1].leaders[2].support.ToString() : null, (GlobalScript.inst.gameState.empires[1].now_leader == 0) ? GlobalScript.inst.new_events_text[1608] : null, (GlobalScript.inst.gameState.empires[1].now_leader == 0) ? GlobalScript.inst.gameState.empires[1].leaders[3].support.ToString() : null, num3, num4, array[1], array[3], array[0], array[2], num5, num6, num8, num7, a.OilProd, a.OilEat, num12 / 10f * -1f, (num12 / 10f * -1f > 0f) ? "lime" : "#DC143C", (num12 / 10f * -1f > 0f) ? "+" : null, num11, GlobalScript.inst.gameState.data[153], (GlobalScript.inst.gameState.data[153] > 0) ? GlobalScript.inst.new_events_text[1609] : GlobalScript.inst.new_events_text[1610], (float)num14 / 10f, (float)num13 / 10f, (num14 > 0) ? "+" : null, (num13 > 0) ? "+" : null);
			break;
		default:
			switch (num)
			{
			case 63:
				text = string.Format(GlobalScript.inst.old_modify_desc[num], GlobalScript.inst.new_texts[697 + GlobalScript.inst.gameState.modifies[63].level], GlobalScript.inst.new_texts[700 + GlobalScript.inst.gameState.modifies[63].level]);
				break;
			case 64:
			{
				float num15 = a.startedDirectWarsNum.Where((KeyValuePair<int, bool> w) => w.Value).Count();
				num15 -= (float)a.startedDirectWarsNum.Where((KeyValuePair<int, bool> w) => (w.Key <= 2 || w.Key == 7 || w.Key == 10 || w.Key == 13 || w.Key == 15) && w.Value).Count();
				text = string.Format(GlobalScript.inst.old_modify_desc[num], num15 / 10f * 2f, num15 * 0.5f * 2f, num15 / 10f * 2f, num15 * 0.5f * 2f, num15 / 10f * 2f, num15 / 10f * 2f);
				break;
			}
			case 65:
				text = string.Format(GlobalScript.inst.old_modify_desc[num], GlobalScript.inst.gameState.data[168], (!GlobalScript.inst.gameState.IsBankAccountFreezed) ? GlobalScript.inst.new_texts[898] : GlobalScript.inst.new_texts[899]);
				break;
			default:
				text = string.Format(GlobalScript.inst.old_modify_desc[num]);
				break;
			}
			break;
		}
		okno1.text = (okno1.text_en = $"<color=red>{GlobalScript.inst.old_modify_texts[num]}</color>|{(activated ? text : GlobalScript.inst.new_texts[229])}");
	}

	public void ChangeIcon(int num, bool activated)
	{
		this.num = num;
		focus_sprite.sprite = Resources.Load<Sprite>(string.Format("modify_sp\\{0}_{1}", num, activated ? "0" : "1"));
		if (focus_sprite.sprite == null)
		{
			focus_sprite.sprite = Resources.Load<Sprite>(string.Format("modify_sp\\{0}_{1}", 7, activated ? "0" : "1"));
		}
	}

	private string BuildEconomyModifyText(string rawText, int economyCode)
	{
		bool flag = PlayerPrefs.GetInt("language") == 0;
		string text = rawText.Replace("\n", "|");
		string value = (flag ? "In planned economy:" : "При плане:");
		string value2 = (flag ? "In a StaMoCap/birdcage:" : "При госмонкапе/птичьей клетке:");
		string value3 = (flag ? "In a mixed economy:" : "При смешанной экономике:");
		string value4 = (flag ? "In an automated economy/minimal regulation: disabled" : "При автоматизации/минимальном регулировании: отключается");
		int num = text.IndexOf(value, StringComparison.Ordinal);
		int num2 = text.IndexOf(value2, StringComparison.Ordinal);
		int num3 = text.IndexOf(value3, StringComparison.Ordinal);
		int num4 = text.IndexOf(value4, StringComparison.Ordinal);
		if (num == -1 || num2 == -1 || num3 == -1 || num4 == -1)
		{
			return rawText;
		}
		string text2 = text.Substring(num, num2 - num).Trim('|');
		string text3 = text.Substring(num2, num3 - num2).Trim('|');
		string text4 = text.Substring(num3, num4 - num3).Trim('|');
		string text5 = text.Substring(num4).Trim('|');
		string text6 = ((economyCode == 10) ? text2 : ToGray(text2));
		string text7 = ((economyCode == 12 || economyCode == 13) ? text3 : ToGray(text3));
		string text8 = ((economyCode == 14) ? text4 : ToGray(text4));
		string text9 = text5;
		string economyName = GetEconomyName(economyCode, flag);
		string text10 = (flag ? ("Current economic model: <color=yellow>" + economyName + "</color>") : ("Текущая модель экономики: <color=yellow>" + economyName + "</color>"));
		return string.Join("|", text6, text7, text8, "", text10, text9);
	}

	private string GetEconomyName(int economyCode, bool isEnglish)
	{
		switch (economyCode)
		{
		case 10:
			if (!isEnglish)
			{
				return "Подзний план";
			}
			return "Planned economy";
		case 11:
			if (!isEnglish)
			{
				return "Автоматизированный план";
			}
			return "Automated plan";
		case 12:
			if (!isEnglish)
			{
				return "Госмонкап";
			}
			return "StaMoCap";
		case 13:
			if (!isEnglish)
			{
				return "Птичья клетка";
			}
			return "Birdcage";
		case 14:
			if (!isEnglish)
			{
				return "Смешанная";
			}
			return "Mixed economy";
		case 15:
			if (!isEnglish)
			{
				return "Минимальное регулирование";
			}
			return "Minimal regulation";
		default:
			if (!isEnglish)
			{
				return "Неизвестно";
			}
			return "Unknown";
		}
	}

	private string ToGray(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		string text2 = Regex.Replace(text, "</?color[^>]*>", "", RegexOptions.IgnoreCase);
		return "<color=#B0B0B0>" + text2 + "</color>";
	}
}
