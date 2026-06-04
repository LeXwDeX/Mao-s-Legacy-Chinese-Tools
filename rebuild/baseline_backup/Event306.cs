using EventsForDLC;
using UnityEngine;

public class Event306 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[69];
		text = string.Format(GlobalScript.inst.new_events_text[70]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[71];
		button_text[1] = GlobalScript.inst.new_events_text[72];
		if (GlobalScript.inst.gameState.NumberOfPolitician(15, 15) >= 0)
		{
			button_text[2] = GlobalScript.inst.new_events_text[73];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[52]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[69];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[74];
			GlobalScript.inst.gameState.data[3] -= 100;
			break;
		case 1:
		{
			text = GlobalScript.inst.new_events_text[75];
			int num2 = -1;
			for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
			{
				if (GlobalScript.inst.gameState.politics[i].name_1 == 15 && GlobalScript.inst.gameState.politics[i].name_2 == 15)
				{
					num2 = i;
					break;
				}
			}
			if (num2 >= 0)
			{
				GlobalScript.inst.gameState.KillPerson(num2);
			}
			break;
		}
		case 2:
		{
			text = GlobalScript.inst.new_events_text[76];
			int num = GlobalScript.inst.gameState.NumberOfPolitician(15, 15);
			GlobalScript.inst.gameState.data[1] -= 250;
			GlobalScript.inst.gameState.data[3] += 100;
			GlobalScript.inst.gameState.data[4] += 250;
			GlobalScript.inst.gameState.data[9] -= 50;
			GlobalScript.inst.gameState.data[6] -= 150;
			GlobalScript.inst.gameState.empires[0].relations += 100;
			GlobalScript.inst.gameState.leader.name_1 = GlobalScript.inst.gameState.politics[num].name_1;
			GlobalScript.inst.gameState.leader.name_2 = GlobalScript.inst.gameState.politics[num].name_2;
			GlobalScript.inst.gameState.leader.traits[0] = GlobalScript.inst.gameState.politics[num].traits[0];
			GlobalScript.inst.gameState.leader.traits[1] = GlobalScript.inst.gameState.politics[num].traits[1];
			GlobalScript.inst.gameState.leader.traits[2] = GlobalScript.inst.gameState.politics[num].traits[2];
			GlobalScript.inst.gameState.leader.age = GlobalScript.inst.gameState.politics[num].age;
			GlobalScript.inst.gameState.leader.face_type = GlobalScript.inst.gameState.politics[num].face_type;
			GlobalScript.inst.gameState.leader.face_parts[0] = GlobalScript.inst.gameState.politics[num].face_parts[0];
			GlobalScript.inst.gameState.leader.face_parts[1] = GlobalScript.inst.gameState.politics[num].face_parts[1];
			GlobalScript.inst.gameState.leader.face_parts[2] = GlobalScript.inst.gameState.politics[num].face_parts[2];
			GlobalScript.inst.gameState.leader.face_parts[3] = GlobalScript.inst.gameState.politics[num].face_parts[3];
			GlobalScript.inst.gameState.leader.face_parts[4] = GlobalScript.inst.gameState.politics[num].face_parts[4];
			GlobalScript.inst.gameState.leader.face_parts[5] = GlobalScript.inst.gameState.politics[num].face_parts[5];
			GlobalScript.inst.gameState.leader.face_parts[6] = GlobalScript.inst.gameState.politics[num].face_parts[6];
			GlobalScript.inst.gameState.leader.face_parts[7] = GlobalScript.inst.gameState.politics[num].face_parts[7];
			GlobalScript.inst.gameState.leader.jacket = GlobalScript.inst.gameState.politics[num].jacket;
			GlobalScript.inst.gameState.KillPerson(num);
			break;
		}
		}
	}
}
