using EventsForDLC;
using UnityEngine;

public class Event124 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[297];
		text = GlobalScript.inst.new_texts[298];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_texts[299];
		button_text[1] = GlobalScript.inst.new_texts[300];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[297];
		text = GlobalScript.inst.new_texts[301];
		if (GlobalScript.inst.gameState.faction_leader[0] < 50)
		{
			GlobalScript.inst.gameState.KillPerson(GlobalScript.inst.gameState.faction_leader[0]);
		}
		if (GlobalScript.inst.gameState.faction_leader[4] < 50)
		{
			GlobalScript.inst.gameState.KillPerson(GlobalScript.inst.gameState.faction_leader[4]);
		}
		int num = 0;
		num = ((GlobalScript.inst.gameState.faction_leader[2] >= 50) ? 16 : GlobalScript.inst.gameState.faction_leader[2]);
		GlobalScript.inst.gameState.politics[num].name_1 = 3;
		GlobalScript.inst.gameState.politics[num].name_2 = 42;
		GlobalScript.inst.gameState.politics[num].traits[0] = 1;
		GlobalScript.inst.gameState.politics[num].traits[1] = 7;
		GlobalScript.inst.gameState.politics[num].traits[2] = 17;
		GlobalScript.inst.gameState.politics[num].age = (byte)(GlobalScript.inst.gameState.data[21] - 1932);
		GlobalScript.inst.gameState.politics[num].face_parts[0] = (byte)Random.Range(0, 3);
		GlobalScript.inst.gameState.politics[num].face_parts[1] = (byte)Random.Range(0, 6);
		GlobalScript.inst.gameState.politics[num].face_parts[2] = (byte)Random.Range(0, 6);
		GlobalScript.inst.gameState.politics[num].face_parts[3] = 0;
		GlobalScript.inst.gameState.politics[num].face_parts[4] = (byte)Random.Range(0, 6);
		GlobalScript.inst.gameState.politics[num].face_parts[5] = (byte)Random.Range(0, 3);
		GlobalScript.inst.gameState.politics[num].face_parts[6] = (byte)Random.Range(0, 6);
		GlobalScript.inst.gameState.politics[num].face_parts[7] = 0;
		GlobalScript.inst.gameState.politics[num].jacket = 2;
		GlobalScript.inst.gameState.politics[num].face_type = 0;
		num = ((GlobalScript.inst.gameState.faction_leader[3] >= 50) ? 15 : GlobalScript.inst.gameState.faction_leader[3]);
		GlobalScript.inst.gameState.politics[num].name_1 = 3;
		GlobalScript.inst.gameState.politics[num].name_2 = 44;
		GlobalScript.inst.gameState.politics[num].traits[0] = 2;
		GlobalScript.inst.gameState.politics[num].traits[1] = 5;
		GlobalScript.inst.gameState.politics[num].traits[2] = 14;
		GlobalScript.inst.gameState.politics[num].age = (byte)(GlobalScript.inst.gameState.data[21] - 1945);
		GlobalScript.inst.gameState.politics[num].face_parts[0] = (byte)Random.Range(0, 3);
		GlobalScript.inst.gameState.politics[num].face_parts[1] = (byte)Random.Range(0, 6);
		GlobalScript.inst.gameState.politics[num].face_parts[2] = (byte)Random.Range(0, 6);
		GlobalScript.inst.gameState.politics[num].face_parts[3] = (byte)Random.Range(0, 4);
		GlobalScript.inst.gameState.politics[num].face_parts[4] = (byte)Random.Range(0, 6);
		GlobalScript.inst.gameState.politics[num].face_parts[5] = (byte)Random.Range(0, 3);
		GlobalScript.inst.gameState.politics[num].face_parts[6] = (byte)Random.Range(0, 6);
		GlobalScript.inst.gameState.politics[num].face_parts[7] = (byte)Random.Range(0, 3);
		GlobalScript.inst.gameState.politics[num].jacket = 3;
		GlobalScript.inst.gameState.politics[num].face_type = 0;
		GlobalScript.inst.gameState.data[9] -= 25;
		GlobalScript.inst.gameState.data[8] -= 25;
		num = ((GlobalScript.inst.gameState.faction_leader[1] >= 50) ? 14 : GlobalScript.inst.gameState.faction_leader[1]);
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.leader.name_1 = 41;
			GlobalScript.inst.gameState.leader.name_2 = 45;
			GlobalScript.inst.gameState.leader.traits[0] = 0;
			GlobalScript.inst.gameState.leader.traits[1] = 4;
			GlobalScript.inst.gameState.leader.traits[2] = 13;
			GlobalScript.inst.gameState.leader.age = (byte)(GlobalScript.inst.gameState.data[21] - 1911);
			GlobalScript.inst.gameState.leader.face_parts[0] = (byte)Random.Range(0, 3);
			GlobalScript.inst.gameState.leader.face_parts[1] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.leader.face_parts[2] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.leader.face_parts[3] = 0;
			GlobalScript.inst.gameState.leader.face_parts[4] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.leader.face_parts[5] = (byte)Random.Range(0, 3);
			GlobalScript.inst.gameState.leader.face_parts[6] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.leader.face_parts[7] = 0;
			GlobalScript.inst.gameState.leader.jacket = 0;
			GlobalScript.inst.gameState.leader.face_type = 0;
			GlobalScript.inst.gameState.politics[num].name_1 = 3;
			GlobalScript.inst.gameState.politics[num].name_2 = 43;
			GlobalScript.inst.gameState.politics[num].traits[0] = 1;
			GlobalScript.inst.gameState.politics[num].traits[1] = 7;
			GlobalScript.inst.gameState.politics[num].traits[2] = 14;
			GlobalScript.inst.gameState.politics[num].age = (byte)(GlobalScript.inst.gameState.data[21] - 1939);
			GlobalScript.inst.gameState.politics[num].face_parts[0] = (byte)Random.Range(0, 3);
			GlobalScript.inst.gameState.politics[num].face_parts[1] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.politics[num].face_parts[2] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.politics[num].face_parts[3] = (byte)Random.Range(0, 4);
			GlobalScript.inst.gameState.politics[num].face_parts[4] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.politics[num].face_parts[5] = (byte)Random.Range(0, 3);
			GlobalScript.inst.gameState.politics[num].face_parts[6] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.politics[num].face_parts[7] = (byte)Random.Range(0, 3);
			GlobalScript.inst.gameState.politics[num].jacket = 1;
			GlobalScript.inst.gameState.politics[num].face_type = 0;
			GlobalScript.inst.gameState.data[5] += 50;
			GlobalScript.inst.gameState.data[3] += 50;
			break;
		case 1:
			GlobalScript.inst.gameState.leader.name_1 = 3;
			GlobalScript.inst.gameState.leader.name_2 = 43;
			GlobalScript.inst.gameState.leader.traits[0] = 1;
			GlobalScript.inst.gameState.leader.traits[1] = 7;
			GlobalScript.inst.gameState.leader.traits[2] = 14;
			GlobalScript.inst.gameState.leader.age = (byte)(GlobalScript.inst.gameState.data[21] - 1939);
			GlobalScript.inst.gameState.leader.face_parts[0] = (byte)Random.Range(0, 3);
			GlobalScript.inst.gameState.leader.face_parts[1] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.leader.face_parts[2] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.leader.face_parts[3] = (byte)Random.Range(0, 4);
			GlobalScript.inst.gameState.leader.face_parts[4] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.leader.face_parts[5] = (byte)Random.Range(0, 3);
			GlobalScript.inst.gameState.leader.face_parts[6] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.leader.face_parts[7] = (byte)Random.Range(0, 3);
			GlobalScript.inst.gameState.leader.jacket = 1;
			GlobalScript.inst.gameState.leader.face_type = 0;
			GlobalScript.inst.gameState.politics[num].name_1 = 41;
			GlobalScript.inst.gameState.politics[num].name_2 = 45;
			GlobalScript.inst.gameState.politics[num].traits[0] = 0;
			GlobalScript.inst.gameState.politics[num].traits[1] = 4;
			GlobalScript.inst.gameState.politics[num].traits[2] = 13;
			GlobalScript.inst.gameState.politics[num].age = (byte)(GlobalScript.inst.gameState.data[21] - 1911);
			GlobalScript.inst.gameState.politics[num].face_parts[0] = (byte)Random.Range(0, 3);
			GlobalScript.inst.gameState.politics[num].face_parts[1] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.politics[num].face_parts[2] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.politics[num].face_parts[3] = 0;
			GlobalScript.inst.gameState.politics[num].face_parts[4] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.politics[num].face_parts[5] = (byte)Random.Range(0, 3);
			GlobalScript.inst.gameState.politics[num].face_parts[6] = (byte)Random.Range(0, 6);
			GlobalScript.inst.gameState.politics[num].face_parts[7] = 0;
			GlobalScript.inst.gameState.politics[num].jacket = 0;
			GlobalScript.inst.gameState.politics[num].face_type = 0;
			GlobalScript.inst.gameState.data[9] += 50;
			GlobalScript.inst.gameState.data[8] += 50;
			break;
		}
		for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
		{
			GlobalScript.inst.gameState.CalcRel(i);
			GlobalScript.inst.gameState.CalcRel2(i);
			GlobalScript.inst.gameState.CalcRelLeader(i);
		}
	}
}
