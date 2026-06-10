using System;
using System.IO;
using DiploAltInfo;
using KGEvent;
using TMPro;
using UnityEngine;

public class CountryScript : MonoBehaviour
{
	private static Color[] colors;

	private static bool _cjkWarmedUp = false;

	public GlobalScript global1;

	public int this_number;

	public Sprite grey;

	public Sprite special;

	private MapChangesScript map1;

	private SpriteRenderer sp;

	public bool on_mouse_it;

	static CountryScript()
	{
		colors = new Color[20];
		colors[0] = new Color(0.4f, 0.4f, 0.4f);
		colors[1] = new Color(0f, 0f, 0f);
		colors[2] = new Color(0f, 1f, 1f);
		colors[3] = new Color(0f, 0f, 0.46f);
		colors[4] = new Color(1f, 0.48f, 0f);
		colors[5] = new Color(0f, 0f, 0.72f);
		colors[6] = new Color(0f, 0f, 0.4f);
		colors[7] = new Color(1f, 0f, 1f);
		colors[8] = new Color32(byte.MaxValue, 140, 0, byte.MaxValue);
		colors[9] = new Color(0f, 0f, 0.5f);
		colors[10] = new Color(0f, 1f, 0.1f);
		colors[11] = new Color(1f, 0.1f, 0f);
		colors[12] = new Color(0.1717331f, 0.4433962f, 0f);
		colors[13] = new Color(89f / 106f, 89f / 106f, 89f / 106f);
		colors[14] = new Color(0.4f, 0f, 0f);
		colors[15] = new Color(0.17f, 0.69f, 1f);
		colors[16] = new Color(0.22f, 0.81f, 0f);
		colors[17] = new Color(0f, 0.22f, 0.6431f);
		colors[18] = new Color(0.16862f, 0.101f, 0f);
		colors[19] = new Color(1f, 0.1367925f, 0.1367925f);
	}

	private void OnMouseEnter()
	{
		Repaint();
		if (grey != null || (this_number != 69 && this_number != 70) || (this_number == 69 && GlobalScript.inst.gameState.data[67] != 0) || (this_number == 70 && GlobalScript.inst.gameState.data[66] != 0))
		{
			sp.material.SetColor("_MainColor", colors[0]);
		}
		on_mouse_it = true;
	}

	private void OnMouseExit()
	{
		if ((this_number != 69 && this_number != 70) || (this_number == 69 && GlobalScript.inst.gameState.data[67] != 0) || (this_number == 70 && GlobalScript.inst.gameState.data[66] != 0))
		{
			Repaint();
			on_mouse_it = false;
		}
	}

	private void ChangeSubIcons(Country Cou)
	{
		map1.okno.transform.Find("占星师（0）").GetComponent<SpriteRenderer>().sprite = map1.sub_znachki[Cou.SubGosstroy];
		if (Cou.SubGosstroy < 18)
		{
			map1.okno.transform.Find("占星师（0）").GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.other_text[(Cou.SubGosstroy < 10) ? (Cou.SubGosstroy + 13) : (Cou.SubGosstroy + 82)];
			map1.okno.transform.Find("占星师（0）").GetComponent<OkoshkoScript>().text = GlobalScript.inst.other_text[(Cou.SubGosstroy < 10) ? (Cou.SubGosstroy + 13) : (Cou.SubGosstroy + 82)];
		}
		else
		{
			map1.okno.transform.Find("占星师（0）").GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.other_text[182];
			map1.okno.transform.Find("占星师（0）").GetComponent<OkoshkoScript>().text = GlobalScript.inst.other_text[182];
		}
		if (this_number > 70 && this_number < 84)
		{
			string text = ColorUtility.ToHtmlStringRGB(new Color(1f / (float)(4 - Cou.Gosstroy), 0f, 1f / (float)(4 - Cou.Gosstroy)));
			string text2 = ColorUtility.ToHtmlStringRGB(new Color((Cou.SubGosstroy < 4) ? (1f / (float)Cou.SubGosstroy) : 0f, (Cou.SubGosstroy > 6) ? (1f / (float)(Cou.SubGosstroy - 6)) : 0f, (Cou.SubGosstroy > 3 && Cou.SubGosstroy < 7) ? (1f / (float)(Cou.SubGosstroy - 3)) : 0f));
			map1.okno.transform.Find("Text_opis_country").GetComponent<TextMesh>().text = string.Format(GlobalScript.inst.other_text[23], '\n', GlobalScript.inst.other_text[Cou.Gosstroy], GlobalScript.inst.other_text[Cou.SubGosstroy + 13], (Cou.next_elections != GlobalScript.inst.gameState.allcountries[0].next_elections) ? (Cou.next_elections.Day + "." + Cou.next_elections.Month + "." + Cou.next_elections.Year) : GlobalScript.inst.other_text[24], Cou.level_of_dev, Cou.level_of_unstab, text, text2);
		}
	}

	private void ChangeIcons()
	{
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		OkoshkoScript[] array = new OkoshkoScript[6]
		{
			map1.okno.transform.Find("占星师（0）").GetComponent<OkoshkoScript>(),
			map1.okno.transform.Find("巫医（1）").GetComponent<OkoshkoScript>(),
			map1.okno.transform.Find("巫医（2）").GetComponent<OkoshkoScript>(),
			map1.okno.transform.Find("巫医（3）").GetComponent<OkoshkoScript>(),
			map1.okno.transform.Find("巫医（4）").GetComponent<OkoshkoScript>(),
			map1.okno.transform.Find("巫医（5）").GetComponent<OkoshkoScript>()
		};
		if (gameState.allcountries[this_number].Gosstroy == 1)
		{
			map1.okno.transform.Find("占星师（0）").GetComponent<SpriteRenderer>().sprite = map1.znachki[1];
			array[0].text_en = inst.other_text[1];
			array[0].text = inst.other_text[1];
		}
		else if (gameState.allcountries[this_number].Gosstroy == 2)
		{
			map1.okno.transform.Find("占星师（0）").GetComponent<SpriteRenderer>().sprite = map1.znachki[3];
			array[0].text_en = inst.other_text[2];
			array[0].text = inst.other_text[2];
		}
		else if (gameState.allcountries[this_number].Gosstroy == 3)
		{
			map1.okno.transform.Find("占星师（0）").GetComponent<SpriteRenderer>().sprite = map1.znachki[4];
			array[0].text_en = inst.other_text[3];
			array[0].text = inst.other_text[3];
		}
		else
		{
			map1.okno.transform.Find("占星师（0）").GetComponent<SpriteRenderer>().sprite = map1.znachki[8];
			array[0].text_en = inst.other_text[0];
			array[0].text = inst.other_text[0];
		}
		if (gameState.allcountries[this_number].isOVD)
		{
			map1.okno.transform.Find("巫医（1）").GetComponent<SpriteRenderer>().sprite = map1.znachki[2];
			array[1].text_en = inst.other_text[4];
			array[1].text = inst.other_text[4];
		}
		else if (gameState.allcountries[this_number].okb)
		{
			if (!gameState.modifies[49].active)
			{
				map1.okno.transform.Find("巫医（1）").GetComponent<SpriteRenderer>().sprite = map1.znachki[6];
				array[1].text_en = inst.other_text[5];
				array[1].text = inst.other_text[5];
			}
			else
			{
				map1.okno.transform.Find("巫医（1）").GetComponent<SpriteRenderer>().sprite = map1.znachki[22];
				array[1].text_en = inst.other_text[355];
				array[1].text = inst.other_text[355];
			}
		}
		else if (this_number == 30 && gameState.OAR)
		{
			map1.okno.transform.Find("巫医（1）").GetComponent<SpriteRenderer>().sprite = map1.znachki[12];
			array[1].text_en = inst.other_text[6];
			array[1].text = inst.other_text[6];
		}
		else if (gameState.allcountries[this_number].oar)
		{
			map1.okno.transform.Find("巫医（1）").GetComponent<SpriteRenderer>().sprite = map1.znachki[12];
			array[1].text_en = inst.other_text[6];
			array[1].text = inst.other_text[6];
		}
		else if (gameState.allcountries[this_number].isNATO)
		{
			map1.okno.transform.Find("巫医（1）").GetComponent<SpriteRenderer>().sprite = map1.znachki[13];
			array[1].text_en = inst.other_text[55];
			array[1].text = inst.other_text[55];
		}
		else if (gameState.allcountries[this_number].isSEATO)
		{
			if (!gameState.allcountries[51].cw)
			{
				array[1].text_en = inst.other_text[201];
				array[1].text = inst.other_text[201];
				map1.okno.transform.Find("巫医（1）").GetComponent<SpriteRenderer>().sprite = map1.znachki[17];
			}
			else
			{
				array[1].text_en = inst.other_text[217];
				array[1].text = inst.other_text[217];
				map1.okno.transform.Find("巫医（1）").GetComponent<SpriteRenderer>().sprite = map1.znachki[19];
			}
		}
		else if (gameState.allcountries[this_number].isSENTO)
		{
			array[1].text_en = inst.other_text[254];
			array[1].text = inst.other_text[254];
			map1.okno.transform.Find("巫医（1）").GetComponent<SpriteRenderer>().sprite = map1.znachki[18];
		}
		else
		{
			map1.okno.transform.Find("巫医（1）").GetComponent<SpriteRenderer>().sprite = null;
			array[1].nonono = true;
		}
		if (gameState.allcountries[this_number].isSEV)
		{
			map1.okno.transform.Find("巫医（2）").GetComponent<SpriteRenderer>().sprite = map1.znachki[5];
			array[2].text_en = inst.other_text[7];
			array[2].text = inst.other_text[7];
		}
		else if (gameState.allcountries[this_number].econ)
		{
			map1.okno.transform.Find("巫医（2）").GetComponent<SpriteRenderer>().sprite = map1.znachki[7];
			array[2].text_en = inst.other_text[8];
			array[2].text = inst.other_text[8];
		}
		else if (gameState.allcountries[this_number].isOil)
		{
			map1.okno.transform.Find("巫医（2）").GetComponent<SpriteRenderer>().sprite = map1.znachki[20];
			array[2].text_en = inst.other_text[292];
			array[2].text = inst.other_text[292];
		}
		else if (gameState.allcountries[this_number].isSocEU)
		{
			map1.okno.transform.Find("巫医（2）").GetComponent<SpriteRenderer>().sprite = map1.znachki[21];
			array[2].text_en = inst.other_text[323];
			array[2].text = inst.other_text[323];
		}
		else if (gameState.allcountries[this_number].isEU)
		{
			map1.okno.transform.Find("巫医（2）").GetComponent<SpriteRenderer>().sprite = map1.znachki[14];
			array[2].text_en = inst.other_text[54];
			array[2].text = inst.other_text[54];
		}
		else if (gameState.allcountries[this_number].isASEAN)
		{
			map1.okno.transform.Find("巫医（2）").GetComponent<SpriteRenderer>().sprite = map1.znachki[16];
			if (!gameState.allcountries[1].isASEAN)
			{
				array[2].text_en = inst.other_text[195];
				array[2].text = inst.other_text[195];
			}
			else
			{
				array[2].text_en = inst.other_text[205];
				array[2].text = inst.other_text[205];
			}
		}
		else
		{
			map1.okno.transform.Find("巫医（2）").GetComponent<SpriteRenderer>().sprite = null;
			array[2].nonono = true;
		}
		if (gameState.allcountries[this_number].Torg)
		{
			map1.okno.transform.Find("巫医（3）").GetComponent<SpriteRenderer>().sprite = map1.znachki[9];
			array[3].text_en = inst.other_text[9];
			array[3].text = inst.other_text[9];
		}
		else
		{
			map1.okno.transform.Find("巫医（3）").GetComponent<SpriteRenderer>().sprite = null;
			array[3].nonono = true;
		}
		if (gameState.allcountries[this_number].Vyshi || ((this_number < 53 || this_number >= 69) && this_number != 61 && gameState.allcountries[this_number].usalliance))
		{
			map1.okno.transform.Find("巫医（4）").GetComponent<SpriteRenderer>().sprite = map1.znachki[0];
			array[4].text_en = inst.other_text[10];
			array[4].text = inst.other_text[10];
		}
		else if (gameState.allcountries[this_number].prosov || ((this_number < 53 || this_number >= 69) && this_number != 61 && gameState.allcountries[this_number].sovalliance))
		{
			map1.okno.transform.Find("巫医（4）").GetComponent<SpriteRenderer>().sprite = map1.znachki[10];
			array[4].text_en = inst.other_text[11];
			array[4].text = inst.other_text[11];
		}
		else if (gameState.allcountries[this_number].proprc)
		{
			map1.okno.transform.Find("巫医（4）").GetComponent<SpriteRenderer>().sprite = map1.znachki[11];
			array[4].text_en = inst.other_text[12];
			array[4].text = inst.other_text[12];
		}
		else
		{
			map1.okno.transform.Find("巫医（4）").GetComponent<SpriteRenderer>().sprite = null;
			array[4].nonono = true;
		}
		if (gameState.allcountries[this_number].puppetOf >= 0)
		{
			if (gameState.allcountries[this_number].EAF)
			{
				map1.znachki[15] = Resources.Load<Sprite>(string.Format("PuppetIcons{0}{1}", Path.DirectorySeparatorChar, "EAF"));
				map1.okno.transform.Find("巫医（5）").GetComponent<SpriteRenderer>().sprite = map1.znachki[15];
				array[5].text = (array[5].text_en = string.Format(inst.new_texts[810], gameState.allcountries[gameState.allcountries[this_number].puppetOf].name));
			}
			else
			{
				map1.znachki[15] = Resources.Load<Sprite>($"PuppetIcons{Path.DirectorySeparatorChar}{gameState.allcountries[this_number].puppetOf}");
				map1.okno.transform.Find("巫医（5）").GetComponent<SpriteRenderer>().sprite = map1.znachki[15];
				array[5].text_en = string.Format(inst.other_text[154], gameState.allcountries[gameState.allcountries[this_number].puppetOf].name);
				array[5].text = string.Format(inst.other_text[154], gameState.allcountries[gameState.allcountries[this_number].puppetOf].name);
			}
		}
		else
		{
			map1.okno.transform.Find("巫医（5）").GetComponent<SpriteRenderer>().sprite = null;
			array[5].nonono = true;
		}
		if (gameState.allcountries[this_number].SubGosstroy >= 0)
		{
			ChangeSubIcons(gameState.allcountries[this_number]);
		}
	}

	private void OnMouseDown()
	{
		if ((this_number != 69 && this_number != 70) || (this_number == 69 && GlobalScript.inst.gameState.data[67] != 0) || (this_number == 70 && GlobalScript.inst.gameState.data[66] != 0))
		{
			map1.ShowHideOcno(active: true);
			try
			{
				var tmpComp = map1.okno.transform.Find("DiploNameText").GetComponent<TextMeshPro>();
				if (!_cjkWarmedUp && tmpComp != null && tmpComp.font != null)
				{
					tmpComp.font.ClearFontAssetData();
					try
					{
						string warmupPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), "cjk_warmup.txt");
						string cjkChars = File.ReadAllText(warmupPath);
						tmpComp.font.TryAddCharacters(cjkChars);
					}
					catch (Exception ex2) { Debug.LogWarning("CJK warmup failed: " + ex2.Message); }
					_cjkWarmedUp = true;
				}
				if (tmpComp != null) tmpComp.text = TimeScript.GetCountryName(GlobalScript.inst, GlobalScript.inst.gameState.allcountries[this_number]);
				map1.okno.transform.Find("占星师（0）").GetComponent<OkoshkoScript>().nonono = false;
				map1.okno.transform.Find("巫医（1）").GetComponent<OkoshkoScript>().nonono = false;
				map1.okno.transform.Find("巫医（2）").GetComponent<OkoshkoScript>().nonono = false;
				map1.okno.transform.Find("巫医（3）").GetComponent<OkoshkoScript>().nonono = false;
				map1.okno.transform.Find("巫医（4）").GetComponent<OkoshkoScript>().nonono = false;
				map1.okno.transform.Find("巫医（5）").GetComponent<OkoshkoScript>().nonono = false;
			}
			catch (Exception)
			{
				Debug.Log($"{this_number} {GlobalScript.inst.gameState.allcountries[this_number]} {GlobalScript.inst.gameState.allcountries}");
			}
			ChangeIcons();
			for (int i = 0; i < 4; i++)
			{
				map1.buttons[i].GetComponent<DiploButtonScript>().Hide();
				map1.buttons[i].GetComponent<DiploButtonScript>().selected_country = this_number;
			}
			if (GlobalScript.inst.gameState.PlayerCountry == 1)
			{
				ChineseButtons();
			}
			else if (GlobalScript.inst.gameState.PlayerCountry == 21)
			{
				FrenchDiplo.CountryButtons((MinorCountries)this_number, map1);
			}
			else
			{
				SovietDiplo.CountryButtons((MinorCountries)this_number, map1);
			}
		}
	}

	private void ChineseButtons()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (this_number == 7)
			{
				if (!GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.ingamewars[22].is_going && GlobalScript.inst.gameState.data[133] != 1 && GlobalScript.inst.gameState.data[133] != 3 && !GlobalScript.inst.gameState.modifies[49].active)
				{
					if (!GlobalScript.inst.gameState.relres)
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show("Relations", 4);
					}
					else
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show("Technology", 81);
					}
					if (GlobalScript.inst.gameState.allcountries[7].Torg || GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						map1.buttons[1].GetComponent<DiploButtonScript>().Show("CMEA", 5);
					}
					else
					{
						map1.buttons[1].GetComponent<DiploButtonScript>().Show("Associate", 74);
					}
					if (GlobalScript.inst.gameState.allcountries[7].isOVD)
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show("华沙条约组织", 6);
					}
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Support", 7);
				}
			}
			else if (this_number == 2 || this_number == 4 || this_number == 98)
			{
				if (GlobalScript.inst.gameState.allcountries[7].isNATO && GlobalScript.inst.gameState.allcountries[this_number].isOVD && !GlobalScript.inst.gameState.ingamewars[17].is_going)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[119], 103);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[120], 104);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[121], 105);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[131], 106);
				}
				else if (!GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.ingamewars[17].is_going && !GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[this_number].isSEV)
				{
					if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show("Far-left", 1);
					}
					else
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[226], 123);
					}
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 24);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 24);
				}
			}
			else if (this_number == 1)
			{
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[183], 114);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[184], 115);
				}
				if (GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[234], 124);
				}
			}
			else if (this_number == 3)
			{
				if (GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.allcountries[7].isNATO)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[106], 100);
				}
				if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Far-left", 1);
				}
				else
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[226], 123);
				}
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Trade", 24);
				if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[5].okb && GlobalScript.inst.gameState.allcountries[4].okb && GlobalScript.inst.gameState.allcountries[2].okb && !GlobalScript.inst.gameState.allcountries[7].isOVD && !GlobalScript.inst.gameState.allcountries[7].isNATO)
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[131], 152);
				}
			}
			else if (this_number == 6)
			{
				if (!GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.ingamewars[17].is_going && !GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[this_number].isSEV)
				{
					if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show("Far-left", 1);
					}
					else
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[226], 123);
					}
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 24);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 24);
				}
				if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[5].okb && GlobalScript.inst.gameState.allcountries[4].okb && GlobalScript.inst.gameState.allcountries[2].okb && !GlobalScript.inst.gameState.allcountries[6].isOVD)
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[131], 151);
				}
			}
			else if (this_number == 8)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Support", 8);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 9);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 10);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			else if (this_number == 9)
			{
				if (!GlobalScript.inst.gameState.ingamewars[22].is_going && GlobalScript.inst.gameState.data[133] != 1 && GlobalScript.inst.gameState.data[133] != 3 && !GlobalScript.inst.gameState.allcountries[7].isNATO && (!GlobalScript.inst.gameState.allcountries[9].isOVD || (GlobalScript.inst.gameState.allcountries[1].isOVD && GlobalScript.inst.gameState.allcountries[9].isOVD)))
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Unrests", 11);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Coup", 12);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Trade", 9);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
				}
			}
			else if (this_number == 10)
			{
				if (!GlobalScript.inst.gameState.allcountries[this_number].econ && !GlobalScript.inst.gameState.allcountries[this_number].isSEV)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Union", 13);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Alliance", 19);
				}
				if (GlobalScript.inst.gameState.data[158] <= 0)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Sanctions", 14);
				}
				if (GlobalScript.inst.gameState.allcountries[this_number].isSEATO || GlobalScript.inst.gameState.allcountries[this_number].isOVD || GlobalScript.inst.gameState.allcountries[this_number].okb)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("War", 15);
					if (!GlobalScript.inst.gameState.guns)
					{
						map1.buttons[1].GetComponent<DiploButtonScript>().Show("Weapons", 16);
					}
					else if (GlobalScript.inst.gameState.data[158] <= 0)
					{
						map1.buttons[1].GetComponent<DiploButtonScript>().Show("Sanctions", 14);
					}
				}
				if (!GlobalScript.inst.gameState.allcountries[this_number].isSEATO && !GlobalScript.inst.gameState.allcountries[this_number].isOVD && !GlobalScript.inst.gameState.allcountries[this_number].okb)
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("War", 15);
				}
				if (!GlobalScript.inst.gameState.allcountries[this_number].isSEATO && !GlobalScript.inst.gameState.allcountries[this_number].isOVD && !GlobalScript.inst.gameState.allcountries[this_number].okb)
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Weapons", 16);
				}
			}
			else if (this_number == 11)
			{
				if (GlobalScript.inst.gameState.war <= 0)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 17);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 18);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Alliance", 19);
				}
				if (!GlobalScript.inst.dlc[5])
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Army", 20);
				}
			}
			else if (this_number == 12)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 9);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 68);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			else if (this_number == 13)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Support", 22);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 23);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("UAR", 67);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Union", 150);
			}
			else if (this_number == 14)
			{
				if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[36].cw)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[293], 133);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("UAR", 25);
				}
				if (!GlobalScript.inst.gameState.allcountries[36].cw)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 24);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 53);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Аlliance", 19);
				}
				if ((GlobalScript.inst.gameState.allcountries[14].proprc || GlobalScript.inst.gameState.allcountries[14].Vyshi) && GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 24);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
				}
			}
			else if (this_number == 15)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Agreement", 26);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Support", 27);
				if ((!GlobalScript.inst.gameState.allcountries[15].proprc || !GlobalScript.inst.gameState.allcountries[15].isSEV) && !GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.allcountries[2].okb && !GlobalScript.inst.gameState.allcountries[4].okb && !GlobalScript.inst.gameState.allcountries[5].okb && !GlobalScript.inst.gameState.allcountries[98].okb)
				{
					if (!GlobalScript.inst.gameState.allcountries[15].cw)
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show("Movement", 72);
					}
					else
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show("Leave", 73);
					}
				}
				else
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 10);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
				}
			}
			else if (this_number == 16)
			{
				if (GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.allcountries[this_number].isNATO)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[310], 135);
				}
				else if (!GlobalScript.inst.dlc[3])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 24);
				}
				if (GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.allcountries[7].isNATO && (!GlobalScript.inst.gameState.event_done[456] || GlobalScript.inst.gameState.resultOfEvents[456] < 0 || GlobalScript.inst.gameState.resultOfEvents[456] > 2))
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[324], 116);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[329], 137);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[334], 138);
				}
			}
			else if (this_number == 17)
			{
				if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Far-left", 1);
				}
				if (GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.allcountries[7].isNATO && (!GlobalScript.inst.gameState.event_done[456] || GlobalScript.inst.gameState.resultOfEvents[456] < 0 || GlobalScript.inst.gameState.resultOfEvents[456] > 2))
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[324], 116);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[329], 137);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[334], 138);
				}
			}
			else if (this_number == 18)
			{
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[424], 139);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[425], 140);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[426], 141);
				}
			}
			else if (this_number == 19)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Naxalite", 28);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Relations", 29);
				if (GlobalScript.inst.gameState.war != 2 && !GlobalScript.inst.gameState.allcountries[this_number].proprc && !GlobalScript.inst.dlc[5])
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("War", 30);
				}
				else if (GlobalScript.inst.gameState.allcountries[this_number].proprc && (GlobalScript.inst.gameState.allcountries[this_number].okb || GlobalScript.inst.gameState.allcountries[this_number].isOVD))
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Agreement", 89);
				}
				else if (!GlobalScript.inst.dlc[5])
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Reinforcements", 71);
				}
				if (GlobalScript.inst.gameState.allcountries[this_number].proprc)
				{
					if (!GlobalScript.inst.gameState.allcountries[this_number].isSEV && !GlobalScript.inst.gameState.allcountries[this_number].econ)
					{
						map1.buttons[3].GetComponent<DiploButtonScript>().Show("Union", 10);
					}
					else
					{
						map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
					}
				}
			}
			else if (this_number == 20)
			{
				if (!GlobalScript.inst.gameState.allcountries[this_number].parts[1])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Union", 31);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Alliance", 19);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("USSR", 32);
				}
			}
			else if (this_number == 21)
			{
				if (!GlobalScript.inst.dlc[3])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Agreement", 33);
				}
				else if (!GlobalScript.inst.gameState.allcountries[21].Torg)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Agreement", 33);
				}
				else if (GlobalScript.inst.gameState.data[131] == 3)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[262], 127);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Agreement", 33);
				}
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Investments", 34);
				if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Far-left", 1);
				}
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[140], 107);
				}
				if (GlobalScript.inst.gameState.allcountries[21].Gosstroy == 1)
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Union", 10);
				}
			}
			else if (this_number == 22)
			{
				if (!GlobalScript.inst.gameState.allcountries[1].isSEATO)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Relations", 35);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[244], 126);
				}
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 36);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			else if (this_number == 23 && !GlobalScript.inst.gameState.allcountries[23].prosov)
			{
				if (!GlobalScript.inst.dlc[5])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Rebellion", 37);
				}
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 10);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			else if (this_number == 24 || this_number == 25)
			{
				if (GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.allcountries[7].isNATO)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 102);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 121);
				}
			}
			else if (this_number >= 26 && this_number <= 29)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 50);
			}
			else if (this_number == 30)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Intervene", 38);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 24);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 39);
			}
			else if (this_number == 31)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Union", 40);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Alliance", 41);
			}
			else if (this_number == 32 || this_number == 42)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Union", 10);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			else if (this_number == 32)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Union", 10);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			else if (this_number == 33)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Assistance", 42);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 10);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			else if (this_number == 34)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("CPT", 43);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 9);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 44);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			else if (this_number == 35)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("UAR", 45);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 24);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 53);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			else if (this_number == 37)
			{
				if (GlobalScript.inst.gameState.data[85] == 3 && GlobalScript.inst.gameState.allcountries[14].okb && GlobalScript.inst.gameState.allcountries[8].okb && GlobalScript.inst.gameState.allcountries[12].okb && GlobalScript.inst.gameState.allcountries[31].okb)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Align", 80);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Negotiation", 46);
				}
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 24);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 10);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			else if (this_number == 38)
			{
				if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Invasion", 48);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
				}
			}
			else if (this_number == 39)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Invest", 49);
				if (GlobalScript.inst.dlc[6])
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.new_texts[891], 155);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.new_texts[892], 156);
				}
				if (GlobalScript.inst.dlc[3])
				{
					if (!GlobalScript.inst.gameState.allcountries[this_number].cw && !GlobalScript.inst.gameState.allcountries[0].isNATO && !GlobalScript.inst.gameState.allcountries[0].isEU)
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[477], 148);
						map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[478], 149);
					}
					else if (GlobalScript.inst.gameState.allcountries[this_number].cw)
					{
						map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[38], 53);
					}
				}
			}
			else if (this_number == 40)
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 10);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("UAR", 45);
			}
			else if (this_number == 41)
			{
				if (GlobalScript.inst.gameState.resultOfEvents[403] == 0 && GlobalScript.inst.gameState.event_done[403] && !GlobalScript.inst.gameState.ingamewars[24].is_going)
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 101);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 112);
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[157], 110);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[158], 111);
				}
			}
			else if (this_number == 43 || this_number == 96 || this_number == 97)
			{
				if (GlobalScript.inst.dlc[3] && GlobalScript.inst.dlc[1])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[73], 97);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 98);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 99);
				}
			}
			else if (this_number == 44)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 52);
				if (!GlobalScript.inst.gameState.allcountries[this_number].proprc)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("CPJ", 51);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Diaoyu", 153);
				}
				if (!GlobalScript.inst.gameState.allcountries[this_number].IsInTheSameEconomicAllianceWith(GlobalScript.inst.gameState.allcountries[1]))
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 53);
				}
				else
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
				}
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Diaoyu", 154);
			}
			else if (this_number == 45)
			{
				if (!GlobalScript.inst.gameState.ingamewars[19].is_going || (GlobalScript.inst.gameState.allcountries[45].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[45].SubGosstroy != 0))
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 9);
					if (!GlobalScript.inst.gameState.allcountries[84].isSocEU)
					{
						map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 54);
					}
				}
			}
			else if (this_number == 46)
			{
				if (!GlobalScript.inst.gameState.allcountries[46].parts[0])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Pressure", 55);
				}
				if (!GlobalScript.inst.gameState.allcountries[46].isSEATO)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 24);
				}
				else if (!GlobalScript.inst.gameState.allcountries[10].isASEAN && GlobalScript.inst.gameState.allcountries[46].isASEAN)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[225], 122);
				}
			}
			else if (this_number == 47)
			{
				if (!GlobalScript.inst.gameState.allcountries[1].isASEAN && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(15))
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Maoists", 56);
				}
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 9);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 44);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			else if (this_number == 48)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 9);
				if (GlobalScript.inst.gameState.allcountries[48].Gosstroy != 3)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 10);
				}
			}
			else if (this_number == 52)
			{
				GlobalScript.inst.gameState.allcountries[this_number].name = GlobalScript.inst.other_text[475];
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 24);
				if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					if (!GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12))
					{
						if (GlobalScript.inst.gameState.allcountries[52].spec <= 0)
						{
							map1.buttons[1].GetComponent<DiploButtonScript>().Show("Sanctions", 58);
						}
						map1.buttons[2].GetComponent<DiploButtonScript>().Show("Revolution", 147);
					}
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Union", 44);
				}
			}
			else if (this_number == 49)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 24);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 10);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Alliance", 19);
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[270], 129);
				}
			}
			else if (this_number == 50)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Sanctions", 58);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 10);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 24);
			}
			else if (this_number >= 2 && this_number <= 6 && this_number != 3 && !GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[this_number].isSEV)
			{
				if (!GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.ingamewars[17].is_going)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 24);
					if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
					{
						map1.buttons[1].GetComponent<DiploButtonScript>().Show("Far-left", 1);
					}
					else
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[226], 123);
					}
				}
			}
			else if (this_number == 51)
			{
				if (!GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.modifies[49].active)
				{
					if (!GlobalScript.inst.gameState.allcountries[51].Torg)
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show("Friendship", 60);
					}
					else if (GlobalScript.inst.dlc[3])
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[195], 117);
					}
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Investment", 34);
					if (GlobalScript.inst.gameState.allcountries[51].dev <= 0)
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show("CIA", 61);
					}
					else if (GlobalScript.inst.dlc[3])
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[201], 118);
					}
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Technology", 75);
				}
			}
			else if (this_number == 69 || this_number == 70)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Preferences", 76);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Coup", 77);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Base", 78);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Reunion", 79);
			}
			else if (((this_number >= 53 && this_number < 69) || (this_number > 105 && this_number < 109)) && !GlobalScript.inst.gameState.allcountries[this_number].africaOff && (GlobalScript.inst.gameState.data[103] != 15 || this_number != 61))
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Support", 62);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("USSR", 63);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("USA", 64);
				if (GlobalScript.inst.gameState.allcountries[this_number].Torg || GlobalScript.inst.gameState.allcountries[this_number].proprc)
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Resources", 66);
				}
				else
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Coup", 65);
				}
			}
			else if (this_number >= 71 && this_number <= 83)
			{
				if (!GlobalScript.inst.gameState.allcountries[this_number].proprc)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[25], 82);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[28], 85);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[27], 84);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[36], 86);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[37], 87);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[38], 88);
				}
			}
			else if (this_number == 84)
			{
				if (GlobalScript.inst.dlc[3])
				{
					if (GlobalScript.inst.gameState.data[21] < 1981)
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[56], 91);
						map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[57], 92);
					}
					if (GlobalScript.inst.gameState.allcountries[84].Gosstroy == 2 || (GlobalScript.inst.gameState.allcountries[84].Gosstroy == 3 && GlobalScript.inst.gameState.data[21] > 1983))
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 9);
						if (!GlobalScript.inst.gameState.allcountries[84].isSocEU)
						{
							map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 53);
						}
					}
					if (GlobalScript.inst.gameState.data[124] > 0)
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[65], 94);
					}
				}
			}
			else if (this_number == 85)
			{
				if (GlobalScript.inst.dlc[3])
				{
					if (GlobalScript.inst.gameState.allcountries[85].SubGosstroy == 10)
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[148], 108);
						map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[149], 109);
						map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 53);
						map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
					}
					else if ((GlobalScript.inst.gameState.event_done[398] && GlobalScript.inst.gameState.resultOfEvents[398] < 3) || (GlobalScript.inst.gameState.event_done[401] && GlobalScript.inst.gameState.resultOfEvents[401] < 3))
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 9);
						map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 10);
						map1.buttons[2].GetComponent<DiploButtonScript>().Show("Alliance", 19);
					}
					else if (GlobalScript.inst.gameState.allcountries[85].inflCh == 6)
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[148], 108);
						map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[149], 109);
					}
					else
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 9);
					}
				}
			}
			else if ((this_number > 87 && this_number < 92) || this_number == 0)
			{
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 9);
				}
			}
			else if (this_number == 86)
			{
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Separatists", 136);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 9);
					if (GlobalScript.inst.gameState.allcountries[86].Gosstroy == 1 || (GlobalScript.inst.gameState.allcountries[86].Gosstroy == 0 && (GlobalScript.inst.gameState.allcountries[1].SubGosstroy == 13 || GlobalScript.inst.gameState.allcountries[1].SubGosstroy == 9 || GlobalScript.inst.gameState.allcountries[1].SubGosstroy == 7)))
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 10);
					}
				}
			}
			else if (this_number == 87)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Operation", 2);
				if (GlobalScript.inst.gameState.data[65] != 2 && !GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Conversation", 3);
				}
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[263], 128);
					if (GlobalScript.inst.gameState.allcountries[87].Gosstroy == 1)
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 10);
					}
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Trade", 9);
				}
			}
			else if (this_number == 92)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Operation", 2);
				if (GlobalScript.inst.gameState.data[65] != 2 && !GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Conversation", 3);
				}
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[176], 113);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Trade", 9);
				}
			}
			else if (this_number == 93)
			{
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[37], 93);
				}
			}
			else if (this_number == 94)
			{
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[65], 95);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 53);
				}
			}
			else if (this_number == 95)
			{
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[37], 96);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 53);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Alliance", 19);
				}
			}
			else if (this_number == 109 || this_number == 110)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 9);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 10);
			}
			else if (this_number == 36 || (this_number > 100 && this_number < 107 && this_number != 104))
			{
				if (GlobalScript.inst.gameState.modifies[51].active)
				{
					if (!GlobalScript.inst.gameState.allcountries[this_number].proprc)
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[457], 142);
						map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[458], 143);
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[459], 144);
					}
					else
					{
						map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[465], 145);
						map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[466], 146);
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[458], 143);
						map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[459], 144);
					}
				}
			}
			else if (this_number == 99)
			{
				if ((!GlobalScript.inst.gameState.allcountries[99].based && !GlobalScript.inst.gameState.ingamewars[26].is_going) || GlobalScript.inst.gameState.allcountries[99].econ || GlobalScript.inst.gameState.allcountries[99].isSEV || (GlobalScript.inst.gameState.allcountries[99].SubGosstroy == 10 && !GlobalScript.inst.gameState.ingamewars[26].is_going) || (GlobalScript.inst.gameState.allcountries[99].SubGosstroy == 7 && !GlobalScript.inst.gameState.ingamewars[26].is_going))
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 101);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 112);
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[165], 110);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[166], 111);
				}
			}
			else if (this_number == 100)
			{
				if ((!GlobalScript.inst.gameState.allcountries[100].based && !GlobalScript.inst.gameState.ingamewars[25].is_going) || GlobalScript.inst.gameState.allcountries[99].econ || GlobalScript.inst.gameState.allcountries[99].isSEV || (GlobalScript.inst.gameState.allcountries[100].Gosstroy == 3 && !GlobalScript.inst.gameState.ingamewars[25].is_going) || (GlobalScript.inst.gameState.allcountries[100].Gosstroy == 1 && !GlobalScript.inst.gameState.ingamewars[25].is_going))
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 101);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 112);
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[161], 110);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[162], 111);
				}
			}
			else if (this_number == 104 && GlobalScript.inst.dlc[3])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[485], 9);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 10);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 19);
			}
			if (this_number == 88 || this_number == 0 || this_number == 29 || this_number == 89 || this_number == 90 || this_number == 91 || this_number == 28)
			{
				if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[477], 148);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[478], 149);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[38], 53);
				}
			}
			else if (this_number == 27 && GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.event_done[453])
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[477], 148);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[478], 149);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[38], 53);
			}
			if (GlobalScript.inst.gameState.allcountries[1].isASEAN)
			{
				if (this_number == 31 || this_number == 32)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
				}
				else if (this_number == 43 || this_number == 96 || this_number == 97 || this_number == 12 || this_number == 11 || this_number == 23 || this_number == 49 || this_number == 52 || this_number == 33 || (this_number == 22 && (GlobalScript.inst.gameState.allcountries[22].proprc || GlobalScript.inst.gameState.allcountries[22].Vyshi)) || this_number == 95)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
				}
				else if (this_number == 34 || this_number == 44 || this_number == 47 || this_number == 50 || (this_number == 35 && GlobalScript.inst.gameState.allcountries[8].SubGosstroy != 35) || (this_number == 8 && GlobalScript.inst.gameState.allcountries[8].SubGosstroy != 9) || this_number == 37 || this_number == 46 || (this_number == 93 && GlobalScript.inst.gameState.allcountries[93].puppetOf == 37) || this_number == 104)
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
				}
				else if (this_number == 19)
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
				}
			}
			if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
			{
				if (this_number == 31 || this_number == 32)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
				}
				else if (this_number == 43 || this_number == 96 || this_number == 97 || this_number == 12 || this_number == 11 || this_number == 23 || this_number == 49 || this_number == 33 || (this_number == 22 && (GlobalScript.inst.gameState.allcountries[22].proprc || GlobalScript.inst.gameState.allcountries[22].Vyshi)) || this_number == 95)
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
				}
				else if (this_number == 34 || this_number == 44 || this_number == 47 || this_number == 46 || this_number == 50 || (this_number == 35 && !GlobalScript.inst.gameState.allcountries[35].oar) || (this_number == 8 && GlobalScript.inst.gameState.allcountries[8].SubGosstroy != 9) || this_number == 37 || (this_number == 93 && GlobalScript.inst.gameState.allcountries[93].puppetOf == 37) || this_number == 104)
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
				}
				else if (this_number == 19 && GlobalScript.inst.gameState.allcountries[19].isASEAN)
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
				}
			}
			if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
			{
				for (int i = 2; i < GlobalScript.inst.gameState.allcountries.Length; i++)
				{
					if (!GlobalScript.inst.gameState.allcountries[i].isSEATO || i == 51)
					{
						continue;
					}
					if (!GlobalScript.inst.gameState.allcountries[i].proprc)
					{
						if (this_number == i)
						{
							map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[277], 131);
							map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[238], 125);
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[i].proprc && this_number == i)
					{
						if (!GlobalScript.inst.gameState.allcountries[i].dota)
						{
							map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[308], 134);
						}
						else
						{
							map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[476], 134);
						}
						map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[238], 132);
					}
				}
			}
			if (GlobalScript.inst.gameState.allcountries[1].isOVD && GlobalScript.inst.dlc[3])
			{
				for (int j = 8; j < GlobalScript.inst.gameState.allcountries.Length; j++)
				{
					if (!GlobalScript.inst.gameState.allcountries[j].isOVD || (j != 8 && j != 11 && j != 14 && j != 12 && j != 31 && j != 43 && j != 34 && j != 47 && j != 42 && j != 22 && j != 37 && j != 23 && j != 32 && j != 33 && j != 35 && j != 96 && j != 97 && j != 98 && j != 95 && j != 49 && j != 50 && j != 104))
					{
						continue;
					}
					if (!GlobalScript.inst.gameState.allcountries[j].proprc)
					{
						if (this_number == j)
						{
							map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[277], 130);
						}
						if (this_number == j)
						{
							map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[238], 125);
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[j].proprc && this_number == j)
					{
						if (!GlobalScript.inst.gameState.allcountries[j].dota)
						{
							map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[308], 134);
						}
						else
						{
							map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[476], 134);
						}
						map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[238], 132);
					}
				}
			}
			if (GlobalScript.inst.gameState.allcountries[this_number].econ && (this_number != 30 || !GlobalScript.inst.gameState.OAR) && !GlobalScript.inst.gameState.allcountries[this_number].oar && (this_number == 19 || this_number == 52 || this_number == 48 || this_number == 50 || this_number == 96 || this_number == 49 || this_number == 47 || this_number == 46 || this_number == 11 || this_number == 22 || this_number == 23 || this_number == 34 || this_number == 33 || this_number == 32 || this_number == 97 || this_number == 43 || this_number == 31 || this_number == 12 || this_number == 8 || this_number == 14 || this_number == 35 || (this_number >= 53 && this_number < 69) || (this_number >= 106 && this_number < 109) || this_number == 104))
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Align", 80);
			}
			return;
		}
		if (this_number == 7)
		{
			if (!GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.ingamewars[22].is_going && GlobalScript.inst.gameState.data[133] != 1 && GlobalScript.inst.gameState.data[133] != 3 && !GlobalScript.inst.gameState.modifies[49].active)
			{
				if (!GlobalScript.inst.gameState.relres)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Отношения", 4);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Технологии", 81);
				}
				if (GlobalScript.inst.gameState.allcountries[7].Torg || GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("СЭВ", 5);
				}
				else
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Партнёр", 74);
				}
				if (GlobalScript.inst.gameState.allcountries[7].isOVD)
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("ОВД", 6);
				}
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Поддержка", 7);
			}
		}
		else if (this_number == 2 || this_number == 4 || this_number == 5 || this_number == 98)
		{
			if (GlobalScript.inst.gameState.allcountries[7].isNATO && GlobalScript.inst.gameState.allcountries[this_number].isOVD && !GlobalScript.inst.gameState.ingamewars[17].is_going)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[119], 103);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[120], 104);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[121], 105);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[131], 106);
			}
			else if (!GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.ingamewars[17].is_going && !GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[this_number].isSEV)
			{
				if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Маоисты", 1);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[226], 123);
				}
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			}
			else
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			}
		}
		else if (this_number == 1)
		{
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[183], 114);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[184], 115);
			}
			if (GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.allcountries[1].isASEAN)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[234], 124);
			}
		}
		else if (this_number == 3)
		{
			if (GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.allcountries[7].isNATO)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[106], 100);
			}
			if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Маоисты", 1);
			}
			else
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[226], 123);
			}
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[5].okb && GlobalScript.inst.gameState.allcountries[4].okb && GlobalScript.inst.gameState.allcountries[2].okb && !GlobalScript.inst.gameState.allcountries[7].isOVD && !GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.allcountries[3].okb)
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[131], 152);
			}
		}
		else if (this_number == 6)
		{
			if (!GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.ingamewars[17].is_going && !GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[this_number].isSEV)
			{
				if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Маоисты", 1);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[226], 123);
				}
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			}
			else
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			}
			if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[5].okb && GlobalScript.inst.gameState.allcountries[4].okb && GlobalScript.inst.gameState.allcountries[2].okb && !GlobalScript.inst.gameState.allcountries[6].isOVD && !GlobalScript.inst.gameState.allcountries[6].okb)
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[131], 151);
			}
		}
		else if (this_number == 8)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Поддержка", 8);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 9);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 10);
			map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
		}
		else if (this_number == 9)
		{
			if (!GlobalScript.inst.gameState.ingamewars[22].is_going && GlobalScript.inst.gameState.data[133] != 1 && GlobalScript.inst.gameState.data[133] != 3 && !GlobalScript.inst.gameState.allcountries[7].isNATO && (!GlobalScript.inst.gameState.allcountries[9].isOVD || (GlobalScript.inst.gameState.allcountries[1].isOVD && GlobalScript.inst.gameState.allcountries[9].isOVD)))
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Волнения", 11);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Переворот", 12);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Торговля", 9);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
			}
		}
		else if (this_number == 10)
		{
			if (!GlobalScript.inst.gameState.allcountries[this_number].econ && !GlobalScript.inst.gameState.allcountries[this_number].isSEV)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Союз", 13);
			}
			else
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Альянс", 19);
			}
			if (GlobalScript.inst.gameState.data[158] <= 0)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Санкции", 14);
			}
			if (GlobalScript.inst.gameState.allcountries[this_number].isSEATO || GlobalScript.inst.gameState.allcountries[this_number].isOVD || GlobalScript.inst.gameState.allcountries[this_number].okb)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Война", 15);
				if (!GlobalScript.inst.gameState.guns)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Оружие", 16);
				}
				else if (GlobalScript.inst.gameState.data[158] <= 0)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Санкции", 14);
				}
			}
			if (!GlobalScript.inst.gameState.allcountries[this_number].isSEATO && !GlobalScript.inst.gameState.allcountries[this_number].isOVD && !GlobalScript.inst.gameState.allcountries[this_number].okb)
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Война", 15);
			}
			if (!GlobalScript.inst.gameState.allcountries[this_number].isSEATO && !GlobalScript.inst.gameState.allcountries[this_number].isOVD && !GlobalScript.inst.gameState.allcountries[this_number].okb)
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Оружие", 16);
			}
		}
		else if (this_number == 11)
		{
			if (GlobalScript.inst.gameState.war <= 0)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 17);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 18);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Альянс", 19);
			}
			if (!GlobalScript.inst.dlc[5])
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Армия", 20);
			}
		}
		else if (this_number == 12)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 9);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 68);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Альянс", 19);
		}
		else if (this_number == 13)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Поддержать", 22);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 23);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("ОАР", 67);
			map1.buttons[3].GetComponent<DiploButtonScript>().Show("Союз", 150);
		}
		else if (this_number == 14)
		{
			if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[36].cw)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[293], 133);
			}
			else
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("ОАР", 25);
			}
			if (!GlobalScript.inst.gameState.allcountries[36].cw)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 24);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 53);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
			}
			if ((GlobalScript.inst.gameState.allcountries[14].proprc || GlobalScript.inst.gameState.allcountries[14].Vyshi) && GlobalScript.inst.gameState.allcountries[1].isASEAN)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 24);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
			}
		}
		else if (this_number == 15)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Договор", 26);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Поддержка", 27);
			if ((!GlobalScript.inst.gameState.allcountries[15].proprc || !GlobalScript.inst.gameState.allcountries[15].isSEV) && !GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.allcountries[2].okb && !GlobalScript.inst.gameState.allcountries[4].okb && !GlobalScript.inst.gameState.allcountries[5].okb && !GlobalScript.inst.gameState.allcountries[98].okb)
			{
				if (!GlobalScript.inst.gameState.allcountries[15].cw)
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Движение", 72);
				}
				else
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Выход", 73);
				}
			}
			else
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 10);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
			}
		}
		else if (this_number == 16)
		{
			if (GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.allcountries[this_number].isNATO)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[310], 135);
			}
			else if (!GlobalScript.inst.dlc[3])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			}
			if (GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.allcountries[7].isNATO && (!GlobalScript.inst.gameState.event_done[456] || GlobalScript.inst.gameState.resultOfEvents[456] < 0 || GlobalScript.inst.gameState.resultOfEvents[456] > 2))
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[324], 116);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[329], 137);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[334], 138);
			}
		}
		else if (this_number == 17)
		{
			if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Маоисты", 1);
			}
			if (GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.allcountries[7].isNATO && (!GlobalScript.inst.gameState.event_done[456] || GlobalScript.inst.gameState.resultOfEvents[456] < 0 || GlobalScript.inst.gameState.resultOfEvents[456] > 2))
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[324], 116);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[329], 137);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[334], 138);
			}
		}
		else if (this_number == 18)
		{
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[424], 139);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[425], 140);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[426], 141);
			}
		}
		else if (this_number == 19)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Наксалиты", 28);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Отношения", 29);
			if (GlobalScript.inst.gameState.war != 2 && !GlobalScript.inst.gameState.allcountries[this_number].proprc && !GlobalScript.inst.dlc[5])
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Война", 30);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].proprc && (GlobalScript.inst.gameState.allcountries[this_number].okb || GlobalScript.inst.gameState.allcountries[this_number].isOVD))
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Договор", 89);
			}
			else if (!GlobalScript.inst.dlc[5])
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Подкрепления", 71);
			}
			if (GlobalScript.inst.gameState.allcountries[this_number].proprc)
			{
				if (!GlobalScript.inst.gameState.allcountries[this_number].isSEV && !GlobalScript.inst.gameState.allcountries[this_number].econ)
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Союз", 10);
				}
				else
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
				}
			}
		}
		else if (this_number == 20)
		{
			if (!GlobalScript.inst.gameState.allcountries[this_number].parts[1])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Союз", 31);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Альянс", 19);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("СССР", 32);
			}
		}
		else if (this_number == 21)
		{
			if (!GlobalScript.inst.dlc[3])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Договор", 33);
			}
			else if (!GlobalScript.inst.gameState.allcountries[21].Torg)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Договор", 33);
			}
			else if (GlobalScript.inst.gameState.data[131] == 3)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[262], 127);
			}
			else
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Договор", 33);
			}
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Инвестиции", 34);
			if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Маоисты", 1);
			}
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[140], 107);
			}
			if (GlobalScript.inst.gameState.allcountries[21].Gosstroy == 1)
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Союз", 10);
			}
		}
		else if (this_number == 22)
		{
			if (!GlobalScript.inst.gameState.allcountries[1].isSEATO)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Отношения", 35);
			}
			else
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[244], 126);
			}
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 36);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Альянс", 19);
		}
		else if (this_number == 23 && !GlobalScript.inst.gameState.allcountries[23].prosov)
		{
			if (!GlobalScript.inst.dlc[5])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Мятеж", 37);
			}
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 10);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Альянс", 19);
		}
		else if (this_number == 24 || this_number == 25)
		{
			if (GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.allcountries[7].isNATO)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 102);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 121);
			}
		}
		else if (this_number >= 26 && this_number <= 29)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 50);
		}
		else if (this_number == 30)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Вмешаться", 38);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 39);
		}
		else if (this_number == 31)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Союз", 40);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Альянс", 41);
		}
		else if (this_number == 32 || this_number == 42)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Союз", 10);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Альянс", 19);
		}
		else if (this_number == 33)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Помощь", 42);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 10);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Альянс", 19);
		}
		else if (this_number == 34)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("КПТ", 43);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 9);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 44);
			map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
		}
		else if (this_number == 35)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("ОАР", 45);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 53);
			map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
		}
		else if (this_number == 37)
		{
			if (GlobalScript.inst.gameState.data[85] == 3 && (GlobalScript.inst.gameState.allcountries[30].okb || (GlobalScript.inst.gameState.allcountries[14].okb && GlobalScript.inst.gameState.allcountries[8].okb && GlobalScript.inst.gameState.allcountries[12].okb && GlobalScript.inst.gameState.allcountries[31].okb)))
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Склонить", 80);
			}
			else
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Переговоры", 46);
			}
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 10);
			map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
		}
		else if (this_number == 38)
		{
			if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Вторжение", 48);
			}
			else
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
			}
		}
		else if (this_number == 39)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Положить", 49);
			if (GlobalScript.inst.dlc[6])
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.new_texts[891], 155);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.new_texts[892], 156);
			}
			if (GlobalScript.inst.dlc[3])
			{
				if (!GlobalScript.inst.gameState.allcountries[this_number].cw && !GlobalScript.inst.gameState.allcountries[0].isNATO && !GlobalScript.inst.gameState.allcountries[0].isEU)
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[477], 148);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[478], 149);
				}
				else if (GlobalScript.inst.gameState.allcountries[this_number].cw)
				{
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[38], 53);
				}
			}
		}
		else if (this_number == 40)
		{
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 10);
			map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("ОАР", 45);
		}
		else if (this_number == 41)
		{
			if (GlobalScript.inst.gameState.resultOfEvents[403] == 0 && GlobalScript.inst.gameState.event_done[403] && !GlobalScript.inst.gameState.ingamewars[24].is_going)
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 101);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 112);
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[157], 110);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[158], 111);
			}
		}
		else if (this_number == 43 || this_number == 96 || this_number == 97)
		{
			if (GlobalScript.inst.dlc[3] && GlobalScript.inst.dlc[1])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[73], 97);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 98);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 99);
			}
		}
		else if (this_number == 44)
		{
			if (!GlobalScript.inst.gameState.allcountries[this_number].proprc)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("КПЯ", 51);
			}
			else
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Дяоютай", 153);
			}
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 52);
			if (!GlobalScript.inst.gameState.allcountries[this_number].IsInTheSameEconomicAllianceWith(GlobalScript.inst.gameState.allcountries[1]))
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 53);
			}
			else
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Aльянс", 19);
			}
			map1.buttons[3].GetComponent<DiploButtonScript>().Show("Дяоютай", 154);
		}
		else if (this_number == 45)
		{
			if (!GlobalScript.inst.gameState.ingamewars[19].is_going || (GlobalScript.inst.gameState.allcountries[45].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[45].SubGosstroy != 0))
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 9);
				if (!GlobalScript.inst.gameState.allcountries[84].isSocEU)
				{
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 54);
				}
			}
		}
		else if (this_number == 46)
		{
			if (!GlobalScript.inst.gameState.allcountries[46].parts[0])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Давление", 55);
			}
			if (!GlobalScript.inst.gameState.allcountries[46].isSEATO)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			}
			else if (!GlobalScript.inst.gameState.allcountries[10].isASEAN && GlobalScript.inst.gameState.allcountries[46].isASEAN)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[225], 122);
			}
		}
		else if (this_number == 47)
		{
			if (!GlobalScript.inst.gameState.allcountries[1].isASEAN && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(15))
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Маоисты", 56);
			}
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 9);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 44);
			map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
		}
		else if (this_number == 48)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 9);
			if (GlobalScript.inst.gameState.allcountries[48].Gosstroy != 3)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 10);
			}
		}
		else if (this_number == 52)
		{
			GlobalScript.inst.gameState.allcountries[this_number].name = GlobalScript.inst.other_text[475];
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
			{
				if (!GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12))
				{
					if (GlobalScript.inst.gameState.allcountries[52].spec <= 0)
					{
						map1.buttons[1].GetComponent<DiploButtonScript>().Show("Санкции", 58);
					}
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Переворот", 147);
				}
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Союз", 44);
			}
		}
		else if (this_number == 49)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 24);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 10);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Aльянс", 19);
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[270], 129);
			}
		}
		else if (this_number == 50)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Санкции", 58);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 10);
			map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 24);
		}
		else if (this_number == 51)
		{
			if (!GlobalScript.inst.gameState.allcountries[7].isNATO && !GlobalScript.inst.gameState.modifies[49].active)
			{
				if (!GlobalScript.inst.gameState.allcountries[51].Torg)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Дружба", 60);
				}
				else if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[195], 117);
				}
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Инвестиции", 34);
				if (GlobalScript.inst.gameState.allcountries[51].dev <= 0)
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("ЦРУ", 61);
				}
				else if (GlobalScript.inst.dlc[3])
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[201], 118);
				}
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Технологии", 75);
			}
		}
		else if (this_number == 69 || this_number == 70)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Преференции", 76);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Смещение", 77);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("База", 78);
			map1.buttons[3].GetComponent<DiploButtonScript>().Show("Возвращение", 79);
		}
		else if (((this_number >= 53 && this_number < 69) || (this_number > 105 && this_number < 109)) && !GlobalScript.inst.gameState.allcountries[this_number].africaOff && (GlobalScript.inst.gameState.data[103] != 15 || this_number != 61))
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Поддержать", 62);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("СССР", 63);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show("США", 64);
			if (GlobalScript.inst.gameState.allcountries[this_number].Torg || GlobalScript.inst.gameState.allcountries[this_number].proprc)
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Ресурсы", 66);
			}
			else
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Переворот", 65);
			}
		}
		else if (this_number >= 71 && this_number <= 83)
		{
			if (!GlobalScript.inst.gameState.allcountries[this_number].proprc)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[25], 82);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[28], 85);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[27], 84);
			}
			else
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[36], 86);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[37], 87);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[38], 88);
			}
		}
		else if (this_number == 84)
		{
			if (GlobalScript.inst.dlc[3])
			{
				if (GlobalScript.inst.gameState.data[21] < 1981)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[56], 91);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[57], 92);
				}
				if (GlobalScript.inst.gameState.allcountries[84].Gosstroy == 2 || (GlobalScript.inst.gameState.allcountries[84].Gosstroy == 3 && GlobalScript.inst.gameState.data[21] > 1983))
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 9);
					if (!GlobalScript.inst.gameState.allcountries[84].isSocEU)
					{
						map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 53);
					}
				}
				if (GlobalScript.inst.gameState.data[124] > 0)
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[65], 94);
				}
			}
		}
		else if (this_number == 85)
		{
			if (GlobalScript.inst.dlc[3])
			{
				if (GlobalScript.inst.gameState.allcountries[85].SubGosstroy == 10)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[148], 108);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[149], 109);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 53);
					map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
				}
				else if ((GlobalScript.inst.gameState.event_done[398] && GlobalScript.inst.gameState.resultOfEvents[398] < 3) || (GlobalScript.inst.gameState.event_done[401] && GlobalScript.inst.gameState.resultOfEvents[401] < 3))
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 9);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 10);
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Альянс", 19);
				}
				else if (GlobalScript.inst.gameState.allcountries[85].inflCh == 6)
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[148], 108);
					map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[149], 109);
				}
				else
				{
					map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 9);
				}
			}
		}
		else if ((this_number > 87 && this_number < 92) || this_number == 0)
		{
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 9);
			}
		}
		else if (this_number == 86)
		{
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show("Сепаратисты", 136);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Tорговля", 9);
				if (GlobalScript.inst.gameState.allcountries[86].Gosstroy == 1 || (GlobalScript.inst.gameState.allcountries[86].Gosstroy == 0 && (GlobalScript.inst.gameState.allcountries[1].SubGosstroy == 13 || GlobalScript.inst.gameState.allcountries[1].SubGosstroy == 9 || GlobalScript.inst.gameState.allcountries[1].SubGosstroy == 7)))
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 10);
				}
			}
		}
		else if (this_number == 87)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Операция", 2);
			if (GlobalScript.inst.gameState.data[65] != 2 && !GlobalScript.inst.gameState.allcountries[1].isSEV)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Переговоры", 3);
			}
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[263], 128);
				if (GlobalScript.inst.gameState.allcountries[87].Gosstroy == 1)
				{
					map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 10);
				}
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Торговля", 9);
			}
		}
		else if (this_number == 92)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Операция", 2);
			if (GlobalScript.inst.gameState.data[65] != 2 && !GlobalScript.inst.gameState.allcountries[1].isSEV)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Переговоры", 3);
			}
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[176], 113);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Торговля", 9);
			}
		}
		else if (this_number == 93)
		{
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[37], 93);
			}
		}
		else if (this_number == 94)
		{
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[65], 95);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 53);
			}
		}
		else if (this_number == 95)
		{
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[37], 96);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 53);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Альянс", 19);
			}
		}
		else if (this_number == 99)
		{
			if (((!GlobalScript.inst.gameState.allcountries[99].based && !GlobalScript.inst.gameState.ingamewars[26].is_going) || GlobalScript.inst.gameState.allcountries[99].econ || GlobalScript.inst.gameState.allcountries[99].isSEV || (GlobalScript.inst.gameState.allcountries[99].SubGosstroy == 10 && !GlobalScript.inst.gameState.ingamewars[26].is_going) || (GlobalScript.inst.gameState.allcountries[99].SubGosstroy == 7 && !GlobalScript.inst.gameState.ingamewars[26].is_going)) && !GlobalScript.inst.gameState.event_done[434])
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 101);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 112);
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[165], 110);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[166], 111);
			}
		}
		else if (this_number == 100)
		{
			if ((!GlobalScript.inst.gameState.allcountries[100].based && !GlobalScript.inst.gameState.ingamewars[25].is_going) || GlobalScript.inst.gameState.allcountries[99].econ || GlobalScript.inst.gameState.allcountries[99].isSEV || (GlobalScript.inst.gameState.allcountries[100].Gosstroy == 3 && !GlobalScript.inst.gameState.ingamewars[25].is_going) || (GlobalScript.inst.gameState.allcountries[100].Gosstroy == 1 && !GlobalScript.inst.gameState.ingamewars[25].is_going))
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 101);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 112);
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[161], 110);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[162], 111);
			}
		}
		else if (this_number == 104)
		{
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[485], 9);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 10);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 19);
			}
		}
		else if (this_number == 109 || this_number == 110)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 9);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 10);
		}
		else if ((this_number == 36 || (this_number > 100 && this_number < 107 && this_number != 104)) && GlobalScript.inst.gameState.modifies[51].active)
		{
			if (!GlobalScript.inst.gameState.allcountries[this_number].proprc)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[457], 142);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[458], 143);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[459], 144);
			}
			else
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[465], 145);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[466], 146);
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[458], 143);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[459], 144);
			}
		}
		if (this_number == 88 || this_number == 29 || this_number == 0 || this_number == 89 || this_number == 90 || this_number == 91 || this_number == 28)
		{
			if (GlobalScript.inst.dlc[3])
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[477], 148);
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[478], 149);
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[38], 53);
			}
		}
		else if (this_number == 27 && GlobalScript.inst.dlc[3] && !GlobalScript.inst.gameState.event_done[453])
		{
			map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[477], 148);
			map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[478], 149);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[38], 53);
		}
		if (GlobalScript.inst.gameState.allcountries[this_number].econ && (this_number != 30 || !GlobalScript.inst.gameState.OAR) && !GlobalScript.inst.gameState.allcountries[this_number].oar && (this_number == 19 || this_number == 52 || this_number == 48 || this_number == 50 || this_number == 96 || this_number == 49 || this_number == 47 || this_number == 46 || this_number == 11 || this_number == 22 || this_number == 23 || this_number == 34 || this_number == 33 || this_number == 32 || this_number == 97 || this_number == 43 || this_number == 31 || this_number == 12 || this_number == 8 || this_number == 14 || this_number == 35 || (this_number >= 53 && this_number < 69) || (this_number >= 106 && this_number < 109) || this_number == 104))
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show("Склонить", 80);
		}
		if (GlobalScript.inst.gameState.allcountries[1].isASEAN)
		{
			if (this_number == 31 || this_number == 32)
			{
				map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
			}
			else if (this_number == 43 || this_number == 96 || this_number == 97 || this_number == 12 || this_number == 11 || this_number == 23 || this_number == 49 || this_number == 52 || this_number == 33 || (this_number == 22 && (GlobalScript.inst.gameState.allcountries[22].proprc || GlobalScript.inst.gameState.allcountries[22].Vyshi)) || this_number == 95)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
			}
			else if (this_number == 34 || this_number == 44 || this_number == 47 || this_number == 50 || (this_number == 35 && GlobalScript.inst.gameState.allcountries[8].SubGosstroy != 35) || (this_number == 8 && GlobalScript.inst.gameState.allcountries[8].SubGosstroy != 9) || this_number == 37 || this_number == 46 || (this_number == 93 && GlobalScript.inst.gameState.allcountries[93].puppetOf == 37) || this_number == 104)
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
			}
			else if (this_number == 19)
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[79], 119);
			}
		}
		if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
		{
			if (this_number == 31 || this_number == 32)
			{
				map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
			}
			else if (this_number == 43 || this_number == 96 || this_number == 97 || this_number == 12 || this_number == 11 || this_number == 23 || this_number == 49 || this_number == 33 || (this_number == 22 && (GlobalScript.inst.gameState.allcountries[22].proprc || GlobalScript.inst.gameState.allcountries[22].Vyshi)) || this_number == 95)
			{
				map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
			}
			else if (this_number == 34 || this_number == 44 || this_number == 47 || this_number == 46 || this_number == 50 || (this_number == 35 && !GlobalScript.inst.gameState.allcountries[35].oar) || (this_number == 8 && GlobalScript.inst.gameState.allcountries[8].SubGosstroy != 9) || this_number == 37 || (this_number == 93 && GlobalScript.inst.gameState.allcountries[93].puppetOf == 37) || this_number == 104)
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
			}
			else if (this_number == 19 && GlobalScript.inst.gameState.allcountries[19].isASEAN)
			{
				map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 120);
			}
		}
		if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
		{
			for (int k = 2; k < GlobalScript.inst.gameState.allcountries.Length; k++)
			{
				if (!GlobalScript.inst.gameState.allcountries[k].isSEATO || k == 51)
				{
					continue;
				}
				if (!GlobalScript.inst.gameState.allcountries[k].proprc)
				{
					if (this_number == k)
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[277], 131);
						map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[238], 125);
					}
				}
				else if (GlobalScript.inst.gameState.allcountries[k].proprc && this_number == k)
				{
					if (!GlobalScript.inst.gameState.allcountries[k].dota)
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[308], 134);
					}
					else
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[476], 134);
					}
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[238], 132);
				}
			}
		}
		else
		{
			if (!GlobalScript.inst.gameState.allcountries[1].isOVD || !GlobalScript.inst.dlc[3])
			{
				return;
			}
			for (int l = 8; l < GlobalScript.inst.gameState.allcountries.Length; l++)
			{
				if (!GlobalScript.inst.gameState.allcountries[l].isOVD || (l != 8 && l != 11 && l != 14 && l != 12 && l != 31 && l != 43 && l != 42 && l != 22 && l != 37 && l != 34 && l != 47 && l != 23 && l != 32 && l != 33 && l != 35 && l != 96 && l != 97 && l != 98 && l != 95 && l != 49 && l != 50 && l != 104))
				{
					continue;
				}
				if (!GlobalScript.inst.gameState.allcountries[l].proprc)
				{
					if (this_number == l)
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[277], 130);
					}
					if (this_number == l)
					{
						map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[238], 125);
					}
				}
				else if (GlobalScript.inst.gameState.allcountries[l].proprc && this_number == l)
				{
					if (!GlobalScript.inst.gameState.allcountries[l].dota)
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[308], 134);
					}
					else
					{
						map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[476], 134);
					}
					map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[238], 132);
				}
			}
		}
	}

	public void Repaint_forTimes()
	{
		if (!on_mouse_it)
		{
			Repaint();
		}
	}

	public void Repaint()
	{
		map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		global1 = GlobalScript.inst;
		sp = GetComponent<SpriteRenderer>();
		if (grey == null || (this_number == 69 && GlobalScript.inst.gameState.data[67] == 0) || (this_number == 70 && GlobalScript.inst.gameState.data[66] == 0))
		{
			return;
		}
		if (GlobalScript.inst.gameState.completedDecisions[19])
		{
			GlobalScript.inst.gameState.allcountries[9].prosov = false;
			GlobalScript.inst.gameState.allcountries[9].proprc = true;
			GlobalScript.inst.gameState.allcountries[9].Vyshi = false;
			GlobalScript.inst.gameState.allcountries[9].isNATO = false;
			GlobalScript.inst.gameState.allcountries[9].isOVD = false;
			GlobalScript.inst.gameState.allcountries[9].okb = false;
			GlobalScript.inst.gameState.allcountries[9].isSEV = false;
			GlobalScript.inst.gameState.allcountries[9].econ = false;
			GlobalScript.inst.gameState.allcountries[9].isEU = false;
			GlobalScript.inst.gameState.data[130] = 1;
			GlobalScript.inst.gameState.allcountries[1].ILoveSuckCocks();
		}
		if (GlobalScript.inst.gameState.completedDecisions[6] || GlobalScript.inst.gameState.completedDecisions[7])
		{
			GlobalScript.inst.gameState.allcountries[1].ILoveSuckCocks();
		}
		else if (this_number == 69 && GlobalScript.inst.gameState.data[62] >= 2)
		{
			sp.sprite = special;
		}
		else if (sp.sprite != special)
		{
			sp.sprite = grey;
		}
		if (this_number == 10 && GlobalScript.inst.gameState.data[83] == 2)
		{
			this_number = 46;
			GlobalScript.inst.gameState.allcountries[10].prosov = GlobalScript.inst.gameState.allcountries[46].prosov;
			GlobalScript.inst.gameState.allcountries[10].proprc = GlobalScript.inst.gameState.allcountries[46].proprc;
		}
		else if (this_number == 46 && GlobalScript.inst.gameState.data[83] == 1)
		{
			this_number = 10;
			GlobalScript.inst.gameState.allcountries[46].prosov = GlobalScript.inst.gameState.allcountries[10].prosov;
			GlobalScript.inst.gameState.allcountries[46].proprc = GlobalScript.inst.gameState.allcountries[10].proprc;
		}
		else if (this_number == 38 && GlobalScript.inst.gameState.completedDecisions[7])
		{
			this_number = 1;
		}
		if (this_number == -2)
		{
			if (!GlobalScript.inst.gameState.BritLost)
			{
				this_number = 92;
			}
			else
			{
				this_number = 71;
			}
		}
		sp.material.SetColor("_MainColor", colors[1]);
		sp.material.SetColor("_MainColor2", colors[1]);
		if (global1.map_type == 0)
		{
			if (GlobalScript.inst.gameState.allcountries[this_number].isNATO)
			{
				sp.material.SetColor("_MainColor", colors[3]);
				sp.material.SetColor("_MainColor2", colors[4]);
			}
			if (GlobalScript.inst.gameState.allcountries[this_number].isSEATO)
			{
				sp.material.SetColor("_MainColor", colors[3]);
				sp.material.SetColor("_MainColor2", colors[14]);
			}
			if (GlobalScript.inst.gameState.allcountries[this_number].isSENTO)
			{
				sp.material.SetColor("_MainColor", colors[3]);
				sp.material.SetColor("_MainColor2", colors[14]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].isOVD)
			{
				sp.material.SetColor("_MainColor2", colors[2]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].okb)
			{
				sp.material.SetColor("_MainColor", colors[8]);
				sp.material.SetColor("_MainColor2", colors[9]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].oar)
			{
				sp.material.SetColor("_MainColor", colors[12]);
				sp.material.SetColor("_MainColor2", colors[13]);
			}
			return;
		}
		if (global1.map_type == 2)
		{
			if (GlobalScript.inst.gameState.allcountries[this_number].isEU && GlobalScript.inst.gameState.allcountries[this_number].Torg)
			{
				sp.material.SetColor("_MainColor2", colors[11]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].isASEAN && GlobalScript.inst.gameState.allcountries[this_number].Torg)
			{
				sp.material.SetColor("_MainColor", colors[17]);
				sp.material.SetColor("_MainColor2", colors[18]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].isEU)
			{
				sp.material.SetColor("_MainColor", colors[3]);
				sp.material.SetColor("_MainColor2", colors[4]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].isSocEU && GlobalScript.inst.gameState.allcountries[this_number].Torg)
			{
				sp.material.SetColor("_MainColor", colors[19]);
				sp.material.SetColor("_MainColor2", colors[9]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].isSocEU)
			{
				sp.material.SetColor("_MainColor", colors[19]);
				sp.material.SetColor("_MainColor2", colors[1]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].isOil)
			{
				sp.material.SetColor("_MainColor", colors[15]);
				sp.material.SetColor("_MainColor2", colors[16]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].isASEAN)
			{
				sp.material.SetColor("_MainColor", colors[3]);
				sp.material.SetColor("_MainColor2", colors[14]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].isSEV && GlobalScript.inst.gameState.allcountries[this_number].Torg)
			{
				sp.material.SetColor("_MainColor2", colors[10]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].isSEV)
			{
				sp.material.SetColor("_MainColor2", colors[2]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].econ)
			{
				sp.material.SetColor("_MainColor", colors[8]);
				sp.material.SetColor("_MainColor2", colors[9]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].Torg)
			{
				sp.material.SetColor("_MainColor", colors[5]);
				sp.material.SetColor("_MainColor2", colors[7]);
			}
			return;
		}
		if (global1.map_type == 3)
		{
			if (GlobalScript.inst.gameState.allcountries[this_number].Vyshi || ((this_number < 53 || this_number >= 69) && this_number != 61 && GlobalScript.inst.gameState.allcountries[this_number].usalliance))
			{
				sp.material.SetColor("_MainColor", colors[3]);
				sp.material.SetColor("_MainColor2", colors[4]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].prosov || ((this_number < 53 || this_number >= 69) && this_number != 61 && GlobalScript.inst.gameState.allcountries[this_number].sovalliance))
			{
				sp.material.SetColor("_MainColor2", colors[2]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].proprc)
			{
				sp.material.SetColor("_MainColor", colors[8]);
				sp.material.SetColor("_MainColor2", colors[9]);
			}
			return;
		}
		try
		{
			if (GlobalScript.inst.gameState.allcountries[this_number].Gosstroy == 0)
			{
				sp.material.SetColor("_MainColor2", colors[1]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].Gosstroy == 1)
			{
				sp.material.SetColor("_MainColor2", colors[2]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].Gosstroy == 2)
			{
				sp.material.SetColor("_MainColor", colors[5]);
				sp.material.SetColor("_MainColor2", colors[7]);
			}
			else if (GlobalScript.inst.gameState.allcountries[this_number].Gosstroy == 3)
			{
				sp.material.SetColor("_MainColor", colors[3]);
				sp.material.SetColor("_MainColor2", colors[4]);
			}
		}
		catch (Exception)
		{
			Debug.Log($"РАЗМЕР МАССИВА СТРАН {GlobalScript.inst.gameState.allcountries.Length}");
			Debug.Log($"НОМЕР {this_number} СТРАНА {GlobalScript.inst.gameState.allcountries[this_number]}");
		}
	}
}
