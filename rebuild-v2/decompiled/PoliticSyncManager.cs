using UnityEngine;

public class PoliticSyncManager : MonoBehaviour
{
	private GlobalScript global;

	private void Start()
	{
		global = GlobalScript.inst;
		if (global == null || global.gameState == null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		for (int i = 0; i < global.gameState.citizens.Length; i++)
		{
			Persona persona = global.gameState.citizens[i];
			if (persona != null && persona.isPolitic)
			{
				UpdatePoliticFromCitizen(persona);
			}
		}
		Debug.Log("PoliticSyncManager завершил работу и удаляется.");
		Object.Destroy(base.gameObject);
	}

	private void UpdatePoliticFromCitizen(Persona citizen)
	{
		for (int i = 0; i < global.gameState.politics.Length; i++)
		{
			Politic politic = global.gameState.politics[i];
			if (politic != null && politic.isCitizen && global.gameState.names1[politic.name_1] == citizen.name && global.gameState.names2[politic.name_2] == citizen.surname)
			{
				politic.traits = ConvertTraitsToPoliticTraits(citizen);
				politic.age = (byte)citizen.age;
				Debug.Log("Политик " + citizen.name + " " + citizen.surname + " обновлён");
				break;
			}
		}
	}

	private byte[] ConvertTraitsToPoliticTraits(Persona citizen)
	{
		byte[] array = new byte[3];
		switch (citizen.primaryTrait)
		{
		case CitizenManager.PrimaryTrait.LeftRadical:
			array[0] = 0;
			break;
		case CitizenManager.PrimaryTrait.Moderate:
			array[0] = 1;
			break;
		case CitizenManager.PrimaryTrait.Reformist:
			array[0] = 2;
			break;
		case CitizenManager.PrimaryTrait.Liberal:
			array[0] = 3;
			break;
		default:
			array[0] = 1;
			break;
		}
		switch (citizen.secondaryTrait)
		{
		case CitizenManager.SecondaryTrait.Firm:
			array[1] = 4;
			break;
		case CitizenManager.SecondaryTrait.Pragmatic:
			array[1] = 5;
			break;
		case CitizenManager.SecondaryTrait.Soft:
			array[1] = 6;
			break;
		case CitizenManager.SecondaryTrait.Scientist:
			array[1] = 7;
			break;
		default:
			array[1] = 5;
			break;
		}
		array[2] = 8;
		if (citizen.tertiaryTraits != null && citizen.tertiaryTraits.Count > 0)
		{
			switch (citizen.tertiaryTraits[0])
			{
			case CitizenManager.TertiaryTrait.Pettytyrant:
				array[2] = 10;
				break;
			case CitizenManager.TertiaryTrait.Thrifty:
				array[2] = 11;
				break;
			case CitizenManager.TertiaryTrait.Arrogant:
				array[2] = 12;
				break;
			case CitizenManager.TertiaryTrait.Idol:
				array[2] = 13;
				break;
			case CitizenManager.TertiaryTrait.Chinophilic:
				array[2] = 14;
				break;
			case CitizenManager.TertiaryTrait.Westophilic:
				array[2] = 15;
				break;
			case CitizenManager.TertiaryTrait.Schemer:
				array[2] = 16;
				break;
			case CitizenManager.TertiaryTrait.Timid:
				array[2] = 17;
				break;
			case CitizenManager.TertiaryTrait.Peculator:
				array[2] = 18;
				break;
			default:
				array[2] = 8;
				break;
			}
		}
		if (global.gameState.gamerules[8] > 0)
		{
			if (array[1] == 7)
			{
				array[1] = 6;
			}
			if (array[2] == 11)
			{
				array[2] = 18;
			}
			else if (array[2] == 13)
			{
				array[2] = 10;
			}
		}
		return array;
	}
}
