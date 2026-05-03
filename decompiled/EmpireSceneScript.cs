using UnityEngine;

public class EmpireSceneScript : MonoBehaviour
{
	private GlobalScript global1;

	public new TextMesh name;

	public SpriteRenderer leader;

	public GameObject[] modifies;

	public GameObject[] politicians;

	public int country = 1;

	public GameObject up;

	public GameObject down;

	public GameObject up2;

	public GameObject down2;

	public GameObject modifyPrefab;

	public void Awake()
	{
		global1 = GlobalScript.inst;
		CreateLeader();
		CreatePoliticiansList(GlobalScript.inst.gameState.empires[country].leaders);
		CreateModifies(GlobalScript.inst.gameState.empires[country]);
	}

	private void CreateLeader()
	{
		name.text = GlobalScript.inst.gameState.empires[country].leaders[GlobalScript.inst.gameState.empires[country].now_leader].leader_name;
		Insider[] insiders = GlobalScript.inst.gameState.empires[country].insiders;
		foreach (Insider insider in insiders)
		{
			name.text = string.Format("{3}{0}<size=30>{1}:{0}{2:F}%</size>", '\n', insider.name, insider.influence, name.text);
		}
		leader.sprite = Resources.Load<Sprite>(string.Format("empirescene_sp\\{1}_{0}", GlobalScript.inst.gameState.empires[country].now_leader, country));
	}

	private float OneHundredPercentKumiha(Leader[] leaders)
	{
		float num = 0f;
		Leader[] leaders2 = GlobalScript.inst.gameState.empires[country].leaders;
		foreach (Leader leader in leaders2)
		{
			num += (float)leader.support;
		}
		return num;
	}

	private void CreatePoliticiansList(Leader[] leaders)
	{
		up.GetComponent<TextMesh>().text = GlobalScript.inst.new_texts[16];
		politicians = new GameObject[leaders.Length];
		float num = up.GetComponent<BoxCollider2D>().bounds.max.y - up.GetComponent<BoxCollider2D>().bounds.min.y;
		for (int i = 0; i < leaders.Length; i++)
		{
			politicians[i] = Object.Instantiate(modifyPrefab, new Vector3(up.transform.position.x, up.transform.position.y - num * (float)(i + 1), -3f), Quaternion.identity);
			politicians[i].GetComponent<EmpireSceneButtonScript>().ChangeText($"{leaders[i].leader_name}: {(float)leaders[i].support:F2}", leaders[i].leader_name);
			politicians[i].transform.parent = base.transform;
			Object.Destroy(politicians[i].GetComponent<BoxCollider2D>());
		}
	}

	private void CreateModifies(Empire imp)
	{
		up2.GetComponent<TextMesh>().text = GlobalScript.inst.new_texts[17];
		modifies = new GameObject[imp.modifies.Length];
		float num = up2.GetComponent<BoxCollider2D>().bounds.max.y - up2.GetComponent<BoxCollider2D>().bounds.min.y;
		for (int i = 0; i < imp.modifies.Length; i++)
		{
			modifies[i] = Object.Instantiate(modifyPrefab, new Vector3(up2.transform.position.x, up2.transform.position.y - num * (float)(i + 1), -3f), Quaternion.identity);
			modifies[i].GetComponent<EmpireSceneButtonScript>().ChangeText($"{GlobalScript.inst.new_modify_texts[imp.modifies[i]]}", GlobalScript.inst.new_modify_desc[imp.modifies[i]]);
			modifies[i].transform.parent = base.transform;
		}
	}

	public void Repaint(int country)
	{
		this.country = country;
		CreateLeader();
		ReCreatePoliticiansList(GlobalScript.inst.gameState.empires[country].leaders);
		ReCreateModifies(GlobalScript.inst.gameState.empires[country]);
	}

	private void ReCreatePoliticiansList(Leader[] leaders)
	{
		for (int i = 0; i < politicians.Length; i++)
		{
			Object.Destroy(politicians[i]);
		}
		CreatePoliticiansList(leaders);
	}

	private void ReCreateModifies(Empire imp)
	{
		for (int i = 0; i < modifies.Length; i++)
		{
			Object.Destroy(modifies[i]);
		}
		CreateModifies(imp);
	}
}
