using EventsForDLC;
using UnityEngine;

public class Event304 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[57];
		text = string.Format(GlobalScript.inst.new_events_text[58]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[59];
		button_text[1] = GlobalScript.inst.new_events_text[60];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[57];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[61];
			break;
		case 1:
		{
			text = GlobalScript.inst.new_events_text[62];
			int num = ((GlobalScript.inst.gameState.faction_leader[1] < 100) ? GlobalScript.inst.gameState.faction_leader[1] : ((GlobalScript.inst.gameState.faction_leader[2] < 100) ? GlobalScript.inst.gameState.faction_leader[2] : GlobalScript.inst.gameState.faction_leader[3]));
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
