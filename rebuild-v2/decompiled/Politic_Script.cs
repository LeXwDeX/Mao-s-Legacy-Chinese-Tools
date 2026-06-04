using UnityEngine;

public class Politic_Script : MonoBehaviour
{
	public byte this_number;

	public GlobalScript global1;

	public Politic_Manager manager;

	public new TextMesh name;

	public TextMesh T1;

	public TextMesh T2;

	public TextMesh T3;

	public SpriteRenderer shkala;

	public SpriteRenderer dolzh;

	public int pol_power;

	public Politic_Face_Renderer[] face = new Politic_Face_Renderer[2];

	public GameObject[] face_obj = new GameObject[2];

	private Material mat;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		if (shkala != null)
		{
			mat = shkala.material;
		}
	}

	private void Start()
	{
		if (this_number == 150)
		{
			Repaint();
		}
	}

	public void Repaint()
	{
		GameObject[] array = face_obj;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		manager.CoopRepaint();
		if (this_number == 150)
		{
			face_obj[GlobalScript.inst.gameState.leader.face_type].SetActive(value: true);
			face[GlobalScript.inst.gameState.leader.face_type].Draw(GlobalScript.inst.gameState.leader.face_parts, GlobalScript.inst.gameState.leader.jacket);
		}
		else
		{
			dolzh.sprite = null;
			for (int j = 0; j < GlobalScript.inst.gameState.politics_dolshnost.Length; j++)
			{
				if (GlobalScript.inst.gameState.politics_dolshnost[j] == this_number)
				{
					dolzh.sprite = manager.stateDolzh[(j < 3) ? j : 3];
					break;
				}
			}
			face_obj[GlobalScript.inst.gameState.politics[this_number].face_type].SetActive(value: true);
			face[GlobalScript.inst.gameState.politics[this_number].face_type].Draw(GlobalScript.inst.gameState.politics[this_number].face_parts, GlobalScript.inst.gameState.politics[this_number].jacket);
		}
		RepaintShkal();
		if (name != null)
		{
			name.text = $"{manager.first_names[GlobalScript.inst.gameState.politics[this_number].name_1]} {manager.second_names[GlobalScript.inst.gameState.politics[this_number].name_2]}";
		}
		if (!(T1 == null))
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				T1.text = manager.traits_en[GlobalScript.inst.gameState.politics[this_number].traits[0]];
				T2.text = manager.traits_en[GlobalScript.inst.gameState.politics[this_number].traits[1]];
				T3.text = manager.traits_en[GlobalScript.inst.gameState.politics[this_number].traits[2]];
			}
			else
			{
				T1.text = manager.traits_ru[GlobalScript.inst.gameState.politics[this_number].traits[0]];
				T2.text = manager.traits_ru[GlobalScript.inst.gameState.politics[this_number].traits[1]];
				T3.text = manager.traits_ru[GlobalScript.inst.gameState.politics[this_number].traits[2]];
			}
			GetComponent<OkoshkoScript>().text = (GetComponent<OkoshkoScript>().text_en = string.Format(GlobalScript.inst.other_text[350], GlobalScript.inst.other_text[351 + GlobalScript.inst.gameState.politics[this_number].wantedDolzh], (float)GlobalScript.inst.gameState.politics[this_number].loyality / 10f, GlobalScript.inst.gameState.politics[this_number].age, (float)GlobalScript.inst.gameState.politics[this_number].power / 10f));
		}
	}

	public void RepaintShkal()
	{
		if (!(shkala == null))
		{
			if (manager.politic_to_display_loyality == 200)
			{
				mat.SetFloat("_M", (float)GlobalScript.inst.gameState.politics[this_number].loyality / 1000f);
				shkala.color = new Color(1f - (float)GlobalScript.inst.gameState.politics[this_number].loyality / 1000f, (float)GlobalScript.inst.gameState.politics[this_number].loyality / 1000f, 0f, 1f);
			}
			else if (manager.politic_to_display_loyality == this_number)
			{
				mat.SetFloat("_M", 1f);
				shkala.color = new Color(0f, 1f, 0f, 1f);
			}
			else
			{
				mat.SetFloat("_M", (float)GlobalScript.inst.gameState.politics[this_number].loyality_to_other[manager.politic_to_display_loyality] / 1000f);
				shkala.color = new Color(1f - (float)GlobalScript.inst.gameState.politics[this_number].loyality_to_other[manager.politic_to_display_loyality] / 1000f, (float)GlobalScript.inst.gameState.politics[this_number].loyality_to_other[manager.politic_to_display_loyality] / 1000f, 0f, 1f);
			}
		}
	}

	private void OnMouseEnter()
	{
		ToDisp();
	}

	public void ToDisp()
	{
		if (this_number != 150)
		{
			manager.politic_to_display_loyality = this_number;
			manager.RepaintOnlyShkal();
		}
	}

	private void OnMouseDown()
	{
		manager.Politic_Selected(this_number);
	}
}
