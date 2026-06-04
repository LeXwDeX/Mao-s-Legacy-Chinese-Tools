using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
	private GlobalScript global1;

	public new TextMesh name;

	public TextMesh text_t;

	public bool is_left;

	public bool is_right;

	public bool names;

	public EndingScript another_one;

	public int number_of_e;

	public SpriteRenderer fon;

	public Sprite fon_win;

	public string[] second_names = new string[41];

	public string[] first_names = new string[41];

	private string fake_text;

	public Sprite on_1;

	public Sprite off_1;

	private GameObject achieves;

	public GameObject scrollComponent;

	private float startTextPosition;

	private float startNamePosition;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		achieves = GameObject.Find("Ach(Clone)");
		startTextPosition = text_t.transform.position.y;
		startNamePosition = name.transform.position.y;
		DoneEnding();
	}

	private void OnMouseEnter()
	{
		if (is_left || is_right)
		{
			GetComponent<SpriteRenderer>().sprite = on_1;
		}
	}

	private void OnMouseExit()
	{
		if (is_left || is_right)
		{
			GetComponent<SpriteRenderer>().sprite = off_1;
		}
	}

	private void DoneEnding()
	{
		if (GlobalScript.inst.gameState.data[35] > 0)
		{
			if (is_left || is_right)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			BadEnding();
			Object.Destroy(GetComponent<EndingScript>());
		}
		else if (!is_left && !is_right)
		{
			ledaer_na();
			fon.sprite = fon_win;
			Check_Chekc_Check();
			GoodEnd();
			Object.Destroy(GetComponent<EndingScript>());
		}
	}

	private void GoodEnd()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (GlobalScript.inst.gameState.data[16] == 11 && GlobalScript.inst.gameState.data[14] <= 0 && GlobalScript.inst.gameState.data[54] <= 38 && GlobalScript.inst.gameState.science[26] && GlobalScript.inst.gameState.science[22] && GlobalScript.inst.gameState.data[71] >= 400 && GlobalScript.inst.gameState.data[72] >= 400 && GlobalScript.inst.gameState.data[4] <= 0 && GlobalScript.inst.gameState.politics_dolshnost[1] == 150 && GlobalScript.inst.gameState.politics_dolshnost[0] == 150)
			{
				name.text = "东方赛博朋克";
				fake_text = "主席" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "将被铭记为中国最伟大的领导人之一——他借助自动化的拱门，\n把国家引入黄金时代；即便号称无所不能的苏联也不敢冒险这样做。\n多名控制论专家的艰苦工作，以及数以百万计能够实施“中国大机器\n”的工人，使国家经济实现现代化。\n党内对这一做法的抵抗被彻底粉碎。\n那一项冒险的设想结出了惊人成果——腐败与赤字几乎被完全消除；\n每一名官员如今都置于冷静无情的电子控制之下，\n无法被贿赂、也无法被欺骗。\n但这场计算机化还没有结束——借助未来推行的电子护照与社会评分\n体系，社会终于清除了反革命与有害分子；\n几乎没有人偏离项目与计划的执行。\n可……机器如今无处不在，它们的权力还在扩张……\n而只有在领袖不幸早逝之后，党和人民似乎才逐渐明白——究竟是\n谁现在在控制一切……";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(60);
				}
			}
			else if (GlobalScript.inst.gameState.data[16] == 11 && GlobalScript.inst.gameState.data[26] <= 0 && GlobalScript.inst.gameState.data[15] <= 6 && GlobalScript.inst.gameState.data[17] >= 19 && GlobalScript.inst.gameState.data[51] >= 33)
			{
				name.text = "一脚踏进共产主义";
				fake_text = "没有民主就没有社会主义，没有社会主义就没有民主。\n我们长期努力在这两种观念之间寻找平衡，\n终于建成了真正的社会主义。\n得益于OGAS的引入，我们克服了赤字，\n并且希望能够永远保护我们的社会免于人类剥削、\n贫富不均以及生产过剩危机的复辟。\n一党民主有助于防止国家落入反革命势力之手，\n消除资产阶级议会争论，并把一切置于中共的控制之下。\n而言论自由与人民监督，则能防止中共及其个别成员滥用权力，\n从而为我们的制度提供必要的平衡。\n我们证明了社会最优结构是可以实现的；\n世界各地几十次失败的社会主义尝试并非徒劳。\n马克思的梦想实现了！";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(58);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] <= 2 && GlobalScript.inst.gameState.modifies[3].active && GlobalScript.inst.gameState.data[90] == 0 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[51].Torg)
			{
				name.text = "毛主义的堡垒";
				fake_text = "主席" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "并且政治局对国家的自信领导，确保中国忠实践行中国人民伟大解放\n者毛泽东主席的教导。\n所有反对力量要么被压制，要么被纳入控制，\n他们领导人的名字如今也早已被遗忘。\n我们走在伟大的道路上——走在伟大舵手为我们指引的道路上！\n至少，只要毛的思想得到人民支持、经济或多或少保持稳定。\n说实话，我们正越来越多地被指控侵犯人权——可又有谁在乎？\n数以百万计的人获得了自己的住房、免费教育与就业；\n多数人的福利在增长，虽然没有我们希望的那么快，\n但却是有把握、稳步推进的。\n中国已经成为一个受人尊敬的国家——而这本身就是一项重大的成就。";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(46);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] == 1 || GlobalScript.inst.gameState.data[14] == 2)
			{
				if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.data[14] == 1 && !GlobalScript.inst.gameState.modifies[6].active && GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.leader.traits[0] == 0)
				{
					achieves.GetComponent<achievements>().Set(1);
				}
				name.text = "面向世界开放……";
				fake_text = "同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "忠诚的党内成员带领国家沿着中国历史经验所指明的道路前进。\n这一次的标志，是开始偏离教条；中国向世界打开了大门——当然不\n是彻底敞开，但迈出了重要一步。\n终于，文化大革命宣告结束；在社会主义框架内进行谨慎改革，\n使我们能够纠正一切错误，并巩固在由毛泽东同志领导的岁月里取得\n的一切正确成果。对数以百万计的中国人而言，\n这段历史时期是中国最稳定、最繁荣的时期。\n尽管也有一些失误，但总体来看，这一路线证明是成功的；\n我们的领导人有时甚至被拿来与列宁相提并论——因为他能“过河”，\n并用脚去试探石头。";
				if (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 700)
				{
					fake_text = fake_text + "|我们恢复了同苏联的睦邻关系，并开始就苏中边界的新划界进行谈\n判。同志 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "对莫斯科进行了重要访问。\n在访问期间，他表示中国对苏联没有任何要求——无论是领土上的，\n还是意识形态上的。回程途中，他抵达珍宝岛，\n向在1969年冲突中牺牲的苏联边防军人的墓地鞠躬，\n并代表中国人民承诺：他将把苏中友谊的道路走到尽头。\n欧亚大陆上最大的两个国家仍在同一方向前进，\n但谁又知道接下来会发生什么呢……？";
				}
				if (GlobalScript.inst.gameState.allcountries[51].Torg && GlobalScript.inst.gameState.empires[0].relations >= 700)
				{
					fake_text += "|We were able to establish reliable relations with the United States. During a visit to Washington, comrade Leader said: \"It does not matter what ideological system prevails in China, which in the US. It is important that China and the US have common interests, and common interests imply cooperation\". We have signed many contracts with American companies, giving them access to our market. However, more and more party members believe that soon the \"socialist\" in China will only have its flag, and everything else will be a capitalist - because the penetration of American influence contribute to the liberalization of the minds of young people. But that's just stupid speculation, right?..";
				}
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(45);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] == 3)
			{
				name.text = "走向世界……";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "将作为中国历史上最杰出的领导人之一载入史册（至少官方宣传是这\n么说的）。我们启动了大规模经济改革，\n鼓励商业活动，并向外资开放机会，同时保护国内市场不至于因民族\n生产崩溃而被外资公司所主宰。\n不错，如今商业已与国家机器牢牢融合；\n而国家机器又不喜欢自由市场的拥护者，\n也不喜欢正统的共产主义者。\n至于思想解放，也没能在社会中走得太远：\n国家实行严格审查，反对力量也在控制之中——可这一切都是为了人\n民的利益，不是吗……？";
				if (GlobalScript.inst.gameState.allcountries[51].Torg)
				{
					fake_text += "|We 去了deepen cooperation with the United States, founded by Zhou Enlai, and opened free economic zones for investors from around the world. Thousands of foreign companies have transferred their enterprises to us, ensuring a boom in the growth of our economy! However, some party members say that \"in the free economic zones, only the socialist Chinese flags are developing over them, and everything else is capitalist\", and a significant share of income from FEZ goes abroad. Maybe the disgruntled party members are right?..";
				}
				else if (GlobalScript.inst.gameState.relres)
				{
					fake_text += "|我们不仅恢复了同苏联的睦邻关系，甚至加入了互助经济委员会。\n与社会主义国家的合作，使中国经济得以复苏，\n并变得更强、更发达；数百个项目已经落地，\n更多项目也正处于不同程度的准备之中。\n我们的专家从朋友那里学到了很多，因此“中国制造”不再等同于仿\n造，而成为全球范围内备受尊敬的高质量产品标志。";
					GlobalScript.inst.gameState.allcountries[1].isSEV = true;
				}
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(44);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] > 3)
			{
				name.text = "新的绝对";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "标志着中国历史上一段艰难时期——与沉重的过去彻底决裂，\n在新的基础上建设新中国；在生活各领域进行深刻而大规模的改革；\n转向民主的普遍价值；提出新的政治思维；\n实现思想与行动的全面解放。\n然而，并非人人都喜欢这样的行动。\n我们无法预知5年、10年、20年或50年后会发生什么——但我\n们的后代一定会记得：这段历史时期对中国而言，\n是一个决定性变革的时代，正因如此，许多事情都发生了改变……";
				if (GlobalScript.inst.gameState.allcountries[51].Torg)
				{
					fake_text = fake_text + "|美国对我们的改革给予了充分支持，先生 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " five times declared \"Man of the year\" according to various major publications and was nominated for the Nobel peace prize (though he could get it only before the resignation). We have opened our market to foreign firms, allowing them to participate in the privatization of state property. By joining globalization, we have provided our labor force to foreigners and opened free economic zones. However, this caused a number of unforeseen difficulties and provoked a wide discussion in society. Time will tell if we did the right thing...";
				}
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(42);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] == 0 && GlobalScript.inst.gameState.data[16] <= 13)
			{
				name.text = "朝鲜，但更大";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "而紧贴领袖身边的政治局成员的坚强领导，\n确保了中华人民共和国对缔造者教诲的忠诚。\n左右两方面的反对势力全部被粉碎，社会主义社会也得到了妥善保护，\n免遭外来间谍和人民的敌人侵害。\n他们把我们的时代拿来和三国、蒙古的专制统治以及汉代宦官的暴政\n相比，但这当然是夸张——在那些年代，\n人民的福利并没有像在我们这个时代这样大幅提高。\n然而，许多人说，我们的意识形态终于脱离了马克思主义，\n变成了一种带有威权色彩的中国式社会主义民族主义，\n但这只是猜测，对吧？";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(43);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] == 0 && GlobalScript.inst.gameState.data[16] >= 14)
			{
				name.text = "亚洲的皮诺切特";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "而他的坚强领导确保了中国在市场改革期间的稳定与繁荣。\n所有反对势力都被摧毁，我们党以铁腕之手引领中国走向光明的市场\n未来。然而，国际组织越来越指控我们侵犯人权，\n称压制自由、缺乏真正的民主，并指责在我们公民超负荷工作的企业\n中，私人商人的任意行事；由于工会运动遭到破坏，\n无法纠正这种局面。但只要有外国投资者和我们方面的支持在背后，\n就无所谓了，对吧？";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(41);
				}
			}
			if ((GlobalScript.inst.gameState.data[16] != 11 || GlobalScript.inst.gameState.data[14] > 0 || GlobalScript.inst.gameState.data[54] > 38 || !GlobalScript.inst.gameState.science[26] || !GlobalScript.inst.gameState.science[22] || GlobalScript.inst.gameState.data[71] < 400 || GlobalScript.inst.gameState.data[72] < 400 || GlobalScript.inst.gameState.data[4] > 0 || GlobalScript.inst.gameState.politics_dolshnost[1] != 150 || GlobalScript.inst.gameState.politics_dolshnost[0] != 150) && (GlobalScript.inst.gameState.data[16] != 11 || GlobalScript.inst.gameState.data[26] > 0 || GlobalScript.inst.gameState.data[15] > 6 || GlobalScript.inst.gameState.data[17] < 19 || GlobalScript.inst.gameState.data[51] < 33))
			{
				if (GlobalScript.inst.gameState.data[16] == 10)
				{
					fake_text += "\n\n We have fully restored the planned economy: all enterprises in the country belong to the state and work according to a single directive plan drawn up by the State Planning Committee. The concepts of unemployment and inequality have almost been forgotten, and crises of overproduction can be not mentioned at all. But instead of the problems inherent in a market economy, new ones may appear. Western economists say that without competition we are in danger of stagnation, and because of the inability to take into account all the needs of the population in time, the country will face a commodity deficit. In any case, we have proved that the planned economy is viable and that there is an alternative to the market economy.";
				}
				else if (GlobalScript.inst.gameState.data[16] == 11)
				{
					fake_text += "\n\n And finally, we have achieved what we sought for so long, something that not even the powerful Soviet Union dared to achieve. We have achieved automatic economic planning almost everywhere, thanks to which we can always deal with the corruption and deficit. However, due to the current limitations of computers, the system still works with some errors and problems and is being held back by the bureaucrats and their attacks all the time on all levels of the government, and some are even saying that this system has its task to create “electronic fascism”. But we are starting to deal with the fundamental problems of a planned economy, making one important step toward Communism.";
				}
				else if (GlobalScript.inst.gameState.data[16] == 12)
				{
					fake_text += "\n\n Not deviating far from the policies of Zhou Enlai, we have managed to create a good and working economy. Although we left our Agriculture free, all production facilities still belong to the Government and only some of them are starting to work by the principle of cost accounting. The private traders are helping to overcome the deficit, and cost accounting id helping very much to increase the rentability of production. However, the conservative wing of the party is lobbying for not tolerating such «capitalist-roadings», and the people want more economic freedom. It seems that we are stuck in a transition phase from Capitalism to Socialism, and it is impossible to know in which direction will we will move afterwards. ";
				}
				else if (GlobalScript.inst.gameState.data[16] == 13)
				{
					fake_text += "\n\n The ideas of Chen Yun have triumphed. Because of the economic reforms, we have given our citizens the opportunity to become private traders and have open channels for foreign investments into China, and a strict government control ensures that there will be no collapse of national production facilities, no monopolies of companies or domination of foreign companies. However, now the business has become one with the government apparatus, which is not liked by either the free market supporters or by orthodox Communists. But we have create an economy that has the advantages of Communism and Capitalism, and the disadvantages of both systems are there too, it seems. Too much depends on the investment climate and the development of global production, the crises of which can affect us.";
				}
				else if (GlobalScript.inst.gameState.data[16] == 14)
				{
					fake_text += "\n\n With the aid of wide reforms we have built a controllable market economy, having kept the national production, and having reached a compromise between business and social structures. Thanks to the social orientation of the economy, we have competition and market freedom, and the population is protected from some of the disadvantages of a market economy and from the criminal elements of the market. Maybe this system can’t completely eradicate inflation, unemployment and the gap between the rich and the poor, and the government control is limiting our access to new markets and is stalling the development of business, but we have come to what most European counties have now.";
				}
				else if (GlobalScript.inst.gameState.data[16] == 15)
				{
					fake_text += "\n\n In just a few years we have been able to move from state planning to a free and low-regulated market. Economic and trade liberalisation has triumphed across China, and we are now consistently ranked among the countries with the most favourable investment climate. And even if analysts and the opposition complain that the privatisation of state property was \"unfair\" and predict that the lack of regulation will cause much of the privatised production to decline and our economy to be controlled by entrenched private monopolies, the market will prove them wrong, won't it?";
				}
			}
		}
		else
		{
			if (GlobalScript.inst.gameState.data[16] == 11 && GlobalScript.inst.gameState.data[14] <= 0 && GlobalScript.inst.gameState.data[54] <= 38 && GlobalScript.inst.gameState.science[26] && GlobalScript.inst.gameState.science[22] && GlobalScript.inst.gameState.data[71] >= 400 && GlobalScript.inst.gameState.data[72] >= 400 && GlobalScript.inst.gameState.data[4] <= 0 && GlobalScript.inst.gameState.politics_dolshnost[1] == 150 && GlobalScript.inst.gameState.politics_dolshnost[0] == 150)
			{
				name.text = "Восточный киберпанк";
				fake_text = "Председатель " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " запомнится как один из величайших руководителей Китая, который ввел страну в золотой век через арку автоматизации - на что не рискнул даже всемогущий Советский Союз. Благодаря упорному труду десятков кибернетиков и миллионов рабочих, которые смогли претворить в жизнь Великую Китайскую Машину - экономика страны была модернизирована. Сопротивление партократии против нее было сломлено. Рискованная идея дала великие результаты - была почти полностью побеждены коррупция и дефицит, каждый чиновник теперь находиться под бесстрастным электронным контролем, который невозможно подкупить или обмануть. Но на этом компьютеризация не закончилась - благодаря внедрению в будущем электронных паспортов и системы социального рейтинга, общество окончательно отчистилось от контрреволюционных и вредительских элементов, почти никто не отходит от программы и выполнения плана. Но... машины теперь повсюду, а их полномочия расширяются... И лишь только после безвременной кончины Лидера, партия и народ, кажется, постепенно начинают понимать - кто на самом деле теперь управляет всем...";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(60);
				}
			}
			else if (GlobalScript.inst.gameState.data[16] == 11 && GlobalScript.inst.gameState.data[26] <= 0 && GlobalScript.inst.gameState.data[15] <= 6 && GlobalScript.inst.gameState.data[17] >= 19 && GlobalScript.inst.gameState.data[51] >= 33)
			{
				name.text = "Одной ногой в коммунизм";
				fake_text = "Без демократии нет и социализма, без социализма нет и демократии. Мы долго пытались найти баланс между этими понятиями и, наконец, смогли, построив настоящий социализм. Благодаря внедрению ОГАС мы победили дефицит и, будем надеться, навсегда защитили наше общество от реставрации эксплуатации человека человеком, неравенства и кризисов перепроизводства. Однопартийная демократия позволяет уберечь страну от попадания во власть контрреволюционных элементов, ликвидировав буржуазную парламентскую дискуссию и поставив все под контроль КПК. А свобода слова и народный контроль защищают от злоупотребления властью КПК и отдельных её членов, тем самым придав нашей системе необходимый баланс. Мы доказали, что лучшее устройство общества возможно, а десятки неудавшихся попыток построить социализм по всему миру были не напрасными. Мечта Маркса осуществилась!";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(58);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] <= 2 && GlobalScript.inst.gameState.modifies[3].active && GlobalScript.inst.gameState.data[90] == 0 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[51].Torg)
			{
				name.text = "Оплот маоизма";
				fake_text = "Председатель " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " и проводимое Политбюро уверенное руководство страной обеспечили верность Китая заветам великого освободителя китайского народа, Председателя Мао Цзэдуна. Вся оппозиция была частью подавлена, частью взята под контроль, имена их вождей отныне забыты. Мы идем великой дорогой - дорогой, которую указал нам Великий Кормчий! По крайней мере, до тех пор, пока идеи Мао находят поддержку в народе, а экономика работает более-менее стабильно. Правда, нас все чаще обвиняют в нарушении прав человека - но кого это волнует? Миллионы людей получили собственное жилье, бесплатное образование, трудоустройство, благосостояние большинства растет, пусть и не так быстро, как хотелось бы, но уверенно и неуклонно. Китай, впервые со времен Цинь Шихуанди, стал уважаемой страной - и уже это является значительным достижением, которое точно будет вписано в историю.";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(46);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] == 1 || GlobalScript.inst.gameState.data[14] == 2)
			{
				if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.data[14] == 1 && !GlobalScript.inst.gameState.modifies[6].active && GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.leader.traits[0] == 0)
				{
					achieves.GetComponent<achievements>().Set(1);
				}
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(45);
				}
				name.text = "Открываясь миру...";
				fake_text = "Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " и верные партийцы провели страну по пути, который был указан самим опытом истории Китая. Это время ознаменовалось началом отхода от ортодоксии, а Китай приоткрыл свои двери для мира - не до конца, разумеется, но весьма сильно. Была, наконец, завершена Культурная революция, проведены осторожные реформы в рамках социализма, которые позволили выправить все неправильное и закрепить все правильное, достигнутое за годы, когда нашей страной руководил товарищ Мао Цзэдун. Для миллионов китайцев этот период в истории Китая стал временем его наибольшей стабильности и процветания. Хотя и были допущены определенные ошибки, но в целом этот курс оказался успешным, а нашего руководителя иногда сравнивают с самим Лениным, ибо он смог пройти вброд, нащупав ногами камни - и провести по нему страну, приумножив её богатство.";
				if (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 700)
				{
					fake_text = fake_text + "|Мы восстановили добрососедские отношения с СССР и начали переговоры о новой демаркации советско-китайской границы. Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " совершил важный визит в Москву, в ходе которого заявил о том, что Китай не имеет к Советскому Союзу никаких претензий - ни территориальных, ни идеологических. На обратном пути, он прибыл на остров Даманский и поклонился могилам советских пограничников, погибших в ходе конфликта 1969 года, пообещав от имени китайского народа, что будет до конца следовать курсом советско-китайской дружбы. Две крупнейшие страны Евразии пока что движутся в едином направлении, но кто знает, что может произойти впредь?..";
				}
				if (GlobalScript.inst.gameState.allcountries[51].Torg && GlobalScript.inst.gameState.empires[0].relations >= 700)
				{
					fake_text += "|Мы смогли добиться установления надежных отношений с США. В ходе визита в Вашингтон, товарищ Руководитель заявил: \"Совершенно неважно, какая идеологическая система господствует в Китае, какая в США. Важно то, что у Китая и США есть общие интересы, а общие интересы подразумевают сотрудничество\". Мы заключили множество договоров с американскими компаниями, дав им доступ к нашему рынку. Правда, все больше и больше партийцев считают, что скоро \"социалистическим\" в Китае останется только его флаг, а все остальное станет капиталистическим - ведь проникновение американского влияния подстегивает либерализацию умов молодежи. Но это только глупые домыслы, верно?..";
				}
			}
			else if (GlobalScript.inst.gameState.data[14] == 3)
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(44);
				}
				name.text = "Навстречу всему миру...";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " останется в истории Китая, как один из самых выдающихся руководителей за всю историю страны (или, по крайней мере, так заявляет наша официальная пропаганда). Были развернуты широкомасштабные экономические реформы, поощрена предпринимательская деятельность и открыты возможности для поступления в Китай иностранных инвестиций, при этом удалось защитить отечественный рынок от развала национального производства и доминирования иностранных компаний. Правда, теперь бизнес крепко сросся с государственным аппаратом, что, в свою очередь, не нравится ни сторонникам свободного рынка, ни ортодоксальным коммунистам, да и либерализация умов не смогла далеко продвинуться в обществе: в стране присутствует жесткая цензура, а оппозиция находится под контролем, но ведь это всё мы делаем на благо народа, верно?..";
				if (GlobalScript.inst.gameState.allcountries[51].Torg)
				{
					fake_text += "|Мы пошли на углубление сотрудничества с США, заложенного ещё Чжоу Эньлаем, и открыли свободные экономические зоны для инвесторов со всего мира. Тысячи иностранных фирм перенесли к нам свои предприятия, обеспечив бум роста нашей экономики! Однако некоторые партийцы говорят, что \"в свободных экономических зонах социалистические только развивающиеся над ними китайские флаги, а все остальное - капиталистическое\", а значительная доля доходов от СЭЗ уходит за границу. Может, недовольные партийцы и правы?..";
				}
				else if (GlobalScript.inst.gameState.relres)
				{
					fake_text += "|Мы не просто восстановили добрососедские отношения с СССР, но и даже вошли в Совет Экономической взаимопомощи. Кооперация с социалистическими странами позволила оживить экономику Китая и сделать её мощнее и более развитой, уже реализованы сотни проектов, ещё больше сейчас в различной степени готовности. Наши специалисты очень многому научились у наших друзей, поэтому Made in China перестало быть синонимом подделки, а стало уважаемым во всем мире знаком продукции вполне высокого качества.";
					GlobalScript.inst.gameState.allcountries[1].isSEV = true;
				}
			}
			else if (GlobalScript.inst.gameState.data[14] > 3)
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(42);
				}
				name.text = "Новые абсолюты";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " ознаменовал в истории Китая непростой период - период решительного разрыва с тяжким прошлым, строительства нового Китая на новых основаниях, глубоких и масштабных реформ во всех отраслях жизни, перехода к демократическим общечеловеческим ценностям, новому политическому мышлению, полному раскрепощению сознания и действий. Однако такие действия понравились далеко не всем. Мы не можем знать, что произойдет через 5, 10, 20 или 50 лет - но наши потомки наверняка вспомнят, что именно этот период истории стал для Китая эпохой решительных перемен, благодаря которым многое изменилось...";
				if (GlobalScript.inst.gameState.allcountries[51].Torg)
				{
					fake_text = fake_text + "|Соединенные Штаты полностью поддержали наши реформы, господин " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " пять раз объявлялся \"Человеком года\" по версии различных крупных изданий и был номинирован на Нобелевскую премию мира (правда, получить её он смог только перед самой отставкой). Мы открыли свой рынок для иностранных фирм, позволив им участвовать в приватизации государственной собственности. Включившись в глобализацию, мы предоставили свою рабочую силу иностранцам и открыли свободные экономические зоны. Правда, это вызвало целый ряд непредвиденных сложностей и спровоцировало широкую дискуссию в обществе. Время покажет, все ли мы сделали правильно...";
				}
			}
			else if (GlobalScript.inst.gameState.data[14] == 0 && GlobalScript.inst.gameState.data[16] <= 13)
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(43);
				}
				name.text = "КНДР, но побольше";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " и твёрдое руководство наиболее близких к особе руководителя членов Политбюро обеспечили верность КНР заветам её основателей. Вся левая и правая оппозиция была разгромлена, а социалистическое общество надёжно защищено от иностранных шпионов и врагов народа. Они сравнивают нашу эпоху с Троецарствием, диктатурой монголов и деспотией евнухов при династии Хань, но это, конечно, приувеличение - во все эти времена благосостояние населения не выросло настолько, насколько оно поднялось за нашу эпоху. Впрочем, многие говорят, что наша идеология уже окончательно отделилась от марксизма и превратилась в этакий китайский социалистический национализм с авторитарным оттенком, но это же домыслы, так?";
			}
			else if (GlobalScript.inst.gameState.data[14] == 0 && GlobalScript.inst.gameState.data[16] >= 14)
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(41);
				}
				name.text = "Азиатский Пиночет";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " и его твёрдое руководство обеспечили Китаю стабильность и процветание во время рыночных реформ. Вся оппозиция была уничтожена, а наша партия твёрдой рукой ведёт Китай в светлое рыночное будущее. Впрочем международные организации всё чаще обвиняют нас в нарушении прав человека, заявляя о притеснении свободы, отсутствии реальной демократии и произволе частников на предприятиях, где наши граждане работают сверх нормы, не имея возможности выправить положение из-за уничтоженного профсоюзного движения. Но пока за нашей спиной иностранные инвесторы и поддержка США - это ведь не имеет значения?";
			}
			if ((GlobalScript.inst.gameState.data[16] != 11 || GlobalScript.inst.gameState.data[14] > 0 || GlobalScript.inst.gameState.data[54] > 38 || !GlobalScript.inst.gameState.science[26] || !GlobalScript.inst.gameState.science[22] || GlobalScript.inst.gameState.data[71] < 400 || GlobalScript.inst.gameState.data[72] < 400 || GlobalScript.inst.gameState.data[4] > 0 || GlobalScript.inst.gameState.politics_dolshnost[1] != 150 || GlobalScript.inst.gameState.politics_dolshnost[0] != 150) && (GlobalScript.inst.gameState.data[16] != 11 || GlobalScript.inst.gameState.data[26] > 0 || GlobalScript.inst.gameState.data[15] > 6 || GlobalScript.inst.gameState.data[17] < 19 || GlobalScript.inst.gameState.data[51] < 33))
			{
				if (GlobalScript.inst.gameState.data[16] == 10)
				{
					fake_text += "\n\n Мы в полном объёме восстановили деятельность плановой экономики: все предприятия в стране принадлежат государству и работают по единому директивному плану, который составляет Госплан. Уже почти забыты такие понятия, как безработица и неравенство, а о кризисах перепроизводства можно и вообще не вспоминать. Вот только вместо проблем, присущих рыночной экономике, могут появиться новые. Западные экономисты говорят, что без конкуренции нам грозит застой, а из-за невозможности вовремя учитывать все потребности населения в стране начнётся товарный дефицит. В любом случае мы доказали, что плановая экономика жизнеспособна, а альтернатива рыночной экономике существует.";
				}
				else if (GlobalScript.inst.gameState.data[16] == 12)
				{
					fake_text += "\n\n Не сильно отходя от экономической политики покойного Чжоу Эньлая, мы смогли создать хорошую и работоспособную экономику. Хоть мы и оставили сельское хозяйство на свободной основе, все предприятия все ещё принадлежит государству, хотя некоторые из них и начали работать по хозрасчету. Частники помогают в борьбе с дефицитом, а хозрасчет значительно повышает рентабельность производства. Однако консервативная часть партии требует отказаться от подобного каппутизма, а народ при этом хочет ещё больше экономических свобод. Кажется, мы надолго застряли в переходной стадии от капитализма к социализму, и неизвестно, в какую же сторону мы двинемся дальше.";
				}
				else if (GlobalScript.inst.gameState.data[16] == 11)
				{
					fake_text += "\n\n И вот, мы совершили то, на что не рискнул даже всемогущий Советский Союз. Добились почти повсеместного автоматизированного экономического планирования, благодаря чему мы вскоре сможем справиться с коррупцией и дефицитом. Правда, система из-за несовершенства современных компьютеров всё ещё работает с перебоями и натыкается на постоянное сопротивление и диверсии бюрократии на всех уровнях управления, а злые языки утверждают, что данная система имеет целью установление \"электронного фашизма\". Но все же мы постепенно начинаем справляться с фундаментальными проблемами плановой экономики, сделав тем самым еще один важный шаг к коммунизму.";
				}
				else if (GlobalScript.inst.gameState.data[16] == 13)
				{
					fake_text += "\n\n Идеи Чэнь Юня восторжествовали. Благодаря экономическим реформам, мы дали нашим гражданам возможность вести предпринимательскую деятельность и открыли каналы для поступления в Китай иностранных инвестиций, при этом жесткий государственный контроль надежно защищает отечественный рынок от развала национального производства, доминирования иностранных компаний и образования частных монополий. Правда, теперь бизнес крепко сросся с государственным аппаратом, что, в свою очередь, не нравится ни сторонникам свободного рынка, ни ортодоксальным коммунистам. Зато мы построили экономику, совмещающую плюсы капитализма и социализма, правда, минусы она, кажется, совмещает тоже. Слишком многое теперь зависит от благоприятного инвестиционного климата и развития глобального производства, кризисы которых смогут воздействовать на нас…";
				}
				else if (GlobalScript.inst.gameState.data[16] == 14)
				{
					fake_text += "\n\n С помощью широкомасштабных реформ мы смогли построить управляемую рыночную экономику, сохранив национальное производство, а также добились компромисса между бизнесом и общественными структурами. Благодаря социальной ориентированности экономики, у нас сохраняется конкуренция и рыночная свобода, при этом население защищено от не добросовестных участников рынка и некоторых отрицательных последствий рыночной экономики. Может, такая система и не сможет полностью искоренить инфляцию, безработицу, разрыв между богатыми и бедными, а государственный контроль мешает развитию бизнеса и затрудняет выход на новые рынки, зато мы пришли к тому же, к чему и большинство европейских стран в наши дни.";
				}
				else if (GlobalScript.inst.gameState.data[16] == 15)
				{
					fake_text += "\n\n Всего за несколько лет мы смогли перейти от государственного планирования к свободному и слаборегулируемому рынку. Либерализация экономики и торговли восторжествовала по всему Китаю, а мы теперь стабильно входим в рейтинги стран с самым благоприятным инвестиционным климатом. И пусть аналитики и оппозиция жалуются на то, что приватизация государственной собственности была «несправедливой», и предрекают, что из-за отсутствия регулирования большая часть приватизированного производства придёт в упадок, а нашу экономику начнут контролировать окрепшие частные монополии, но ведь рынок докажет им обратное, верно?";
				}
			}
		}
		text_t.text = Text(fake_text, 83);
	}

	private void Check_Chekc_Check()
	{
		if (!GlobalScript.inst.gameState.iron_and_blood)
		{
			return;
		}
		if (GlobalScript.inst.dlc[0])
		{
			if (GlobalScript.inst.gameState.gamerules[8] == 1)
			{
				achieves.GetComponent<achievements>().Set(165);
			}
			else if (GlobalScript.inst.gameState.gamerules[8] == 2)
			{
				achieves.GetComponent<achievements>().Set(166);
			}
			else if (GlobalScript.inst.gameState.gamerules[8] == 3)
			{
				achieves.GetComponent<achievements>().Set(167);
			}
			if (GlobalScript.inst.gameState.gamerules[6] == 1)
			{
				achieves.GetComponent<achievements>().Set(168);
			}
			if (GlobalScript.inst.gameState.gamerules[8] == 2 && GlobalScript.inst.gameState.diff == 4 && GlobalScript.inst.gameState.gamerules[6] == 1)
			{
				achieves.GetComponent<achievements>().Set(169);
			}
		}
		if (GlobalScript.inst.gameState.data[5] < 100 && GlobalScript.inst.gameState.influencePRC < 50 && GlobalScript.inst.gameState.data[14] >= 5 && GlobalScript.inst.gameState.data[67] > 0 && GlobalScript.inst.gameState.data[66] > 0 && GlobalScript.inst.gameState.data[65] <= 0 && GlobalScript.inst.gameState.data[62] <= 0)
		{
			achieves.GetComponent<achievements>().Set(56);
		}
		if (GlobalScript.inst.gameState.allcountries[9].proprc && GlobalScript.inst.gameState.allcountries[32].proprc && GlobalScript.inst.gameState.allcountries[19].proprc && GlobalScript.inst.gameState.allcountries[12].proprc && GlobalScript.inst.gameState.allcountries[31].proprc && GlobalScript.inst.gameState.allcountries[8].proprc && GlobalScript.inst.gameState.allcountries[14].proprc && GlobalScript.inst.gameState.allcountries[37].proprc && GlobalScript.inst.gameState.allcountries[30].proprc)
		{
			achieves.GetComponent<achievements>().Set(110);
		}
		if (GlobalScript.inst.gameState.allcountries[14].proprc)
		{
			achieves.GetComponent<achievements>().Set(64);
		}
		if (GlobalScript.inst.gameState.checking[0] && GlobalScript.inst.gameState.checking[1] && GlobalScript.inst.gameState.checking[2] && GlobalScript.inst.gameState.checking[3] && GlobalScript.inst.gameState.checking[4])
		{
			achieves.GetComponent<achievements>().Set(111);
		}
		if (GlobalScript.inst.gameState.influencePRC <= 1 && GlobalScript.inst.gameState.modifies[16].active && GlobalScript.inst.gameState.modifies[17].active && GlobalScript.inst.gameState.modifies[12].active && GlobalScript.inst.gameState.modifies[0].active && GlobalScript.inst.gameState.modifies[1].active && GlobalScript.inst.gameState.modifies[15].active)
		{
			achieves.GetComponent<achievements>().Set(57);
		}
		if (GlobalScript.inst.gameState.data[5] > 800 && GlobalScript.inst.gameState.allcountries[51].Torg && GlobalScript.inst.gameState.data[14] >= 5 && GlobalScript.inst.gameState.leader.name_1 == 15 && GlobalScript.inst.gameState.leader.name_2 == 15)
		{
			achieves.GetComponent<achievements>().Set(59);
		}
		if (GlobalScript.inst.gameState.diff == 3)
		{
			achieves.GetComponent<achievements>().Set(52);
		}
		else if (GlobalScript.inst.gameState.diff == 4)
		{
			achieves.GetComponent<achievements>().Set(53);
		}
		if ((GlobalScript.inst.gameState.data[60] == 0 || GlobalScript.inst.gameState.data[60] == 3) && GlobalScript.inst.gameState.allcountries[20].proprc && GlobalScript.inst.gameState.allcountries[23].proprc && GlobalScript.inst.gameState.allcountries[23].Gosstroy == 0)
		{
			achieves.GetComponent<achievements>().Set(2);
		}
		if (GlobalScript.inst.gameState.politics_dolshnost[0] < 18 && GlobalScript.inst.gameState.politics_dolshnost[1] < 18 && GlobalScript.inst.gameState.politics_dolshnost[2] < 18 && GlobalScript.inst.gameState.leader.traits[0] == 3 && GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[0]].traits[0] == 3 && GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[1]].traits[0] == 3 && GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[3]].traits[0] == 3)
		{
			achieves.GetComponent<achievements>().Set(20);
		}
		int num = 0;
		Politic[] politics = GlobalScript.inst.gameState.politics;
		foreach (Politic politic in politics)
		{
			if (politic != null && politic.traits[0] == 0 && (((politic.name_1 == 0) & (politic.name_2 == 0)) || ((politic.name_1 == 3) & (politic.name_2 == 3)) || (politic.name_1 == 4 && politic.name_2 == 4) || (politic.name_1 == 5 && politic.name_2 == 5)))
			{
				num++;
			}
		}
		if (num >= 4)
		{
			achieves.GetComponent<achievements>().Set(3);
		}
		if (GlobalScript.inst.gameState.leader.name_1 == 2 && GlobalScript.inst.gameState.leader.name_2 == 2)
		{
			int num2 = 0;
			politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic2 in politics)
			{
				if (politic2 != null && politic2.traits[0] == 0 && (((politic2.name_1 == 6) & (politic2.name_2 == 6)) || ((politic2.name_1 == 9) & (politic2.name_2 == 9)) || (politic2.name_1 == 10 && politic2.name_2 == 10) || (politic2.name_1 == 11 && politic2.name_2 == 11)))
				{
					num2++;
				}
			}
			if (num2 >= 4)
			{
				achieves.GetComponent<achievements>().Set(4);
			}
		}
		bool flag = true;
		for (int j = 0; j < 7; j++)
		{
			if (GlobalScript.inst.gameState.ingamewars[j] != null && GlobalScript.inst.gameState.ingamewars[j].fortnight_go == 0 && GlobalScript.inst.gameState.ingamewars[j].infl1 == 0 && GlobalScript.inst.gameState.ingamewars[j].infl2 == 0 && !GlobalScript.inst.gameState.ingamewars[j].is_going)
			{
				flag = false;
				break;
			}
		}
		if (GlobalScript.inst.gameState.data[112] >= 2)
		{
			achieves.GetComponent<achievements>().Set(27);
		}
		if (flag && GlobalScript.inst.gameState.data[51] == 30 && GlobalScript.inst.gameState.data[12] >= 950)
		{
			achieves.GetComponent<achievements>().Set(29);
		}
		if (GlobalScript.inst.gameState.modifies[11].active && GlobalScript.inst.gameState.modifies[17].active && GlobalScript.inst.gameState.modifies[16].active)
		{
			achieves.GetComponent<achievements>().Set(12);
		}
		bool flag2 = true;
		bool flag3 = true;
		int num3 = 0;
		bool flag4 = true;
		for (int k = 0; k < GlobalScript.inst.gameState.allcountries.Length; k++)
		{
			if (GlobalScript.inst.gameState.allcountries[k] == null)
			{
				continue;
			}
			if (k >= 53 && k < 69)
			{
				if (!GlobalScript.inst.gameState.allcountries[k].proprc)
				{
					flag2 = false;
				}
			}
			else if (k >= 71 && k <= 83 && k != 78 && !GlobalScript.inst.gameState.allcountries[k].proprc)
			{
				flag4 = false;
			}
			if (GlobalScript.inst.gameState.allcountries[k].proprc && k != 1)
			{
				flag3 = false;
			}
			if (GlobalScript.inst.gameState.allcountries[k].econ && GlobalScript.inst.gameState.allcountries[k].okb && k != 1)
			{
				num3++;
			}
		}
		if (flag3 && !GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.modifies[17].active && GlobalScript.inst.gameState.modifies[16].active)
		{
			achieves.GetComponent<achievements>().Set(32);
		}
		if (flag4)
		{
			achieves.GetComponent<achievements>().Set(86);
			if (!GlobalScript.inst.gameState.rev_done)
			{
				achieves.GetComponent<achievements>().Set(87);
			}
		}
		if (flag2)
		{
			achieves.GetComponent<achievements>().Set(14);
		}
		if (num3 >= 14)
		{
			achieves.GetComponent<achievements>().Set(68);
		}
		if (num3 >= 8)
		{
			achieves.GetComponent<achievements>().Set(67);
		}
		if (GlobalScript.inst.gameState.allcountries[2].proprc && GlobalScript.inst.gameState.allcountries[20].proprc && GlobalScript.inst.gameState.allcountries[5].proprc)
		{
			achieves.GetComponent<achievements>().Set(19);
		}
		bool flag5 = true;
		for (int l = 0; l < GlobalScript.inst.gameState.politics_dolshnost.Length; l++)
		{
			if (GlobalScript.inst.gameState.politics_dolshnost[l] < 18 && GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[l]] != null && GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[l]].traits[0] != 3)
			{
				flag5 = false;
				break;
			}
		}
		if (flag5)
		{
			achieves.GetComponent<achievements>().Set(20);
		}
		if (GlobalScript.inst.gameState.modifies[3].active)
		{
			achieves.GetComponent<achievements>().Set(30);
		}
		if (GlobalScript.inst.gameState.modifies[7].active)
		{
			achieves.GetComponent<achievements>().Set(7);
		}
	}

	private void OnMouseDown()
	{
		if (is_left)
		{
			number_of_e--;
			if (number_of_e < 0)
			{
				number_of_e = 7;
			}
		}
		else if (is_right)
		{
			number_of_e++;
			if (number_of_e > 7)
			{
				number_of_e = 0;
			}
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (number_of_e == 0)
			{
				GoodEnd();
			}
			else if (number_of_e == 1)
			{
				if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.data[66] == 0 && GlobalScript.inst.gameState.data[67] == 0 && GlobalScript.inst.gameState.data[65] > 0 && GlobalScript.inst.gameState.data[62] == 2)
				{
					achieves.GetComponent<achievements>().Set(8);
				}
				name.text = "旧领土";
				if (GlobalScript.inst.gameState.allcountries[70].numberOfSpecialEnding < 0)
				{
					if (GlobalScript.inst.gameState.data[66] <= 0)
					{
						fake_text = "尽管我们的对手煽动分裂情绪，新疆维吾尔自治区仍然是中国不可分\n割的一部分。然而，地区局势仍在掌控之中，\n主管部门运转如预期；国家安全部与新疆生产建设兵团成功阻止了任\n何组织“新疆脱离中国”的严重分裂运动的企图。";
					}
					else if (GlobalScript.inst.gameState.data[66] == 1)
					{
						fake_text = "The USSR-supported Xinjiang separatists were able, however, taking advantage of our problems, to seize power in the region and achieve independence from China. However, \"independence\" was quickly replaced by total dependence on the Soviet Union - the leadership of the East-Turkestan People's Republic is formed in coordination with Moscow, the army is commanded by Soviet officers, and the economy is under the full control of advisers from the Union. All parties, except the Communist Party of East Turkestan, are prohibited. De facto, Xinjiang became a \"non-aligned republic\" of the USSR on the model of Bulgaria and Mongolia...";
					}
					else if (GlobalScript.inst.gameState.data[66] == 2)
					{
						fake_text = "然而，在我们出现问题之际，新疆分裂分子得以趁机夺取地区政权，\n实现了对中国的“独立”。\n正如所料，在与我们企业合作中断之后，\n地区经济崩溃；而新疆共和国领导层试图在我们、\n苏联和美国之间寻求平衡，反而把它变成地缘政治争夺的战场。\n上层社会与重新崛起的资产阶级沉浸在奢华之中，\n挥霍来自超级大国的美元、卢布和人民币；\n而新疆人民则生活在极端贫困中，因此伊斯兰主义情绪愈发流行……";
					}
				}
				if (GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding < 0 || GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding > 10)
				{
					if (GlobalScript.inst.gameState.data[67] <= 0)
					{
						fake_text += "||The Tibet Autonomous Region continues to be an integral part of China, despite the disruptive propaganda of supporters of the Dalai Lama and part of the local clergy who fled abroad. Huge funds are being spent on the economic development of the region, called upon to \"bind\" it more tightly to the rest of the country, on the other hand, we do not weaken the control over the clergy and resolutely stop any attempts to organize a serious separatist movement for the withdrawal of Tibet from China.";
					}
					else
					{
						fake_text += "||Tibetan separatists were able, taking advantage of our problems, to seize power in the region and achieve independence from China. 14th Dalai Lama solemnly returned to Lhasa, where he made a solemn speech, exposing us and rejoicing \"the end of the Chinese occupation of free Tibet\". However, not everything is so rosy in the \"free Tibet\" - with a break in cooperation with our enterprises, the district’s economy has actually collapsed, the population has to literally survive cattle breeding and the collection of medicinal herbs, and India is already starting to raise a long-standing territorial dispute over 阿鲁纳恰尔邦 and requires revision \"McMahon Line\" in their favor...";
					}
				}
				if (!GlobalScript.inst.gameState.completedDecisions[6] && !GlobalScript.inst.gameState.completedDecisions[7])
				{
					if (GlobalScript.inst.gameState.allcountries[38].dev > 0)
					{
						fake_text = fake_text + "||Taiwanese separatists hid behind the backs of their American friends, but they overestimated their defenders and underestimated our determination to reunite our homeland. The landing force recaptured the border islands off the coast of Taiwan and drove the separatists out of there, restoring our sovereignty over this territory. \"The territory of China is one and indivisible!\" - answered the 主席" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "面对帝国主义的愤怒叫嚣。\n不错，我们自己由于岛上存在美国军事基地，\n短期内也无法收复台湾本岛；而且在此之后当然也不会去谈判……";
					}
					else if ((GlobalScript.inst.gameState.allcountries[38].proprc && GlobalScript.inst.gameState.data[6] < 700 && GlobalScript.inst.gameState.data[16] >= 13 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.modifies[17].active) || GlobalScript.inst.gameState.completedDecisions[6])
					{
						fake_text = fake_text + "||同志 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " put forward an important theory \"One country - two systems\", according to which Taiwan, Hong Kong and Macau can return to the bosom of the motherland while maintaining their political and economic system for 50 years in advance and very broad autonomy. The leadership of Taiwan for a very long time refused any negotiations with us, but, finally, we managed to put them at a round table and come to an agreement. In exchange for the formal recognition by the PRC of the independence of the Republic of China and its rejection of claims to the coastal islands, Taiwan officially renounces \"Three Principles of the People\" and recognizes the policy \"One country - two systems\". Negotiations have already begun on the basic principles for the reunification of Taiwan with China (the conditions will be clearly confederate or even broader) and on the withdrawal of American military bases from the island, but the final reunification of the homeland will not happen soon...";
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(66);
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[38].proprc || GlobalScript.inst.gameState.allcountries[38].Torg)
					{
						fake_text = fake_text + "||同志 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "，尽管许多保守派和强硬派进行了激烈抵制，\n他仍然作出坚决的意志决定：承认台湾独立，\n并结束近半个世纪的敌对。\n按照中国外交的新方针，台湾独立的时间太久了，\n在那段时间里，它在文化、经济和政治上都逐渐远离大陆，\n并与世界共同体建立了过于紧密的联系，\n因此再谈它属于中华人民共和国已不现实。\n双方宣布将制定全新的、睦邻关系的原则：\n中华人民共和国与“中华民国”之间建立全新原则；\n而“中华民国”方面也相应放弃对大陆的主张。";
					}
					else
					{
						fake_text += "||The separatist \"Republic of China\" continues to hold Taiwan and the coastal islands, relying on US military support and flatly refusing to normalize relations with mainland China. We can only sigh and send the invaders \"last Chinese warnings\"...";
					}
				}
			}
			else if (number_of_e == 2)
			{
				name.text = "新领土";
				if (GlobalScript.inst.gameState.data[65] <= 0)
				{
					fake_text = "香港和澳门仍分别是英国和葡萄牙的殖民地，\n和他们的祖国分离。西方殖民主义者拒绝就其归还我们进行任何谈判，\n而我们也不敢冒险采取军事行动，担心遭到美国干预并引发第三次\n世界大战。";
				}
				else if (GlobalScript.inst.gameState.data[65] == 1)
				{
					fake_text = "同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " 同志and the NPC put forward an important theory \"One country - two systems\", according to which Hong Kong and Macao can return to the bosom of the Motherland with the preservation of their political and economic system for 50 years ahead and very wide autonomy. Negotiations on this issue with the English and Portuguese sides were very difficult and were repeatedly disrupted by the colonialists, but they were still successful - on July 1, 1997 we will return sovereignty over Hong Kong, and on December 19, 1999 - over Macau. Thus, the great dream of the Chinese people - Hong Kong (Hong Kong) and Macao (Macao) - to return to us is to be fulfilled — let's hope thats forever.";
				}
				else if (GlobalScript.inst.gameState.data[65] == 2 && GlobalScript.inst.gameState.allcountries[0].stab == 1)
				{
					fake_text = "在国家领导期间 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", may have made a lot of mistakes, but this period will go down in the history of China as \"Restoration of the Motherland\" - for historical justice was restored and Hong Kong and Macao, which for hundreds of years were held by foreign invaders, were returned by China. Now Hong Kong (Hong Kong) and Macao (Macau) are back together with the Motherland, and we will never give them to anyone again!";
				}
				else if (GlobalScript.inst.gameState.data[65] == 2)
				{
					fake_text = "我们外交人员的本领以及在世界上的声誉，\n使我们在殖民当局的严重阻挠之下，仍在与英方和葡方的谈判中达成\n协议：实现香港和澳门的移交，并使其全面融入中华人民共和国，\n同时保障外国人的私有财产得到保留。\n就此与英方和葡方进行的谈判极其艰难，\n且屡遭殖民主义者破坏，但最终仍取得成功——1997年7月1日，\n我们将收回对香港的主权；1999年12月19日——收回对澳\n门的主权。于是，香港（香港）和澳门（澳门）\n回到我们身边——但愿是永远。";
				}
				if (GlobalScript.inst.gameState.data[62] <= 0)
				{
					fake_text += "||阿鲁纳恰尔邦仍然属于印度，而中国顽固地拒绝承认。\n就此问题进行谈判的尝试——包括借助国际组织的“斡旋”——都未\n能取得成功，因此印中边境局势依然紧张。\n不过，双方显然都不太可能对彼此开战……";
				}
				else if (GlobalScript.inst.gameState.data[62] == 1 || (GlobalScript.inst.gameState.allcountries[19].Torg && (GlobalScript.inst.gameState.data[91] == 1 || GlobalScript.inst.gameState.data[91] == 2 || GlobalScript.inst.gameState.data[91] == 3) && (!GlobalScript.inst.gameState.allcountries[31].Torg || GlobalScript.inst.gameState.allcountries[31].Gosstroy == 2 || GlobalScript.inst.gameState.allcountries[31].Gosstroy == 1)))
				{
					fake_text += "||我们终于与印度领导层就领土问题达成了折中方案：\n中国拒绝对阿鲁纳恰尔邦的主张，印度则拒绝对我们在1962年边\n境冲突中占领的阿克赛钦地区的主张；而这一区域正穿过连接新疆与\n西藏的重要G219公路。\n此项决定终于为恢复亚洲两大国的睦邻关系打开了道路，\n并大大缓和了亚洲地区的紧张局势。";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(39);
					}
				}
				else if (GlobalScript.inst.gameState.data[62] == 2)
				{
					fake_text += "||中国终于彻底结束了与印度长期存在的领土争端——我军采取了\n决定性行动，阿鲁纳恰尔邦已全部归还中国。\n印度领导层在国内锡克地区局势再次恶化、\n并与巴基斯坦发生冲突的背景下，不得不承认我们对该领土的权利，\n尽管失去这个对国家十分重要的邦令他们极为恼火。\n根据我们的情报，印度正在秘密与美国、\n苏联和英国就向其军队进行大规模换装所需的大批武器与装备进行谈\n判。这些准备究竟是针对谁的——不必猜……";
				}
				else if (GlobalScript.inst.gameState.data[62] >= 3)
				{
					fake_text += "||中国终于通过我方外交人员的决定性行动，\n彻底结束了与印度长期存在的领土争端——阿鲁纳恰尔邦已全部归还\n中国。鉴于该国锡克地区局势不断恶化以及经济问题，\n印度领导人不得不承认我们对该领土的权利，\n尽管失去这个对国家十分重要的邦令他们的人民非常愤怒。\n根据我们的信息，印度正在秘密与美国、\n苏联和英国安排大规模供给装备与器材，\n用于其军队的大规模武装扩充，并扩大其情报机构。\n至于这些准备是针对谁——很难说：是镇压本国人民，\n还是煽动阿鲁纳恰尔邦的不安？";
				}
				if (GlobalScript.inst.gameState.data[167] == 0)
				{
					fake_text += "||钓鱼岛仍继续处于日本的占有之下……";
				}
				else if (GlobalScript.inst.gameState.data[167] == 1)
				{
					fake_text += "||我们终于夺取了钓鱼岛，如今我们的旗帜在我们自己的海军基地\n上在那里高高飘扬！海洋是我们的！";
				}
				else if (GlobalScript.inst.gameState.data[167] == 2)
				{
					fake_text += "||我们设法与日本方面达成了折中。\n如今钓鱼岛实现非军事化，由中日委员会共同拥有，\n并获得双方投资，同时也为两国带来收益。";
				}
				if (GlobalScript.inst.gameState.allcountries[9].prosov && !GlobalScript.inst.gameState.completedDecisions[19])
				{
					fake_text += "||不管怎样，蒙古仍然是莫斯科积极的朋友与伙伴。";
				}
				if (!GlobalScript.inst.gameState.allcountries[9].proprc && !GlobalScript.inst.gameState.completedDecisions[19] && !GlobalScript.inst.gameState.allcountries[9].prosov)
				{
					fake_text += "||蒙古奉行多方位政策，试图为了本国人民同时与苏联和中国做朋\n友";
				}
				else if (GlobalScript.inst.gameState.allcountries[9].proprc && !GlobalScript.inst.gameState.completedDecisions[19])
				{
					fake_text += "||蒙古是中国势力范围内一名名副其实的平等成员，\n在解决争端和外交政策问题上以北京为导向。";
				}
				else
				{
					fake_text += "||通过勤劳与苦干，中蒙兄弟再次找到了共同立场，\n并在中华人民共和国这个共同家园的屋檐下团结起来。";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(109);
					}
				}
			}
			else if (number_of_e == 3)
			{
				name.text = "苏联的命运";
				if (GlobalScript.inst.gameState.empires[1].now_leader == 3)
				{
					fake_text = "谢尔比茨基|在取代勃列日涅夫之后，弗拉基米尔·谢尔比茨基一上\n台就对政治局进行清洗，让乌克兰的自己人空降上位，\n撼动了僵化的勃列日涅夫体系，也打断了其成员之间盘根错节的腐败\n关系。对腐败的重拳，加上老经理的行政才能，\n使联盟经济保持稳步增长，民众福利同步提升。\n谢尔比茨基的内外政策与勃列日涅夫差别不大——加强经互会国家的\n经济一体化，对整个共同体产生积极影响；\n对华关系推进缓和；对计划自动化采取谨慎而缓慢的尝试；\n总体而言一切稳定。联盟站得住，而且还会站很久。";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(48);
					}
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 5)
				{
					fake_text = "Grishin|In the end, the old ruler was replaced by the old and experienced Viktor Grishin, a favorite of conservative circles. For the USSR, nothing much has changed - relatively stable economic growth allowed every year to spend more money on grain and social spending, very cautious and slow attempts to automate planning, suppressed by the party government, foreign policy was characterized by the continuation of the \"Brezhnev Doctrine\", but with an emphasis on improving relations with China.. However, the Board Grishin meant the final consolidation of the party, rampant nepotism, corruption and forgery in plan.";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(37);
					}
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 6)
				{
					fake_text = "戈尔巴乔夫|最终，旧统治者被安德罗波夫的改革派干部之一——年\n轻且有前途的米哈伊尔·戈尔巴乔夫取代。\n然而，戈尔巴乔夫的改革举措没有一项善终——禁酒运动导致农业衰\n退与替代品泛滥；“加速”政策造成资金的无能浪费与工业下滑；\n“公开性”则助长民族主义，迎来反苏谎言的鼎盛时期。";
					if (!GlobalScript.inst.gameState.startedDirectWarsNum.Any((KeyValuePair<int, bool> k) => k.Key == 10 && k.Value))
					{
						if (GlobalScript.inst.gameState.allcountries[51].isNATO)
						{
							fake_text += "Attempts to increase or reduce the role of the state in the economy, the incompetent and uncontrolled introduction of cooperatives, decentralization and the destruction of planned mechanisms have led to a huge external debt, the collapse of the economy, the deficit and impoverishment of the population. Foreign policy was characterized by subservience to the US and surrender of all the gains of socialism, culminating in the dissolution of the 华沙条约组织 and COMECON. The USSR itself did not survive them for long - the liberals and nationalists raised by Gorbachev, having won the support of the population, at the end of 1991 announced the dissolution of the USSR, actually taking away power from the would-be reformer.";
						}
						else
						{
							fake_text += "试图在经济中增减国家角色、低效且失控地推行合作社、\n分权以及破坏计划机制，导致巨额外债、\n经济崩溃、赤字扩大与民众贫困。\n1991年，离心力量逼得戈尔巴乔夫走到签署新联盟条约的地步。\n但在1991年8月，他被更务实的改革派夺权，\n成立了GKChP。由此成为代总统的亚纳耶夫逮捕了包括叶利钦在\n内的最激进分离主义运动领导人。\n随后，务实改革者伊万·波洛兹科夫于1992年2月当选总统，\n把经济从衰退带向小幅但稳定的增长。\n苏联在SRs的原则下建立了苏维埃的半市场民主。";
						}
					}
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(36);
					}
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 8)
				{
					fake_text = "利加乔夫|最终，旧统治者被经验丰富的地方领导人叶戈尔·利加乔\n夫取代——安德罗波夫改革派干部之一。\n他宣告推行“公开性”政策，扩大民主化，\n并以列宁的“新经济政策”（NEP）为模式转向社会主义市场经济。\n然而，利加乔夫的所有改革举措都举步维艰——禁酒运动导致替代\n品流通，尽管提高了出生率、降低了犯罪；\n“加速”政策确实提高了工业产量，却使消费品短缺赤字进一步扩大；\n“公开性”虽然扩大了自由，却催生了反苏出版物。\n试图在经济中从行政决策转向经济机制，\n却对合作社引入、分权以及违反计划机制的后果考虑不足，\n结果导致消费品生产下降，并使相当一部分人口陷入贫困。";
					if (GlobalScript.inst.gameState.allcountries[51].isNATO)
					{
						fake_text += "Foreign policy was characterized by the unsuccessful attempts of Detente with the United States and the reduction control of the 华沙条约组织 and the CMEA, which led to growth of separatist tendencies in these blocks. The USSR itself is in a rather difficult situation, and Ligachev's attempts to strengthen the situation by promoting people such as Boris Yeltsin and Vitaly Korotich, led to the emergence of the CPSU legal opposition, undermining the unity of the party. So far, the country's leadership controls the situation, but economists warn that within 25 years a major crisis is possible, which the Soviet pseudo-reformers may not survive...";
					}
					else if (GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[1].power && !GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text += "尽管如此，苏联经济还是挺过了这场考验：\n通过大幅扩大与西欧的贸易来“续命”。\n经互会与华约国家在控制减弱后仍未能解决“改革”（佩列斯特罗伊\n卡）问题。一股反对改革的民族爱国保守反对派随之出现。\n最终，1993年苏共XXX次代表大会之后，\n利加乔夫在全会上被撤换，由阿曼·图列耶夫接任。\n图列耶夫开始削减加盟共和国的权利，放慢市场改革，\n并把斯大林“平反”为与伊凡雷帝、彼得大帝并列的俄罗斯政治家。\n苏联被宣布为“历史上的俄罗斯国家”，\n而“所有用俄语思考的人”都被认定为俄罗斯人。";
					}
					else
					{
						fake_text += "尽管如此，苏联经济仍通过大幅扩大与西欧的贸易挺过了这场考验。\n经互会与华约国家在控制减弱后也不敢搞“改革”（佩列斯特罗伊卡）。\n反对势头被压制，改革则继续沿着“邓式”与NEP的精神推进。\n最终，2000年苏共XXXIII次代表大会上，\n利加乔夫宣布辞职。继任者是根纳季·久加诺夫：\n支持传统价值，继续市场改革，并在不提“建设共产主义”的情况下\n正式通过党的纲领。";
					}
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(61);
					}
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 7)
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1568], "\n");
				}
				else if (GlobalScript.inst.gameState.resultOfEvents[85] >= 3 && GlobalScript.inst.gameState.empires[1].now_leader == 2)
				{
					fake_text = string.Format(GlobalScript.inst.new_texts[692], "\n");
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 4)
				{
					if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[7].parts[2])
					{
						fake_text = string.Format(GlobalScript.inst.new_events_text[1565], "\n");
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(140);
						}
					}
					else if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[7].parts[0])
					{
						fake_text = string.Format(GlobalScript.inst.new_events_text[1566], "\n");
					}
					else if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[7].parts[1])
					{
						fake_text = string.Format(GlobalScript.inst.new_events_text[1567], "\n");
					}
					else
					{
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(38);
						}
						fake_text = "罗曼诺夫|最终，旧统治者被相对年轻、\n前途看好的党内成员格里戈里·罗曼诺夫取代——他以担任苏共列宁\n格勒州委书记的功绩而闻名。\n他的到来标志着党内对改革派的清洗拉开序幕，\n加强安全部门控制，并对持不同政见者展开迫害。\n讽刺的是，在他的统治下，文艺领域开始出现某些审查让步——音乐\n俱乐部很多，仿照列宁格勒摇滚俱乐部；\n电影工作者也更自由地尝试新的题材类型。\n苏联对外政策变得更强硬，特点是更积极地扩散苏联影响力、\n更严密地保护苏联利益。";
						if (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.data[16] == 11)
						{
							fake_text += "|受中国自动化成功的鼓舞，罗曼诺夫决定大规模推行自动化计划，\n并继续开发CSA与USNCC；同时从搁置项目OGAS入手，\n其开发与实施最终得以完成，尽管党内成员颇有不满。\n罗曼诺夫一直领导苏联到2008年去世，\n在此期间反复提升苏联的国际影响力、经济实力与民众福利。";
							if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.data[16] == 11 && GlobalScript.inst.gameState.allcountries[1].isSEV)
							{
								achieves.GetComponent<achievements>().Set(35);
							}
						}
						else if (GlobalScript.inst.gameState.allcountries[15].Gosstroy == 0 && GlobalScript.inst.gameState.allcountries[15].SubGosstroy == 0 && GlobalScript.inst.gameState.allcountries[4].Gosstroy == 1 && GlobalScript.inst.gameState.allcountries[4].SubGosstroy == 16)
						{
							fake_text += "|亲眼见证匈牙利与南斯拉夫经济政策的结果失败后，\n罗曼诺夫决定走与安德罗波夫计划不同的道路，\n开始大规模推行自动化计划。\n他继续开发CSA与USNCC，并从搁置项目OGAS入手，\n其开发与实施最终得以完成，尽管党内成员不满。\n罗曼诺夫一直领导苏联到2008年去世，\n在此期间反复提升苏联的国际影响力、经济实力与民众福利。";
							if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.data[16] == 11 && GlobalScript.inst.gameState.allcountries[1].isSEV)
							{
								achieves.GetComponent<achievements>().Set(35);
							}
						}
						else
						{
							fake_text += "|After the collapse of oil prices in the mid-1980s, it was decided to launch economic reforms - the Andropov reform plan (based on the Kosygin-Lieberman reform and the economic systems of Yugoslavia and Hungary) was taken as a basis, which together raised the competitiveness and flexibility of the Soviet economy, but the negative effects of decentralisation were not long in coming: inefficient distribution of profits by enterprises, obsolescence of equipment and mechanisms due to enterprises' savings on modernisation, development of nepotism and corruption (supply became the first priority for acquaintances and people started to \"buy\" places in the queue for raw materials). However, along with this, a categorical ban on any private property and private employment was introduced, which was even written into the Constitution. Romanov led the Soviet Union until his death in 2008, during which time greatly raising the international influence of the USSR, its economic power and the welfare of the population. However, after his death, the new Soviet leaders sadly confirmed the observations of international experts that the growth of the Soviet economy for several years was near to zero, and it should be needed do something with this...";
						}
					}
				}
			}
			else if (number_of_e == 4)
			{
				name.text = "苏联社会主义阵营";
				if (GlobalScript.inst.gameState.empires[1].now_leader == 4 && GlobalScript.inst.gameState.event_done[377])
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1570], "\n", (GlobalScript.inst.gameState.allcountries[7].parts[1] || GlobalScript.inst.gameState.allcountries[1].parts[2]) ? GlobalScript.inst.new_events_text[1571] : null);
				}
				else if ((GlobalScript.inst.gameState.empires[1].now_leader == 3 || GlobalScript.inst.gameState.empires[1].now_leader == 5 || GlobalScript.inst.gameState.empires[1].now_leader == 4) && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[1].isOVD)
				{
					fake_text = "For the socialist camp nothing has changed much - the CMEA and 华沙条约组织 continue to remain a stable alternative to capitalist alliances, and the USSR is their undisputed leader.";
				}
				else if ((GlobalScript.inst.gameState.empires[1].now_leader == 3 || GlobalScript.inst.gameState.empires[1].now_leader == 5 || GlobalScript.inst.gameState.empires[1].now_leader == 4) && (GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.allcountries[1].isOVD))
				{
					fake_text = "The entry of the PRC into the CMEA and the 华沙条约组织 and the growth of its influence in organizations and in the world cause serious fears of the Soviet governance for their leadership. For the rest, for the socialist camp nothing has changed much - the CMEA and 华沙条约组织 continue to remain a stable alternative to capitalist alliances.";
					if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[1].isOVD && GlobalScript.inst.gameState.relres)
					{
						achieves.GetComponent<achievements>().Set(5);
					}
				}
				else if (GlobalScript.inst.gameState.resultOfEvents[85] >= 3 && GlobalScript.inst.gameState.empires[1].now_leader == 2)
				{
					int num;
					if (GlobalScript.inst.gameState.modifies[49].active && GlobalScript.inst.gameState.allcountries[92].okb)
					{
						num = 693;
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(161);
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.influencePRC > 500 && GlobalScript.inst.gameState.modifies[6].active)
					{
						num = 694;
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(162);
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						num = 695;
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(163);
						}
					}
					else
					{
						num = 696;
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(164);
						}
					}
					fake_text = string.Format(GlobalScript.inst.new_texts[num], "\n");
				}
				else if (GlobalScript.inst.gameState.event_done[433])
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1602], "\n");
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 6 && ((GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.allcountries[1].econ && GlobalScript.inst.gameState.allcountries[1].okb) || (GlobalScript.inst.gameState.allcountries[5].Torg && !GlobalScript.inst.gameState.allcountries[2].prosov && !GlobalScript.inst.gameState.allcountries[4].prosov && (GlobalScript.inst.gameState.allcountries[1].econ || GlobalScript.inst.gameState.allcountries[1].okb))))
				{
					fake_text = "After Gorbachev came to power in the USSR, the social camp began to slowly fall apart, and without Soviet support, the power of its members began to falter. But the well-established relations of the PRC and the USSR, along with trade with the CMEA, allowed us to get what Gorbachev could not hold. After the dissolution of the 华沙条约组织 and the CMEA, we insistently offered Eastern Europe membership in our alliances on favorable terms, for which Romania, Bulgaria, Hungary, Poland and Czechoslovakia agreed.";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(6);
					}
				}
				else if ((GlobalScript.inst.gameState.empires[1].now_leader == 6 || GlobalScript.inst.gameState.empires[1].now_leader == 8) && ((GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[1].isOVD) || (GlobalScript.inst.gameState.allcountries[5].Torg && !GlobalScript.inst.gameState.allcountries[2].prosov && !GlobalScript.inst.gameState.allcountries[4].prosov && (GlobalScript.inst.gameState.allcountries[1].isOVD || GlobalScript.inst.gameState.allcountries[1].isSEV))))
				{
					if (GlobalScript.inst.gameState.empires[1].now_leader == 8)
					{
						fake_text = "After Ligachev came to power in the USSR, the social camp began to slowly fall apart, and without Soviet support, the power of its members began to falter. However, our membership in the 华沙条约组织 and the CMEA has helped us keep them in a slightly modified form. At a secret meeting, we developed a plan for the final fall of Soviet leadership in the CMEA and WPO. Of course, fearing a dark future, most countries happily agreed, and now the CMEA and WPO formed a more equal and updated socialist camp with our leadership. However, instead of the USSR, now we provide all possible assistance for these countries...";
					}
					else
					{
						fake_text = "After Gorbachev came to power in the USSR, the social camp began to slowly fall apart, and without Soviet support, the power of its members began to falter. However, our membership in the 华沙条约组织 and the CMEA has helped us keep them in a slightly modified form. After the dissolution of the CMEA and the 华沙条约组织, we proposed to their members the creation of new blocks, taking on all the costs of supporting the economy of our old friends. Of course, most countries happily agreed - the GDR, Romania, Bulgaria, Czechoslovakia, Hungary and Poland continue to form a more equal and updated socialist camp with our leadership.";
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(6);
						}
					}
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 6 || GlobalScript.inst.gameState.empires[1].now_leader == 8)
				{
					if (GlobalScript.inst.gameState.empires[1].now_leader == 8)
					{
						fake_text = "For the socialist camp nothing has changed much - the CMEA and 华沙条约组织 continue to remain an alternative to capitalist alliances, and the USSR is still their leader.";
					}
					else
					{
						fake_text = "戈尔巴乔夫上台后，社会阵营开始缓慢瓦解；\n在失去苏联支持后，成员国的力量也开始动摇。\n欧洲社会主义的堡垒终于被戈尔巴乔夫、\n美国中央情报局（CIA）与克格勃（KGB）\n亲手摧毁。";
						if (GlobalScript.inst.gameState.allcountries[0].isNATO && GlobalScript.inst.gameState.allcountries[0].isEU)
						{
							fake_text += "尽管这些国家如今名义上保持中立，但加入欧盟与北约也为时不远。";
						}
						else if (GlobalScript.inst.gameState.allcountries[0].isNATO)
						{
							fake_text += "尽管这些国家如今名义上保持中立，但加入北约也为时不远";
						}
						else if (GlobalScript.inst.gameState.allcountries[0].isEU)
						{
							fake_text += "尽管这些国家如今名义上保持中立，但加入欧盟也为时不远。";
						}
					}
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 7)
				{
					int num2 = 0;
					for (int num3 = 0; num3 < 100; num3++)
					{
						if ((num3 == 2 || num3 == 99 || num3 == 4 || num3 == 5) && GlobalScript.inst.gameState.allcountries[num3].isNATO)
						{
							num2++;
						}
					}
					if (num2 <= 0 && GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(139);
					}
					if (num2 == 4)
					{
						fake_text = string.Format(GlobalScript.inst.new_events_text[1572], "\n");
					}
					else if (num2 > 0)
					{
						fake_text = string.Format(GlobalScript.inst.new_events_text[1573], "\n");
					}
					else
					{
						fake_text = string.Format(GlobalScript.inst.new_events_text[1635], "\n");
					}
				}
				else
				{
					fake_text = "For the socialist camp nothing has changed much - the CMEA and 华沙条约组织 continue to remain a stable alternative to capitalist alliances, and the USSR is their undisputed leader.";
				}
			}
			else if (number_of_e == 5)
			{
				if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[0].power + GlobalScript.inst.gameState.empires[1].power > 20 && !GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.data[14] == 3)
				{
					achieves.GetComponent<achievements>().Set(15);
				}
				if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.influencePRC >= 400)
				{
					achieves.GetComponent<achievements>().Set(21);
				}
				name.text = "冷战";
				if (GlobalScript.inst.gameState.allcountries[7].isNATO)
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1575], "\n");
				}
				else if (GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1576], "\n", (GlobalScript.inst.gameState.empires[1].now_leader != 6 && GlobalScript.inst.gameState.influencePRC + GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.empires[1].power) ? GlobalScript.inst.new_events_text[1577] : GlobalScript.inst.new_events_text[1578]);
				}
				else if (!GlobalScript.inst.gameState.allcountries[51].isNATO && GlobalScript.inst.gameState.allcountries[7].isOVD)
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1604], "\n", (GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.influencePRC && GlobalScript.inst.gameState.empires[1].now_leader != 6) ? GlobalScript.inst.new_events_text[1606] : GlobalScript.inst.new_events_text[1605]);
				}
				else if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[0].power + GlobalScript.inst.gameState.empires[1].power <= 80 && GlobalScript.inst.gameState.empires[1].now_leader != 6)
				{
					fake_text = "Times are changing, the Cold War is passing... To begin again with a new force. And even the most implacable enemies of the 20th century - the Soviet Union and the United States had to become sworn friends, and again, like during World War II, unite against a common enemy - China - the new hegemon of the modern world, risen from the ashes and rapidly claiming to dominate the world domination. Trying to save the remnants of their influence, the former enemies, begin a new round of the arms race: NATO and 华沙条约组织 conduct joint exercises, the military budgets of the USSR and the USA double each year, with the joint efforts of American and Soviet scientists developing new types of nuclear weapons. It seems that a new large-scale war is becoming a matter of time, but will humanity survive it?";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(17);
					}
				}
				else if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.influencePRC)
				{
					fake_text = "冷战快走到尽头了，似乎在这场长期对抗中，\n苏联将占上风——成为世界上最有影响力的力量。\n美国在世界上的影响力迅速衰退，美元体系土崩瓦解；\n北约成员奉行越来越独立的政策，而北约本身也接近解体。\n最后但同样重要的是：这都源于中华人民共和国在世界政治中的积极\n介入，以及美国影响力的逐步被挤出。";
				}
				else if (GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.influencePRC && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.influencePRC)
				{
					fake_text = "过去几年对苏联并非白费——它在世界上的影响力大幅扩张；\n也许有一天，冷战会以胜利告终——美国正在失去影响力，\n世界共产主义运动不断扩大，北约成员奉行越来越独立的政策。\n尽管中国在对外政策上颇有动作，但它始终未能跻身超级大国行列，\n仍落在美国与苏联之后；不过也许迟早会改变……";
				}
				else if (GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.influencePRC && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.influencePRC)
				{
					fake_text = "过去几年对美国并非白费——它在世界上的影响力大幅提升，\n看来他们终将从冷战中某个时刻赢得胜利：\n苏联在世界上的影响力（包括在社会主义阵营）\n正在下降，世界共产主义运动也在走弱。\n尽管中国在对外政策上颇有动作，但它始终未能跻身超级大国行列，\n仍落在美国与苏联之后；不过也许迟早会改变……";
				}
				else if (GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.influencePRC)
				{
					fake_text = "冷战快走到尽头了，似乎在这场长期对抗中，\n美国将占上风——成为世界上最有影响力的力量。\n苏联在世界上的影响力正在丧失，包括在社会主义阵营（其奉行越来\n越独立的政策）以及世界共产主义运动方面。\n最后但同样重要的是：这都源于中华人民共和国在世界政治中的积极\n介入，以及苏联影响力的逐步被挤出。";
				}
				else if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.empires[0].power)
				{
					fake_text = "一开始，中国的支持者只有零散的游击派“毛主义者”，\n但它最终还是突破重围，成为世界超级大国，\n在国际组织中获得巨大分量，并在不同国家赢得了众多追随者。\n||苏联与美国之间的对抗正逐渐淡出背景，\n但似乎苏联将成为胜利者——美国正在迅速失去对世界的影响力，\n美元体系土崩瓦解；北约成员奉行越来越独立的政策，\n而北约本身也接近解体。";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(33);
					}
				}
				else if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.empires[1].power)
				{
					fake_text = "一开始，中国的支持者只有零散的游击派“毛主义者”，\n但它最终还是突破重围，成为世界超级大国，\n在国际组织中获得巨大分量，并在不同国家赢得了众多追随者。\n||苏联与美国之间的对抗正逐渐淡出背景，\n但似乎美国将成为胜利者——苏联对世界共产主义与单纯反美运动失\n去任何影响；社会主义阵营在我们眼前崩塌，\n最可能在中华人民共和国与美国之间分割，\n而我们将得到最好的那一份。";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(33);
					}
				}
				if (!GlobalScript.inst.gameState.allcountries[0].isEU)
				{
					fake_text += string.Format(GlobalScript.inst.new_events_text[1579], "\n");
				}
				if (GlobalScript.inst.gameState.allcountries[85].isSocEU)
				{
					fake_text += string.Format(GlobalScript.inst.new_events_text[1580], "\n");
				}
				if (GlobalScript.inst.gameState.allcountries[15].Vyshi && GlobalScript.inst.gameState.allcountries[15].isEU && GlobalScript.inst.gameState.allcountries[15].SubGosstroy == 14)
				{
					fake_text += string.Format(GlobalScript.inst.new_events_text[1581], "\n");
				}
				else if (GlobalScript.inst.gameState.allcountries[20].puppetOf == 15)
				{
					fake_text += string.Format(GlobalScript.inst.new_events_text[1582], "\n");
				}
				else if (GlobalScript.inst.gameState.allcountries[20].spec == 1 && GlobalScript.inst.gameState.influencePRC >= 750)
				{
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(154);
					}
					fake_text += string.Format(GlobalScript.inst.new_events_text[1583], "\n");
				}
				else if (GlobalScript.inst.gameState.allcountries[20].spec == 1 && GlobalScript.inst.gameState.influencePRC < 750)
				{
					fake_text += string.Format(GlobalScript.inst.new_events_text[1584], "\n");
				}
				else if (!GlobalScript.inst.gameState.allcountries[15].isMonatchy && (!GlobalScript.inst.gameState.event_done[455] || GlobalScript.inst.gameState.resultOfEvents[455] > 2) && GlobalScript.inst.gameState.allcountries[15].isSEV && (GlobalScript.inst.gameState.empires[1].now_leader != 6 || (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.influencePRC)))
				{
					fake_text += "||20世纪80年代成为南斯拉夫的转折点：\n巨额外债、铁托经济政策的后果；借助市场改革来改善局势的尝试可\n能带来灾难性后果——但多亏社会主义阵营的及时介入，\n这一切被避免。南斯拉夫决定以正式成员身份加入经互会；\n在与社会主义阵营合作、获得优惠价格以及苏联援助的帮助下，\n经济得以复苏，并开始逐步偿还债务；克格勃的帮助也有助于安抚民\n族主义者与自由派。当然，这也导致南斯拉夫社会主义联邦共和国（\nSFRY）与西方分离，并向苏联靠拢。";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(65);
					}
				}
				else if (GlobalScript.inst.gameState.allcountries[7].isNATO)
				{
					fake_text += "||The 80s were difficult times for Yugoslavia: huge external debt, the consequences of Tito's economic policy, attempts to improve the situation through market reforms and the absence of influential patrons led to a deterioration in the economic situation, a decline in living standards and, as a result, an increase in nationalism in the republics. After the escalation of a serious confrontation between the renewed NATO and China, Western countries did not dare to interfere in the situation inside the SFRY and limited themselves to \"concerns about the violation of democracy and the rights of national minorities,\" thanks to which the SFRY continues to deepen military and economic cooperation with China.";
				}
				else if (GlobalScript.inst.gameState.allcountries[15].prosov)
				{
					fake_text += "||The 80s were difficult times for Yugoslavia: huge external debt, the consequences of Tito's economic policy, attempts to improve the situation through market reforms and the absence of influential patrons led to a deterioration in the economic situation, a decline in living standards and, as a result, an increase in nationalism in the republics. Attempts by the United States and the West to support the nationalists led to a deterioration in relations, which is why Belgrade eventually decided to join the 华沙条约组织, having received a generous offer from Romanov: huge financial assistance, preferential supplies of raw materials and full protection from the West.";
				}
				else if (!GlobalScript.inst.gameState.allcountries[15].isMonatchy && (!GlobalScript.inst.gameState.event_done[455] || GlobalScript.inst.gameState.resultOfEvents[455] > 2) && GlobalScript.inst.gameState.allcountries[4].okb && GlobalScript.inst.gameState.empires[1].now_leader == 6)
				{
					fake_text += "||20世纪80年代对南斯拉夫而言是艰难时期：\n巨额外债、铁托经济政策的后果；通过市场改革试图改善局势，\n却因缺乏有影响力的“保护人”，导致经济状况恶化、\n生活水平下降，进而使各共和国民族主义抬头。\n美国与西方试图支持民族主义者，导致关系恶化；\n因此，贝尔格莱德开始更加聚焦俄罗斯与中国，\n并全面加入“16+1”计划。";
				}
				else if (GlobalScript.inst.gameState.allcountries[15].Gosstroy == 0 && !GlobalScript.inst.gameState.allcountries[15].prosov)
				{
					fake_text += "||20世纪80年代对南斯拉夫而言是艰难时期：\n巨额外债、铁托经济政策的后果；通过市场改革试图改善局势，\n却因缺乏有影响力的“保护人”，导致经济状况恶化、\n生活水平下降，进而使各共和国民族主义抬头。\n然而，南斯拉夫仍设法挺过这些考验，尤其多亏了我们的帮助。\n市场改革被限制在继续进行成本核算与分权的试验上，\n到了90年代初便彻底停止。\n民族主义者利用民众不满情绪，试图分离出去，\n但所有分离主义企图都被YPA迅速镇压。\n美国与西方试图支持民族主义者，导致西方与SFRY之间关系恶化；\n于是SFRY开始更加聚焦苏联与中国，\n尽管它仍继续保持中立。";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(65);
					}
				}
				else if (!GlobalScript.inst.gameState.allcountries[15].isMonatchy && (!GlobalScript.inst.gameState.event_done[455] || GlobalScript.inst.gameState.resultOfEvents[455] > 2) && GlobalScript.inst.gameState.allcountries[15].Torg && (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power || GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[0].power || (GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.empires[1].power + GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[0].power)))
				{
					fake_text += "||20世纪80年代对南斯拉夫而言是艰难时期：\n巨额外债、铁托经济政策的后果；通过市场改革试图改善局势，\n却因缺乏有影响力的领导人，导致经济状况恶化、\n生活水平下降，进而使各共和国民族主义抬头。\n然而，南斯拉夫仍设法挺过这些考验，尤其多亏了我们的帮助。\n市场改革规模并未扩大到那种程度，而自由派政治改革也很快被军方\n与保守派破坏并镇压。\n但仍无法避免内战；斯洛文尼亚与克罗地亚最终借内战结果获得独立，\n不过在其他地区，叛乱很快被JNA镇压。\n美国试图支持分离主义者，导致其与南斯拉夫的关系恶化；\n而南斯拉夫每年都在更紧密地与苏联与中国建立合作。\n南斯拉夫尽管规模缩小，仍继续存在。";
				}
				else if (!GlobalScript.inst.gameState.allcountries[15].isMonatchy && (!GlobalScript.inst.gameState.event_done[455] || GlobalScript.inst.gameState.resultOfEvents[455] > 2))
				{
					fake_text += "||20世纪80年代对南斯拉夫而言是艰难时期：\n巨额外债、铁托经济政策的后果；通过市场改革试图改善局势，\n却因缺乏有影响力的领导人，导致经济状况恶化、\n生活水平下降，进而使各共和国民族主义抬头。\n政府无法稳定局势，最终导致军方派系夺取政权，\n并爆发中央政府（很快发现实际上由塞尔维亚与黑山代表）\n与克罗地亚、斯洛文尼亚及阿尔巴尼亚民族主义者之间的内战。\n谁会从中胜出并不清楚，因为北约部队以对塞尔维亚的行动终结了这\n一切。巴尔干单一国家不复存在，几乎所有原共和国如今都转向西方\n与美国。";
				}
			}
			else if (number_of_e == 6)
			{
				name.text = "甜蜜生活";
				if (GlobalScript.inst.gameState.data[5] <= 400)
				{
					fake_text = "你们的治理并没有给中国普通公民的生活带来多少改善——我们的生\n活水平仍停留在70年代初。\n时不时就会出现粮食危机，乡下人连现代便利都不懂；\n而在城市里情况也并不理想——老百姓住在设备简陋的房子里，\n往往挤在合住房与棚户区；富裕阶层的商品很少，\n所谓奢侈品也只供高官与企业董事享用。";
				}
				else if (GlobalScript.inst.gameState.data[5] <= 700)
				{
					fake_text = "你们的治理以中国人民生活水平的持续攀升为标志——粮食供应问题\n终于得到解决，大多数人如今都能接触到富裕阶层的商品，\n许多中国人在城市中的生活条件也明显改善，\n尽管仍有不少工人不得不住在大杂院和贫民窟。\n农村情况更糟，但基础设施已经在发展：\n现代住房在乡村兴建，现代通信也正在向他们延伸。\n我们预计很快就能达到日本的生活水平。\n人民将永远铭记你们为他们光明未来所作出的贡献。";
				}
				else
				{
					fake_text = "你们的治理以中国生活水平的巨大跃升为标志——不仅粮食供应问题\n已被彻底解决，我们还达到这样一个水平：\n几乎人人都能获得富裕阶层的商品，越来越多的人拥有奢侈品。\n我们积极弥合城乡差距——实现了普遍通电，\n引入了现代通信，乡村正在兴建现代住房。\n如今，每一个诚实的劳动者都有体面的住处和饭食；\n在生活水平上，中国已经超过包括日本在内的所有亚洲国家。\n对人民而言，你们永远是深受爱戴的统治者——为中国带来发展与新\n生活。";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(47);
					}
				}
			}
			else if (number_of_e == 7)
			{
				if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.OAR && GlobalScript.inst.gameState.allcountries[14].oar && GlobalScript.inst.gameState.allcountries[35].oar && GlobalScript.inst.gameState.allcountries[13].oar && GlobalScript.inst.gameState.data[85] == 3)
				{
					achieves.GetComponent<achievements>().Set(13);
				}
				name.text = "世界局势";
				if (GlobalScript.inst.gameState.allcountries[10].numberOfSpecialEnding < 0)
				{
					if (GlobalScript.inst.gameState.data[83] <= 0 && !GlobalScript.inst.gameState.allcountries[46].Vyshi && GlobalScript.inst.gameState.allcountries[46].Gosstroy == 2)
					{
						fake_text = "After long-awaited peaceful unification of Korea and withdrawal of american troops the long and difficult integration began. It was not so easy to unite self-sustained DPRK with RK, based on the foreign capital. Another problem is foreign policy, where \"southerners\" stand for keeping friendly contacts with the West and \"northerners\" - for independent foreign policy and establishing a new power in the region. Though Koreans, enjoying the unification and true independence, don't care nuch for the policy now.";
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(50);
						}
					}
					else if (GlobalScript.inst.gameState.data[83] <= 0 && (!GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.empires[1].now_leader == 6) && GlobalScript.inst.gameState.allcountries[10].Gosstroy == 1)
					{
						fake_text = "朝鲜半岛上并没有太大变化——两朝对峙仍在继续。\n而在21世纪初，朝鲜民主主义人民共和国为抵御美国的侵略而开始\n发展核武器。朝鲜继续奉行中立外交政策：\n同中国和莫斯科保持良好关系，但不加入他们的阵营。";
					}
					else if (GlobalScript.inst.gameState.data[83] <= 0 && GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.empires[1].now_leader != 6 && GlobalScript.inst.gameState.allcountries[10].Gosstroy == 1)
					{
						fake_text = "朝鲜半岛上并没有太大变化——两朝对峙仍在继续。\n为了在90年代争取优势，朝鲜民主主义人民共和国加入了经互会（\nCMEA），不久又加入了华沙条约组织（WPO），\n因为它看到中华人民共和国与苏联之间的分裂终于被克服。\n这为它带来了经济上的提振，并提供了对抗美国侵略的坚实保障。";
					}
					else if (GlobalScript.inst.gameState.data[83] <= 0 && (!GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.empires[1].now_leader == 6) && GlobalScript.inst.gameState.allcountries[10].Gosstroy == 2)
					{
						fake_text = "朝鲜半岛上并没有太大变化——两朝对峙仍在继续，\n只是以更缓和的形式呈现。\n朝鲜民主主义人民共和国进行了大规模改革：\n意味着计划体制的分权、对民间的放宽管制，\n并计划开放经济特区。\n尽管这些举措改善了朝鲜同美国及亲美邻国的关系，\n但在21世纪初，朝鲜仍发展核武器以保护自己免受美国侵略。\n朝鲜继续奉行中立外交政策：同中国和莫斯科保持良好关系，\n但不加入他们的阵营。";
					}
					else if (GlobalScript.inst.gameState.data[83] <= 0 && GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.empires[1].now_leader != 6 && GlobalScript.inst.gameState.allcountries[10].Gosstroy == 2)
					{
						fake_text = "朝鲜半岛上并没有太大变化——两朝对峙仍在继续，\n只是以更缓和的形式呈现。\n朝鲜民主主义人民共和国进行了大规模改革：\n意味着计划体制的分权、对民间的放宽管制，\n并计划开放经济特区。\n尽管这些举措改善了朝鲜同美国及亲美邻国的关系，\n但在90年代，朝鲜加入了经互会（CMEA），\n不久又加入了华沙条约组织（WPO），\n因为它看到中华人民共和国与苏联之间的分裂终于被克服。\n这为它带来了经济上的提振，并提供了对抗美国侵略的坚实保障。";
					}
					else if (GlobalScript.inst.gameState.data[83] == 1)
					{
						fake_text = "在朝鲜民主主义人民共和国旗帜下实现朝鲜成功统一、\n驱逐美国侵略者之后，久盼的复兴与发展开始了；\n而在90年代，该国宣布核武器研发取得成功。";
						if (GlobalScript.inst.gameState.empires[1].now_leader == 6)
						{
							fake_text += "在核弹头的保护下，朝鲜民主主义人民共和国迅速开始推行独立的外\n交政策。朝鲜试图成为地区乃至全球政治中的新独立力量，\n而且看起来它最终会做到。";
							if (GlobalScript.inst.gameState.iron_and_blood)
							{
								achieves.GetComponent<achievements>().Set(16);
							}
						}
						else if (GlobalScript.inst.gameState.allcountries[10].econ)
						{
							fake_text += "不久，朝鲜民主主义人民共和国加入了我们的联盟，这又进一步推动了该国经济发展。";
						}
						else
						{
							fake_text += "不久，朝鲜民主主义人民共和国加入了经互会（CMEA），这又进一步推动了该国经济发展。";
						}
					}
					else if (GlobalScript.inst.gameState.data[83] == 2)
					{
						fake_text = "在朝鲜民主主义人民共和国遭到挫败、并在共和国旗帜下实现朝鲜统\n一之后，美国首先向被吞并地区增派更多军队，\n以打击日益壮大的游击运动。\n游击队控制了许多北方地区，并通过持续袭击消耗美国人。\n看来，久盼的朝鲜复兴恐怕不会很快到来。";
						if (GlobalScript.inst.gameState.empires[1].now_leader != 6 || GlobalScript.inst.gameState.data[14] < 3)
						{
							fake_text += " And soon americans have brought their nuclear weapons to the Korea \"to defend peace and american interests in the region\" that caused the protest of many countries.";
							if (GlobalScript.inst.gameState.iron_and_blood)
							{
								achieves.GetComponent<achievements>().Set(51);
							}
						}
					}
				}
				else
				{
					fake_text = "朝鲜半岛上没有发生什么有意思的事。";
				}
				if (GlobalScript.inst.gameState.allcountries[37].SubGosstroy == 17 && GlobalScript.inst.gameState.allcountries[37].okb)
				{
					fake_text += "|With the direct support of China, a regime of traditionalist agrarians, who rejected the capitalist system of economy, was established in the 联邦国家 of Palestine and Israel. But this was not enough for the Chinese authorities, they were not satisfied with the too slow pace of reforms. Therefore, the option of creating Death Battalions, where the poor were recruited, and a large-scale purge of the Palestinian-Israeli army was put forward, officially \"to protect it from the reactionary forces in the army\".|Year after year this organisation gradually grew replacing the army, and was led by Chinese advisers and individuals recruited by the Chinese intelligence services. And when the organisation became strong enough according to the opinion of foreign curators, it was time to implement the plan: in one night the Death Battalions seized all government and administrative buildings and residential centres of political power of all cities and regions of the country and executed them all on the spot. Then arrested and deposed the remnants of the army. And finally they set fire to all the cities and towns, blowing up everything they could. The alarmed citizens ran out of their homes, where they were met by Death Battalion units and taken to special tent camps. There, the entire population of the country was divided into several hundred tribes, led by Death Battalion leaders. And each family was given a horse, a wagon and stacks of hard warm fabric. So like that in Palestine and Israel it started a period of return to the roots - to nomadic tribal life. And the remaining bits of civilisation survived only in water extraction areas and minor settlements nearby to support water extraction under the control of Death Battalions. Money had also been abolished in the country, replaced by barter.|<color=red>\"My children, you have finally found the Promised Land bequeathed to us by God.\"</color>";
					achieves.GetComponent<achievements>().Set(160);
				}
				else if (GlobalScript.inst.gameState.data[85] == 0)
				{
					fake_text += "|巴勒斯坦人与以色列之间的冲突长期未能解决，\n直到1987—1993年的巴勒斯坦起义——被称为第一次起义（\nFirst Intifada）——遭到以色列的严厉镇压，\n才迫使双方开始谈判。\n奥斯陆协议（Oslo Accords）\n在巴勒斯坦领土上设立了巴勒斯坦民族行政机构（作为领土自治安排），\n并使巴解组织（PLO）停止恐怖袭击。\n但以色列不愿作出让步，以及来自不同组织的持续恐怖活动，\n导致和平进程遭到破坏，并引发2000—2005年的第二次起义\n（Second Intifada）。";
				}
				else if (GlobalScript.inst.gameState.data[85] == 1)
				{
					fake_text += "|我们的介入与强迫双方谈判，标志着巴勒斯坦—以色列冲突走向“\n解决”的开端。北京协议（Beijing Accords）\n在巴勒斯坦领土上设立了巴勒斯坦民族行政机构（作为领土自治安排），\n并使巴解组织（PLO）停止恐怖袭击。\n但以色列不愿作出让步，以及来自不同组织的持续恐怖活动，\n导致和平进程遭到破坏，并引发2000—2005年的巴勒斯坦起\n义。";
				}
				else if (GlobalScript.inst.gameState.data[85] == 2)
				{
					fake_text += "|我们的介入与强迫双方谈判，标志着巴勒斯坦—以色列冲突走向“\n解决”的开端。北京协议（Beijing Accords）\n在以色列领土的部分地区建立了巴勒斯坦国。\n将这些地区的控制权移交给巴勒斯坦行政机构的过程中伴随着种种越\n界行为；东耶路撒冷的地位、在加沙地带与约旦河西岸之间建立走廊，\n以及持续的恐怖袭击至今仍在制造麻烦。\n两国关系仍然紧张，但在实现和平方面已经出现了进展。";
				}
				else if (GlobalScript.inst.gameState.data[85] == 3)
				{
					fake_text += "|我们的介入与强迫双方谈判，标志着巴勒斯坦—以色列冲突走向“\n解决”的开端。北京协议（Beijing Accords）\n建立了巴勒斯坦—以色列联合国家（United State o\nf Palestine and Israel），\n并确定两种国家语言，同时发展地方治理。\n有关领土边界以及东耶路撒冷地位的问题，\n成为激烈争议的焦点；一些恐怖组织也在继续制造麻烦。\n另一个问题是USPI的外交政策，它在新成立的国家机构内部引发\n了尖锐争论。新国家内各民族之间的关系将长期紧张，\n但在国际控制以及“平等与兄弟情谊”的宣传之下，\n这场冲突最终会被终结。";
				}
				else
				{
					fake_text += "|阿拉伯—以色列冲突中没有发生什么值得一提的事。";
				}
				if (GlobalScript.inst.gameState.allcountries[30].parts[0])
				{
					fake_text += string.Format(GlobalScript.inst.new_events_text[1601], "\n");
				}
				else if (GlobalScript.inst.gameState.OAR && GlobalScript.inst.gameState.allcountries[14].oar && GlobalScript.inst.gameState.allcountries[35].oar && GlobalScript.inst.gameState.allcountries[13].oar)
				{
					fake_text += "|以阿拉伯社会主义原则为基础、将主要阿拉伯国家统一到阿拉伯联\n合共和国（UAR）这一久盼的目标，终于实现了。\n把拥有相似制度的国家合并为一个并不算太难；\n尽管中央集权支持者与地方精英之间的斗争正在削弱国家稳定，\n但共同整合进展顺利。\n通过联合数国经济并组建统一军队，UAR成为近东最强大的国家，\n并成为国际社会中的有力成员。\nUAR试图同社会主义国家保持友谊，但其日益膨胀的胃口正在侵蚀\n本就脆弱的地区和平。\n以色列加强了边境防务，有人甚至说UAR即将入侵沙特阿拉伯和苏\n丹。";
				}
				else if (GlobalScript.inst.gameState.OAR)
				{
					fake_text += "|建立统一阿拉伯国家的初期欢呼，很快被对诸多问题的认识所取代\n——并非所有阿拉伯国家都加入了UAR；\n而加入的国家也开始在新国家内部争夺权力。\n中央集权支持者与地方精英之间的斗争，\n导致出台了大量自治法令与特殊地位安排，\n却并未帮助提升治理效率。\nUAR仍在存在，但其成员的独立政策越来越多，\n统一也越来越流于形式。";
				}
				else if (GlobalScript.inst.gameState.data[85] == 2)
				{
					fake_text += "|阿拉伯国家继续各自分散，统一计划也被遗忘了";
				}
				else
				{
					fake_text += "|阿拉伯问题中没有发生什么有意思的事。";
				}
			}
		}
		else if (number_of_e == 0)
		{
			GoodEnd();
		}
		else if (number_of_e == 1)
		{
			if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.data[66] == 0 && GlobalScript.inst.gameState.data[67] == 0 && GlobalScript.inst.gameState.data[65] > 0 && GlobalScript.inst.gameState.data[62] == 2)
			{
				achieves.GetComponent<achievements>().Set(8);
			}
			name.text = "Старые территории";
			if (GlobalScript.inst.gameState.allcountries[70].numberOfSpecialEnding < 0)
			{
				if (GlobalScript.inst.gameState.data[66] <= 0)
				{
					fake_text = "Синьцзян-Уйгурский автономный район продолжает оставаться составной частью Китая, несмотря на подогреваемые нашими противниками сепаратистские настроения. Однако ситуация в районе пока под контролем, органы власти функционируют, как положено, а МГБ и Синьцзянский производственно-строительный корпус успешно пресекают любые попытки организовать серьезное сепаратистское движение за выход Синьцзяна из состава Китая.";
				}
				else if (GlobalScript.inst.gameState.data[66] == 1)
				{
					fake_text = "Поддерживаемые СССР синьцзянские сепаратисты смогли-таки, воспользовавшись нашими проблемами, захватить власть в районе и добиться независимости от Китая. Впрочем, \"независимость\" быстро сменилась тотальной зависимостью от Советского Союза - руководство Восточно-Туркестанской Народной республики формируется по согласованию с Москвой, армией командуют советские офицеры, а экономика под полным контролем советников из Союза. Все партии, кроме Коммунистической партии Восточного Туркестана, запрещены. Де-факто, Синьцзян стал \"внеблоковой республикой\" СССР по образцу Болгарии и Монголии...";
				}
				else if (GlobalScript.inst.gameState.data[66] >= 2)
				{
					fake_text = "Синьцзянские сепаратисты смогли-таки, воспользовавшись нашими проблемами, захватить власть в районе и добиться независимости от Китая. Как и следовало ожидать, экономика района после разрыва кооперационных связей с нашими предприятиями развалилась, а попытки руководства Синьцзянской республики балансировать между нами, СССР и США привели к превращению её в поле геополитической борьбы. Пока верхушка и возродившаяся буржуазия купаются в роскоши, растрачивая полученные от сверхдержав доллары, рубли и юани, народ Синьцзяна живет в крайней нищете, вследствие чего всю большую популярность набирают исламистские настроения... ";
				}
			}
			if (GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding < 0 || GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding > 10)
			{
				if (GlobalScript.inst.gameState.data[67] <= 0)
				{
					fake_text += "||Тибетский автономный район продолжает оставаться составной частью Китая, несмотря на подрывную пропаганду бежавших за границу сторонников Далай-Ламы и части местного духовенства. На экономическое развитие района тратятся огромные средства, призванные ещё крепче \"привязать\" его к остальной стране, с другой стороны, мы не ослабляем контроль над духовенством и решительно пресекаем любые попытки организовать серьезное сепаратистское движение за выход Тибета из состава Китая.";
				}
				else
				{
					fake_text += "||Тибетские сепаратисты смогли-таки, воспользовавшись нашими проблемами, захватить власть в районе и добиться независимости от Китая. Далай-Лама XIV торжественно вернулся в Лхасу, где выступил с торжественной речью, обличая нас и радуясь \"окончанию китайской оккупации свободного Тибета\". Впрочем, не все так радужно в \"свободном Тибете\" - с разрывом кооперации с нашими предприятиями, экономика района фактически развалилась, населению приходится буквально выживать скотоводством и сбором лекарственных трав, а Индия уже начинает поднимать давний территориальный спор за Аруначал Прадеш и требует пересмотра \"линии Мак-Магона\" в свою пользу...";
				}
			}
			if (!GlobalScript.inst.gameState.completedDecisions[6] && !GlobalScript.inst.gameState.completedDecisions[7])
			{
				if (GlobalScript.inst.gameState.allcountries[38].dev > 0)
				{
					fake_text = fake_text + "||Тайваньские сепаратисты спрятались за спины своих американских друзей, но они переоценили своих защитников и недооценили нашу решимость воссоединить Родину. Десант наших вооруженных сил отбил приграничные острова у берега Тайваня и выгнал оттуда сепаратистов, восстановив над этой территорией наш суверенитет. \"Территория Китая едина и неделима!\" - ответил Председатель " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " на бешенные крики империалистов. Правда, сам Тайвань мы силой отбить не сможем из-за расположенных там американских военных баз, а на переговоры он после такого точно не пойдет...";
				}
				else if ((GlobalScript.inst.gameState.allcountries[38].proprc && GlobalScript.inst.gameState.data[6] < 700 && GlobalScript.inst.gameState.data[16] >= 13 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.modifies[17].active) || GlobalScript.inst.gameState.completedDecisions[6])
				{
					fake_text = fake_text + "||Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " выдвинул важную теорию \"Одна страна - две системы\", в соответствии с которой Тайвань, Гонконг и Макао могут вернуться в лоно Родины с сохранением своей политической и экономической системы на 50 лет вперед и очень широкой автономией. Руководство Тайваня очень долго отказывалось от каких-либо переговоров с нами, но, наконец, нам удалось усадить их за круглый стол и прийти к соглашению. В обмен на формальное признание КНР независимости Китайской республики и её отказа от претензий на прибрежные острова, Тайвань официально отказывается от \"Трех народных принципов\" и признает политику \"Одна страна - две системы\". Уже начаты переговоры об основных принципах воссоединения Тайваня с Китаем (условия будут явно конфедеративными или даже более широкими) и о выводе с острова американских военных баз, однако окончательное объединение Родины произойдет нескоро...";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(66);
					}
				}
				else if (GlobalScript.inst.gameState.allcountries[38].proprc || GlobalScript.inst.gameState.allcountries[38].Torg)
				{
					fake_text = fake_text + "||Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", несмотря на яростное сопротивление многих консерваторов и сторонников жёсткой линии, всё же принял волевое решение признать независимость Тайваня и покончить с почти полувековой враждой. По мнению нового курса китайской дипломатии, Тайвань слишком долго был независимым и за это время отдалился от материкового Китая в культурном, экономическом и политическом плане и выстроил слишком крепкие отношения с мировым сообществом, чтобы можно было говорить о его принадлежности к КНР. Было заявлено о выработке полностью новых принципов добрососедских отношений КНР и Китайской Республики, которая в свою очередь отказалась от претензий на материковый Китай.";
				}
				else
				{
					fake_text += "||Сепаратистская \"Китайская республика\" продолжает удерживать Тайвань и прибрежные острова, опираясь на военную поддержку США и наотрез отказываясь от нормализации отношений с континентальным Китаем. Нам остается только вздыхать и посылать захватчикам \"последние китайские предупреждения\"...";
				}
			}
		}
		else if (number_of_e == 2)
		{
			name.text = "Новые территории";
			if (GlobalScript.inst.gameState.data[65] <= 0)
			{
				fake_text = "Гонконг и Макао продолжают оставаться колониями, соответственно, Великобритании и Португалии, оторванными от своей Родины. Западные колонизаторы отказываются от каких-либо переговоров по вопросу их возвращения нам, а на военные действия мы не рискуем, опасаясь вмешательства США и начала Третьей Мировой войны.";
			}
			else if (GlobalScript.inst.gameState.data[65] == 1)
			{
				fake_text = "Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " и ВСНП выдвинули важную теорию \"Одна страна - две системы\", в соответствии с которой Гонконг и Макао могут вернуться в лоно Родины с сохранением своей политической и экономической системы на 50 лет вперед и очень широкой автономией. Переговоры по этому вопросу с английской и португальской стороной были очень трудными и неоднократно срывались колонизаторами, но они все-таки увенчались успехом - 1 июля 1997 года нам будет возвращен суверенитет над Гонконгом, а 19 декабря 1999 года - и над Макао. Таким образом, исполниться великая мечта китайского народа - Сянган (Гонконг) и Аомынь (Макао) вернуться к нам - остается надеяться, что навсегда.";
			}
			else if (GlobalScript.inst.gameState.data[65] >= 2 && GlobalScript.inst.gameState.allcountries[0].stab == 1)
			{
				fake_text = "За время руководства страной " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", возможно, было совершено немало ошибок, но этот период войдет в историю Китая как \"Восстановление Родины\" - ибо была восстановлена историческая справедливость и Гонконг и Макао, которые сотни лет удерживались иностранными захватчиками, были возвращены Китаем. Теперь Сянган (Гонконг) и Аомынь (Макао) - снова вместе с Родиной-Матерью, и мы их больше никому никогда не отдадим!";
			}
			else if (GlobalScript.inst.gameState.data[65] >= 2)
			{
				fake_text = "Мастерство наших дипломатов и наша репутация в мире позволили, несмотря на серьёзное противодействие колониальных властей, добиться на переговорах с англичанами и португальцами передачи Гонконга и Макао с их полной интеграцией в состав КНР при гарантии сохранения частной собственности иностранцев. Переговоры по этому вопросу с английской и португальской стороной были очень трудными и неоднократно срывались колонизаторами, но они все-таки увенчались успехом - 1 июля 1997 года нам будет возвращен суверенитет над Гонконгом, а 19 декабря 1999 года - и над Макао. Таким образом, Сянган (Гонконг) и Аомынь (Макао) вернуться к нам - остается надеяться, что навсегда.";
			}
			if (GlobalScript.inst.gameState.data[62] <= 0)
			{
				fake_text += "||Штат Аруначал Прадеш продолжает оставаться в составе Индии, что Китай упорно отказывается признавать. Попытки переговоров по этому вопросу, в том числе при патронаже международных организаций, не увенчались успехом, так что ситуация на индо-китайской границе продолжает оставаться напряженной. Однако непохоже, чтобы стороны были заинтересованы в войне друг с другом...";
			}
			else if (GlobalScript.inst.gameState.data[62] == 1 || (GlobalScript.inst.gameState.allcountries[19].Torg && (GlobalScript.inst.gameState.data[91] == 1 || GlobalScript.inst.gameState.data[91] == 2 || GlobalScript.inst.gameState.data[91] == 3) && (!GlobalScript.inst.gameState.allcountries[31].Torg || GlobalScript.inst.gameState.allcountries[31].Gosstroy == 2 || GlobalScript.inst.gameState.allcountries[31].Gosstroy == 1 || GlobalScript.inst.gameState.allcountries[31].SubGosstroy == 8 || GlobalScript.inst.gameState.allcountries[31].SubGosstroy == 5)))
			{
				fake_text += "||Нам удалось договориться с руководством Индии о компромиссном решении территориального вопроса - Китай отказывается от претензий на штат Аруначал Прадеш, а Индия - на район Аксай Чин, занятый нами в ходе приграничного конфликта 1962 года и через который проходит важное шоссе Годао 219, соединяющее Синьцзян с Тибетом. Это решение, наконец, открыло дорогу к восстановлению добрососедских отношений двух самых крупных стран Азии и сильно разрядило напряженность в Азиатском регионе.";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(39);
				}
			}
			else if (GlobalScript.inst.gameState.data[62] == 2)
			{
				fake_text += "||Китай, наконец, положил конец давнему территориальному спору с Индией - решительными действиями наших вооруженных сил штат Аруначал Прадеш полностью возвращен в состав Китая. Руководству Индии, на фоне очередного обострения обстановки в сикхских районах страны и конфликта с Пакистаном, пришлось признать за нами права на эту территорию, хотя факт потери этого, весьма важного для страны штата, его очень сильно разозлил. По нашим данным, Индия тайно договаривается с США, СССР и Великобританией о больших поставках оружия и снаряжения для масштабного перевооружения своей армии. Против кого эти приготовления - гадать не приходится...";
			}
			else if (GlobalScript.inst.gameState.data[62] >= 3)
			{
				fake_text += "||Китай, наконец, положил конец давнему территориальному спору с Индией - решительными действиями наших дипломатов Аруначал Прадеш полностью возвращен в состав Китая. Руководству Индии, на фоне очередного обострения обстановки в сикхских районах страны и экономических проблем, пришлось признать за нами права на эту территорию, хотя факт потери этого, весьма важного для страны штата, очень сильно разозлил их население. По нашим данным, Индия тайно договаривается с США, СССР и Великобританией о больших поставках техники и снаряжения для масштабного перевооружения и расширение штата своих спецслужб. Против кого эти приготовления - трудно сказать: подавлять своё население или разжигать волнения в Аруначале Прадеше?";
			}
			if (GlobalScript.inst.gameState.data[167] == 0)
			{
				fake_text += "||Острова Дяоютай всё ещё продолжают находиться под владением Японии...";
			}
			else if (GlobalScript.inst.gameState.data[167] == 1)
			{
				fake_text += "||Нам удалось забрать себе Острова Дяоютай и теперь там гордо развевается наш флаг на нашей же Военно-Морской базе! Море - наше!!";
			}
			else if (GlobalScript.inst.gameState.data[167] == 2)
			{
				fake_text += "||Нам удалось найти компромисс с японской стороной. Теперь Острова Дяоютай демилитаризованы и находятся в совместном владении китайско-японской комиссии и получают инвестиции с обоих сторон, как и выгоду для обоих стран.";
			}
			if (GlobalScript.inst.gameState.allcountries[9].prosov && !GlobalScript.inst.gameState.completedDecisions[19])
			{
				fake_text += "||Монголия остаётся активным другом и партнёром Москвы несмотря ни на что.";
			}
			if (!GlobalScript.inst.gameState.allcountries[9].proprc && !GlobalScript.inst.gameState.completedDecisions[19] && !GlobalScript.inst.gameState.allcountries[9].prosov)
			{
				fake_text += "||Монголия проводит многовекторную политику, стараясь дружить как с СССР, так и с Китаем во благо своего народа.";
			}
			else if (GlobalScript.inst.gameState.allcountries[9].proprc && !GlobalScript.inst.gameState.completedDecisions[19])
			{
				fake_text += "||Монголия является полноправным равным членом китайской сферы влияния и ориентируется на Пекин в решении спорных и внешнеполитических вопросов.";
			}
			else
			{
				fake_text += "||Благодаря усердию и труду китайские и монгольские братья смогли вновь найти общий язык и объединиться под крышей единого дома в лице Китайской народной республики";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(109);
				}
			}
		}
		else if (number_of_e == 3)
		{
			name.text = "Судьба СССР";
			if (GlobalScript.inst.gameState.empires[1].now_leader == 3)
			{
				fake_text = "Щербицкий|Пришедший на смену Брежневу Владимир Щербицикий начал своё правление с чисток в Политбюро, приводя на освободившиеся места свои кадры из УССР, что встряхнуло застоявшийся брежневский аппарат и нарушило коррупционные связи между его членами. Удары по коррупции и припискам вкупе с административными талантами старого управленца обеспечили Союзу устойчивый рост экономики и благосостояния населения. Внешняя же и внутренняя политика Щербицкого мало чем отличались от брежневской - была усилена экономическая интеграция стран СЭВ, что положительно сказалось на всём содружестве, проведена разрядка в отношениях с КНР, предпринимаются осторожные и медленные попытки автоматизации планирования, но в целом всё стабильно. Союз стоит и собирается стоять ещё очень долго.";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(48);
				}
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 5)
			{
				fake_text = "Гришин|В конечном итоге, на смену старому правителю пришёл старый и опытный Виктор Гришин, любимец консервативных кругов. Для СССР ничего особо не изменилось - относительно устойчивый экономический рост позволял с каждым годом тратить больше денег на зерно и социальные расходы, предпринимаются очень осторожные и медленные попытки автоматизации планирования, подавляемые партократией, внешняя политика характеризовалась продолжением \"Доктрины Брежнева\", однако с упором на разрядку отношений с КНР. Вместе с тем, правление Гришина означало окончательное закрепление партократии, разгул кумовства, коррупции и приписок.";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(37);
				}
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 6)
			{
				fake_text = "Горбачёв|В конечном итоге, на смену старому правителю пришёл молодой и перспективный Михаил Горбачёв, один из реформаторских кадров Андропова. Однако ни одна реформаторская инициатива Горбачёва хорошо не закончилась - антиалкогольная кампания привела к упадку сельского хозяйства и массовому хождению суррогатов, политика Ускорения - к бездарной растрате средств и упадку промышленности, Гласность - к росту национализма и расцвету антисоветской лжи.";
				if (!GlobalScript.inst.gameState.startedDirectWarsNum.Any((KeyValuePair<int, bool> k) => k.Key == 10 && k.Value))
				{
					if (GlobalScript.inst.gameState.allcountries[51].isNATO)
					{
						fake_text += "Попытки то увеличить, то снизить роль государства в экономике, бездарное и бесконтрольное внедрение кооперативов, децентрализация и разрушение плановых механизмов привели к огромному внешнему долгу, развалу экономики, дефициту и обнищанию населения. Внешняя же политика характеризовалась подхалимством перед США и сдачей всех социалистических завоеваний, кульминацией чего стал роспуск ОВД и СЭВ. Сам же СССР ненадолго их пережил - взращенные Горбачёвым либералы и националисты, завоевав поддержку населения, в конце 1991 года объявили о роспуске СССР, фактически отобрав власть у горе-реформатора.";
					}
					else
					{
						fake_text += "Попытки то увеличить, то снизить роль государства в экономике, бездарное и бесконтрольное внедрение кооперативов, децентрализация и разрушение плановых механизмов привели к огромному внешнему долгу, развалу экономики, дефициту и обнищанию населения. В 1991 центробежные силы довели до того, что Горбачев решил подписать новый союзный договор. Но в августе 1991 года его отстранили от власти более прагматичные реформаторы, образовав ГКЧП. Янаев, став временным президентом, арестовал лидеров самых радикальных сепаратистских движений, в т.ч. Ельцина. После этого в феврале 1992 года президентом был избран Иван Полозков, прагматичный реформатор, который вывел экономику из падения в небольшой, но уверенный рост. В СССР установилась полурыночная демократия Советов по заветам эсеров.";
					}
				}
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(36);
				}
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 7)
			{
				fake_text = string.Format(GlobalScript.inst.new_events_text[1568], "\n");
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 8)
			{
				fake_text = "Лигачёв|В конечном итоге, на смену старому правителю пришёл опытный региональный руководитель Егор Лигачёв, один из реформаторских кадров Андропова. Он провозгласил политику Гласности, расширения демократизации и перехода к социалистической рыночной экономике по образцу ленинского НЭП. Однако все реформаторские инициативы Лигачёва пошли с большим трудом - антиалкогольная кампания привела к хождению суррогатов, хотя и позволила увеличить рождаемость и сократить преступность, политика Ускорения позволила увеличить промышленное производство, однако вызвала рост дефицита ТНП, Гласность - хотя и позволила расширить свободы, но привела к появлению антисоветских публикаций. Попытки перейти от директивных к индикативным механизмам в экономике, не до конца обдуманное внедрение кооперативов, децентрализация и нарушение плановых механизмов привели к спаду производства ТНП и обнищанию довольно существенной части населения.";
				if (GlobalScript.inst.gameState.allcountries[51].isNATO)
				{
					fake_text += "Внешняя же политика характеризовалась безуспешными попытками Разрядки с США и сокращением контроля за ОВД и СЭВ, что привело к росту в этих блоках сепаратистских тенденций. Сам же СССР находится в достаточно сложном положении, а попытки Лигачёва укрепить положение дел путем продвижения таких людей, как Борис Ельцин и Виталий Коротич, привели к появлению в КПСС легальной оппозиции, подрывающей единство партии. Пока что руководство страны контролирует ситуацию, но экономисты предупреждают, что в течении 25 лет возможен крупный кризис, который советские горе-реформаторы могут и не пережить...";
				}
				else if (GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[1].power && !GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					fake_text += "Несмотря на это, советская экономика выдержала это испытание, существенно расширив торговлю с Западной Европой. Страны СЭВ и ОВД не решились на свою Перестройку, несмотря на сокращение контроля над ними. Появилась национально-патриотическая консервативная оппозиция, которая противилась реформам. В конце концов после XXX съезда КПСС в 1993 Лигачева отстранили на пленуме, а вместо него был избран Аман Тулеев, который начал сокращать права республик, тормозить рыночные реформы и реабилитировать Сталина как российского государственника наравне с Иваном Грозным и Петром I. СССР был объявлен историческим российским государством государством, а русскими признали \"всех, кто думает на русском\".";
				}
				else
				{
					fake_text += "Несмотря на это, советская экономика выдержала это испытание, существенно расширив торговлю с Западной Европой. Страны СЭВ и ОВД не решились на свою Перестройку, несмотря на сокращение контроля над ними. Оппозицию удалось подавить, и реформы были продолжены в духе денгизма и НЭП. В конце концов на XXXIII съезде КПСС в 2000 Лигачев объявил о своей отставке. Его преемником стал Геннадий Зюганов, который стал поддерживать традиционные ценности, продолжил рыночные реформы и официально принял программу партии без упоминания построения коммунизма. ";
				}
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(61);
				}
			}
			else if (GlobalScript.inst.gameState.resultOfEvents[85] >= 3 && GlobalScript.inst.gameState.empires[1].now_leader == 2)
			{
				fake_text = string.Format(GlobalScript.inst.new_texts[692], "\n");
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 4)
			{
				if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[7].parts[2])
				{
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(140);
					}
					fake_text = string.Format(GlobalScript.inst.new_events_text[1565], "\n");
				}
				else if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[7].parts[0])
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1566], "\n");
				}
				else if (GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.allcountries[7].parts[1])
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1567], "\n");
				}
				else
				{
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(38);
					}
					fake_text = "Романов|В конечном итоге, на смену старому правителю пришел относительно молодой и перспективный партиец Григорий Романов, известный своими заслугами на посту главы Ленинградского обкома КПСС. Его приход ознаменовал начало внутрипартийных чисток от реформаторов, усиление контроля спецслужб и преследование диссидентов. Парадоксальным образом при нём же начались некоторые цензурные послабления в творческой сфере - в стране было открыто множество музыкальных клубов, по образцу Ленинградского рок-клуба, а кинорежиссёры стали свободней экспериментировать с новыми жанрами. Внешняя политика СССР стала более жёсткой и охарактеризовалась более активным распространением советского влияния и более жёсткой защитой советских интересов. ";
					if (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.data[16] == 11)
					{
						fake_text += "|Вдохновлённый успехом китайской автоматизации, Романов решил начать массовое внедрение механизмов автоматизации планирования, продолжив развитие АСУ и ЕГСВЦ, а также, достав с полки проект ОГАС, разработку и внедрение которого удалось завершить, несмотря на недовольство партократов. Романов руководил Советским Союзом до своей смерти в 2008 году, за это время многократно подняв международное влияние СССР, его экономическую мощь и благосостояние населения.";
						if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.data[16] == 11 && GlobalScript.inst.gameState.allcountries[1].isSEV)
						{
							achieves.GetComponent<achievements>().Set(35);
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[15].Gosstroy == 0 && GlobalScript.inst.gameState.allcountries[15].SubGosstroy == 0 && GlobalScript.inst.gameState.allcountries[4].Gosstroy == 1 && GlobalScript.inst.gameState.allcountries[4].SubGosstroy == 16)
					{
						fake_text += "|Увидев на личном примере провальность результатов экономической политики Венгрии и Югославии Романов решил пойти другим путём отличающимся от планов Андропова и начать массовое внедрение механизмов автоматизации планирования, продолжив развитие АСУ и ЕГСВЦ, а также, достав с полки проект ОГАС, разработку и внедрение которого удалось завершить, несмотря на недовольство партократов. Романов руководил Советским Союзом до своей смерти в 2008 году, за это время многократно подняв международное влияние СССР, его экономическую мощь и благосостояние населения.";
						if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.data[16] == 11 && GlobalScript.inst.gameState.allcountries[1].isSEV)
						{
							achieves.GetComponent<achievements>().Set(35);
						}
					}
					else
					{
						fake_text += "|После обвала цен на нефть в середине 80-х было принято решение о начале экономических реформ - за основу были взяты проекты андроповских планов реформ (основанных на реформе Косыгина-Либермана и экономических систем Югославии и Венгрии), что в совокупности подняло конкурентоспособность и гибкость советской экономики, однако и негативные эффекты децентрализации не заставили себя долго ждать: неэффективное распределение прибыли предприятиями, устаревание аппаратуры и механизмов из-за экономии предприятий на модернизации, развитие кумовства и коррупционных связей между звеньями производства-снабжения (когда снабжение стало первоочерёдно даваться по знакомству, а люди стали \"покупать\" места в очереди за сырьём). Однако, вместе с этим был введён категорический запрет на любую частную собственность и частный найм, что было даже вписано в Конституцию. Романов руководил Советским Союзом до своей смерти в 2008 году, за это время сильно подняв международное влияние СССР, его экономическую мощь и благосостояние населения. Впрочем, после его смерти, новые советские лидеры с прискорбием подтвердили наблюдения международных экспертов о том, что рост советской экономики уже несколько лет как крайне близок к нулю, и с этим надо что-то делать...";
					}
				}
			}
		}
		else if (number_of_e == 4)
		{
			name.text = "Советский соцлагерь";
			if (GlobalScript.inst.gameState.empires[1].now_leader == 4 && GlobalScript.inst.gameState.event_done[377])
			{
				fake_text = string.Format(GlobalScript.inst.new_events_text[1570], "\n", (GlobalScript.inst.gameState.allcountries[7].parts[1] || GlobalScript.inst.gameState.allcountries[1].parts[2]) ? GlobalScript.inst.new_events_text[1571] : null);
			}
			else if ((GlobalScript.inst.gameState.empires[1].now_leader == 3 || GlobalScript.inst.gameState.empires[1].now_leader == 5 || GlobalScript.inst.gameState.empires[1].now_leader == 4) && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[1].isOVD)
			{
				fake_text = "Для социалистического лагеря ничего особо не изменилось - СЭВ и ОВД продолжают оставаться стабильной альтернативой капиталистическим альянсам, а СССР - их неоспоримым лидером.";
			}
			else if ((GlobalScript.inst.gameState.empires[1].now_leader == 3 || GlobalScript.inst.gameState.empires[1].now_leader == 5 || GlobalScript.inst.gameState.empires[1].now_leader == 4) && GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[1].isOVD)
			{
				fake_text = "Вступление КНР в СЭВ и ОВД и рост её влияния в организации и в мире вызывают серьёзные опасения советского руководства за своё лидерство. В остальном же для социалистического лагеря ничего особо не изменилось - СЭВ и ОВД продолжают оставаться стабильной альтернативой капиталистическим альянсам.";
				if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[1].isOVD && GlobalScript.inst.gameState.relres)
				{
					achieves.GetComponent<achievements>().Set(5);
				}
			}
			else if (GlobalScript.inst.gameState.resultOfEvents[85] >= 3 && GlobalScript.inst.gameState.empires[1].now_leader == 2)
			{
				int num4;
				if (GlobalScript.inst.gameState.modifies[49].active && GlobalScript.inst.gameState.allcountries[92].okb)
				{
					num4 = 693;
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(161);
					}
				}
				else if (GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.influencePRC > 500 && GlobalScript.inst.gameState.modifies[6].active)
				{
					num4 = 694;
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(162);
					}
				}
				else if (GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					num4 = 695;
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(163);
					}
				}
				else
				{
					num4 = 696;
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(164);
					}
				}
				fake_text = string.Format(GlobalScript.inst.new_texts[num4], "\n");
			}
			else if (GlobalScript.inst.gameState.event_done[433])
			{
				fake_text = string.Format(GlobalScript.inst.new_events_text[1602], "\n");
			}
			else if ((GlobalScript.inst.gameState.empires[1].now_leader == 6 || GlobalScript.inst.gameState.empires[1].now_leader == 8) && ((GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.allcountries[1].econ && GlobalScript.inst.gameState.allcountries[1].okb) || (GlobalScript.inst.gameState.allcountries[5].Torg && !GlobalScript.inst.gameState.allcountries[2].prosov && !GlobalScript.inst.gameState.allcountries[4].prosov && (GlobalScript.inst.gameState.allcountries[1].econ || GlobalScript.inst.gameState.allcountries[1].okb))))
			{
				if (GlobalScript.inst.gameState.empires[1].now_leader == 8)
				{
					fake_text = "Для социалистического лагеря ничего особо не изменилось - СЭВ и ОВД продолжают оставаться альтернативой капиталистическим альянсам, а СССР - пока ещё их лидером.";
				}
				else
				{
					fake_text = "После прихода Горбачёва к власти в СССР соцлагерь начал медленно разваливаться, а без советской поддержки власть его членов начала шататься. Но налаженные отношения КНР и СССР вместе с торговлей с СЭВ позволили нам получить то, что не смог удержать Горбачёв. После роспуска ОВД и СЭВ мы настойчиво предложили Восточной Европе членство в наших альянсах на выгодных условиях, на что Румыния, Болгария, Венгрия, Польша и Чехословакия согласились.";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(6);
					}
				}
			}
			else if ((GlobalScript.inst.gameState.empires[1].now_leader == 6 || GlobalScript.inst.gameState.empires[1].now_leader == 8) && ((GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[1].isOVD) || (GlobalScript.inst.gameState.allcountries[5].Torg && !GlobalScript.inst.gameState.allcountries[2].prosov && !GlobalScript.inst.gameState.allcountries[4].prosov && (GlobalScript.inst.gameState.allcountries[1].isOVD || GlobalScript.inst.gameState.allcountries[1].isSEV))))
			{
				if (GlobalScript.inst.gameState.empires[1].now_leader == 8)
				{
					fake_text = "После прихода Лигачёва к власти в СССР соцлагерь начал медленно разваливаться, а без советской поддержки власть его членов начала шататься. Однако наше членство в ОВД и СЭВ помогло нам сохранить их в слегка изменённом виде. На тайном заседании мы разработали план по окончательному падению советского лидерства в СЭВ и ОВД. Само собой, опасаясь тёмного будущего, большинство стран с радостью согласилось и теперь СЭВ и ОВД составляют уже более равноправный и обновлённый соцлагерь с нашим лидерством. Правда теперь, вместо СССР, мы оказываем всю посильную помощь этим странам.";
				}
				else
				{
					fake_text = "После прихода Горбачёва к власти в СССР соцлагерь начал медленно разваливаться, а без советской поддержки власть его членов начала шататься. Однако наше членство в ОВД и СЭВ помогло нам сохранить их в слегка изменённом виде. После роспуска СЭВ и ОВД, мы предложили их членам создание новых блоков, взяв на себя все расходы на поддержку экономики наших старых друзей. Само собой большинство стран с радостью согласилось - ГДР, Румыния, Болгария, Чехословакия, Венгрия и Польша продолжают составлять уже более равноправный и обновлённый соцлагерь с нашим лидерством.";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(6);
					}
				}
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 6 || GlobalScript.inst.gameState.empires[1].now_leader == 8)
			{
				if (GlobalScript.inst.gameState.empires[1].now_leader == 8)
				{
					fake_text = "Для социалистического лагеря ничего особо не изменилось - СЭВ и ОВД продолжают оставаться альтернативой капиталистическим альянсам, а СССР - пока ещё их лидером.";
				}
				else
				{
					fake_text = "После прихода Горбачёва к власти в СССР соцлагерь начал медленно разваливаться, а без советской поддержки власть его членов начала шататься, что и завершилось в конце 80-х \"бархатными революциями\" и падением социалистических правительств Восточной Европы. ";
					if (GlobalScript.inst.gameState.allcountries[0].isNATO && GlobalScript.inst.gameState.allcountries[0].isEU)
					{
						fake_text += "И хотя эти страны теперь номинально являются нейтральными, их вступление в ЕС и НАТО не за горами.";
					}
					else if (GlobalScript.inst.gameState.allcountries[0].isNATO)
					{
						fake_text += "И хотя эти страны теперь номинально являются нейтральными, их вступление в НАТО не за горами.";
					}
					else if (GlobalScript.inst.gameState.allcountries[0].isEU)
					{
						fake_text += "И хотя эти страны теперь номинально являются нейтральными, их вступление в ЕС не за горами.";
					}
				}
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 7)
			{
				int num5 = 0;
				for (int num6 = 0; num6 < 100; num6++)
				{
					if ((num6 == 2 || num6 == 99 || num6 == 4 || num6 == 5) && GlobalScript.inst.gameState.allcountries[num6].isNATO)
					{
						num5++;
					}
				}
				if (num5 <= 0 && GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(139);
				}
				if (num5 == 4)
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1572], "\n");
				}
				else if (num5 > 0)
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1573], "\n");
				}
				else
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1635], "\n");
				}
			}
			else
			{
				fake_text = "Для социалистического лагеря ничего особо не изменилось - СЭВ и ОВД продолжают оставаться стабильной альтернативой капиталистическим альянсам, а СССР - их неоспоримым лидером.";
			}
		}
		else if (number_of_e == 5)
		{
			if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[0].power + GlobalScript.inst.gameState.empires[1].power > 20 && !GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.data[14] == 3)
			{
				achieves.GetComponent<achievements>().Set(15);
			}
			if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.influencePRC >= 400)
			{
				achieves.GetComponent<achievements>().Set(21);
			}
			name.text = "Холодная война";
			if (GlobalScript.inst.gameState.allcountries[7].isNATO)
			{
				fake_text = string.Format(GlobalScript.inst.new_events_text[1575], "\n");
			}
			else if (GlobalScript.inst.gameState.allcountries[1].isASEAN)
			{
				fake_text = string.Format(GlobalScript.inst.new_events_text[1576], "\n", (GlobalScript.inst.gameState.influencePRC + GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.empires[1].power) ? GlobalScript.inst.new_events_text[1577] : GlobalScript.inst.new_events_text[1578]);
			}
			else if (!GlobalScript.inst.gameState.allcountries[51].isNATO && GlobalScript.inst.gameState.allcountries[7].isOVD)
			{
				fake_text = string.Format(GlobalScript.inst.new_events_text[1604], "\n", (GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.influencePRC && GlobalScript.inst.gameState.empires[1].now_leader != 6) ? GlobalScript.inst.new_events_text[1606] : GlobalScript.inst.new_events_text[1605]);
			}
			else if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[0].power + GlobalScript.inst.gameState.empires[1].power <= 80 && GlobalScript.inst.gameState.empires[1].now_leader != 6)
			{
				fake_text = "Времена меняются, Холодная Война уходит в прошлое... Чтобы снова начаться с новой силой. И даже самым непримиримым врагам XX века - Советскому Союзу и Соединённым Штатам пришлось стать заклятыми друзьями, и вновь, как во времена Второй мировой войны, объединиться против общего врага – нового гегемона современного мира, восставшего из пепла и стремительно претендующего на мировое господство Китая. Пытаясь спасти остатки своего влияния, бывшие враги, начинают новый виток гонки вооружений: НАТО и ОВД проводят совместные учения, военные бюджеты СССР и США ежегодно удваиваются, при совместных усилиях американских и советских учёных разрабатывается новые типы ядерного оружия. Похоже, что новая масштабная война становится вопросом времени, но переживёт ли её человечество? ";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(17);
				}
			}
			else if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.influencePRC)
			{
				fake_text = "Холодная война близится к концу и похоже СССР одержит верх в этом долгом противостоянии, являясь самой влиятельной силой в мире. США стремительно теряет влияние на мир, долларовая система разваливается, члены НАТО проводят всё более независимую политику, а сама организация близка к роспуску. Не в последнюю очередь так произошло из-за активного вмешательства КНР в мировую политику и постепенного вытеснения ей американского влияния.";
			}
			else if (GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.influencePRC && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.influencePRC)
			{
				fake_text = "Последние несколько лет не прошли даром для СССР - его влияние на мир серьёзно расширилось и наверное однажды Холодная война всё-таки закончится его победой - США теряет своё влияние, мировое коммунистическое движение расширяется, а члены НАТО проводят всё более независимую политику. КНР же, несмотря на определённую внешнеполитическую активность так и не смогла выбиться в сверхдержавы, всё ещё оставаясь позади США и СССР, но может рано или поздно это изменится...";
			}
			else if (GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.influencePRC && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.influencePRC)
			{
				fake_text = "Последние несколько лет не прошли даром для США - их влияние на мир серьёзно расширилось и похоже они когда-нибудь выйдут победителями из Холодной войны - СССР теряет влияние в мире, в том числе на соцлагерь, а мировое коммунистическое движение слабеет. КНР же, несмотря на определённую внешнеполитическую активность так и не смогла выбиться в сверхдержавы, всё ещё оставаясь позади США и СССР, но может рано или поздно это изменится...";
			}
			else if (GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.influencePRC)
			{
				fake_text = "Холодная война близится к концу и похоже США одержит верх в этом долгом противостоянии, являясь самой влиятельной силой в мире. СССР теряет влияние на мир, в том числе на соцлагерь, который проводит всё более независимую политику, и на мировое коммунистическое движение. Не в последнюю очередь так произошло из-за активного вмешательства КНР в мировую политику и постепенного вытеснения ей советского влияния.";
			}
			else if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.empires[0].power)
			{
				fake_text = "Некогда имея среди своих сторонников только разрозненных партизан-маоистов, КНР всё же сумела пробиться и стать мировой сверхдержавой, получив большой вес в международных организациях и множество последователей в разных странах.||Противостояние же СССР и США постепенно отходит на второй план, однако похоже, что СССР выйдет из него победителем - США стремительно теряет влияние на мир, долларовая система разваливается, члены НАТО проводят всё более независимую политику, а сама организация близка к роспуску.";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(33);
				}
			}
			else if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.empires[1].power)
			{
				fake_text = "Некогда имея среди своих сторонников только разрозненных партизан-маоистов, КНР всё же сумела пробиться и стать мировой сверхдержавой, получив большой вес в международных организациях и множество последователей в разных странах.||Противостояние же СССР и США постепенно отходит на второй план, однако похоже, что США выйдет из него победителем - СССР теряет всякое влияние на мировое коммунистическое и просто антиамериканское движение, соцлагерь разваливается на глазах и скорее всего будет разделён между КНР и США, причём лучшая часть достанется нам.";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(33);
				}
			}
			if (!GlobalScript.inst.gameState.allcountries[0].isEU)
			{
				fake_text += string.Format(GlobalScript.inst.new_events_text[1579], "\n");
			}
			if (GlobalScript.inst.gameState.allcountries[85].isSocEU)
			{
				fake_text += string.Format(GlobalScript.inst.new_events_text[1580], "\n");
			}
			if (GlobalScript.inst.gameState.allcountries[15].Vyshi && GlobalScript.inst.gameState.allcountries[15].isEU && GlobalScript.inst.gameState.allcountries[15].SubGosstroy == 14)
			{
				fake_text += string.Format(GlobalScript.inst.new_events_text[1581], "\n");
			}
			else if (GlobalScript.inst.gameState.allcountries[20].puppetOf == 15)
			{
				fake_text += string.Format(GlobalScript.inst.new_events_text[1582], "\n");
			}
			else if (GlobalScript.inst.gameState.allcountries[20].spec == 1 && GlobalScript.inst.gameState.influencePRC >= 750)
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(154);
				}
				fake_text += string.Format(GlobalScript.inst.new_events_text[1583], "\n");
			}
			else if (GlobalScript.inst.gameState.allcountries[20].spec == 1 && GlobalScript.inst.gameState.influencePRC < 750)
			{
				fake_text += string.Format(GlobalScript.inst.new_events_text[1584], "\n");
			}
			else if (!GlobalScript.inst.gameState.allcountries[15].isMonatchy && (!GlobalScript.inst.gameState.event_done[455] || GlobalScript.inst.gameState.resultOfEvents[455] > 2) && GlobalScript.inst.gameState.allcountries[15].isSEV && (GlobalScript.inst.gameState.empires[1].now_leader != 6 || (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.influencePRC)) && !GlobalScript.inst.gameState.allcountries[15].prosov)
			{
				fake_text += "||80-е стали для Югославии переломным моментом: огромный внешний долг, последствия экономической политики Тито, попытки выправить положение с помощью рыночных реформ могли бы привести к катастрофическим последствиям, однако, благодаря своевременному вмешательству соцлагеря, этого удалось избежать. Югославия приняла решение вступить в СЭВ на правах полноценного члена, что, благодаря кооперации с соцлагерем, льготным ценам и советской помощи, помогло ей оживить экономику и начать постепенно выплачивать свои долги, а помощь от КГБ помогла унять националистов и либералов. Разумеется, это привело к отдалению СФРЮ от Запада и сближению с СССР.";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(65);
				}
			}
			else if (GlobalScript.inst.gameState.allcountries[15].Gosstroy == 0 && !GlobalScript.inst.gameState.allcountries[15].prosov && !GlobalScript.inst.gameState.allcountries[15].okb)
			{
				fake_text += "||80-е стали для Югославии тяжёлыми временами: огромный внешний долг, последствия экономической политики Тито, попытки выправить положение с помощью рыночных реформ и отсутствие влиятельных покровителей привели к ухудшению экономической ситуации, падению уровня жизни и, как следствие, росту национализма в республиках. Однако Югославия всё же сумела пережить эти испытания, не в последнюю очередь благодаря нашей помощи. Рыночные реформы ограничились продолжением экспериментов с хозрасчётом и децентрализацией, а в начале 90-х и вовсе прекратились. Националистам удалось сыграть на недовольстве народа и попытаться отделиться, однако все попытки сепаратизма были быстро пресечены ЮНА. Попытки США и Запада поддержать националистов привели к ухудшению отношений запада и СФРЮ, которая стала больше ориентироваться на СССР и Китай, хотя и продолжает сохранять свой нейтралитет.";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(65);
				}
			}
			else if (GlobalScript.inst.gameState.allcountries[7].isNATO)
			{
				fake_text += "||80-е стали для Югославии тяжёлыми временами: огромный внешний долг, последствия экономической политики Тито, попытки выправить положение с помощью рыночных реформ и отсутствие влиятельных покровителей привели к ухудшению экономической ситуации, падению уровня жизни и, как следствие, росту национализма в республиках. После нарастания серьёзной конфронтации обновлённого НАТО с Китаем Западные страны не решились вмешиваться в ситуацию внутри СФРЮ и ограничились \"беспокойствами о нарушении демократии и прав национальных меньшинств\", благодаря чему СФРЮ продолжает углублять военное и экономическое сотрудничество с Китаем.";
			}
			else if (GlobalScript.inst.gameState.allcountries[15].prosov)
			{
				fake_text += "||80-е стали для Югославии тяжёлыми временами: огромный внешний долг, последствия экономической политики Тито, попытки выправить положение с помощью рыночных реформ и отсутствие влиятельных покровителей привели к ухудшению экономической ситуации, падению уровня жизни и, как следствие, росту национализма в республиках. Попытки США и Запада поддержать националистов привели к ухудшению отношений, из-за чего Белград в конечном итоге решил присоединиться к Варшавскому договору, получив от Романова щедрое предложение: огромную финансовую помощь, льготные поставки сырья и полную защиту от Запада.";
			}
			else if (!GlobalScript.inst.gameState.allcountries[15].isMonatchy && (!GlobalScript.inst.gameState.event_done[455] || GlobalScript.inst.gameState.resultOfEvents[455] > 2) && GlobalScript.inst.gameState.allcountries[4].okb && GlobalScript.inst.gameState.empires[1].now_leader == 6)
			{
				fake_text += "||80-е стали для Югославии тяжёлыми временами: огромный внешний долг, последствия экономической политики Тито, попытки выправить положение с помощью рыночных реформ и отсутствие влиятельных покровителей привели к ухудшению экономической ситуации, падению уровня жизни и, как следствие, росту национализма в республиках. Попытки США и Запада поддержать националистов привели к ухудшению отношении, из-за чего Белград стал больше ориентироваться на Россию и Китай, полноправно присоединившись к программе 16+1.";
			}
			else if (!GlobalScript.inst.gameState.allcountries[15].isMonatchy && (!GlobalScript.inst.gameState.event_done[455] || GlobalScript.inst.gameState.resultOfEvents[455] > 2) && GlobalScript.inst.gameState.allcountries[15].Torg && (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power || GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[0].power || (GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.empires[1].power + GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[0].power)))
			{
				fake_text += "||80-е стали для Югославии тяжёлыми временами: огромный внешний долг, последствия экономической политики Тито, попытки выправить положение с помощью рыночных реформ и отсутствие влиятельных покровителей привели к ухудшению экономической ситуации, падению уровня жизни и, как следствие, росту национализма в республиках. Однако Югославия всё же сумела пережить эти испытания, не в последнюю очередь благодаря нашей помощи. Рыночные реформы не приобрели такого большого размаха, а либеральные политические были быстро саботированы и задавлены военными и консерваторами. Впрочем избежать гражданской войны всё равно не удалось, и Словения с Хорватией всё же смогли получить независимость по её итогам, однако в остальных регионах мятежи были вскоре подавлены ЮНА. Попытки американцев поддерживать сепаратистов привели к ухудшению их отношений с Югославией, которая с каждым годом всё больше налаживает сотрудничество с СССР и КНР. СФРЮ, пусть и уменьшившись в размерах, продолжает существовать.";
			}
			else if (!GlobalScript.inst.gameState.allcountries[15].isMonatchy && (!GlobalScript.inst.gameState.event_done[455] || GlobalScript.inst.gameState.resultOfEvents[455] > 2))
			{
				fake_text += "||80-е стали для Югославии тяжёлыми временами: огромный внешний долг, последствия экономической политики Тито, попытки выправить положение с помощью рыночных реформ и отсутствие влиятельных покровителей привели к ухудшению экономической ситуации, падению уровня жизни и, как следствие, росту национализма в республиках. Неспособность правительства стабилизировать ситуацию привела в итоге к взятию власти провоенной фракцией и началу гражданской войны между центральным правительством (которое вскоре оказалось представлено фактически одной Сербией) и хорватскими, словенскими и албанскими националистами. Неизвестно, кто вышел бы из неё победителем, так как точку в ней и в истории Югославии поставили войска НАТО своей операцией против Сербии. Единое балканское государство перестало существовать, а почти все его бывшие республики отныне ориентируются на запад и США.";
			}
		}
		else if (number_of_e == 6)
		{
			name.text = "Сладкая жизнь";
			if (GlobalScript.inst.gameState.data[5] <= 400)
			{
				fake_text = "Ваше правление не принесло Китаю особых улучшений в жизни простых его граждан - наш уровень жизни по-прежнему на уровне начала 70-х. Периодически случаются продовольственные кризисы, жителям деревень зачастую незнакомы удобства современной жизни, да и в городах, несмотря на большой разрыв с деревней, положение не самое лучшее - простой народ живёт в плохо оборудованных домах, нередко в коммуналках и трущобах, населению редко доступны товары зажиточных классов, а о какой-то роскоши могут говорить только высокие государственные работники и руководящие кадры предприятий.";
			}
			else if (GlobalScript.inst.gameState.data[5] <= 700)
			{
				fake_text = "Ваше правление ознаменовалось подъёмом уровня жизни китайских граждан - были наконец решены проблемы с продовольственным обеспечением, большей части населения стали повсеместно доступны товары зажиточного класса, а жилищные условия в городах для многих китайцев значительно улучшились, хотя многим обычным рабочим всё ещё приходится ютиться в тесных коммуналках и трущобах. В деревнях всё обстоит похуже, однако уже идёт активное развитие инфрастуктуры, современная застройка деревень и подведение к ним современных коммуникаций, ожидается, что в скором времени мы достигнем японского уровня жизни. Народ всегда будет помнить ваш вклад в его светлое будущее.";
			}
			else
			{
				fake_text = "Ваше правление ознаменовалось колоссальным подъёмом уровня жизни китайских граждан - были не просто решены проблемы продовольственного обеспечения, но и достигнут уровень, когда практически всем стали доступны многие товары богатого и зажиточного класса и всё больше людей обзаводятся и предметами роскоши. Полным ходом идёт преодоление разрыва города и деревни - была проведена повсеместная электрификация, проведены современные коммуникации, идёт активная застройка деревень современными домами. Теперь у каждого честного труженика есть достойное жилище и питание, Китай уже опередил все страны Азии, включая Японию, по уровню жизни, а для народа вы навсегда останетесь любимым правителем, подарившим Китаю развитие и новую жизнь.";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(47);
				}
			}
		}
		else if (number_of_e == 7)
		{
			if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.OAR && GlobalScript.inst.gameState.allcountries[14].oar && GlobalScript.inst.gameState.allcountries[35].oar && GlobalScript.inst.gameState.allcountries[13].oar && GlobalScript.inst.gameState.data[85] == 3)
			{
				achieves.GetComponent<achievements>().Set(13);
			}
			name.text = "Мировая ситуация";
			if (GlobalScript.inst.gameState.allcountries[10].numberOfSpecialEnding < 0)
			{
				if (GlobalScript.inst.gameState.data[83] <= 0 && !GlobalScript.inst.gameState.allcountries[46].Vyshi && GlobalScript.inst.gameState.allcountries[46].Gosstroy == 2)
				{
					fake_text = "После долгожданного мирного объединения Кореи и вывода американских войск начался долгий и тернистый путь интеграции. Объединить социалистическую самодостаточную КНДР с основанной на иностранном капитале РК оказалось не так то просто, что породило систему множества сдержек и противовесов. Другой проблемой является внешняя политика, где \"южане\" выступают за сохранение дружеских контактов с Западом, а \"северяне\" - за независимую внешнюю политику и становление новой силой в регионе. Однако радующихся объединению и подлинной независимости рядовых корейцев нюансы политики сейчас мало волнуют.";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(50);
					}
				}
				else if (GlobalScript.inst.gameState.data[83] <= 0 && (!GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.empires[1].now_leader == 6) && GlobalScript.inst.gameState.allcountries[10].Gosstroy == 1)
				{
					fake_text = "На Корейском полуострове ничего особо не изменилось - противостояние двух Корей продолжается. И именно оно привело в начале 2000-х к тому, что для защиты от американской агрессии в КНДР было разработано ядерное оружие. КНДР продолжает проводить нейтральную внешнюю политику, поддерживая хорошие отношения и с Пекином и с Москвой, но не присоединяясь ни к одному лагерю.";
				}
				else if (GlobalScript.inst.gameState.data[83] <= 0 && GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.empires[1].now_leader != 6 && GlobalScript.inst.gameState.allcountries[10].Gosstroy == 1)
				{
					fake_text = "На Корейском полуострове ничего особо не изменилось - противостояние двух Корей продолжается. Для получения преимущества в нём в 90-х, видя, что раскол между КНР и СССР окончательно преодолён, КНДР вступила в СЭВ, а вскоре и в ОВД. Это обеспечило ей экономический подъём и надёжную защиту от американской агрессии. ";
				}
				else if (GlobalScript.inst.gameState.data[83] <= 0 && (!GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.empires[1].now_leader == 6) && GlobalScript.inst.gameState.allcountries[10].Gosstroy == 2)
				{
					fake_text = "На Корейском полуострове ничего особо не изменилось - противостояние двух Корей продолжается, хотя и в более мягкой форме. В КНДР тем временем были проведены масштабные реформы, предполагающие децентрализацию планирования, гражданскую либерализацию, а скоро планируется открытие СЭЗ. Несмотря на то, что эти действия улучшили отношения КНДР с США и проамериканскими соседями, в начале 2000-х для защиты от американской агрессии в КНДР было разработано ядерное оружие. КНДР продолжает проводить нейтральную внешнюю политику, поддерживая хорошие отношения и с Китаем и с Москвой, но не присоединяясь ни к одному лагерю.";
				}
				else if (GlobalScript.inst.gameState.data[83] <= 0 && GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.empires[1].now_leader != 6 && GlobalScript.inst.gameState.allcountries[10].Gosstroy == 2)
				{
					fake_text = "На Корейском полуострове ничего особо не изменилось - противостояние двух Корей продолжается, хотя и в более мягкой форме. В КНДР тем временем были проведены масштабные реформы, предполагающие децентрализацию планирования, гражданскую либерализацию, а скоро планируется открытие СЭЗ. Несмотря на то, что эти действия улучшили отношения КНДР с США и проамериканскими соседями, в 90-х, видя, что раскол между КНР и СССР окончательно преодолён, КНДР вступила в СЭВ, а вскоре и в ОВД. Это обеспечило ей экономический подъём и надёжную защиту от американской агрессии. ";
				}
				else if (GlobalScript.inst.gameState.data[83] == 1)
				{
					fake_text = "После успешного объединения Кореи под знаменем КНДР и изгнания американских захватчиков наступило долгожданное возрождение и развитие Кореи, а уже в 90-х страна объявила о разработке собственного ядерного оружия. ";
					if (GlobalScript.inst.gameState.empires[1].now_leader == 6)
					{
						fake_text += " КНДР, защищаемая ядерной дубиной, довольно быстро стала проводить независимую внешнюю политику. Корея активно пытается стать новой независимой силой в регионе и в мировой политике и, кажется, со временем ей это удастся.";
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(16);
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[10].econ)
					{
						fake_text += " Вскоре КНДР вступила в наш альянс, что ещё больше подстегнуло экономику страны. В остальном же КНДР старается проводить независимую политику, отстаивая собственные интересы.";
					}
					else
					{
						fake_text += " Вскоре КНДР вступила в СЭВ, что ещё больше подстегнуло экономику страны. В остальном же КНДР старается проводить независимую политику, отстаивая собственные интересы.";
					}
				}
				else if (GlobalScript.inst.gameState.data[83] == 2)
				{
					fake_text = "После поражения КНДР и объединения Кореи под знаменем Республики США первым делом ввели дополнительный контингент на присоединённые территории для борьбы с растущим партизанским движением. Партизаны контролируют многие области на севере и изматывают американцев постоянными атаками. Кажется, долгожданное возрождение Кореи будет ещё очень нескоро. ";
					if (GlobalScript.inst.gameState.empires[1].now_leader != 6 || GlobalScript.inst.gameState.data[14] < 3)
					{
						fake_text += " А вскоре \"для защиты мира и американских интересов в регионе\" на полуостров было введено американское ядерное оружие, что вызвало недовольство многих стран.";
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(51);
						}
					}
				}
			}
			else
			{
				fake_text = "Ничего примечательного в корейском вопросе не произошло";
			}
			if (GlobalScript.inst.gameState.allcountries[37].SubGosstroy == 17 && GlobalScript.inst.gameState.allcountries[37].okb)
			{
				fake_text += "|При прямой поддержке Китая в Союзном Государстве Палестины и Израиля была поставлена власть состоящая из традиционалистских аграристов, отвергают капиталистическую систему экономики. Но китайским властям этого было недостаточно, их не устраивал слишком медленный темп реформ. Поэтому был продавлен вариант создания Батальонов Смерти, куда стали набирать бедноту, и масштабной чистки Палестино-Израильской армии официально \"для защиты от реакционных сил, засевших в армии\".|Год за годом постепенно эта организация разрасталась год за годом замещая собой армию, а возглавляли её китайские советники и завербованные китайскими спецслужбами лица. И когда организация стала достаточно сильной по мнению иностранных кураторов, то настал час реализации плана: в одну ночь Батальоны Смерти захватили все правительстве и административные здания и жилые центры политической власти всех городов и регионов страны и казнили всех на месте. Затем арестовали и низложили остатки армии. И наконец-то подожгли все города и селения подорвав всё что только можно. Взволнованные граждане выбежали из своих домов, где их уже встречали отряды Батальона Смерти и уводили в специальные палаточные лагеря. Там всё население страны было разделено на несколько сотен племён, возглавляемых руководителями Батальонов Смерти. А каждой семье выдали по лошади, повозке и стопок твёрдой тёплой ткани. Так в Палестине и Израиле наступил период возвращения к истокам - к кочевой племенной жизни. А оставшиеся куски цивилизации сохранились только на территориях добычи воды и незначительных поселений рядом для поддержки вододобычи под контролем Батальонов Смерти. Деньги в стране также были отменены, им на смену вернулся бартер.|<color=red>\"Дети мои, вы наконец-то нашли Землю Обетованную, завещанную нам богом\"</color>.";
				achieves.GetComponent<achievements>().Set(160);
			}
			else if (GlobalScript.inst.gameState.data[85] == 0)
			{
				fake_text += "|Конфликт между палестинцами и Израилем так и оставался нерешённым, пока восстание палестинцев в 1987-1993 годах, известное как Первая палестинская интифада и жёстко подавленное Израилем, вынудило стороны на переговоры. По итогам соглашений в Осло была создана Палестинская Национальная Администрация в качестве автономии палестинских территорий, а ООП прекратила террористические атаки. Однако нежелание Израиля идти на уступки и продолжение терроризма со стороны отдельных организаций привели к срыву дальнейшего мирного процесса и ко Второй палестинской интифаде в 2000-2005 годах.";
			}
			else if (GlobalScript.inst.gameState.data[85] == 1)
			{
				fake_text += "|Наше вмешательство и принуждение сторон к переговорам положило начало урегулированию палестинско-израильского конфликта. По итогам соглашений в Пекине была создана Палестинская Национальная Администрация в качестве автономии палестинских территорий, а ООП прекратила террористические атаки. Однако нежелание Израиля идти на уступки и продолжение терроризма со стороны отдельных организаций привели к срыву дальнейшего мирного процесса и к восстанию палестинцев в 2000-2005 годах, изветсному как Палестинская интифада.";
			}
			else if (GlobalScript.inst.gameState.data[85] == 2)
			{
				fake_text += "|Наше вмешательство и принуждение сторон к переговорам положило начало урегулированию палестинско-израильского конфликта. По итогам соглашений в Пекине было начато создание Государства Палестины на части израильских территорий. Передача контроля над этими территориями палестинской администрации сопровождалась множеством эксцессов, проблемой по-прежнему является статус Восточного Иерусалима, создание коридора между Сектором Газа и Западным берегом реки Иордан и продолжающиеся атаки террористических организаций. Отношения между двумя государствами по-прежнему натянутые, однако уже есть определённый прогресс в достижении долгожданного мира.";
			}
			else if (GlobalScript.inst.gameState.data[85] == 3)
			{
				fake_text += "|Наше вмешательство и принуждение сторон к переговорам положило начало урегулированию палестинско-израильского конфликта. По итогам соглашений в Пекине было решено создать Союзное Государство Палестины и Израиля с двумя государственными языками и развитым местным самоуправлением. Предметом острых споров стали границы субъектов государства и статус Иерусалима, проблемы также доставляют некоторые террористические группировки, несогласные с таким исходом. Другой проблемой является внешняя политика СГПИ, которая вызывает жаркие споры в новообразованных государственных органах. Отношения между народами в новом государстве ещё долго будут натянутыми, однако международный контроль и пропаганда равенства и братства рано или поздно положат конец этому конфликту.";
			}
			else
			{
				fake_text = "Ничего примечательного в арабо-израильском конфликте не произошло";
			}
			if (GlobalScript.inst.gameState.allcountries[30].parts[0])
			{
				fake_text += string.Format(GlobalScript.inst.new_events_text[1601], "\n");
			}
			else if (GlobalScript.inst.gameState.OAR && GlobalScript.inst.gameState.allcountries[14].oar && GlobalScript.inst.gameState.allcountries[35].oar && GlobalScript.inst.gameState.allcountries[13].oar)
			{
				fake_text += "|Долгожданное объединение главных арабских государств в Объединённую Арабскую Республику, основанную на принципах арабского социализма, наконец состоялось. Объединить государства с похожими системами в одно оказалось не особо сложно, и хотя борьба между сторонниками централизации и местными элитами периодически подтачивает стабильность страны, интеграция в целом прошла успешно. Объединив экономику нескольких стран и создав единую армию, ОАР стала сильнейшей страной на Ближнем Востоке и весомым членом мирового сообщества. ОАР старается поддерживать дружбу с социалистическими странами, а её растущие аппетиты расшатывают и без того хрупкий мир в регионе, Израиль укрепляет границы, а некоторые поговаривают о скором вторжении ОАР в Саудовскую Аравию и Судан.";
			}
			else if (GlobalScript.inst.gameState.OAR)
			{
				fake_text += "|Первоначальное ликование от создания единого арабского государства сменилось осознанием кучи проблем - в ОАР вступили не все арабские страны, а вступившие начали активно бороться за власть в новом государстве. Борьба сторонников централизации и местных элит привела к куче законов об автономиях и особых статусах, что не лучшим образом сказалось на эффективности управления. ОАР продолжает существовать, однако её члены проводят всё более независимую политику, а объединение с каждым годом становится больше номинальным.";
			}
			else if (GlobalScript.inst.gameState.data[85] == 2)
			{
				fake_text += "|Арабские государства продолжают оставаться разрозненными, а про планы объединения уже никто не вспоминает.";
			}
			else
			{
				fake_text = "Ничего примечательного в арабском вопросе не произошло.";
			}
		}
		text_t.text = Text(fake_text, 83);
	}

	private void BadEnding()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (GlobalScript.inst.gameState.data[35] == 1)
			{
				name.text = "Uprising";
				fake_text = "你的政策使中国人民的愤怒与日俱增。\n你试图不择手段地平息不断高涨的抗议，\n却失败了，并引发了公开起义；起义很快得到军队和部分党内成员的\n支持。高层党政人士与将军们将你逮捕并在法庭上审判，\n宣布成立临时政府。中国的未来一片昏暗……";
			}
			else if (GlobalScript.inst.gameState.data[35] == 2)
			{
				name.text = "党内政变";
				fake_text = "你的所作所为使党越来越愤怒。\n高层党内人士对你忍无可忍，组织了批判你的会议，\n党内表决通过了你的辞职。\n如今你成了领退休金的人——无人问津；\n而你原来的位置被一名折中候选人占据，\n试图在各派对立之间周旋。";
			}
			else if (GlobalScript.inst.gameState.data[35] == 3)
			{
				name.text = "核战争";
				fake_text = "你走到了那枚珍贵的红色按钮前，按下并发射了导弹。\n你的打击摧毁了美苏之间那脆弱的平衡；\n在你之后，他们也互相进行了核打击。\n大多数城市已被毁灭，地球遭到污染；幸存者中的大多数都躲进了掩\n体与防空洞。";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(18);
				}
			}
			else if (GlobalScript.inst.gameState.data[35] == 4)
			{
				name.text = "Genocide";
				fake_text = "在你的领导时期，中国的人口——曾是世界上最多的——急剧下降。\n这件事不可能被忽视：你越来越频繁地被指控犯下种族灭绝罪；\n最终，当党也厌倦了这一切，你被逮捕并送上法庭。";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(49);
				}
			}
			else if (GlobalScript.inst.gameState.data[35] == 6)
			{
				name.text = "机器背后都有一个人";
				fake_text = "同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "决定避免可能的流血冲突，并以健康原因主动辞职。\n旧领导人被新的取代，但新者却远不如前者积极。\n国内政治中的审查进一步收紧，任何偏离总路线的行为都被彻底压制。\nIECS被限制在对生产与武装力量的自动化上；\n而如今每一台机器后面都有一个人，因此国家机器甚至不得不大幅扩\n充。即便如此，中华人民共和国的经济仍在发展，\n但每年的增长率却一年比一年下滑；总有一天，\n中国经济的所有问题都会暴露出来。\n中国的未来一片迷雾。";
			}
			else if (GlobalScript.inst.gameState.data[35] == 7)
			{
				name.text = GlobalScript.inst.new_events_text[533];
				fake_text = GlobalScript.inst.new_events_text[534];
			}
			else if (GlobalScript.inst.gameState.data[35] == 5)
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(55);
				}
				name.text = "新秩序";
				if (GlobalScript.inst.gameState.party_number[0] > GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] > GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] > GlobalScript.inst.gameState.party_number[4])
				{
					fake_text = "在全国人大（NPC）的选举中，中共（CPC）\n未能取得成功；来自MCPC的激进共产党人乘着民粹浪潮获胜，\n赢得相对多数票。MCPC候选人也赢得总统选举。\n凭借总统职位以及议会中的相对多数，MCPC组建了一个准联合政\n府：其他党派的代表只获得3个小职位。\n新政府宣布其目标是回归毛主义——在中国及全世界建设社会主义与\n共产主义，并与苏联修正主义者和美国帝国主义者展开决定性的对抗。\n作为回归社会主义政策的一部分，首先决定恢复一党制：\n摧毁资产阶级共和国，并对修正主义者与资本家发动新的文化大革命。\n被列为修正主义者与资本家的名单包括除MCPC以外的所有党派。\n其他党派试图组织针对毛主义者及其政策的公开行动，\n呼吁美国与苏联予以支持，但这一倡议在军队支持下、\n并由MCPC军事组织中的武装青年配合下，\n被警方压制。作为回应，毛主义者在全国范围内组织了更多支持毛主\n义事业的集会，在那里他们强行围捕所有前来声援毛主席事业的人。\n由国家与党领导的人民击败了反对党总部：\n他们的部分领导人和积极分子被杀，部分则被送往农村。\n中共领导层同样未能躲过“公正的民愤”：\n领导人遭到“羞辱走廊”的审判，随后公开忏悔修正主义——并立刻\n为此悔悟——之后被流放到人民公社。\n美国与苏联谴责这类行动；中国政府道歉，\n把责任推给激进派，称“无法遏制人民的愤怒，\n也并不寻求阻止人民与其敌人作战，担心让诚实的人陷入危险”。\n然而，当反对力量被摧毁后，武装力量进入北京及其他主要城市，\n战斗中四散开来——不愿把权力交到MCPC的国家战斗组织手中；\n该组织也正式自愿解散。\n中国历史将迎来一个新的时代：经济改革将与国家对社会的极端强化、\n党对国家的极端强化相结合；在争夺中国社会主义文化、\n以及通过专政、全面控制与对毛、意识形态和党的无私奉献的新文化\n来建设社会主义与共产主义的斗争中，清除保守传统主义与自由多元\n主义。";
				}
				else if (GlobalScript.inst.gameState.party_number[0] > 1500)
				{
					fake_text = "在全国人大（NPC）的历次选举中，中共（CPC）\n未能取得成功；而在议会选举中，胜利由MCPC的激进共产党人赢\n得——在民粹浪潮中获得绝对多数。\nMCPC候选人也赢得总统选举。\n凭借总统职位以及议会中的绝对多数，MCPC组建了同质化政府。\n新政府宣布其目标是回归毛主义——在中国及全世界建设社会主义与\n共产主义，并与苏联修正主义者和美国帝国主义者展开决定性的对抗。\n作为回归社会主义政策的一部分，首先决定恢复一党制：\n摧毁资产阶级共和国，并对修正主义者与资本家发动新的文化大革命。\n被列为修正主义者与资本家的名单包括除MCPC以外的所有党派。\n其他党派试图组织针对毛主义者及其政策的公开行动，\n呼吁美国与苏联予以支持，但这一倡议在军队支持下、\n并由MCPC军事组织中的武装青年配合下，\n被警方压制。作为回应，毛主义者在全国范围内组织了更多支持毛主\n义事业的集会，在那里他们强行围捕所有前来声援毛主席事业的人。\n由国家与党领导的人民击败了反对党总部：\n他们的部分领导人和积极分子被杀，部分则被送往农村。\n中共领导层同样未能躲过“公正的民愤”：\n党内领导人遭到“羞辱走廊”的审判，随后承认修正主义——并立刻\n为之悔悟——之后被流放到人民公社。\n美国与苏联谴责这类行动；中国政府道歉，\n把责任推给激进派，称“无法遏制人民的愤怒，\n也并不寻求阻止人民与其敌人作战，担心让诚实的人陷入危险”。\n然而，当反对力量被摧毁后，武装力量进入北京及其他主要城市，\n战斗中四散开来——不愿把权力交到MCPC的国家战斗组织手中；\n该组织也正式自愿解散。\n中国历史将迎来一个新的时代：经济改革将与国家对社会的极端强化、\n党对国家的极端强化相结合；在争夺中国社会主义文化、\n以及通过专政、全面控制与对毛、意识形态和党的无私奉献的新文化\n来建设社会主义与共产主义的斗争中，清除保守传统主义与自由多元\n主义。";
				}
				else if (GlobalScript.inst.gameState.party_number[4] > 1500)
				{
					if (GlobalScript.inst.gameState.data[14] < 4)
					{
						fake_text = "中国新的自由民主政府宣布：战胜旧秩序、\n实现政权自由化，是其首要且最重要的目标。\n政府推行面向自由市场的经济改革，这对经济造成了严重打击：\n旧的联系崩塌，导致体系失序；但年轻的公民社会在反腐败与反欺诈\n方面的斗争，叠加来自美国与西方的大额贷款和巨额投资，\n使局势得以逐步应对，进入某种增长状态——在一定程度上弥补了此\n前的衰退，甚至可以谈到经济增长与社会财富增加的一些“成就”。\n然而，收入的巨大份额集中在一小撮人手中——新兴寡头；\n与此同时，数以百万计的人离开中国，期望在海外找到更好的生活。\nDPC正在取消公共生活各领域的国家控制，\n包括政治生活领域——在那里，少数反对力量有机会运作。\n如今国家被称为“中华人民共和国民主共和国”，\n正在形成自由民主政体。\n与美国的关系变得友好，而与苏联的关系则恶化。\n美国正成为中国的主要经济伙伴、世界市场中年轻参与者的主要债权\n人和投资者，其对发达国家的依赖也在不断加深。\n苏联逐步中断与中国的贸易关系，并在苏中边境增加军事存在。";
					}
					else
					{
						fake_text = "中国新的自由民主政府宣布：加强并完善民主，\n是其首要目标。政府坚持“国内自由、对外开放”的市场路线；\n经济继续增长，但GDP相当不稳定——因为危机会时不时地强烈冲\n击它。与此同时，大多数人口试图适应市场，\n而只有一小部分人变得更富；外资则继续抽取本国资源。\nDPC在公共生活各领域（包括政治生活）\n保障自由，创造条件让反对派得以“半自由”地活动；\n尽管在危机时期，政府对激进组织仍施加强有力的行政压力。\n如今国家被称为“中华人民共和国民主共和国”，\n维持自由民主政体。与美国的关系仍保持友好，\n而与苏联——则相当敌对。\n美国仍是DRC的主要经济伙伴、世界市场中年轻参与者的主要债权\n人和投资者，其对发达国家的依赖正在增长。\n苏联逐步中断与中国的贸易关系，并在苏中边境增加军事存在。";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中失利的中共（CCP）仍能维持部分人口的支持，\n尤其是工人阶级，并保持党内队伍的团结；\n在DPC掌权期间，党纲路线以及与民主党人的坚决对抗，\n促使整个反对派都围绕中共集结。\n然而，中共的活动受到多项法院裁决的严厉限制，\n其数名领导人也因各种（且显然是捏造的）\n指控被逮捕。";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中落败后，中共（CPC）仍能保住民众支持与党内团结；\n党内路线以及对DPC部分自由化政策的支持，\n使中共得以在几年内以“建设性反对派”的身份继续留在政治舞台上，\n并与DPC和CZGP在联合阵营中结成同盟。";
					}
					else
					{
						fake_text += "在选举中失利的中共（CCP）未能维持党内团结，\n同时也失去了大部分民众的支持，并分裂成三个党派。\n在DPC掌权时期，其中一派支持民主党，\n另外两派则站在反对方。\n近几年，他们重新合拢以恢复中共，但中国共产党人距离全面复兴仍\n然很远……";
					}
				}
				else if (GlobalScript.inst.gameState.party_number[3] > GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[3] > GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[3] > GlobalScript.inst.gameState.party_number[4])
				{
					if (GlobalScript.inst.gameState.data[14] < 4)
					{
						fake_text = "中华人民共和国新成立的社会—爱国政府宣布，\n其首要且最重要的目标是：在多民族人口的基础上维护国家统一，\n并实现社会繁荣的可持续增长。\n政府还宣布朝向社会导向型市场经济的经济改革——这对经济是一次\n沉重打击，旧的纽带崩塌导致体系失序；\n而维持社会保障的努力又引发预算赤字，\n最终在腐败与诈骗的普遍爆发中导致中国经济崩溃。\n只有来自美国和西方的贷款与投资才能最终应对局势，\n使经济进入快速增长状态；这在一定程度上弥补了此前的衰退，\n甚至让我们能够谈论经济增长与社会财富增加的某些“成就”。\n但巨额收入却流向中国的经济伙伴。\n鉴于需要维护国家统一，CZGP将实行联邦化并推进进一步的民主\n改革：在保持国家监管的同时，在各领域引入更多自由。\n在中国，正在形成具有中国特色的社会主义制度。\n对美国关系升温，对苏联关系转冷。\n美国正成为中国的主要经济伙伴、世界市场上年轻参与者的主要债权\n人和投资者；其对发达国家的依赖不断加深。\n但与此同时，随着合作的深化，关于归还香港与澳门、\n以及台湾地位的谈判正在进行，似乎将以对中国有利的折中告终。\n苏联继续与中国就建立全面外交关系进行谈判，\n但在美国的怂恿下，中华人民共和国要求领土让步，\n而苏联一再拒绝。";
					}
					else
					{
						fake_text = "中华人民共和国新成立的社会—爱国政府宣布，\n其首要且最重要的目标是：在多民族人口的基础上维护国家统一，\n并实现社会繁荣的可持续增长。\n政府还宣布朝向社会导向型市场经济的经济改革：\n公共部门比重上升、国家控制加强、对上层阶级的税负提高——这对\n经济增长造成打击，导致国内外投资减少，\n并使企业家的整体市场环境不利；但与此同时，\n通过加大对社会保障的公共投资，提升了公众的财富水平。\n在需要维护国家统一的背景下，CZPG遵循联邦主义与民主原则，\n同时在国家媒体中加强爱国动员。\n在中国，正在形成具有中国特色的社会主义制度。\n对美国关系降温，对苏联关系升温。\n美国通过选择其他国家来达到目的，削减对华贷款与投资；\n关于归还香港与澳门、以及台湾地位的谈判陷入停滞。\n苏联继续与中华人民共和国就建立全面外交关系进行谈判并取得成功：\n中华人民共和国拒绝其领土要求，苏联向中华人民共和国派遣专家，\n并发放若干大额无息贷款。";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中失利的中共，仍能维持一部分民众的支持，\n并保持党内队伍的团结；而党的路线以及对CZGP政策的坚决抵抗，\n使其成为主要的激进反对力量。\n中共继续同CZGP进行政治斗争：既保持议会党派身份，\n又采取多种对抗方式——不仅限于参加选举与竞选活动，\n常常组织激进的反对派公开行动。";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中失利的中共，仍能维持一部分民众的支持，\n并保持党内队伍的团结；而党的路线以及对CZGP在各方面都过度\n社会主义化的政策的坚决反对，使其成为主要的民主反对力量。\n中共继续同CZGP进行政治斗争：不只限于参加选举与竞选活动，\n常常组织民主派的公开行动。";
					}
					else
					{
						fake_text += "在选举中失利的中共未能维持党内团结，\n但同时失去民众支持，几乎在败选后立刻分裂为数个独立且彼此对立\n的党派。在CZGP执政期间，其中一些支持激进派，\n一些支持CZGP，还有一些支持民主派。\n最终，所有党派要么并入其他更大、更紧密的政党，\n要么仍作为缺乏真实政治影响力的小型分裂团体存在。";
					}
				}
				else if (GlobalScript.inst.gameState.party_number[3] > 1500)
				{
					if (GlobalScript.inst.gameState.data[14] < 4)
					{
						fake_text = "以承诺“稳定繁荣”而上台的中华人民共和国新政府宣布，\n其首要且最重要的目标是：在更审慎地处理民族问题的同时，\n维护国家统一，并实现社会繁荣的可持续增长。\n政府还宣布朝向社会导向型市场经济的经济改革——对经济造成一定\n打击，旧的纽带崩塌导致失序，但远低于预期，\n因此得以或多或少把后果降到最低（不过，\n这确实打击了相当一部分民众的生活水平）。\n鉴于需要维护国家统一，CZGP将实行联邦化并推进进一步的民\n主改革：在保持国家监管的同时，在各领域引入更多自由。\n在中国，正在形成具有中国特色的社会主义制度。\n对美国关系升温，对苏联关系转冷。\n美国成为中国的主要经济伙伴、世界市场上年轻参与者的主要债权人\n和投资者；其对发达国家的依赖不断加深。\n但与此同时，随着合作深化，关于归还香港与澳门以及台湾的特殊地\n位的谈判正在进行，似乎将以对中国有利的折中告终。\n苏联继续与中华人民共和国就恢复全面外交关系进行谈判，\n但在美国的怂恿下，中华人民共和国要求领土让步，\n而苏联一再拒绝。";
					}
					else
					{
						fake_text = "中华人民共和国新成立的社会—爱国政府宣布，\n其首要且最重要的目标是：在多民族人口的基础上维护国家统一，\n并实现社会繁荣的可持续增长。\n政府还宣布朝向社会导向型市场经济的经济改革：\n公共部门比重上升、国家控制加强、对上层阶级的税负提高——对经\n济增长造成一定影响，导致国内外投资减少，\n并使企业家的整体市场环境不利；但与此同时，\n通过加大对社会保障的公共投资，提升了公众的财富水平。\n在需要维护国家统一的背景下，CZGP遵循联邦主义与民主原则，\n同时在国家媒体中加强爱国动员。\n在中国，正在形成具有中国特色的社会主义制度。\n对美国关系恶化，对苏联关系改善。\n美国通过选择其他国家来达到目的，削减对华贷款与投资；\n关于归还香港与澳门、以及台湾地位的谈判在最后一点上陷入停滞，\n但前两项正在逐步走向成功。\n苏联继续与中华人民共和国就恢复全面外交关系进行谈判并取得成功：\n中华人民共和国放弃其领土要求，苏联向中华人民共和国派遣专家，\n并发放若干大额无息贷款。";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中失利的中共，能够维持相当大一部分民众的支持，\n尤其是工人阶级，并保持党内队伍的团结；\n而党的路线以及对CZGP政策的坚决抵抗——后者在各方面都过于\n“温和”——使其成为主要反对力量。\n中共继续同CZGP进行政治斗争：既保持议会党派身份，\n又采取多种对抗方式——不仅限于参加选举与竞选活动，\n常常组织公开行动。";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中失利的中共，能够维持一部分民众的支持，\n并保持党内队伍的团结；而党的路线以及对CZGP过度谨慎政策的\n坚决反对，使其成为主要的民主反对力量。\n中共继续同CZGP进行政治斗争：不只限于参加选举与竞选活动，\n常常组织公开行动。";
					}
					else
					{
						fake_text += "在选举中失利的中共未能维持党内团结，\n但与此同时失去民众支持，并分裂为两个党派。\n在CZGP执政期间，第一个党派与其结成联合，\n第二个党派支持反对派。\n最终，两党在3年后重新合并，恢复为单一的中共；\n但中国共产党人要在广袤全国范围内重建影响力，\n还得很长时间……";
					}
				}
				else if (GlobalScript.inst.gameState.party_number[2] > GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[2] > GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[2] > GlobalScript.inst.gameState.party_number[4])
				{
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(22);
					}
					if (GlobalScript.inst.gameState.data[14] < 4)
					{
						fake_text = "中国新政府宣布，其首要且最重要的目的，\n是维护中国的国家统一，并实现失地回归——香港、\n澳门和台湾。政府还宣布经济改革：在保持国家控制的同时扩大民间\n自主性，并允许有限的外资进入。\n此举为经济增长注入动力，但同时也滋生腐败与诈骗；\n由此产生的收入将用于扩充并改善国家机构与社会保障。\n短期内这有助于强化国家、提高民众生活水平，\n但却阻碍进一步增长，并拖慢经济发展。\n在国家分裂的背景下，决定加强民族国家，\n这导致对来自CZGP的反对联邦派与来自DPC的自由派采取“非\n正式”的压制；同时在媒体领域建立强有力的国家控制，\n配合激进的民族主义宣传，并对任何未经授权的公开行动同样施加“\n非正式”的禁令。几乎没有遭遇抵抗，中国便形成了“左翼仿民主”\n的政权。对美国与苏联的关系仍然紧张且不友好。\n然而，美国并未放弃通过有利可图的投资来施加影响，\n推动其盟友就失去的香港与澳门回归以及台湾地位问题启动谈判；\n但由于RCCK与——事实上——国民党之间关系紧张，\n这些谈判严重受阻。苏联则继续与中华人民共和国就恢复全面外交关\n系进行谈判，但中华人民共和国要求领土让步，\n苏联不予同意，谈判也逐步走向停滞。";
					}
					else
					{
						fake_text = "新中国政府宣布，其首要且最重要的目标是维护中国的国家统一，\n并实现失地回归——香港、澳门和台湾。\n政府还宣布经济“反改革”：减少民间自主性、\n强化国家控制，并限制外资。\n这导致经济增长下降，同时腐败与诈骗增长、\n创业力量与国家机构合流；但这也使国家能够获得大量资源，\n主要用于扩充并改善国家机构与社会保障。\n短期内这有助于强化国家、提高民众生活水平，\n但却阻碍进一步增长，并拖慢经济发展。\n在国家分裂的背景下，决定加强民族国家，\n这导致对来自CZGP的反对联邦派与来自DPC的自由派采取“非\n正式”的压制；同时在媒体领域建立强有力的国家控制，\n配合激进的民族主义议程，并对任何未经授权的公开行动同样施加“\n非正式”的禁令。反对派被压制或被收买，\n中国形成了“左翼仿民主”的政权。\n对美国与苏联的关系明显恶化。\n美国作为对反改革的回应，开始逐步撤回投资，\n并推动其盟友共同加强在香港、澳门和台湾（中国认为是其领土）\n的西方军事存在。苏联则作为对反改革的回应，\n称中国为“社会法西斯国家”，并进一步增加其在与中国争议地区的\n军事存在。";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中失利的中共，能够维持相当大一部分民众的支持，\n并保持党内队伍的团结；而在反改革时期，\n党的路线以及对RCCK的强力支持，使其得以继续留在政治舞台上，\n成为合法反对党之一。\n中共继续开展活动：在议会投票，并通过宣传动员为其造势、\n组织行动；它对RCCK给予强力支持，\n仅偶尔对其部分代表提出批评。";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中失利的中共，能够维持一部分民众的支持，\n并保持党内队伍的团结；而在反改革期间，\n党的路线以及与RCCK的果断对抗，促使整个反对派都围绕中共集\n结。然而作为回应，中共的活动受到多项法院裁决的严厉限制，\n且其部分领导人因各种（且显然是捏造的）\n指控被逮捕。";
					}
					else
					{
						fake_text += "在选举中失利的中共未能维持党内团结，\n但与此同时失去民众支持，分裂为四个党派。\n在反改革期间，其中一个支持RCCK，\n三个支持反对派。第一个在几年后加入RCCK；\n第二个与第三个合并，恢复中共；第四个则作为反对执政政权的独立\n党派继续存在。";
					}
				}
				else if (GlobalScript.inst.gameState.party_number[2] > 1500)
				{
					if (GlobalScript.inst.gameState.data[14] < 4)
					{
						fake_text = "中国新政府宣布，其首要且最重要的目的，\n是维护中国的国家统一，并实现失地回归——香港、\n澳门和台湾。政府还宣布经济改革：在保持国家控制的同时扩大民间\n自主性，并允许有限的外资进入。\n此举为经济增长注入动力，但同时也滋生腐败与诈骗；\n由此产生的收入将用于扩充并改善国家机构与社会保障。\n短期内这有助于强化国家、提高民众生活水平，\n但却阻碍进一步增长，并拖慢经济发展。\n在国家分裂的背景下，决定加强民族国家，\n这导致对来自CZGP的反对联邦派与来自DPC的自由派采取“非\n正式”的压制；同时在媒体领域建立强有力的国家控制，\n配合激进的民族主义宣传，并对任何未经授权的公开行动同样施加“\n非正式”的禁令。几乎没有遭遇抵抗，中国便形成了“左翼仿民主”\n的政权。对美国与苏联的关系仍然紧张且不友好。\n然而，美国并未放弃通过有利可图的投资来施加影响，\n推动其盟友就失去的香港与澳门回归以及台湾地位问题启动谈判；\n但由于RCCK与——事实上——国民党之间关系紧张，\n这些谈判严重受阻。苏联则继续与中华人民共和国就恢复全面外交关\n系进行谈判，但中华人民共和国要求领土让步，\n苏联不予同意，谈判也逐步走向停滞。";
					}
					else
					{
						fake_text = "新中国政府宣布，其首要且最重要的目标是维护中国的国家统一，\n并实现失地回归——香港、澳门和台湾。\n政府还宣布经济“反改革”：减少民间自主性、\n强化国家控制，并限制外资。\n这导致经济增长下降，同时腐败与诈骗增长、\n创业力量与国家机构合流；但这也使国家能够获得大量资源，\n主要用于扩充并改善国家机构与社会保障。\n短期内这有助于强化国家、提高民众生活水平，\n但却阻碍进一步增长，并拖慢经济发展。\n在国家分裂的背景下，决定加强民族国家，\n这导致对来自CZGP的反对联邦派与来自DPC的自由派采取“非\n正式”的压制；同时在媒体领域建立强有力的国家控制，\n配合激进的民族主义议程，并对任何未经授权的公开行动同样施加“\n非正式”的禁令。反对派被压制或被收买，\n中国形成了“左翼仿民主”的政权。\n对美国与苏联的关系明显恶化。\n美国作为对反改革的回应，开始逐步撤回投资，\n并推动其盟友共同加强在香港、澳门和台湾（中国认为是其领土）\n的西方军事存在。苏联则作为对反改革的回应，\n称中国为“社会法西斯国家”，并进一步增加其在与中国争议地区的\n军事存在。";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中失利的中共，能够维持相当大一部分民众的支持，\n并保持党内队伍的团结；而在反改革时期，\n党的路线以及对RCCK的强力支持，使其得以继续留在政治舞台上，\n成为合法反对党之一。\n中共继续开展活动：在议会投票，并通过宣传动员为其造势、\n组织行动；它对RCCK给予强力支持，\n仅偶尔对其部分代表提出批评。";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中失利的中共，能够维持一部分民众的支持，\n并保持党内队伍的团结；而在反改革期间，\n党的路线以及与RCCK的果断对抗，促使整个反对派都围绕中共集\n结。然而作为回应，中共的活动受到多项法院裁决的严厉限制，\n且其部分领导人因各种（且显然是捏造的）\n指控被逮捕。";
					}
					else
					{
						fake_text += "在选举中失利的中共未能维持党内团结，\n但与此同时失去民众支持，分裂为四个党派。\n在反改革期间，其中一个支持RCCK，\n三个支持反对派。第一个在几年后加入RCCK；\n第二个与第三个合并，恢复中共；第四个则作为反对执政政权的独立\n党派继续存在。";
					}
				}
				else
				{
					if (GlobalScript.inst.gameState.data[14] < 4)
					{
						fake_text = "中国新成立的自由民主政府宣布：战胜旧秩序、\n实现政权自由化，是其首要且最重要的目标。\n政府推行面向自由市场的经济改革——这对经济造成严重打击，\n旧的纽带崩塌引发阵痛与失序；然而，年轻的民间社会在反腐败与反\n诈骗方面的斗争，再加上来自美国和西方的贷款与投资，\n最终使局势得以应对，并进入经济增长状态；\n这在一定程度上抵消了此前的衰退，甚至让我们能够谈论经济增长与\n社会财富增加领域的某些“成功”。\n但绝大多数收入集中在一小撮个人手中——新兴寡头；\n与此同时，数十万乃至更多的人离开中国，\n希望在国外找到更好的生活。\nDPC在公共生活的各个领域取消国家控制，\n包括政治生活领域——在那里，消除了反对派自由活动的一切障碍。\n如今被称为“中华民主共和国”的国家，\n正在形成自由民主的政权。\n对美国关系日益友好，对苏联关系则逐步恶化。\n美国正成为中国的主要经济伙伴、世界市场上年轻参与者的主要债权\n人和投资者，其对发达国家的依赖不断加深。\n苏联则逐步中断与中国的贸易关系，并增加其在苏中边境的军事存在。\n新当局已经开始与台湾谈判，以恢复国家统一，\n因为双方之间的所有矛盾都已被消除。";
					}
					else
					{
						fake_text = "中国新自由民主政府宣布：加强并完善民主，\n是其首要目标。政府坚持“国内自由、对外开放”的市场方针；\n经济继续增长，但GDP相当不稳定——危机时不时强烈冲击它；\n而当大多数民众试图适应市场时，一小撮人却只会变得更富，\n外资则继续抽取国内资源。\nDPC在公共生活各领域（包括政治生活）\n保障自由，为反对派的“半自由”活动创造条件；\n尽管在危机时期，仍对激进组织施加强有力的行政压力。\n如今被称为“中华民主共和国”的国家，\n维持自由民主的政权。\n对美国关系保持友好，对苏联则相当敌对。\n美国仍是“刚果民主共和国”的主要经济伙伴、\n世界市场上年轻参与者的主要债权人和投资者，\n其对发达国家的依赖正在增长。\n苏联则逐步中断与中国的贸易关系，并增加其在苏中边境的军事存在。";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中失利的中共（CCP）仍能维持部分人口的支持，\n尤其是工人阶级，并保持党内队伍的团结；\n在DPC掌权期间，党纲路线以及与民主党人的坚决对抗，\n促使整个反对派都围绕中共集结。\n然而，中共的活动受到多项法院裁决的严厉限制，\n其数名领导人也因各种（且显然是捏造的）\n指控被逮捕。";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "在选举中落败后，中共（CPC）仍能保住民众支持与党内团结；\n党内路线以及对DPC部分自由化政策的支持，\n使中共得以在几年内以“建设性反对派”的身份继续留在政治舞台上，\n并与DPC和CZGP在联合阵营中结成同盟。";
					}
					else
					{
						fake_text += "在选举中失利的中共未能维持党内团结，\n但与此同时失去相当大一部分民众的支持，\n并分裂为三个党派。在DPC执政时期，\n其中一个支持民主派，另外两个支持反对派。\n近几年它们重新合拢，恢复了中共；但要实现中国共产党人的全面复\n兴，仍然遥遥无期……";
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.data[35] == 1)
		{
			name.text = "Восстание";
			fake_text = "Ваша политика стала всё больше злить народ Китая. Когда вы попытались всеми возможными средствами успокоить разрастающиеся протесты, это вам не удалось и народ начал открытое восстание, на сторону которого быстро перешли армия и часть партии. Арестовав и судив вас прежде, чем страна успела погрузиться в хаос, партийная верхушка и генералы объявили о создании временного правительства. Будущее Китая туманно...";
		}
		else if (GlobalScript.inst.gameState.data[35] == 2)
		{
			name.text = "Партийный переворот";
			fake_text = "Ваши действия стали всё больше злить партаппарат. Устав от вас, верхушка партии организовала съезд, на котором раскритиковала вас и проголосовала за вашу отставку и исключение. Вы теперь - никому не нужный пенсионер, а на вашем бывшем месте сидит компромиссный кандидат, пытающийся лавировать между враждующими фракциями.";
		}
		else if (GlobalScript.inst.gameState.data[35] == 3)
		{
			name.text = "Ядерная война";
			fake_text = "Добравшись до заветной красной кнопки, вы запустили ракеты. Ваш удар разрушил хрупкое равновесие между США и СССР и вслед за вами те тоже обменялись ядерными ударами. Большинство городов уничтожено, планета загрязнена, а большинство выживших спустились в бункеры и бомбоубежища. ";
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				achieves.GetComponent<achievements>().Set(18);
			}
		}
		else if (GlobalScript.inst.gameState.data[35] == 4)
		{
			name.text = "Геноцид";
			fake_text = "За время вашего правления население Китая - некогда самой густонаселённой страны - катастрофически снизилось. Это не могло остаться незамеченным, вас всё чаще открыто обвиняли в геноциде, и в конце концов, когда партия окончательно от этого устала, вас арестовали и отправили под трибунал. ";
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				achieves.GetComponent<achievements>().Set(49);
			}
		}
		else if (GlobalScript.inst.gameState.data[35] == 6)
		{
			name.text = "За каждой машиной - человек";
			fake_text = "Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " решил избежать возможного кровопролития и добровольно подал в отставку по состоянию здоровья. На смену старых лидеров пришли новые, но уже гораздо менее инициативные. Во внутренней была ужесточена цензура, а любые отклонения от генеральной линии тотально пресекаются. МЭСУ был ограничен автоматизацией производства и вооружённых сил, а за каждой машиной отныне стоит человек, поэтому государственный аппарат пришлось даже значительно увеличить. Даже, несмотря на это, экономка КНР развивается, но с каждым годом темпы роста всё падают и падают и когда-нибудь все проблемы китайской экономики всплывут на поверхность. Будущее Китая туманно.";
		}
		else if (GlobalScript.inst.gameState.data[35] == 7)
		{
			name.text = GlobalScript.inst.new_events_text[533];
			fake_text = GlobalScript.inst.new_events_text[534];
		}
		else if (GlobalScript.inst.gameState.data[35] == 5)
		{
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				achieves.GetComponent<achievements>().Set(55);
			}
			name.text = "Новый порядок";
			if (GlobalScript.inst.gameState.party_number[0] > GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] > GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] > GlobalScript.inst.gameState.party_number[4])
			{
				fake_text = "Прошедшие выборы в ВСНП не принесли успеха КПК, и победу, на волне популизма, одержали радикальные коммунисты из МКПК, набрав относительное большинство голосов. Кандидат от МКПК одержал победу так же и на президентских выборах. Пользуясь должностью президента, а также относительным большинством в парламенте, МКПК сформировала квазикоалиционное правительство, в котором представители иных партий получили только 3 незначительных поста. Новое правительство объявило своей целью возвращение к маоизму, построение социализма и коммунизма в Китае и во всём мире, вступив в решительное противостояние с советскими ревизионистами и американскими империалистами. В рамках политики возвращения к социализму, в первую очередь, было принято решение вернуться к однопартийности, уничтожив буржуазную республику и развернув новую Культурную революцию против ревизионистов и капиталистов. В список ревизионистов и капиталистов попали все партии, за исключением МКПК. Иные партии попытались было организовать публичные акции против маоистов и их политики, призвав в свою поддержку США и СССР, однако данное начинание было подавлено силами милиции при поддержке армии и вооружённой молодёжи из боевой организации МКПК. В ответ на это маоисты организовали в свою поддержку куда более многочисленные митинги по всей стране, куда силой сгоняли всех попавшихся под руку в поддержку дела Председателя Мао. Народ, ведомый государством и партией, разгромил штаб-квартиры оппозиционных партий, а их руководители и активисты были частью убиты, частью - высланы в деревню. Лидерам КПК тоже не удалось избежать справедливого народного гнева: руководители были подвергнуты 'коридору позора', после чего публично сознались в ревизионизме, в чём тут же и раскаялись, а затем были сосланы в народные коммуны. США и СССР осудили подобные действия, в китайское правительство извинилось, переложив ответственность на радикалов, заявив, что “не смогло сдержать народную ярость, и не стремилось препятствовать народу в борьбу с его врагами, боясь подвергнуть честных людей опасности”. Тем не менее, когда оппозиция была уничтожена, Вооружённые Силы вошли в Пекин и другие крупные города и разогнали с боем не желающие отдавать власть в руки государства боевые организации МКПК, которые официально добровольно самораспустились. Начинается новая эпоха в истории Китая, в которой экономические реформы будут сочетаться с крайним усилением власти государства над обществом и партии над государством в деле борьбы за китайскую социалистическую культуру и построение социализма и коммунизма через диктатуру, тотальный контроль и продвигаемую с их помощью новую культуру беззаветной преданности Мао, идеологии и партии, искореняя консервативный традиционализм и либеральный плюрализм.";
			}
			else if (GlobalScript.inst.gameState.party_number[0] > 1500)
			{
				fake_text = "Прошедшие выборы в ВСНП не принесли успеха КПК, и победу на парламентских выборах одержали радикальные коммунисты из МКПК, набрав абсолютное большинство голосов на волне популизма. Кандидат от МКПК одержал победу так же и на президентских выборах. Пользуясь должностью президента, а также абсолютным большинством в парламенте, МКПК сформировала однородное правительство. Новое правительство объявило своей целью возвращение к маоизму, построение социализма и коммунизма в Китае и во всём мире, вступив в решительное противостояние с советскими ревизионистами и американскими империалистами. В рамках политики возвращения к социализму, в первую очередь, было предпринято решение вернуться к однопартийности, уничтожив буржуазную республику и развернув новую Культурную революцию против ревизионистов и капиталистов. В список ревизионистов и капиталистов попали все партии, за исключением МКПК. Другие партии попытались организовать публичные акции против маоистов и их политики, призвав в свою поддержку США и СССР, однако данное начинание было подавлено силами милиции при поддержке армии и вооружённой молодёжи из боевой организации МКПК. В ответ на это маоисты организовали в свою поддержку куда более многочисленные митинги по всей стране, куда силой сгоняли всех попавшихся под руку в поддержку дела Председателя Мао. Народ, ведомый государством и партией, разгромил штаб-квартиры оппозиционных партий, а их руководители и активисты были частью убиты, частью - высланы в деревню. Руководству КПК тоже не удалось избежать справедливого народного гнева: руководители партии были подвергнуты 'коридору позора', после чего сознались в ревизионизме, в чём тут же и раскаялись, а затем были сосланы в народные коммуны. США и СССР осудили подобные действия, китайское правительство извинилось, переложив ответственность на радикалов, заявив, что “не смогло сдержать народную ярость, и не стремилось препятствовать народу в борьбу с его врагами, боясь подвергнуть честных людей опасности”. Тем не менее, когда оппозиция была уничтожена, Вооружённые Силы вошли в Пекин и другие крупные города и разогнали с боем не желающие отдавать власть в руки государства боевые организации МКПК, которые официально добровольно самораспустились. Начинается новая эпоха в истории Китая, в которой экономические реформы будут сочетаться с крайним усилением власти государства над обществом и партии над государством в деле борьбы за китайскую социалистическую культуру и построение социализма и коммунизма через диктатуру, тотальный контроль и продвигаемую с их помощью новую культуру беззаветной преданности Мао, идеологии и партии, искореняя консервативный традиционализм и либеральный плюрализм.";
			}
			else if (GlobalScript.inst.gameState.party_number[4] > 1500)
			{
				if (GlobalScript.inst.gameState.data[14] < 4)
				{
					fake_text = "Новое либерал-демократическое правительство Китая объявило своей первостепенной и важнейшей целью победу над старым порядком и либерализацию режима. Правительство провело экономические реформы в сторону свободного рынка, что нанесло серьёзный удар по экономике, вызывая дезорганизацию через распад старых связей, однако  борьба с коррупцией и махинациями со стороны молодого гражданского общества в совокупности с  кредитами и огромными инвестициями со стороны США и Запада позволили постепенно справиться с ситуацией, войдя в состояние определенного роста, который несколько компенсирует былой упадок и даже позволяет говорить о кое-каких успехах в области экономического роста и увеличения общественного богатства, однако огромная доля дохода сосредотачивается в руках узкой группы лиц - зарождающейся олигархии, в то время, как миллионы людей покидают Китай, надеясь найти лучшую жизнь за границей. ДПК ликвидирует государственный контроль во всех областях общественной жизни, включая и политическую, где создана возмоность для функционированя незначительной оппозиции. В Демократической республике Китай, как теперь называется страна, формируется режим либеральной демократии. Отношения с США становятся дружескими, а с СССР ухудшаются. США становятся главным экономическим партнёром КНР, основным кредитором и инвестором молодого участника мирового рынка, зависимость которого от развитых стран все возрастает. СССР постепенно разрывает с КНР торговые отношения и увеличивает военное присутствие на советско-китайской границе.";
				}
				else
				{
					fake_text = "Новое либерал-демократическое правительство Китая объявило своей первостепенной и важнейшей целью укрепление и совершенствование демократии. Правительство сохранило курс на свободный внутри и открытый вовне рынок, экономика продолжает расти, но уже с довольно нестабильным показателем ВВП, ведь кризисы сильно сотрясают её время от времени и пока большая часть населения пытается вписаться в рынок, узкая группа лиц становится только богаче, а иностранные инвесторы продолжают выкачивать из страны ресурсы. ДПК оберегает свободу во всех областях общественной жизни, в том числе и в политической, создавая условия для полусвободной деятельности оппозиции, хотя в период кризисов имеет место сильное административное давление на радикальные организации. В Демократической республике Китай, как теперь называется страна, сохраняется режим либеральной демократии. Отношения с США остаются дружескими, а с СССР - скорее враждебными. США остаются главным экономическим партнёром ДРК, основным кредитором и инвестором молодого участника мирового рынка, зависимость которого от развитых стран всё возрастает. СССР постепенно разрывает с КНР торговые отношения и увеличивает военное присутствие на советско-китайской границе.";
				}
				if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку части населения, особенно рабочего класса, и единство в своих рядах, а линия партии и решительное противостояние с демократами во время власти ДПК сплотило всю оппозицию вокруг КПК. Однако деятельность КПК была сильно ограничена рядом судебных постановлений, а несколько её руководителей по различным (и явно ложным) обвинениям были арестованы.";
				}
				else if (GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку части населения и единство в своих рядах, а линия партии и определенная поддержка либеральной политики ДПК позволили КПК остаться в политике в качестве 'конструктивной оппозиции', через несколько лет объединившись с ДПК и КПСС в коалиционный блок.";
				}
				else
				{
					fake_text += "Проигравшая выборы КПК не смогла сохранить единство в своих рядах, а вместе с тем утратила поддержку значительной части населения и пережила раскол на три партии. В период власти ДПК одна из них поддержала демократов, а две - оппозицию. Последние через несколько лет воссоединились, восстановив КПК, но до полного возрождения китайским коммунистам ещё очень далеко...";
				}
			}
			else if (GlobalScript.inst.gameState.party_number[3] > GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[3] > GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[3] > GlobalScript.inst.gameState.party_number[4])
			{
				if (GlobalScript.inst.gameState.data[14] < 4)
				{
					fake_text = "Новое социал-патриотическое правительство КНР объявило своей первостепенной и важнейшей целью сохранение государственного единства при многонациональности и устойчивом росте общественного процветания. Правительство также объявило об экономических реформах в сторону социально-ориентированной рыночной экономики, что наносит серьёзный удар по экономике, вызывая дезорганизацию через распад старых связей, а попытка сохранить социальное обеспечение приводит к дефициту бюджета и окончательному краху китайской экономики, подпитываемому повсеместным всплеском коррупции и махинаций, и только кредиты и инвестиции со стороны США и Запада позволяют наконец справиться с ситуацией, войдя в состояние быстрого роста, который частично компенсирует былой упадок и даже позволяет говорить об определённых успехах в области экономического роста и увеличении общественного богатства, однако огромная доля дохода покидает КНР в пользу её экономических партнёров. В условиях необходимости сохранения государственного единства, КПСС идёт на федерализацию и дальнейшие демократические реформы, внедряя больше свободы во всех областях при сохранении государственного регулирования. В КНР формируется режим социализма с китайской спецификой. Отношения с США теплеют, а с СССР холодеют. США становятся главным экономическим партнёром КНР, основным кредитором и инвестором молодого участника мирового рынка, зависимость которого от развитых стран возрастает, но в то же время в рамках углубления сотрудничества ведутся переговоры о возвращении Гонконга и Макао, статусе Тайваня, которые, кажется, закончатся компромиссом в пользу КНР. СССР продолжает переговоры с КНР об установлении полноценных дипломатических отношений, однако КНР, подначиваемая США, требует территориальных уступок, а СССР раз за разом отвечает отказом.";
				}
				else
				{
					fake_text = "Новое социал-патриотическое правительство КНР объявило своей первостепенной и важнейшей целью сохранение государственного единства при многонациональности и устойчивом росте общественного процветания. Правительство также объявило об экономических реформах в сторону социально-ориентированной рыночной экономики, что ведёт к увеличению государственного сектора, усилению государственного контроля и росту налогов для высшего класса, нанося удар по экономическому росту, вызывая сокращение внутренних и внешних инвестиций и общую неблагоприятную для предпринимателей обстановку на рынке, однако в то же время и подъём уровня общественного богатства за счёт увеличения государственных вложений в социальное обеспечение. В условиях необходимости сохранения государственного единства, КПСС следует принципам федерализма и демократии, усиливая при этом патриотическую агитацию в государственных СМИ. В КНР формируется режим социализма с китайской спецификой. Отношения с США холодеют, а с СССР теплеют. США сокращают кредиты и инвестиции, выбирая для этих целей другие страны, а переговоры о возвращении Гонконга и Макао, статусе Тайваня, заходят в тупик. СССР продолжает переговоры с КНР об установлении полноценных дипломатических отношений и добивается успеха: КНР отказывается от своих территориальных требований, а СССР направляет в КНР специалистов, выдаёт целый ряд больших беспроцентных кредитов.";
				}
				if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку части населения и единство в рядах своих членов, а линия партии и решительное сопротивление излишне мягкой во всех смыслах политике КПСС сделали её главной радикально-оппозиционной силой. КПК продолжает свою политическую борьбу против КПСС, оставаясь парламентской партией и при этом прибегая к многочисленным способом противостояния, не ограничиваясь участием в выборах и агитацией, нередко устраивая радикально-оппозиционные публичные акции.";
				}
				else if (GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку части населения и единство в рядах своих членов, а линия партии и решительное противостояние излишне социалистической во всех смыслах политике КПСС сделали её главной демократически-оппозиционной силой. КПК продолжает свою политическую борьбу против КПСС, не ограничиваясь участием в выборах и агитацией, нередко устраивая демократически-оппозиционные публичные акции.";
				}
				else
				{
					fake_text += "Проигравшая выборы КПК не смогла сохранить единство в рядах своих членов, а вместе с тем утратила поддержку населения и распалась на несколько независимых и противоположных партий почти сразу же после поражения. В период власти КПСС часть из них поддержала радикалов, часть - КПСС, а часть - демократов. В конечном итоге все части вошли в состав других, более крупных и сплочённых партий или так и остались небольшими разрозненными группами, не имеющими реального влияния на политику.";
				}
			}
			else if (GlobalScript.inst.gameState.party_number[3] > 1500)
			{
				if (GlobalScript.inst.gameState.data[14] < 4)
				{
					fake_text = "Новое  правительство КНР, пришедшее к власти путем обещаний стабильного процветания, объявило своей первостепенной и важнейшей целью сохранение всенародного единства при более внимательном рассмотрении проблем национального вопроса и устойчивом росте общественного процветания. Правительство также объявило об экономических реформах в сторону социально-ориентированной рыночной экономики, что наносит определенный удар по экономике, вызывая дезорганизацию через распад старых связей, но гораздо меньше, чем ожидалось, что позволило более-менее минимизировать последствия (тем не менее, по уровню жизни значительной части населения это ударило). В условиях необходимости сохранения государственного единства, КПСС идёт на федерализацию и дальнейшие демократические реформы, внедряя больше свободы во всех областях при сохранении государственного регулирования. В КНР формируется режим социализма с китайской спецификой. Отношения с США теплеют, а с СССР холодают. США становятся главным экономическим партнёром КНР, основным кредитором и инвестором молодого участника мирового рынка, зависимость которого от развитых стран возрастает, но в то же время в рамках углубления сотрудничества ведутся переговоры о возвращении Гонконга и Макао, и особом статусе Тайваня, которые, кажется, закончатся компромиссом в пользу КНР. СССР продолжает переговоры с КНР об восстановлении полноценных дипломатических отношений, однако КНР, подначиваемая США, требует территориальных уступок, а СССР раз за разом отвечает отказом.";
				}
				else
				{
					fake_text = "Новое социал-патриотическое правительство КНР объявило своей первостепенной и важнейшей целью сохранение государственного единства при многонациональности и устойчивом росте общественного процветания. Правительство также объявило об экономических реформах в сторону социально-ориентированной рыночной экономики, что ведёт к увеличению государственного сектора, усилению государственного контроля и росту налогов для высшего класса, нанося некоторый удар по экономическому росту, вызывая сокращение внутренних и внешних инвестиций и общую неблагоприятную для предпринимателей обстановку на рынке, однако в то же время и подъём уровня общественного богатства за счёт увеличения государственных вложений в социальное обеспечение. В условиях необходимости сохранения государственного единства, КПСС следует принципам федерализма и демократии, усиливая при этом патриотическую агитацию в государственных СМИ. В КНР формируется режим социализма с китайской спецификой. Отношения с США холодеют, а с СССР теплеют. США сокращают кредиты и инвестиции, выбирая для этих целей другие страны, а переговоры о возвращении Гонконга и Макао, статусе Тайваня, заходят в тупик по последнему пункту, но с первыми двумя постепенно идут к успеху. СССР продолжает переговоры с КНР об восстановлении полноценных дипломатических отношений и добивается успеха: КНР отказывается от своих территориальных требований, а СССР направляет в КНР специалистов, выдаёт целый ряд больших беспроцентных кредитов.";
				}
				if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку значительной части населения, особенно рабочего класса, и единство в своих рядах, а линия партии и решительное сопротивление излишне мягкой во всех смыслах политике КПСС сделали её главной оппозиционной силой. КПК продолжает свою политическую борьбу против КПСС, оставаясь парламентской партией и при этом прибегая к многочисленным способом противостояния, не ограничиваясь участием в выборах и агитацией, нередко устраивая публичные акции.";
				}
				else if (GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку части населения и единство в своих рядах, а линия партии и решительное противостояние излишне осторожной политике КПСС сделали её главной демократически-оппозиционной силой. КПК продолжает свою политическую борьбу против КПСС, не ограничиваясь участием в выборах и агитацией, нередко устраивая публичные акции.";
				}
				else
				{
					fake_text += "Проигравшая выборы КПК не смогла сохранить единство в своих рядах, а вместе с тем утратила поддержку населения и распалась на две партии. В период власти КПСС первая вошла с ней в коалицию, а вторая - поддержала оппозицию. В конечном итоге, обе партии воссоединились через 3 года, восстановив единую КПК, однако китайским коммунистам ещё долго придется восстанавливать свое влияние по всей необъятной стране...";
				}
			}
			else if (GlobalScript.inst.gameState.party_number[2] > GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[2] > GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[2] > GlobalScript.inst.gameState.party_number[4])
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(22);
				}
				if (GlobalScript.inst.gameState.data[14] < 4)
				{
					fake_text = "Новое правительство Китая объявило своей первостепенной и важнейшей целью сохранение национального единства Китая, а также возвращение утраченных территорий - Гонконга, Макао и Тайваня. Правительство также объявило об экономических реформах в сторону расширения частной инициативы при сохранении государственного контроля, а также допущении ограниченных иностранных инвестиций, что даёт толчок экономическому росту, однако вместе с этим возрастают коррупция и махинации, а образовавшийся доход идёт на расширение и улучшение содержания государственного аппарата и социального обеспечения, что в краткосрочной перспективе позволяет усилить государство и поднять уровень жизни населения, однако препятствует дальнейшему росту и замедляет развитие экономики. В условиях национальной раздробленности было решено усилить национальное государство, что повлекло за собой неформальные репрессии в отношении оппозиционных федералистов из КПСС и либералов из ДПК, а также установление мощного государственного контроля в СМИ, выступающих с агрессивной националистической пропагандой, при всё таком же неформальном запрете на любые несанкционированные публичные акции. Не встретив почти никакого сопротивления, в КНР сформировался режим левой имитационной демократии. Отношения с США и СССР остаются всё такими же напряжёнными и недружественными. Тем не менее, США не обошли стороной возможность выгодных вложений, подтолкнув своих союзников к началу переговоров о возвращении утраченных Гонконга и Макао и статусе Тайваня, которые, впрочем, сильно пробуксовывают из-за напряженных отношений между РКГ и, собственно, Гоминьданом. СССР, в свою очередь, продолжил переговоры с КНР об восстановлении полноценных дипломатических отношений, однако КНР требует территориальных уступок, на что СССР не согласен, и переговоры также постепенно заходят в тупик.";
				}
				else
				{
					fake_text = "Новое правительство КНР объявило своей первостепенной и важнейшей целью сохранение национального единства Китая, а также возвращение утраченных территорий - Гонконга, Макао и Тайваня. Правительство также объявило об экономических контрреформах в сторону сокращения частной инициативы, усиления государственного контроля, а также ограничении иностранных инвестиций, что приводит к снижению экономического роста в совокупности с ростом коррупции и махинаций, слиянии предпринимательства и государственного аппарата, однако даёт государству доступ к большим ресурсам, которые, в основном, идут на расширение и улучшение содержания государственного аппарата и социального обеспечения, что в краткосрочной перспективе позволяет усилить государство и поднять уровень жизни населения, однако препятствует дальнейшему росту и замедляет развитие экономики. В условиях национальной раздробленности было решено усилить национальное государство, что повлекло за собой неформальные репрессии в отношении оппозиционных федералистов из КПСС и либералов из ДПК, а также установление мощного государственного контроля в СМИ, выступающих с агрессивной националистической повесткой, при всё таком же неформальном запрете на любые несанкционированные публичные акции. Оппозиция была подавлена или подкуплена, в КНР сформировался режим левой имитационной демократии. Отношения с США и СССР заметно ухудшились. США в ответ на контреформы начали постепенный вывод вложений и подтолкнули своих союзников к совместному усилению западного военного присутствия в Гонконге, Макао и на Тайваня, которые КНР считает своими. СССР в ответ на контреформы назвал Китай социал-фашистским государством, также увеличив своё военное присутствие на спорных с КНР территориях.";
				}
				if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку немалой части населения и единство в своих рядах, а линия партии и решительная поддержка РКГ в период контрреформ позволили ей остаться в политике, став одной из легальных оппозиционных партий. КПК продолжает свою деятельность, голосуя в парламенте, проводя агитацию в свою пользу и организуя акции, решительно поддерживая РКГ и лишь изредка выступая с критикой в адрес отдельных её представителей.";
				}
				else if (GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку части населения и единство в своих рядах, а линия партии и решительное противостояние с РКГ в период контрреформ сплотила всю оппозицию вокруг КПК. Однако, в ответ на это, деятельность КПК была сильно ограничена рядом судебных решений, а часть её руководителей по различным (и явно ложным) обвинениям была арестована.";
				}
				else
				{
					fake_text += "Проигравшая выборы КПК не смогла сохранить единство в своих рядах, а вместе с тем утратила поддержку населения и распалась на четыре партии. В период контрреформ одна из них поддержала РКГ, а три - оппозицию. Первая через несколько лет влилась в состав РКГ, вторая объединилась с третьей, восстановив КПК, а четвертая осталась самостоятельной партией, оппозиционной правящему режиму.";
				}
			}
			else if (GlobalScript.inst.gameState.party_number[2] > 1500)
			{
				if (GlobalScript.inst.gameState.data[14] < 4)
				{
					fake_text = "Новое правительство Китая объявило своей первостепенной и важнейшей целью сохранение национального единства Китая, а также возвращение утраченных территорий - Гонконга, Макао и Тайваня. Правительство также объявило об экономических реформах в сторону расширения частной инициативы при сохранении государственного контроля, а также допущении ограниченных иностранных инвестиций, что даёт толчок экономическому росту, однако вместе с этим возрастают коррупция и махинации, а образовавшийся доход идёт на расширение и улучшение содержания государственного аппарата и социального обеспечения, что в краткосрочной перспективе позволяет усилить государство и поднять уровень жизни населения, однако препятствует дальнейшему росту и замедляет развитие экономики. В условиях национальной раздробленности было решено усилить национальное государство, что повлекло за собой неформальные репрессии в отношении оппозиционных федералистов из КПСС и либералов из ДПК, а также установление мощного государственного контроля в СМИ, выступающих с агрессивной националистической пропагандой, при всё таком же неформальном запрете на любые несанкционированные публичные акции. Не встретив почти никакого сопротивления, в КНР сформировался режим левой имитационной демократии. Отношения с США и СССР остаются всё такими же напряжёнными и недружественными. Тем не менее, США не обошли стороной возможность выгодных вложений, подтолкнув своих союзников к началу переговоров о возвращении утраченных Гонконга и Макао и статусе Тайваня, которые, впрочем, сильно пробуксовывают из-за напряженных отношений между РКГ и, собственно, Гоминьданом. СССР, в свою очередь, продолжил переговоры с КНР об восстановлении полноценных дипломатических отношений, однако КНР требует территориальных уступок, на что СССР не согласен, и переговоры также постепенно заходят в тупик.";
				}
				else
				{
					fake_text = "Новое правительство КНР объявило своей первостепенной и важнейшей целью сохранение национального единства Китая, а также возвращение утраченных территорий - Гонконга, Макао и Тайваня. Правительство также объявило об экономических контрреформах в сторону сокращения частной инициативы, усиления государственного контроля, а также ограничении иностранных инвестиций, что приводит к снижению экономического роста в совокупности с ростом коррупции и махинаций, слиянии предпринимательства и государственного аппарата, однако даёт государству доступ к большим ресурсам, которые, в основном, идут на расширение и улучшение содержания государственного аппарата и социального обеспечения, что в краткосрочной перспективе позволяет усилить государство и поднять уровень жизни населения, однако препятствует дальнейшему росту и замедляет развитие экономики. В условиях национальной раздробленности было решено усилить национальное государство, что повлекло за собой неформальные репрессии в отношении оппозиционных федералистов из КПСС и либералов из ДПК, а также установление мощного государственного контроля в СМИ, выступающих с агрессивной националистической повесткой, при всё таком же неформальном запрете на любые несанкционированные публичные акции. Оппозиция была подавлена или подкуплена, в КНР сформировался режим левой имитационной демократии. Отношения с США и СССР заметно ухудшились. США в ответ на контреформы начали постепенный вывод вложений и подтолкнули своих союзников к совместному усилению западного военного присутствия в Гонконге, Макао и на Тайваня, которые КНР считает своими. СССР в ответ на контреформы назвал Китай социал-фашистским государством, также увеличив своё военное присутствие на спорных с КНР территориях.";
				}
				if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку немалой части населения и единство в своих рядах, а линия партии и решительная поддержка РКГ в период контрреформ позволили ей остаться в политике, став одной из легальных оппозиционных партий. КПК продолжает свою деятельность, голосуя в парламенте, проводя агитацию в свою пользу и организуя акции, решительно поддерживая РКГ и лишь изредка выступая с критикой в адрес отдельных её представителей.";
				}
				else if (GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку части населения и единство в своих рядах, а линия партии и решительное противостояние с РКГ в период контрреформ сплотила всю оппозицию вокруг КПК. Однако, в ответ на это, деятельность КПК была сильно ограничена рядом судебных решений, а часть её руководителей по различным (и явно ложным) обвинениям была арестована.";
				}
				else
				{
					fake_text += "Проигравшая выборы КПК не смогла сохранить единство в своих рядах, а вместе с тем утратила поддержку населения и распалась на четыре партии. В период контрреформ одна из них поддержала РКГ, а три - оппозицию. Первая через несколько лет влилась в состав РКГ, вторая объединилась с третьей, восстановив КПК, а четвертая осталась самостоятельной партией, оппозиционной правящему режиму.";
				}
			}
			else
			{
				if (GlobalScript.inst.gameState.data[14] < 4)
				{
					fake_text = "Новое либерал-демократическое правительство Китая объявило своей первостепенной и важнейшей целью победу над старым порядком и либерализацию режима. Правительство провело экономические реформы в сторону свободного рынка, что нанесло серьёзный удар по экономике, вызывая дезорганизацию через распад старых связей, однако борьба с коррупцией и махинациями со стороны молодого гражданского общества в совокупности с кредитами и инвестициями со стороны США и Запада позволили со временем справиться с ситуацией, войдя в состояние экономического роста, который несколько компенсирует былой упадок и даже позволяет говорить о определенных успехах в области экономического роста и увеличении общественного богатства, однако подавляющая часть дохода сосредотачивается в руках узкой группы лиц - зарождающейся олигархии, в то время, как сотни тысяч людей покидают Китай, надеясь найти лучшую жизнь за границей. ДПК ликвидирует государственный контроль во всех областях общественной жизни, включая и политическую, где всякие препятствия для свободной деятельности оппозиции ликвидируются. В Демократической республике Китай, как теперь называется страна, формируется режим либеральной демократии. Отношения с США становятся дружескими, а с СССР постепенно ухудшаются. США становятся главным экономическим партнёром КНР, основным кредитором и инвестором молодого участника мирового рынка, зависимость которого от развитых стран возрастает. СССР же постепенно разрывает с КНР торговые отношения и увеличивает военное присутствие на советско-китайской границе. Новые власти уже начинают переговоры с Тайванем об восстановлении единства страны, благо что все противоречия между ними устранены.";
				}
				else
				{
					fake_text = "Новое либерал-демократическое правительство Китая объявило своей первостепенной и важнейшей целью укрепление и совершенствование демократии. Правительство сохранило курс на свободный внутри и открытый вовне рынок, экономика продолжает расти, но уже с довольно нестабильным показателем ВВП, ведь кризисы сильно сотрясают её время от времени и пока большая часть населения пытается вписаться в рынок, узкая группа лиц становится только богаче, а иностранные инвесторы продолжают выкачивать из страны ресурсы. ДПК оберегает свободу во всех областях общественной жизни, в том числе и в политической, создавая условия для полусвободной деятельности оппозиции, хотя в период кризисов имеет место сильное административное давление на радикальные организации. В Демократической республике Китай, как теперь называется страна, сохраняется режим либеральной демократии. Отношения с США остаются дружескими, а с СССР - скорее враждебными. США остаются главным экономическим партнёром ДРК, основным кредитором и инвестором молодого участника мирового рынка, зависимость которого от развитых стран всё возрастает. СССР постепенно разрывает с КНР торговые отношения и увеличивает военное присутствие на советско-китайской границе.";
				}
				if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку части населения, особенно рабочего класса, и единство в своих рядах, а линия партии и решительное противостояние с демократами во время власти ДПК сплотило всю оппозицию вокруг КПК. Однако деятельность КПК была сильно ограничена рядом судебных постановлений, а несколько её руководителей по различным (и явно ложным) обвинениям были арестованы.";
				}
				else if (GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text += "Проигравшая выборы КПК смогла сохранить поддержку части населения и единство в своих рядах, а линия партии и определенная поддержка либеральной политики ДПК позволили КПК остаться в политике в качестве 'конструктивной оппозиции', через несколько лет объединившись с ДПК и КПСС в коалиционный блок.";
				}
				else
				{
					fake_text += "Проигравшая выборы КПК не смогла сохранить единство в своих рядах, а вместе с тем утратила поддержку значительной части населения и пережила раскол на три партии. В период власти ДПК одна из них поддержала демократов, а две - оппозицию. Последние через несколько лет воссоединились, восстановив КПК, но до полного возрождения китайским коммунистам ещё очень далеко...";
				}
			}
		}
		text_t.text = Text(fake_text, 83);
	}

	private void MakeScrollable(ref int stroki)
	{
		float focus_down = text_t.characterSize * -1f * (float)stroki + startTextPosition;
		text_t.transform.position = new Vector3(text_t.transform.position.x, startTextPosition, text_t.transform.position.z);
		name.transform.position = new Vector3(name.transform.position.x, startNamePosition, name.transform.position.z);
		scrollComponent.GetComponent<ScrollScript>().MakeThings(name.transform.position.y, focus_down);
	}

	private string Text(string text, int col)
	{
		int num = 0;
		int stroki = 5;
		string text2 = "";
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == char.Parse("|"))
			{
				num = 0;
				text2 += "\n";
				stroki++;
			}
			else if (num >= col)
			{
				if (text[i] == char.Parse(" "))
				{
					num = 0;
					text2 += "\n";
					stroki++;
					continue;
				}
				text2 += text[i];
				for (int num2 = i; num2 >= 0; num2--)
				{
					if (text2[num2] == char.Parse(" "))
					{
						text2 = text2.Substring(0, num2) + "\n" + text2.Substring(num2 + 1, text2.Length - 1 - (num2 + 1) + 1);
						stroki++;
						num = text2.Length - 1 - (num2 + 1) + 1;
						break;
					}
				}
			}
			else
			{
				text2 += text[i];
				num++;
			}
		}
		Debug.Log($"Количество строк: {stroki}");
		MakeScrollable(ref stroki);
		return text2;
	}

	private void ledaer_na()
	{
		if (GlobalScript.inst.gameState.empires[1].now_leader != 6)
		{
			return;
		}
		if (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.influencePRC)
		{
			if (GlobalScript.inst.gameState.empires[0].power > GlobalScript.inst.gameState.influencePRC)
			{
				GlobalScript.inst.gameState.empires[1].power = GlobalScript.inst.gameState.empires[0].power + 10;
			}
			else
			{
				GlobalScript.inst.gameState.empires[1].power = GlobalScript.inst.gameState.influencePRC + 10;
			}
		}
		else
		{
			GlobalScript.inst.gameState.empires[1].power = 0;
		}
	}
}
