using UnityEngine;

public class Stat_script : MonoBehaviour
{
	public TextMesh[] Name = new TextMesh[12];

	private GlobalScript global1;

	private void Awake()
	{
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (PlayerPrefs.GetInt("language") == 0)
		{
			GetComponent<TextMesh>().text = "Report (% of 1985)\n(in real)";
			Name[1].text = "Report (% of 1985)\n(player)";
			Name[2].text = "Date\nJan 89\nFeb 89\nMarch 89\nApr 89\nMay 89\nJune 89\nJuly 89\nAug 89\nSep 89\nOct 89\nNov 89\nDec 89\n";
			Name[2].text += "Jan 90\nFeb 90\nMarch 90\nApr 90\nMay 90\nJune 90\nJuly 90\nAug 90\nSep 90\nOct 90\nNov 90\nDec 90\n";
			Name[2].text += "Jan 91\nFeb 91\nMarch 91\nApr 91\nMay 91\nJune 91\nJuly 91\nAug 91\nSep 91\nOct 91\nNov 91\nDec 91";
			Name[3].text = "GDP";
			Name[4].text = "HDI";
			Name[5].text = "Deficit\nof goods";
			Name[6].text = "Growth of\neconomy";
			Name[3].text += PlayerPrefs.GetString("VVP");
			Name[4].text += PlayerPrefs.GetString("IRCHP");
			Name[5].text += PlayerPrefs.GetString("SALARY");
			Name[6].text += PlayerPrefs.GetString("ROST");
			Name[7].text = "Date\nJan 89\nFeb 89\nMarch 89\nApr 89\nMay 89\nJune 89\nJuly 89\nAug 89\nSep 89\nOct 89\nNov 89\nDec 89\n";
			Name[7].text += "Jan 90\nFeb 90\nMarch 90\nApr 90\nMay 90\nJune 90\nJuly 90\nAug 90\nSep 90\nOct 90\nNov 90\nDec 90\n";
			Name[7].text += "Jan 91\nFeb 91\nMarch 91\nApr 91\nMay 91\nJune 91\nJuly 91\nAug 91\nSep 91\nOct 91\nNov 91\nDec 91";
			Name[8].text = "GDP";
			Name[9].text = "HDI";
			Name[10].text = "Deficit\nof goods";
			Name[11].text = "Growth of\neconomy";
		}
		else
		{
			Name[3].text += PlayerPrefs.GetString("VVP");
			Name[4].text += PlayerPrefs.GetString("IRCHP");
			Name[5].text += PlayerPrefs.GetString("SALARY");
			Name[6].text += PlayerPrefs.GetString("ROST");
		}
		if (GlobalScript.inst.gameState.data[0] == 1)
		{
			Name[8].text += "\n148%\n148%\n148%\n148%\n140%\n140%\n140%\n145%\n145%\n144%\n135%\n130%\n";
			Name[9].text += "\n100%\n100%\n100%\n99%\n99%\n99%\n99%\n99%\n99%\n99%\n100%\n100%\n";
			Name[10].text += "\n-1%\n-1%\n-1%\n0%\n0%\n1%\n1%\n1%\n1%\n1%\n0%\n0%\n";
			Name[11].text += "\n2.49%\n2.49%\n2.49%\n2.47%\n2.38%\n2.38%\n2.38%\n2.43%\n2.43%\n2.4%\n2.35%\n2.3%\n";
			Name[8].text += "121%\n107%\n103%\n99%\n91%\n83%\n-\n-\n-\n-\n-\n-\n";
			Name[9].text += "101%\n101%\n103%\n105%\n108%\n110%\n-\n-\n-\n-\n-\n-\n";
			Name[10].text += "0\n0%\n0%\n-1%\n-1%\n-5%\n-\n-\n-\n-\n-\n-\n";
			Name[11].text += "2.19%\n2.08%\n2.02%\n1.96%\n1.9%\n1.88%\n-\n-\n-\n-\n-\n-\n";
			Name[8].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[9].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[10].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[11].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
		}
		else if (GlobalScript.inst.gameState.data[0] == 5)
		{
			Name[8].text += "\n101%\n100%\n99%\n138%\n130%\n129%\n128%\n127%\n126%\n119%\n112%\n91%\n";
			Name[9].text += "\n55%\n53%\n51%\n49%\n47%\n45%\n43%\n41%\n39%\n37%\n32%\n27%\n";
			Name[10].text += "\n4%\n4%\n4%\n4%\n5%\n5%\n5%\n5%\n5%\n6%\n6%\n10%\n";
			Name[11].text += "\n1.52%\n1.49%\n1.46%\n1.83%\n1.72%\n1.69%\n1.66%\n1.63%\n1.6%\n1.5%\n1.39%\n1.08%\n";
			Name[8].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[9].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[10].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[11].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[8].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[9].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[10].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[11].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
		}
		else if (GlobalScript.inst.gameState.data[0] == 2)
		{
			Name[8].text += "\n131%\n131%\n131%\n131%\n131%\n131%\n131%\n136%\n136%\n136%\n136%\n136%\n";
			Name[9].text += "\n86%\n86%\n85%\n84%\n83%\n82%\n81%\n53%\n53%\n53%\n53%\n52%\n";
			Name[10].text += "\n0%\n0%\n0%\n0%\n0%\n0%\n0%\n-1%\n-1%\n-1%\n-3%\n-3%\n";
			Name[11].text += "\n2.22%\n2.17%\n2.17%\n2.16%\n2.14%\n2.13%\n2.12%\n2.19%\n2.19%\n2.19%\n2.19%\n2.19%\n";
			Name[8].text += "136%\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[9].text += "52%\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[10].text += "-5%\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[11].text += "2.22%\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[8].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[9].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[10].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[11].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
		}
		else
		{
			Name[8].text += "\n150%\n150%\n150%\n150%\n146%\n146%\n146%\n146%\n141%\n139%\n127%\n142%\n";
			Name[9].text += "\n100%\n100%\n100%\n100%\n100%\n100%\n99%\n99%\n99%\n100%\n100%\n98%\n";
			Name[10].text += "\n-1%\n-1%\n-2%\n-2%\n-1%\n0%\n0%\n0%\n0%\n0%\n0%\n3%\n";
			Name[11].text += "\n2.5%\n2.5%\n2.52%\n2.52%\n2.47%\n2.45%\n2.45%\n2.45%\n2.45%\n2.41%\n2.37%\n2.41%\n";
			Name[8].text += "151%\n137%\n117%\n68%\n66%\n64%\n-\n-\n-\n-\n-\n-\n";
			Name[9].text += "66%\n64%\n62%\n63%\n63%\n63%\n-\n-\n-\n-\n-\n-\n";
			Name[10].text += "7%\n7%\n7%\n8%\n8%\n9%\n-\n-\n-\n-\n-\n-\n";
			Name[11].text += "2.37%\n2.22%\n1.74%\n1.23%\n1.21%\n1.19%\n-\n-\n-\n-\n-\n-\n";
			Name[8].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[9].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[10].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
			Name[11].text += "-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n-\n";
		}
	}
}
