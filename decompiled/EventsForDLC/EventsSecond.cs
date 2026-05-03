using UnityEngine;

namespace EventsForDLC;

public abstract class EventsSecond : MonoBehaviour
{
	public abstract void TextOfEvents(ref string name, ref string text);

	public abstract void VariantsOfEvents(ref int kolvo_variant, ref string[] fake_text, ref GameObject[] button);

	public abstract void ResultsOfEvents(ref string name, ref string text, int result_num);
}
