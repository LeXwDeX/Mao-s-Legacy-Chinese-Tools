namespace LEGK;

public class EventDesc
{
	public string name;

	public string desc;

	public string title;

	public string icon;

	public string[] options;

	public string[] results;

	public string[] lockeds;

	public string[] title_result;

	public EventDesc(string name, string desc, string title, string icon, string[] options, string[] results, string[] title_result, string[] lockeds)
	{
		this.name = name;
		this.desc = desc;
		this.title = title;
		this.icon = icon;
		this.options = options;
		this.results = results;
		this.title_result = title_result;
		this.lockeds = lockeds;
	}
}
