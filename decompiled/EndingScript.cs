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
				name.text = "Eastern Cyberpunk";
				fake_text = "Chairman " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " will be remembered as one of the greatest leaders of China, who introduced the country into the golden age through the arch of automation - which even the almighty Soviet Union did not risk to do. Thanks to the hard work of dozens of cybernetics and millions of workers who were able to implement the The Great Machine of China - the country's economy was modernized. The resistance of the party against it was destroyed. The risky idea gave great results - corruption and deficit were almost completely eliminated, every official is now under the dispassionate electronic control, which can not be bribed or deceived. But this computerization is not over - thanks to the future introduction of electronic passports and social rating system, the society is finally cleared of counter-revolutionary and harmful elements, almost no one departs from the program and implementation of the plan. But... machines are everywhere now, and their powers are expanding... And only after the untimely death of the Leader, the party and the people, it seems, gradually begin to understand - who really now controls everything...";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(60);
				}
			}
			else if (GlobalScript.inst.gameState.data[16] == 11 && GlobalScript.inst.gameState.data[26] <= 0 && GlobalScript.inst.gameState.data[15] <= 6 && GlobalScript.inst.gameState.data[17] >= 19 && GlobalScript.inst.gameState.data[51] >= 33)
			{
				name.text = "One foot in communism";
				fake_text = "Without democracy there is no socialism, without socialism there is no democracy. We tried for a long time to find a balance between these concepts and finally managed to build a real socialism. Thanks to the introduction of OGAS, we have overcome the deficit and, hopefully, forever protected our society from the restoration of human exploitation, inequality and overproduction crises. One-party democracy helps to protect the country from falling into the power of counter-revolutionary elements, eliminating bourgeois parliamentary debate and putting everything under the control of the CPC. And freedom of speech and people's control protect against abuse of power by the CPC and its individual members, thereby giving our system the necessary balance. We have proved that the best structure of society is possible, and dozens of failed attempts to build socialism around the world were not in vain. Marx's dream came true! ";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(58);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] <= 2 && GlobalScript.inst.gameState.modifies[3].active && GlobalScript.inst.gameState.data[90] == 0 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[51].Torg)
			{
				name.text = "The Stronghold of Maoism";
				fake_text = "Chairman " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " and the political Bureau's confident leadership of the country ensured China's loyalty to the precepts of the great liberator of the Chinese people, Chairman Mao Zedong. All opposition was part suppressed, part taken under control, the names of their leaders are now forgotten. We are on the great road - the road that the Great Helmsman has shown us! At least, as long as Mao's ideas are supported by the people, and the economy is more or less stable. In truth, we are increasingly accused of human rights violations - but who cares? Millions of people have received their own housing, free education, employment, the welfare of the majority is growing, albeit not as fast as we would like, but confidently and steadily. China has become a respected country - and this is already a significant achievement.";
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
				name.text = "Opening to the world...";
				fake_text = "Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " and faithful party members led the country along the path that was indicated by the experience of the history of China. This time was marked by the beginning of a departure from Orthodoxy, and China opened its doors to the world - not to the end, of course, but an important step was taken. Finally, the Cultural revolution was completed, cautious reforms were carried out within the framework of socialism, which allowed to correct all the wrong and consolidate all the right achieved during the years when our country was led by comrade Mao Zedong. For millions of Chinese, this period in China's history was the time of its greatest stability and prosperity. Although there had been some mistakes, but overall, this course proved successful and our leader has sometimes been compared to Lenin himself, for he could pass to Wade, feeling with their feet the stones.";
				if (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 700)
				{
					fake_text = fake_text + "|We restored good-neighbourly relations with the USSR and began negotiations on a new demarcation of the Soviet-Chinese border. Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " made an important visit to Moscow, during which he said that China has no claims to the Soviet Union - neither territorial nor ideological. On the way back, he arrived on the island of Damansky and bowed to the graves of Soviet border guards who died during the 1969 conflict, promising on behalf of the Chinese people that he would follow the course of Soviet-Chinese friendship to the end. The two largest Eurasian countries are still moving in the same direction, but who knows what could happen?..";
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
				name.text = "Towards the world...";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " will remain in the history of China as one of the most outstanding leaders in the history of the country (or at least so says our official propaganda).  Large-scale economic reforms were launched, business activities were encouraged and foreign investment opportunities opened up in China, while protecting the domestic market from the collapse of national production and the dominance of foreign companies. True, now the business is firmly fused with the state apparatus, which, in turn, does not like neither the supporters of the free market nor the orthodox communists, and the liberalization of minds could not move far in society: the country has strict censorship, and the opposition is under control, but it's all we do for the benefit of the people, right?..";
				if (GlobalScript.inst.gameState.allcountries[51].Torg)
				{
					fake_text += "|We went to deepen cooperation with the United States, founded by Zhou Enlai, and opened free economic zones for investors from around the world. Thousands of foreign companies have transferred their enterprises to us, ensuring a boom in the growth of our economy! However, some party members say that \"in the free economic zones, only the socialist Chinese flags are developing over them, and everything else is capitalist\", and a significant share of income from FEZ goes abroad. Maybe the disgruntled party members are right?..";
				}
				else if (GlobalScript.inst.gameState.relres)
				{
					fake_text += "|We not only restored good-neighbourly relations with the USSR, but even joined the Council for Mutual economic Assistance. Cooperation with socialist countries has made it possible to revive China's economy and make it stronger and more developed, hundreds of projects have already been implemented, and even more are now in varying degrees of readiness.Our experts have learned a lot from our friends, so Made in China has ceased to be synonymous with forgery, and has become a respected worldwide sign of products of quite high quality.";
					GlobalScript.inst.gameState.allcountries[1].isSEV = true;
				}
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(44);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] > 3)
			{
				name.text = "The new Absolutes";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " marked a difficult period in China's history - a period of a decisive break with the grave past, the construction of a new China on new grounds, deep and large-scale reforms in all sectors of life, the transition to democratic universal values, new political thinking, full emancipation of consciousness and action. However, not everyone liked such actions. We cannot know what will happen in 5, 10, 20 or 50 years - but our descendants will surely remember that this period of history was for China an era of decisive change, thanks to which much has changed...";
				if (GlobalScript.inst.gameState.allcountries[51].Torg)
				{
					fake_text = fake_text + "|The United States fully supported our reforms, Mr. " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " five times declared \"Man of the year\" according to various major publications and was nominated for the Nobel peace prize (though he could get it only before the resignation). We have opened our market to foreign firms, allowing them to participate in the privatization of state property. By joining globalization, we have provided our labor force to foreigners and opened free economic zones. However, this caused a number of unforeseen difficulties and provoked a wide discussion in society. Time will tell if we did the right thing...";
				}
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(42);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] == 0 && GlobalScript.inst.gameState.data[16] <= 13)
			{
				name.text = "DPRK, but bigger";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " and firm leadership of the Politburo members closest to the person of the leader ensured the loyalty of the PRC to the precepts of its founders. The entire left and right opposition was defeated, and the socialist society is well protected from foreign spies and enemies of the people. They compare our era to the three Kingdoms, the Mongol dictatorship and the despotism of the eunuchs under the Han dynasty, but this is certainly an exaggeration - in all these times, the welfare of the population has not increased as much as it has risen over our era. However, many people say that our ideology has finally separated from Marxism and turned into a kind of Chinese socialist nationalism with an authoritarian tinge, but this is speculation, right?";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(43);
				}
			}
			else if (GlobalScript.inst.gameState.data[14] == 0 && GlobalScript.inst.gameState.data[16] >= 14)
			{
				name.text = "Asian Pinochet";
				fake_text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " and his firm leadership ensured China's stability and prosperity during the market reforms. All opposition was destroyed, and our party with a firm hand leads China to a bright market future. However, international organizations are increasingly accusing us of violating human rights, claiming oppression of freedom, lack of real democracy and arbitrariness of private traders in enterprises where our citizens work beyond the norm, unable to rectify the situation because of the destroyed trade Union movement. But as long as foreign investors and us support are behind us, it doesn't matter, does it?";
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
				name.text = "Old territories";
				if (GlobalScript.inst.gameState.allcountries[70].numberOfSpecialEnding < 0)
				{
					if (GlobalScript.inst.gameState.data[66] <= 0)
					{
						fake_text = "The Xinjiang Uygur Autonomous Region continues to be an integral part of China, despite the separatist sentiments fueled by our opponents. However, the situation in the region is still under control, the authorities are functioning as expected,  MSS and the Xinjiang Production and Construction Corps successfully stop any attempts to organize a serious separatist movement for Xinjiang to secede from China.";
					}
					else if (GlobalScript.inst.gameState.data[66] == 1)
					{
						fake_text = "The USSR-supported Xinjiang separatists were able, however, taking advantage of our problems, to seize power in the region and achieve independence from China. However, \"independence\" was quickly replaced by total dependence on the Soviet Union - the leadership of the East-Turkestan People's Republic is formed in coordination with Moscow, the army is commanded by Soviet officers, and the economy is under the full control of advisers from the Union. All parties, except the Communist Party of East Turkestan, are prohibited. De facto, Xinjiang became a \"non-aligned republic\" of the USSR on the model of Bulgaria and Mongolia...";
					}
					else if (GlobalScript.inst.gameState.data[66] == 2)
					{
						fake_text = "The Xinjiang separatists were able, however, taking advantage of our problems, to seize power in the region and achieve independence from China. As was to be expected, after the breakdown of cooperation with our enterprises, the district’s economy collapsed, and the attempts of the leadership of the Xinjiang Republic to balance between us, the USSR and the USA, turned it into a field of geopolitical struggle. While the upper crust and the resurgent bourgeoisie are basking in luxury, squandering dollars, rubles and yuan from superpowers, the people of Xinjiang live in extreme poverty, which is why Islamist sentiments are gaining more and more popularity... ";
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
						fake_text += "||Tibetan separatists were able, taking advantage of our problems, to seize power in the region and achieve independence from China. 14th Dalai Lama solemnly returned to Lhasa, where he made a solemn speech, exposing us and rejoicing \"the end of the Chinese occupation of free Tibet\". However, not everything is so rosy in the \"free Tibet\" - with a break in cooperation with our enterprises, the district’s economy has actually collapsed, the population has to literally survive cattle breeding and the collection of medicinal herbs, and India is already starting to raise a long-standing territorial dispute over Arunachal Pradesh and requires revision \"McMahon Line\" in their favor...";
					}
				}
				if (!GlobalScript.inst.gameState.completedDecisions[6] && !GlobalScript.inst.gameState.completedDecisions[7])
				{
					if (GlobalScript.inst.gameState.allcountries[38].dev > 0)
					{
						fake_text = fake_text + "||Taiwanese separatists hid behind the backs of their American friends, but they overestimated their defenders and underestimated our determination to reunite our homeland. The landing force recaptured the border islands off the coast of Taiwan and drove the separatists out of there, restoring our sovereignty over this territory. \"The territory of China is one and indivisible!\" - answered the Chairman " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " to the furious cries of the imperialists. True, we ourselves will not be able to recapture Taiwan itself because of the American military bases located there, and it certainly will not go to negotiations after this...";
					}
					else if ((GlobalScript.inst.gameState.allcountries[38].proprc && GlobalScript.inst.gameState.data[6] < 700 && GlobalScript.inst.gameState.data[16] >= 13 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.modifies[17].active) || GlobalScript.inst.gameState.completedDecisions[6])
					{
						fake_text = fake_text + "||Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " put forward an important theory \"One country - two systems\", according to which Taiwan, Hong Kong and Macau can return to the bosom of the motherland while maintaining their political and economic system for 50 years in advance and very broad autonomy. The leadership of Taiwan for a very long time refused any negotiations with us, but, finally, we managed to put them at a round table and come to an agreement. In exchange for the formal recognition by the PRC of the independence of the Republic of China and its rejection of claims to the coastal islands, Taiwan officially renounces \"Three Principles of the People\" and recognizes the policy \"One country - two systems\". Negotiations have already begun on the basic principles for the reunification of Taiwan with China (the conditions will be clearly confederate or even broader) and on the withdrawal of American military bases from the island, but the final reunification of the homeland will not happen soon...";
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(66);
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[38].proprc || GlobalScript.inst.gameState.allcountries[38].Torg)
					{
						fake_text = fake_text + "||Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", despite the fierce resistance of many conservatives and hardliners, he nevertheless made a strong-willed decision to recognize Taiwan's independence and end almost half a century of hostility. According to the new course of Chinese diplomacy, Taiwan was independent for too long and during that time moved away from mainland China culturally, economically and politically and built too strong relations with the world community to talk about its belonging to the PRC. It was announced the development of completely new principles of good-neighborly relations between the PRC and the Republic of China, which in turn renounced claims to mainland China.";
					}
					else
					{
						fake_text += "||The separatist \"Republic of China\" continues to hold Taiwan and the coastal islands, relying on US military support and flatly refusing to normalize relations with mainland China. We can only sigh and send the invaders \"last Chinese warnings\"...";
					}
				}
			}
			else if (number_of_e == 2)
			{
				name.text = "New Territories";
				if (GlobalScript.inst.gameState.data[65] <= 0)
				{
					fake_text = "Hong Kong and Macao continue to be colonies, respectively, of Great Britain and Portugal, separated from their homeland. Western colonialists refuse any negotiations on their return to us, and we don’t risk military action for fear of US intervention and the start of the Third World War.";
				}
				else if (GlobalScript.inst.gameState.data[65] == 1)
				{
					fake_text = "Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " Comrade and the NPC put forward an important theory \"One country - two systems\", according to which Hong Kong and Macao can return to the bosom of the Motherland with the preservation of their political and economic system for 50 years ahead and very wide autonomy. Negotiations on this issue with the English and Portuguese sides were very difficult and were repeatedly disrupted by the colonialists, but they were still successful - on July 1, 1997 we will return sovereignty over Hong Kong, and on December 19, 1999 - over Macau. Thus, the great dream of the Chinese people - Hong Kong (Hong Kong) and Macao (Macao) - to return to us is to be fulfilled — let's hope thats forever.";
				}
				else if (GlobalScript.inst.gameState.data[65] == 2 && GlobalScript.inst.gameState.allcountries[0].stab == 1)
				{
					fake_text = "During the leadership of the country " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", may have made a lot of mistakes, but this period will go down in the history of China as \"Restoration of the Motherland\" - for historical justice was restored and Hong Kong and Macao, which for hundreds of years were held by foreign invaders, were returned by China. Now Hong Kong (Hong Kong) and Macao (Macau) are back together with the Motherland, and we will never give them to anyone again!";
				}
				else if (GlobalScript.inst.gameState.data[65] == 2)
				{
					fake_text = "The skill of our diplomats and our reputation in the world allowed, despite serious opposition from the colonial authorities, to achieve in negotiations with the British and Portuguese transfer of Hong Kong and Macao with their full integration into the PRC, while guaranteeing the preservation of private property of foreigners. Negotiations on this issue with the English and Portuguese sides were very difficult and were repeatedly disrupted by the colonialists, but they were still successful - on July 1, 1997 we will return sovereignty over Hong Kong, and on December 19, 1999 - over Macau. Thus, the Hong Kong (Xianggang) and Macau (Macau) to come back to us - hopefully, forever.";
				}
				if (GlobalScript.inst.gameState.data[62] <= 0)
				{
					fake_text += "||The state of Arunachal Pradesh continues to be part of India, which China stubbornly refuses to recognize. Attempts to negotiate on this issue, including the patronage of international organizations, were not crowned with success, so the situation on the Indo-Chinese border remains tense. However, it is unlikely that the parties are interested in war with each other...";
				}
				else if (GlobalScript.inst.gameState.data[62] == 1 || (GlobalScript.inst.gameState.allcountries[19].Torg && (GlobalScript.inst.gameState.data[91] == 1 || GlobalScript.inst.gameState.data[91] == 2 || GlobalScript.inst.gameState.data[91] == 3) && (!GlobalScript.inst.gameState.allcountries[31].Torg || GlobalScript.inst.gameState.allcountries[31].Gosstroy == 2 || GlobalScript.inst.gameState.allcountries[31].Gosstroy == 1)))
				{
					fake_text += "||We were able to reach an agreement with the leadership of India on a compromise solution to the territorial issue - China refuses claims to the state of Arunachal Pradesh, and India - to the Aksai Chin area that we occupied during the border conflict of 1962 and through which passes the important G219 highway connecting Xinjiang with Tibet. This decision finally opened the way to restoring the good-neighborly relations of the two largest countries of Asia and greatly eased tensions in the Asian region.";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(39);
					}
				}
				else if (GlobalScript.inst.gameState.data[62] == 2)
				{
					fake_text += "||China finally put an end to the long-standing territorial dispute with India - the decisive actions of our armed forces, the state of Arunachal Pradesh was fully returned to China. The leadership of India, against the background of yet another aggravation of the situation in the Sikh regions of the country and the conflict with Pakistan, had to recognize our rights to this territory, although the fact of losing this very important state for the country made them very angry. According to our data, India is secretly negotiating with the United States, the USSR and Great Britain about large deliveries of weapons and equipment for the large-scale re-equipment of its army. Against whom are these preparations - no guessing...";
				}
				else if (GlobalScript.inst.gameState.data[62] >= 3)
				{
					fake_text += "||China has finally put an end to the long-standing territorial dispute with India - through the decisive actions of our diplomats Arunachal Pradesh has been fully returned to China. Against the background of regular aggravation of situation in the Sikh areas of the country and economic problems, the Indian leaders had to acknowledge our rights to this territory, though the fact of loss of this very important for the country state angered their people very much. According to our information, India is secretly making arrangements with the US, the USSR and Britain for large supplies of equipment and gear for large-scale rearmament and expansion of its intelligence services. Who are these preparations against - it is hard to say: suppressing their own population or fomenting unrest in Arunachal Pradesh?";
				}
				if (GlobalScript.inst.gameState.data[167] == 0)
				{
					fake_text += "||The Diaoyu Islands still continue to be under Japanese possession.....";
				}
				else if (GlobalScript.inst.gameState.data[167] == 1)
				{
					fake_text += "||We managed to take over the Diaoyu Islands and now our flag flies proudly there at our own naval base! The sea is ours!";
				}
				else if (GlobalScript.inst.gameState.data[167] == 2)
				{
					fake_text += "||We managed to find a compromise with the Japanese side. Now the Diaoyu Islands are demilitarised and jointly owned by the Sino-Japanese Commission and receive investment from both sides, as well as benefits for both countries.";
				}
				if (GlobalScript.inst.gameState.allcountries[9].prosov && !GlobalScript.inst.gameState.completedDecisions[19])
				{
					fake_text += "||Mongolia remains an active friend and partner of Moscow no matter what.";
				}
				if (!GlobalScript.inst.gameState.allcountries[9].proprc && !GlobalScript.inst.gameState.completedDecisions[19] && !GlobalScript.inst.gameState.allcountries[9].prosov)
				{
					fake_text += "||Mongolia is pursuing a multi-vector policy, trying to be friends with both the USSR and China for the benefit of its people";
				}
				else if (GlobalScript.inst.gameState.allcountries[9].proprc && !GlobalScript.inst.gameState.completedDecisions[19])
				{
					fake_text += "||Mongolia is a full-fledged equal member of China's sphere of influence and is oriented on Beijing in resolving disputes and foreign policy issues.";
				}
				else
				{
					fake_text += "||Through diligence and hard work, Chinese and Mongolian brothers have once again been able to find a common ground and unite under the roof of a single home of the People's Republic of China.";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(109);
					}
				}
			}
			else if (number_of_e == 3)
			{
				name.text = "The fate of the USSR";
				if (GlobalScript.inst.gameState.empires[1].now_leader == 3)
				{
					fake_text = "Shcherbitsky|Replaced Brezhnev, Vladimir Shcherbitskiy began his reign with cleanings in the Politburo, leading to the vacant seats of his people from Ukraine, which shook the stagnant Brezhnev apparatus and violated the corruption ties between its members. Blows to corruption, coupled with the administrative talents of the old Manager provided the Union with a steady growth of the economy and the welfare of the population. The foreign and domestic policy of Shcherbitsky differed little from Brezhnev's - the economic integration of the CMEA countries was strengthened, which had a positive impact on the entire Commonwealth, the détente in relations with China was carried out, cautious and slow attempts are made to automate planning, but in General everything is stable. The Union stands and is going to stand for a very long time.";
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
					fake_text = "Gorbachev|In the end, the old ruler was replaced by a young and promising Mikhail Gorbachev, one of Andropov's reformist cadres. However, none of Gorbachev's reform initiative ended well - the anti-alcohol campaign led to the decline of agriculture and the mass circulation of surrogates, the policy of Acceleration - to the talentless waste of funds and the decline of industry, Glasnost - to the growth of nationalism and the heyday of anti-Soviet lies.";
					if (!GlobalScript.inst.gameState.startedDirectWarsNum.Any((KeyValuePair<int, bool> k) => k.Key == 10 && k.Value))
					{
						if (GlobalScript.inst.gameState.allcountries[51].isNATO)
						{
							fake_text += "Attempts to increase or reduce the role of the state in the economy, the incompetent and uncontrolled introduction of cooperatives, decentralization and the destruction of planned mechanisms have led to a huge external debt, the collapse of the economy, the deficit and impoverishment of the population. Foreign policy was characterized by subservience to the US and surrender of all the gains of socialism, culminating in the dissolution of the Warsaw Pact and COMECON. The USSR itself did not survive them for long - the liberals and nationalists raised by Gorbachev, having won the support of the population, at the end of 1991 announced the dissolution of the USSR, actually taking away power from the would-be reformer.";
						}
						else
						{
							fake_text += "Attempts to increase and decrease the role of the state in the economy, the ineffective and uncontrolled introduction of cooperatives, decentralisation and the destruction of planned mechanisms led to a huge foreign debt, the collapse of the economy, deficits and the impoverishment of the population. In 1991, centrifugal forces brought Gorbachev to the point where he decided to sign a new union treaty. But in August 1991 he was removed from power by more pragmatic reformers who formed the GKChP. Yanayev, who became interim president, arrested the leaders of the most radical separatist movements, including Yeltsin. Ivan Polozkov, a pragmatic reformer, was then elected president in February 1992, leading the economy from decline to small but steady growth. The USSR established the semi-market democracy of the Soviets on the precepts of the SRs.";
						}
					}
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(36);
					}
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 8)
				{
					fake_text = "Ligachev|In the end, the old ruler was replaced by an experienced regional leader Yegor Ligachev, one of the reformist cadres of Andropov. He proclaimed a policy of Glasnost, expansion of democratization and transition to a socialist market economy on the model of Lenin's NEP. However, all the reform initiatives of Ligachev went with great difficulty - the anti-alcohol campaign led to the circulation of surrogates, although it allowed to increase the birth rate and reduce crime, the policy of Acceleration allowed to increase industrial production, but caused an increase in the deficit of consumer goods, Glasnost - although it allowed to expand freedom, led to the emergence of anti-Soviet publications. Attempts to move from decision-making to economic mechanisms in the economy, not fully considered the introduction of cooperatives, decentralization and violation of planned mechanisms led to a decline in the production of consumer goods and impoverishment of quite a significant part of the population.";
					if (GlobalScript.inst.gameState.allcountries[51].isNATO)
					{
						fake_text += "Foreign policy was characterized by the unsuccessful attempts of Detente with the United States and the reduction control of the Warsaw Pact and the CMEA, which led to growth of separatist tendencies in these blocks. The USSR itself is in a rather difficult situation, and Ligachev's attempts to strengthen the situation by promoting people such as Boris Yeltsin and Vitaly Korotich, led to the emergence of the CPSU legal opposition, undermining the unity of the party. So far, the country's leadership controls the situation, but economists warn that within 25 years a major crisis is possible, which the Soviet pseudo-reformers may not survive...";
					}
					else if (GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[1].power && !GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text += "Despite this, the Soviet economy survived the ordeal by significantly expanding trade with Western Europe. The CMEA and OVD countries did not resolve their Perestroika despite the reduction of control over them. A national-patriotic conservative opposition emerged that opposed the reforms. Eventually, after the XXX Congress of the CPSU in 1993, Ligachev was removed at a plenum and replaced by Aman Tuleyev, who began reducing the rights of the republics, slowing market reforms, and rehabilitating Stalin as a Russian statesman on a par with Ivan the Terrible and Peter the Great. The USSR was declared a historical Russian state, and ‘all those who think in Russian’ were recognised as Russians.";
					}
					else
					{
						fake_text += "Despite this, the Soviet economy survived the ordeal by significantly expanding trade with Western Europe. The CMEA and OVD countries did not dare to perestroika, despite the reduction of control over them. Opposition was suppressed and reforms were continued in the spirit of dengism and NEP. Eventually, at the XXXIII Congress of the CPSU in 2000, Ligachev announced his resignation. He was succeeded by Gennady Zyuganov, who supported traditional values, continued market reforms and officially adopted the party programme without mentioning the building of communism. ";
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
						fake_text = "Romanov|In the end, the old ruler was replaced by a relatively young and promising party member Grigory Romanov, known for his services as head of the Leningrad regional Committee of the CPSU. His arrival marked the beginning of internal party purges from the reformers, increased control of the security services and the persecution of dissidents. Paradoxically, under his rule, began to have some censorship concessions in the creative sector - there were plenty of music clubs, on the model of the Leningrad rock club, and filmmakers have become freer to experiment with new genres. The foreign policy of the USSR became more rigid and was characterized by more active spread of Soviet influence and more rigid protection of Soviet interests. ";
						if (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.data[16] == 11)
						{
							fake_text += "|Inspired by the success of the Chinese automation, Romanov decided to start mass implementation of automation planning, and continued development of the CSA and USNCC, and, taking from a shelf project OGAS, development and implementation of which managed to finish, despite dissatisfaction with the party members. Romanov led the Soviet Union until his death in 2008, during which time repeatedly raising the international influence of the USSR, its economic power and the welfare of the population.";
							if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.data[16] == 11 && GlobalScript.inst.gameState.allcountries[1].isSEV)
							{
								achieves.GetComponent<achievements>().Set(35);
							}
						}
						else if (GlobalScript.inst.gameState.allcountries[15].Gosstroy == 0 && GlobalScript.inst.gameState.allcountries[15].SubGosstroy == 0 && GlobalScript.inst.gameState.allcountries[4].Gosstroy == 1 && GlobalScript.inst.gameState.allcountries[4].SubGosstroy == 16)
						{
							fake_text += "|Having seen by personal example the failure of the results of the economic policy of Hungary and Yugoslavia, Romanov decided to take a different path from Andropov's plans and to start mass implementation of automation planning. He continued development of the CSA and USNCC, and, taking from a shelf project OGAS, development and implementation of which managed to finish, despite dissatisfaction with the party members. Romanov led the Soviet Union until his death in 2008, during which time repeatedly raising the international influence of the USSR, its economic power and the welfare of the population.";
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
				name.text = "Soviet Socialist Camp";
				if (GlobalScript.inst.gameState.empires[1].now_leader == 4 && GlobalScript.inst.gameState.event_done[377])
				{
					fake_text = string.Format(GlobalScript.inst.new_events_text[1570], "\n", (GlobalScript.inst.gameState.allcountries[7].parts[1] || GlobalScript.inst.gameState.allcountries[1].parts[2]) ? GlobalScript.inst.new_events_text[1571] : null);
				}
				else if ((GlobalScript.inst.gameState.empires[1].now_leader == 3 || GlobalScript.inst.gameState.empires[1].now_leader == 5 || GlobalScript.inst.gameState.empires[1].now_leader == 4) && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[1].isOVD)
				{
					fake_text = "For the socialist camp nothing has changed much - the CMEA and Warsaw Pact continue to remain a stable alternative to capitalist alliances, and the USSR is their undisputed leader.";
				}
				else if ((GlobalScript.inst.gameState.empires[1].now_leader == 3 || GlobalScript.inst.gameState.empires[1].now_leader == 5 || GlobalScript.inst.gameState.empires[1].now_leader == 4) && (GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.allcountries[1].isOVD))
				{
					fake_text = "The entry of the PRC into the CMEA and the Warsaw Pact and the growth of its influence in organizations and in the world cause serious fears of the Soviet governance for their leadership. For the rest, for the socialist camp nothing has changed much - the CMEA and Warsaw Pact continue to remain a stable alternative to capitalist alliances.";
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
					fake_text = "After Gorbachev came to power in the USSR, the social camp began to slowly fall apart, and without Soviet support, the power of its members began to falter. But the well-established relations of the PRC and the USSR, along with trade with the CMEA, allowed us to get what Gorbachev could not hold. After the dissolution of the Warsaw Pact and the CMEA, we insistently offered Eastern Europe membership in our alliances on favorable terms, for which Romania, Bulgaria, Hungary, Poland and Czechoslovakia agreed.";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(6);
					}
				}
				else if ((GlobalScript.inst.gameState.empires[1].now_leader == 6 || GlobalScript.inst.gameState.empires[1].now_leader == 8) && ((GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[1].isOVD) || (GlobalScript.inst.gameState.allcountries[5].Torg && !GlobalScript.inst.gameState.allcountries[2].prosov && !GlobalScript.inst.gameState.allcountries[4].prosov && (GlobalScript.inst.gameState.allcountries[1].isOVD || GlobalScript.inst.gameState.allcountries[1].isSEV))))
				{
					if (GlobalScript.inst.gameState.empires[1].now_leader == 8)
					{
						fake_text = "After Ligachev came to power in the USSR, the social camp began to slowly fall apart, and without Soviet support, the power of its members began to falter. However, our membership in the Warsaw Pact and the CMEA has helped us keep them in a slightly modified form. At a secret meeting, we developed a plan for the final fall of Soviet leadership in the CMEA and WPO. Of course, fearing a dark future, most countries happily agreed, and now the CMEA and WPO formed a more equal and updated socialist camp with our leadership. However, instead of the USSR, now we provide all possible assistance for these countries...";
					}
					else
					{
						fake_text = "After Gorbachev came to power in the USSR, the social camp began to slowly fall apart, and without Soviet support, the power of its members began to falter. However, our membership in the Warsaw Pact and the CMEA has helped us keep them in a slightly modified form. After the dissolution of the CMEA and the Warsaw Pact, we proposed to their members the creation of new blocks, taking on all the costs of supporting the economy of our old friends. Of course, most countries happily agreed - the GDR, Romania, Bulgaria, Czechoslovakia, Hungary and Poland continue to form a more equal and updated socialist camp with our leadership.";
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
						fake_text = "For the socialist camp nothing has changed much - the CMEA and Warsaw Pact continue to remain an alternative to capitalist alliances, and the USSR is still their leader.";
					}
					else
					{
						fake_text = "After Gorbachev came to power in the USSR, the social camp began to slowly fall apart, and without Soviet support, the power of its members began to falter. The bastion of European socialism is finally destroyed by the hands of Gorbachev, the CIA and the KGB. ";
						if (GlobalScript.inst.gameState.allcountries[0].isNATO && GlobalScript.inst.gameState.allcountries[0].isEU)
						{
							fake_text += "And although these countries are now nominally neutral, their accession to the EU and NATO is not far off.";
						}
						else if (GlobalScript.inst.gameState.allcountries[0].isNATO)
						{
							fake_text += "And although these countries are now nominally neutral, their accession to the NATO is not far off";
						}
						else if (GlobalScript.inst.gameState.allcountries[0].isEU)
						{
							fake_text += "And although these countries are now nominally neutral, their accession to the EU is not far off.";
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
					fake_text = "For the socialist camp nothing has changed much - the CMEA and Warsaw Pact continue to remain a stable alternative to capitalist alliances, and the USSR is their undisputed leader.";
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
				name.text = "Cold war";
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
					fake_text = "Times are changing, the Cold War is passing... To begin again with a new force. And even the most implacable enemies of the 20th century - the Soviet Union and the United States had to become sworn friends, and again, like during World War II, unite against a common enemy - China - the new hegemon of the modern world, risen from the ashes and rapidly claiming to dominate the world domination. Trying to save the remnants of their influence, the former enemies, begin a new round of the arms race: NATO and Warsaw Pact conduct joint exercises, the military budgets of the USSR and the USA double each year, with the joint efforts of American and Soviet scientists developing new types of nuclear weapons. It seems that a new large-scale war is becoming a matter of time, but will humanity survive it?";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(17);
					}
				}
				else if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.influencePRC)
				{
					fake_text = "The Cold War is nearing its end, and it seems that the USSR will prevail in this long-standing confrontation, being the most influential force in the world. The US is rapidly losing influence on the world, the dollar system is falling apart, NATO members are pursuing an increasingly independent policy, and the organization itself is close to dissolution. Last but not least, this happened because of the active intervention of the PRC in world politics and the gradual ousting of American influence.";
				}
				else if (GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.influencePRC && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.influencePRC)
				{
					fake_text = "The last few years have not been in vain for the USSR - its influence on the world has seriously expanded and probably one day the Cold War will end in victory - the US is losing its influence, the world communist movement is expanding, and NATO members are pursuing an increasingly independent policy. The PRC, despite a certain foreign policy activity, was never able to break into superpowers, still remaining behind the United States and the USSR, but maybe sooner or later it will change...";
				}
				else if (GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.influencePRC && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.influencePRC)
				{
					fake_text = "The last few years have not been in vain for the United States - their influence on the world has greatly expanded and it looks like they will sometime emerge victorious from the Cold War - the USSR is losing influence in the world, including the socialist camp, and the world communist movement is weakening. The PRC, despite a certain foreign policy activity, was never able to break into superpowers, still remaining behind the United States and the USSR, but maybe sooner or later it will change...";
				}
				else if (GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.influencePRC)
				{
					fake_text = "The Cold War is nearing its end, and it seems that the United States will prevail in this long-standing confrontation, being the most influential force in the world. The USSR is losing influence on the world, including on the socialist camp, which is pursuing an increasingly independent policy, and on the world communist movement. Last but not least, this happened because of the active intervention of the PRC in world politics and the gradual ousting of Soviet influence.";
				}
				else if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[1].power >= GlobalScript.inst.gameState.empires[0].power)
				{
					fake_text = "Once having among its supporters only scattered partisans-Maoists, China nevertheless managed to break through and become a world superpower, gaining great weight in international organizations and many followers in different countries.||The confrontation between the USSR and the USA is gradually fading into the background, however it seems that the USSR will emerge as the winner - the US is rapidly losing influence on the world, the dollar system is falling apart, NATO members are pursuing an increasingly independent policy, and the organization itself is close to dissolving.";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(33);
					}
				}
				else if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power && GlobalScript.inst.gameState.empires[0].power >= GlobalScript.inst.gameState.empires[1].power)
				{
					fake_text = "Once having among its supporters only scattered partisans-Maoists, China nevertheless managed to break through and become a world superpower, gaining great weight in international organizations and many followers in different countries.||The confrontation between the USSR and the USA is gradually fading into the background, however it seems that the USA will emerge as the winner - the USSR loses any influence on the world communist and simply anti-American movement, the socialist camp collapses before our eyes and most likely will be divided between the PRC and the USA, and we will get the best part.";
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
					fake_text += "||The 80s became a turning point for Yugoslavia: a huge external debt, the consequences of Tito's economic policy, attempts to improve the situation with the help of market reforms could lead to disastrous consequences, however, thanks to the timely intervention of the socialist camp, this was avoided. Yugoslavia decided to join CMEA as a full member, which, thanks to cooperation with the social camp, preferential prices and Soviet help, helped to revive the economy and begin to gradually pay off its debts, and the help of the KGB helped appease nationalists and liberals. Of course, this led to the separation of the SFRY from the West and the rapprochement with the USSR.";
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
					fake_text += "||The 80s were difficult times for Yugoslavia: huge external debt, the consequences of Tito's economic policy, attempts to improve the situation through market reforms and the absence of influential patrons led to a deterioration in the economic situation, a decline in living standards and, as a result, an increase in nationalism in the republics. Attempts by the United States and the West to support the nationalists led to a deterioration in relations, which is why Belgrade eventually decided to join the Warsaw Pact, having received a generous offer from Romanov: huge financial assistance, preferential supplies of raw materials and full protection from the West.";
				}
				else if (!GlobalScript.inst.gameState.allcountries[15].isMonatchy && (!GlobalScript.inst.gameState.event_done[455] || GlobalScript.inst.gameState.resultOfEvents[455] > 2) && GlobalScript.inst.gameState.allcountries[4].okb && GlobalScript.inst.gameState.empires[1].now_leader == 6)
				{
					fake_text += "||The 80s were difficult times for Yugoslavia: huge external debt, the consequences of Tito's economic policy, attempts to improve the situation through market reforms and the absence of influential patrons led to a deterioration in the economic situation, a decline in living standards and, as a result, an increase in nationalism in the republics. Attempts by the United States and the West to support the nationalists led to a deterioration of relations, which is why Belgrade began to focus more on Russia and China, fully joining the 16+1 program.";
				}
				else if (GlobalScript.inst.gameState.allcountries[15].Gosstroy == 0 && !GlobalScript.inst.gameState.allcountries[15].prosov)
				{
					fake_text += "||The 80s were difficult times for Yugoslavia: huge external debt, the consequences of Tito's economic policy, attempts to improve the situation through market reforms and the absence of influential patrons led to a deterioration in the economic situation, a decline in living standards and, as a result, an increase in nationalism in the republics. However, Yugoslavia still managed to survive these trials, not least thanks to our help. Market reforms were limited to the continuation of experiments with cost accounting and decentralization, and in the early 90's they completely stopped. The nationalists managed to play on the discontent of the people and try to secede, but all the attempts of separatism were quickly suppressed by the YPA. Attempts by the USA and the West to support nationalists led to a deterioration in relations between the West and the SFRY, which began to focus more on the USSR and China, although it continued to remain neutral.";
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(65);
					}
				}
				else if (!GlobalScript.inst.gameState.allcountries[15].isMonatchy && (!GlobalScript.inst.gameState.event_done[455] || GlobalScript.inst.gameState.resultOfEvents[455] > 2) && GlobalScript.inst.gameState.allcountries[15].Torg && (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power || GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[0].power || (GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.empires[1].power + GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[0].power)))
				{
					fake_text += "||The 80s were difficult times for Yugoslavia: huge foreign debt, the consequences of Tito's economic policy, attempts to improve the situation through market reforms and the absence of influential leaders led to a deterioration in the economic situation, a decline in living standards and, as a result, an increase in nationalism in the republics. However, Yugoslavia still managed to survive these trials, especially thanks to our help. Market reforms did not take on such a large scale, and liberal political ones were quickly sabotaged and crushed by the military and conservatives. However, it was still not possible to avoid a civil war, and Slovenia and Croatia were still able to gain independence by its results, however, in other regions, the rebellions were soon suppressed by the JNA. Attempts by the Americans to support the separatists led to a deterioration in their relations with Yugoslavia, which every year is increasingly establishing cooperation with the USSR and China. Yugoslavia, albeit declining in size, continues to exist.";
				}
				else if (!GlobalScript.inst.gameState.allcountries[15].isMonatchy && (!GlobalScript.inst.gameState.event_done[455] || GlobalScript.inst.gameState.resultOfEvents[455] > 2))
				{
					fake_text += "||The 80s were difficult times for Yugoslavia: huge foreign debt, the consequences of Tito's economic policy, attempts to improve the situation through market reforms and the absence of influential leaders led to a deterioration in the economic situation, a decline in living standards and, as a result, an increase in nationalism in the republics. The government’s inability to stabilize the situation eventually led to the seizure of power by the military faction and the outbreak of civil war between the central government (which soon turned out to be actually represented by Serbia and Montenegro) and Croatian, Slovenian and Albanian nationalists. It is not known who would emerge victorious from it, since NATO troops put an end to it and in the history of Yugoslavia by their operation against Serbia. A single Balkan state ceased to exist, and almost all of its former republics are now oriented toward the west and the USA.";
				}
			}
			else if (number_of_e == 6)
			{
				name.text = "Sweet life";
				if (GlobalScript.inst.gameState.data[5] <= 400)
				{
					fake_text = "Your governance haven't brought China much improvements in life of it's common citizens - our standards of living are still like in the beginning of 70-s. Food crisises are happening sometimes, villagers don't know the modern conveniences, and in cities the situation is not the best - common people live in poorly equipped houses, often in communal houses and slums, goods of wealthy classes are rare and luxury is only available for high goverment officials and enterprise directors.";
				}
				else if (GlobalScript.inst.gameState.data[5] <= 700)
				{
					fake_text = "Your governance was marked by a rising chinese standards of living - food supply problems have been finally solved, most people now have access to goods os wealthy classes and living conditions in cities have improved for many Chinese, though many workers still have to live in communal houses and slums. Situation is worse in the villages but infrastructure is already developing, modern houses are built in villages and modern communications are being brought to them. We are expected to reach japanese level of standards of living soon. The people will always remember your contributions to their bright future.";
				}
				else
				{
					fake_text = "Your governance was marked by a huge rising in chinese standards of living - not only the food supply problems have been solved but we have reached a level where almost everyone has access to the goods of wealthy classes and more and more people acquire luxury items. We actively overcoming the gap between the city and the village - ubiquitous electrification was made, modern communications were brought, modern houses are being built in villages. Now every honest worker has worthy home and food, in standards of living China have already outrun all Asian countries, including Japan, and for the people you will always be the loved ruler who gave China development and a new life.";
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
				name.text = "Worldwide situation";
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
						fake_text = "Nothing much has changed on the Korean peninsula - the confrontation of two Koreas continues. And in the beginning of 2000-s it brought to a development of nuclear weapons in DPRK to protect itself against american agression. DPRK continues neutral foreign policy maintaining good relations with China and Moscow but without joining their blocks.";
					}
					else if (GlobalScript.inst.gameState.data[83] <= 0 && GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.empires[1].now_leader != 6 && GlobalScript.inst.gameState.allcountries[10].Gosstroy == 1)
					{
						fake_text = "Nothing much has changed on the Korean peninsula - the confrontation of two Koreas continues. To gain advantage in it in the 90-s DPRK has joined CMEA and soon joined the WPO, seeing that the split between PRC and USSR had finally been overcame. That gave it economic boost and a solid protection against american agression.";
					}
					else if (GlobalScript.inst.gameState.data[83] <= 0 && (!GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.empires[1].now_leader == 6) && GlobalScript.inst.gameState.allcountries[10].Gosstroy == 2)
					{
						fake_text = "Nothing much has changed on the Korean peninsula - the confrontation of two Koreas continues though in a more soft form. Massive reforms were made in DPRK - which meant decentralization of planning, civil liberalization and SEZ opening is planned. Thoug these actions have improved DPRK's relations with USA and pro-american neighbors, in the beginning of 2000-s nuclear weapons have been developed in DPRK to protect itself against american agression. DPRK continues neutral foreign policy maintaining good relations with China and Moscow but without joining their blocks.";
					}
					else if (GlobalScript.inst.gameState.data[83] <= 0 && GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.empires[1].now_leader != 6 && GlobalScript.inst.gameState.allcountries[10].Gosstroy == 2)
					{
						fake_text = "Nothing much has changed on the Korean peninsula - the confrontation of two Koreas continues though in a more soft form. Massive reforms were made in DPRK - which meant decentralization of planning, civil liberalization and SEZ opening is planned. Thoug these actions have improved DPRK's relations with USA and pro-american neighbors, in the 90-s DPRK has joined CMEA and soon WPO, seeing that the split between PRC and USSR had finally been overcame. That gave it economic boost and a solid protection against american agression.";
					}
					else if (GlobalScript.inst.gameState.data[83] == 1)
					{
						fake_text = "After successful unification of Korea under DPRK's banner and exile of american invaders a long-awaited revival and development began in Korea and in the 90-s the country has announced about successful nuclear weapons development. ";
						if (GlobalScript.inst.gameState.empires[1].now_leader == 6)
						{
							fake_text += " DPRK, protected by the nuclear warheads, quickly started to conduct independent foreign policy. Korea tries to become a new independent power in the region and global politics and it seems that it will eventually.";
							if (GlobalScript.inst.gameState.iron_and_blood)
							{
								achieves.GetComponent<achievements>().Set(16);
							}
						}
						else if (GlobalScript.inst.gameState.allcountries[10].econ)
						{
							fake_text += " Soon DPRK joined our alliance, what boosted the country's economy even more.";
						}
						else
						{
							fake_text += " Soon DPRK joined CMEA, what boosted the country's economy even more.";
						}
					}
					else if (GlobalScript.inst.gameState.data[83] == 2)
					{
						fake_text = "After DPRK's defeat and unification of Korea under Republic's banner the USA have firstly brought more troops to annexed regions to fight growing guerilla movement. The guerillas control many northern areas and wear down americans by ongoing attacks. It seems that long-awaited Korean revival won't come soon.";
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
					fake_text = "Nothing interesting has happened on the Korean peninsula.";
				}
				if (GlobalScript.inst.gameState.allcountries[37].SubGosstroy == 17 && GlobalScript.inst.gameState.allcountries[37].okb)
				{
					fake_text += "|With the direct support of China, a regime of traditionalist agrarians, who rejected the capitalist system of economy, was established in the Union State of Palestine and Israel. But this was not enough for the Chinese authorities, they were not satisfied with the too slow pace of reforms. Therefore, the option of creating Death Battalions, where the poor were recruited, and a large-scale purge of the Palestinian-Israeli army was put forward, officially \"to protect it from the reactionary forces in the army\".|Year after year this organisation gradually grew replacing the army, and was led by Chinese advisers and individuals recruited by the Chinese intelligence services. And when the organisation became strong enough according to the opinion of foreign curators, it was time to implement the plan: in one night the Death Battalions seized all government and administrative buildings and residential centres of political power of all cities and regions of the country and executed them all on the spot. Then arrested and deposed the remnants of the army. And finally they set fire to all the cities and towns, blowing up everything they could. The alarmed citizens ran out of their homes, where they were met by Death Battalion units and taken to special tent camps. There, the entire population of the country was divided into several hundred tribes, led by Death Battalion leaders. And each family was given a horse, a wagon and stacks of hard warm fabric. So like that in Palestine and Israel it started a period of return to the roots - to nomadic tribal life. And the remaining bits of civilisation survived only in water extraction areas and minor settlements nearby to support water extraction under the control of Death Battalions. Money had also been abolished in the country, replaced by barter.|<color=red>\"My children, you have finally found the Promised Land bequeathed to us by God.\"</color>";
					achieves.GetComponent<achievements>().Set(160);
				}
				else if (GlobalScript.inst.gameState.data[85] == 0)
				{
					fake_text += "|The conflict between Palestinians and Israel remained unsolved until palestinian rebellion in 1987-1993, known as the First Intifada and harshly suppressed by Israel, forced sides to negotiate. The Oslo Accords created Palestinian National Administration as a palestininan territory authonomy and the PLO stopped terrorist attacks. But Israel's reluctance to make concessions and ongoing terrorism from different organizations led to disruption of peaceful process and the Second Intifada in 2000-2005.";
				}
				else if (GlobalScript.inst.gameState.data[85] == 1)
				{
					fake_text += "|Our interference and forcing sides to negotiate marked the beginning of Palestinian-Israeli conflict's settlement. The Beijing Accords created Palestinian National Administration as a palestininan territory authonomy and the PLO stopped terrorist attacks. But Israel's reluctance to make concessions and ongoing terrorism from different organizations led to disruption of peaceful process and the Palestinian Intifada in 2000-2005.";
				}
				else if (GlobalScript.inst.gameState.data[85] == 2)
				{
					fake_text += "|Our interference and forcing sides to negotiate marked the beginning of Palestinian-Israeli conflict's settlement. The Beijing Accords created the State of Palestine on some parts of Israel's territory. Transfering control of these areas to palestinian administration was accompanied by many excesses, the status of Eastern Jerusalem, creating a corridor between the Gaza Strip and the West Bank of Jordan river and ongoing terrorist's attacks are still causing trouble. The relations between two states are still strained but there is already a progress in achieving peace.";
				}
				else if (GlobalScript.inst.gameState.data[85] == 3)
				{
					fake_text += "|Our interference and forcing sides to negotiate marked the beginning of Palestinian-Israeli conflict's settlement. The Beijing Accords created the United State of Palestine and Israel with two state languages and developed local governance. The subjects' borders and status of Eastern Jerusalem became subjects of sharp disputes, some terrorists organizations are also causing trouble. Another problem is USPI's foreign policy, which causes harsh arguments in newly created state agency. The relations between nations in the new state will be strained for long but international control and equality and brotherhood propaganda will eventually end this conflict.";
				}
				else
				{
					fake_text += "|Nothing interesting has happened in the Arab-Israeli conflict.";
				}
				if (GlobalScript.inst.gameState.allcountries[30].parts[0])
				{
					fake_text += string.Format(GlobalScript.inst.new_events_text[1601], "\n");
				}
				else if (GlobalScript.inst.gameState.OAR && GlobalScript.inst.gameState.allcountries[14].oar && GlobalScript.inst.gameState.allcountries[35].oar && GlobalScript.inst.gameState.allcountries[13].oar)
				{
					fake_text += "|The long-awaited unification of main Arab states into the United Arab Republic, based on arabic socialism principles, had finally been done. Uniting states with similar systems into one was not so difficult, and though the struggle between centralization supporters and local elites is weakening the country's stability, the integration in common went fine. By uniting the economy of several countries and creating a united army UAR became the strongest country in the Near East and a powerful member of international community. UAR tries to maintain friendship with socialist countries and it's growing appetites undermine already weak peace in the region. Israel strengthens the borders and some people say about coming UAR's invasion to Saudi Arabia and Sudan.";
				}
				else if (GlobalScript.inst.gameState.OAR)
				{
					fake_text += "|Initial jubilation of creating the united Arab state was changed by comprehension of many problems - not all Arab countries have joined the UAR and the ones who joined began to struggle for power in the new state. The struggle between centralization supporters and local elites led to many laws of authonomies and special statuses what didn't helped the efficiency of governance. The UAR continues to exist but it's members conduct more and more independent policy and the unity is more and more formal.";
				}
				else if (GlobalScript.inst.gameState.data[85] == 2)
				{
					fake_text += "|Arabic states continue to remain scattered and plans of unification are forgotten";
				}
				else
				{
					fake_text += "|Nothing interesting has happened in the Arab issue.";
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
				fake_text = "Your policy has made Chinese people more and more angry. When you tried to calm the growing protests by any means, you failed and began an open uprising, which was quickly supported by army and some party members. Arresting and judging you in court, high party members and generals have declared a temporary goverment. Chinese future is obscure...";
			}
			else if (GlobalScript.inst.gameState.data[35] == 2)
			{
				name.text = "Party coup";
				fake_text = "Your actions has made the Party more and more angry. Getting tired of you, high party members had organised the meeting where you were criticized and the party voted for your resignation. Now you are a pensioner, nobody wants, and your former spot is occupied by a compromise candidate, trying to manoeuvre between rival fractions.";
			}
			else if (GlobalScript.inst.gameState.data[35] == 3)
			{
				name.text = "Nuclear war";
				fake_text = "You have made your way to the precious red button and launched the missiles. Your strike has destroyed the weak balance between USA and USSR and after you they have also swapped nuclear strikes. Most cities have been destroyed, the planet is polluted and most of the survivors have gone down to the bunkers and shelters.";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(18);
				}
			}
			else if (GlobalScript.inst.gameState.data[35] == 4)
			{
				name.text = "Genocide";
				fake_text = "During your leadership China's population - once the largest in the world - decreased dramatically. This cannot remain unnoticed, you were more and more often accused  in genocide and eventually when the Party got tired of it you were arrested and sent to court.";
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					achieves.GetComponent<achievements>().Set(49);
				}
			}
			else if (GlobalScript.inst.gameState.data[35] == 6)
			{
				name.text = "Behind every machine is a man";
				fake_text = "Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " decided to avoid possible bloodshed and voluntarily resigned for health reasons. The old leaders were replaced by new, but much less proactive.  Censorship has been tightened in domestic politics, and any deviations from the general line are totally suppressed. IECS was limited to automation of production and the armed forces, and now there is a person behind each machine, so the state apparatus even had to be significantly increased. Even despite this, the economy of the PRC is developing, but every year the growth rate is falling and falling, and someday all the problems of the Chinese economy will surface. China's future is foggy.";
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
				name.text = "New Order";
				if (GlobalScript.inst.gameState.party_number[0] > GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] > GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] > GlobalScript.inst.gameState.party_number[4])
				{
					fake_text = "The elections in the NPC did not bring success to the CPC, and radical Communists from the MCPC get the victory on the wave of populism, gaining a relative majority of votes. The MCPC candidate also won the presidential election. Taking advantage of the position of President, as well as the relative majority in Parliament, the MCPC formed a quasi-coalition government in which representatives of other parties received only 3 minor posts. The new government declared its goal to return to Maoism, building socialism and communism in China and around the world, entering into a decisive confrontation with the Soviet revisionists and American imperialists. As part of the policy of returning to socialism, first of all, it was decided to return to the one-party system, destroying the bourgeois Republic and launching a new Cultural revolution against the revisionists and capitalists. The list of revisionists and capitalists included all parties, except for the MCPC. Other parties tried to organize public actions against the Maoists and their policies, calling in support of the United States and the USSR, but this initiative was suppressed by the police with the support of the army and armed youth from the military organization of the MCPC. In response, the Maoists organized far more rallies in support of the Maoist cause throughout the country, where they forcibly rounded up all those who came to hand in support of Chairman Mao's cause. The people, led by the state and the party, defeated the headquarters of the opposition parties, and their leaders and activists were killed part, part - sent to the village. The leaders of the CCP also failed to avoid a fair popular anger: the leaders were subjected to the 'corridor of shame', after which they publicly confessed to revisionism, which they immediately repented of, and then were exiled to the people's communes. The United States and the USSR condemned such actions, the Chinese government apologized, shifting the responsibility to the radicals, saying that “could not contain the people's rage, and did not seek to prevent the people in the fight against his enemies, fearing to expose honest people in danger”. However, when the opposition was destroyed, the Armed Forces entered Beijing and other major cities and dispersed with battle not wishing to give power in the hands of the state combat organizations of the MCPC, which officially voluntarily dissolved. A new era in China's history is beginning, in which economic reforms will be combined with an extreme increase in the power of the state over society and the party over the state in the struggle for Chinese socialist culture and the construction of socialism and communism through dictatorship, total control and the new culture of selfless devotion to Mao, ideology and party, eradicating conservative traditionalism and liberal pluralism.";
				}
				else if (GlobalScript.inst.gameState.party_number[0] > 1500)
				{
					fake_text = "The past elections in the NPC did not bring success to the CPC, and the victory in the parliamentary elections was won by radical Communists from the MCPC, gaining an absolute majority in the wave of populism. The MCPC candidate also won the presidential election. Taking advantage of the office of President, as well as the absolute majority in Parliament, the MCPC formed a homogeneous government. The new government declared its goal to return to Maoism, building socialism and communism in China and around the world, entering into a decisive confrontation with the Soviet revisionists and American imperialists. As part of the policy of returning to socialism, first of all, it was decided to return to one-party system, destroying the bourgeois Republic and launching a new Cultural revolution against the revisionists and capitalists. The list of revisionists and capitalists included all parties, except for the MCPC. Other parties tried to organize public actions against the Maoists and their policies, calling for the support of the United States and the USSR, but this initiative was suppressed by the police with the support of the army and armed youth from the military organization of the MCPC. In response, the Maoists organized far more rallies in support of the Maoist cause throughout the country, where they forcibly rounded up all those who came to hand in support of Chairman Mao's cause. The people, led by the state and the party, defeated the headquarters of the opposition parties, and their leaders and activists were killed part, part - sent to the village. The leadership of the CCP also failed to avoid fair popular anger: the leaders of the party were subjected to the 'corridor of shame', and then confessed to revisionism, which immediately repented, and then were exiled to the people's communes. The United States and the Soviet Union condemned such actions, the Chinese government apologized, shifting the responsibility to the radicals, saying that “could not contain the people's rage, and did not seek to prevent the people in the fight against his enemies, afraid to put honest people in danger.”. ТHowever, when the opposition was destroyed, the Armed Forces entered Beijing and other major cities and dispersed with battle not wishing to give power in the hands of the state combat organizations of the MCPC, which officially voluntarily dissolved. A new era in China's history is beginning, in which economic reforms will be combined with an extreme increase in the power of the state over society and the party over the state in the struggle for Chinese socialist culture and the construction of socialism and communism through dictatorship, total control and the new culture of selfless devotion to Mao, ideology and party, eradicating conservative traditionalism and liberal pluralism.";
				}
				else if (GlobalScript.inst.gameState.party_number[4] > 1500)
				{
					if (GlobalScript.inst.gameState.data[14] < 4)
					{
						fake_text = "The new liberal democratic government of China has declared the victory over the old order and the liberalization of the regime as its primary and most important goal. The government carried out economic reforms in the direction of the free market, which dealt a serious blow to the economy, causing disorganization through the collapse of old ties, but the fight against corruption and fraud on the part of the young civil society in conjunction with loans and huge investments from the United States and the West allowed to gradually cope with the situation, entering into a state of a certain growth, which somewhat compensates for the former decline and even allows us to talk about some successes in economic growth and increasing social wealth, however, a huge share of income is concentrated in the hands of a narrow group of people - the nascent oligarchy, while millions of people leave China, hoping to find a better life abroad. The DPC is eliminating state control in all areas of public life, including political life, where there is an opportunity for the functioning of a minor opposition. In the Democratic Republic of China, as the country is now called, a regime of liberal democracy is being formed. Relations with the United States become friendly, and with the USSR deteriorate. The US is becoming the main economic partner of China, the main creditor and investor of a young participant in the world market, whose dependence on developed countries is increasing. The USSR gradually breaks off trade relations with China and increases its military presence on the Soviet-Chinese border.";
					}
					else
					{
						fake_text = "The new liberal democratic government of China has declared the strengthening and improvement of democracy to be its first and foremost goal. The government has kept the course for a free inside and open outside market, the economy continues to grow, but with a rather unstable GDP, because the crises strongly shake it from time to time and while most of the population is trying to fit into the market, a narrow group of people becomes only richer, and foreign investors continue to pump out of country resources. The DPC protects freedom in all areas of public life, including political life, creating conditions for the semi-free activity of the opposition, although in times of crisis there is strong administrative pressure on radical organizations. The Democratic Republic of China, as the country is now called, maintains a regime of liberal democracy. Relations with the US remain friendly, and with the USSR - rather hostile. The US remains the main economic partner of the DRC, the main creditor and investor of a young participant in the world market, whose dependence on developed countries is growing. The USSR gradually breaks off trade relations with China and increases its military presence on the Soviet-Chinese border.";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "The CCP, which lost the election, was able to maintain the support of part of the population, especially the working class, and unity in its ranks, and the party line and a decisive confrontation with the Democrats during the power of the DPC rallied the entire opposition around the CCP. However, CPC's activities were severely limited by a number of court decisions, and several of its leaders were arrested on various (and manifestly false) charges.";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "Lost the election, the CPC was able to retain the support of the population and the unity in its ranks, and the line of the party and some support the liberal policies of the DPC allowed the CCP to remain in politics as a 'constructive opposition' in a few years United with the DPC and the CZGP in the coalition block.";
					}
					else
					{
						fake_text += "The CCP, which lost the elections, was unable to maintain unity in its ranks, but at the same time lost the support of a large part of the population and suffered a split into three parties. During the period of power of the DPC, one of them supported the Democrats, and two - the opposition. The last few years, they reunited to restore the CCP, but the Chinese Communists are still far from a full revival...";
					}
				}
				else if (GlobalScript.inst.gameState.party_number[3] > GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[3] > GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[3] > GlobalScript.inst.gameState.party_number[4])
				{
					if (GlobalScript.inst.gameState.data[14] < 4)
					{
						fake_text = "The new social-Patriotic government of the PRC declared its primary and most important goal to preserve state unity with multinational population and sustainable growth of social prosperity. The government has also announced economic reforms towards a socially-oriented market economy, which is a serious blow to the economy, causing disorganization through the collapse of old ties, and an attempt to maintain social security leads to a budget deficit and the final collapse of the Chinese economy, fueled by a widespread surge of corruption and fraud, and only loans and investments from the US and the West can finally cope with the situation, entering a state of rapid growth, which partially compensates for the former decline and even allows us to talk about some success in economic growth and increasing social wealth, but a huge share of income leaves China in favor of its economic partners. Given the need to preserve state unity, the CZGP is going to federalize and further democratic reforms, introducing more freedom in all areas while maintaining state regulation. In China, a regime of socialism with Chinese specifics is being formed. Relations with the US warm, and with the USSR cold. The US is becoming the main economic partner of China, the main creditor and investor of a young participant in the world market, whose dependence on developed countries is increasing, but at the same time, as part of deepening cooperation, negotiations are underway to return Hong Kong and Macau, the status of Taiwan, which seems to end in a compromise in favor of China. The USSR continues negotiations with China on the establishment of full diplomatic relations, but the PRC, urged by the US, requires territorial concessions, and the USSR repeatedly refuses.";
					}
					else
					{
						fake_text = "The new social-Patriotic government of the PRC declared its primary and most important goal to preserve state unity with multinational population and sustainable growth of social prosperity. The government has also announced economic reforms towards a socially oriented market economy, leading to an increase in the public sector, increased state control and higher taxes for the upper class, striking a blow to economic growth, causing a reduction in domestic and foreign investment and an overall unfavourable market environment for entrepreneurs, but at the same time raising the level of public wealth through increased public investment in social security. In the context of the need to preserve state unity, the CZPG follows the principles of federalism and democracy, while strengthening Patriotic agitation in the state media. In China, a regime of socialism with Chinese specifics is being formed. Relations with the US are getting cold, and with the USSR warm. The US is cutting loans and investments by choosing other countries for this purpose, and negotiations on the return of Hong Kong and Macau, the status of Taiwan, are stalled. The USSR continues negotiations with the PRC on the establishment of full-fledged diplomatic relations and achieves success: the PRC refuses its territorial requirements, and the USSR sends specialists to the PRC, issues a number of large interest-free loans.";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "The CCP, which lost the elections, was able to maintain the support of a part of the population and unity in the ranks of its members, and the party's line and resolute resistance to the policy of the CZGP made it the main radical opposition force. The CCP continues its political struggle against the CZGP, remaining a parliamentary party and at the same time resorting to numerous ways of confrontation, not limited to participation in elections and campaigning, often arranging radical opposition public actions.";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "The CCP, which lost the elections, was able to maintain the support of a part of the population and unity in the ranks of its members, and the party's line and resolute opposition to the excessively socialist in all senses policy of the CZGP made it the main democratic opposition force. The CCP continues its political struggle against the CZGP, not limited to participation in elections and campaigning, often arranging democratic opposition public actions.";
					}
					else
					{
						fake_text += "The CCP, which had lost the elections, had failed to maintain unity among its members, but had lost popular support and had broken up into several independent and opposing parties almost immediately after the defeat. During the power of the CZGP, some of them supported the radicals, some - the CZGP, and some - Democrats. In the end, all the parties became part of other, larger and more cohesive parties or remained small, fragmented groups with no real influence on politics.";
					}
				}
				else if (GlobalScript.inst.gameState.party_number[3] > 1500)
				{
					if (GlobalScript.inst.gameState.data[14] < 4)
					{
						fake_text = "The new government of the PRC, which came to power through promises of stable prosperity, declared its primary and most important goal to preserve national unity with a more careful consideration of the problems of the national issue and the sustainable growth of social prosperity. The government has also announced economic reforms in the direction of a socially oriented market economy, which strikes a certain blow to the economy, causing disorganization through the collapse of old ties, but much less than expected, which allowed to more or less minimize the consequences (however, it struck a blow to the standard of living of a large part of the population). Given the need to preserve state unity, the CZGP is going to federalize and further democratic reforms, introducing more freedom in all areas while maintaining state regulation. In China, a regime of socialism with Chinese specifics is being formed. Relations with the US warm, and with the USSR cold. The US becomes China's main economic partner, the main creditor and investor of a young participant in the world market, whose dependence on developed countries is increasing, but at the same time, as part of deepening cooperation, negotiations are underway to return Hong Kong and Macau, and the special status of Taiwan, which seems to end in a compromise in favor of China. The USSR continues negotiations with the PRC on the restoration of full diplomatic relations, but the PRC, urged by the US, requires territorial concessions, and the USSR repeatedly refuses.";
					}
					else
					{
						fake_text = "The new social-Patriotic government of the PRC declared its primary and most important goal to preserve state unity with multinational population and sustainable growth of social prosperity. The government has also announced economic reforms towards a socially oriented market economy, leading to an increase in the public sector, increased state control and higher taxes for the upper class, with some impact on economic growth, causing a reduction in domestic and foreign investment and an overall unfavourable market environment for entrepreneurs, but at the same time raising the level of public wealth through increased public investment in social security. In the context of the need to preserve state unity, the CZGP follows the principles of federalism and democracy, while strengthening Patriotic agitation in the state media. In China, a regime of socialism with Chinese specifics is being formed. Relations with the US deteriorated and with the USSR improved. The US is cutting loans and investments by choosing other countries for this purpose, and negotiations on the return of Hong Kong and Macao, the status of Taiwan, come to a standstill on the last point, but with the first two are gradually going to success. The USSR continues negotiations with the PRC on the restoration of full-fledged diplomatic relations and achieves success: the PRC abandons its territorial requirements, and the USSR sends specialists to the PRC, issues a number of large interest-free loans.";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "The CCP, which lost the elections , was able to maintain the support of a large part of the population, especially the working class, and unity in its ranks, and the party's line and resolute resistance to the CZGP's policy, which was too soft in every sense, made it the main opposition force. The CCP continues its political struggle against the CZGP, remaining a parliamentary party and at the same time resorting to numerous ways of confrontation, not limited to participation in elections and campaigning, often arranging public actions.";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "The CCP, which lost the elections, was able to maintain the support of part of the population and unity in its ranks, and the party's line and resolute opposition to the overly cautious policy of the CZGP made it the main democratic opposition force. The CPC continues its political struggle against the CZGP, not limited to participation in elections and campaigning, often arranging public actions.";
					}
					else
					{
						fake_text += "The CCP, which lost the elections, was unable to maintain unity in its ranks, but at the same time lost the support of the population and split into two parties. During the power of the CZGP, the first entered into a coalition with it, and the second supported the opposition. In the end, both parties reunited after 3 years, restoring a single CCP, but the Chinese Communists will have to restore their influence throughout the vast country for a long time...";
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
						fake_text = "China's new government announced that its primary and most important purpose of preserving the national unity of China, as well as the return of lost territories - Hong Kong, Macau and Taiwan. The government has also announced economic reforms in the direction of expanding private initiative while maintaining state control, as well as allowing limited foreign investment, which gives impetus to economic growth, but at the same time increasing corruption and fraud, and the resulting income is to expand and improve the content of the state apparatus and social security, which in the short term allows to strengthen the state and raise the standard of living of the population, but prevents further growth and slows down the development of the economy. In the context of national fragmentation, it was decided to strengthen the national state, which led to informal repression against opposition Federalists from the CZGP and liberals from the DPC, as well as the establishment of strong state control in the media, acting with aggressive nationalist propaganda, with the same informal ban on any unauthorized public actions. Having met almost no resistance, the regime of the left imitation democracy was formed in China. Relations with the US and the USSR remain tense and unfriendly. Nevertheless, the US has not spared the possibility of profitable investments, pushing its allies to start negotiations on the return of the lost Hong Kong and Macao and the status of Taiwan, which, however, strongly stalled because of the tense relations between the RCCK and, in fact, the Kuomintang. The USSR, in turn, continued negotiations with the PRC on the restoration of full-fledged diplomatic relations, but the PRC requires territorial concessions, to which the USSR does not agree, and the negotiations are also gradually coming to a standstill.";
					}
					else
					{
						fake_text = "The new Chinese government has declared its primary and most important goal to preserve the national unity of China, as well as the return of the lost territories - Hong Kong, Macau and Taiwan. The government also announced economic counter-reforms in the direction of reducing private initiative, strengthening state control, as well as limiting foreign investment, which leads to a decrease in economic growth in conjunction with the growth of corruption and fraud, the merger of entrepreneurship and the state apparatus, but gives the state access to large resources, which mainly go to expand and improve the content of the state apparatus and social security, which in the short term allows to strengthen the state and raise the standard of living of the population, however, it hinders further growth and slows down economic development. In the context of national fragmentation, it was decided to strengthen the national state, which led to informal repression against opposition Federalists from the CZGP and liberals from the DPC, as well as the establishment of strong state control in the media, acting with an aggressive nationalist agenda, with the same informal ban on any unauthorized public actions. The opposition was suppressed or bribed, the regime of the left imitation democracy was formed in China. Relations with the US and the USSR deteriorated markedly. The US, in response to counter-reforms, began a gradual withdrawal of investments and pushed its allies to jointly strengthen the Western military presence in Hong Kong, Macau and Taiwan, which China considers its own. The USSR in response to the counter-reforms called China a social fascist state, also increasing its military presence in the disputed territories with China.";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "The CCP, which lost the elections, was able to maintain the support of a large part of the population and unity in its ranks, and the party's line and strong support for the RCCK during the period of counter-reforms allowed it to remain in politics, becoming one of the legal opposition parties. The CCP continues its activities, voting in Parliament and through agitation in his favor, and organizing actions, strongly supporting the RCCK and only occasionally speaking with a criticism of some of its representatives.";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "The CCP, which lost the elections, was able to maintain the support of a part of the population and unity in its ranks, and the party's line and a decisive confrontation with the RCCK during the counter-reforms rallied the entire opposition around the CCP. However, in response, CPC's activities were severely limited by a number of court decisions and some of its leaders were arrested on various (and manifestly false) charges.";
					}
					else
					{
						fake_text += "The CCP, which lost the elections, was unable to maintain unity in its ranks, but at the same time lost the support of the population and broke up into four parties. During the counter-reforms, one of them supported the RCCK and three supported the opposition. The first joined the RCCK a few years later, the second merged with the third, restoring the CCP, and the fourth remained an independent party in opposition to the ruling regime.";
					}
				}
				else if (GlobalScript.inst.gameState.party_number[2] > 1500)
				{
					if (GlobalScript.inst.gameState.data[14] < 4)
					{
						fake_text = "China's new government announced that its primary and most important purpose of preserving the national unity of China, as well as the return of lost territories - Hong Kong, Macau and Taiwan. The government has also announced economic reforms in the direction of expanding private initiative while maintaining state control, as well as allowing limited foreign investment, which gives impetus to economic growth, but at the same time increasing corruption and fraud, and the resulting income is to expand and improve the content of the state apparatus and social security, which in the short term allows to strengthen the state and raise the standard of living of the population, but prevents further growth and slows down the development of the economy. In the context of national fragmentation, it was decided to strengthen the national state, which led to informal repression against opposition Federalists from the CZGP and liberals from the DPC, as well as the establishment of strong state control in the media, acting with aggressive nationalist propaganda, with the same informal ban on any unauthorized public actions. Having met almost no resistance, the regime of the left imitation democracy was formed in China. Relations with the US and the USSR remain tense and unfriendly. Nevertheless, the US has not spared the possibility of profitable investments, pushing its allies to start negotiations on the return of the lost Hong Kong and Macao and the status of Taiwan, which, however, strongly stalled because of the tense relations between the RCCK and, in fact, the Kuomintang. The USSR, in turn, continued negotiations with the PRC on the restoration of full-fledged diplomatic relations, but the PRC requires territorial concessions, to which the USSR does not agree, and the negotiations are also gradually coming to a standstill.";
					}
					else
					{
						fake_text = "The new Chinese government has declared its primary and most important goal to preserve the national unity of China, as well as the return of the lost territories - Hong Kong, Macau and Taiwan. The government also announced economic counter-reforms in the direction of reducing private initiative, strengthening state control, as well as limiting foreign investment, which leads to a decrease in economic growth in conjunction with the growth of corruption and fraud, the merger of entrepreneurship and the state apparatus, but gives the state access to large resources, which mainly go to expand and improve the content of the state apparatus and social security, which in the short term allows to strengthen the state and raise the standard of living of the population, however, it hinders further growth and slows down economic development. In the context of national fragmentation, it was decided to strengthen the national state, which led to informal repression against opposition Federalists from the CZGP and liberals from the DPC, as well as the establishment of strong state control in the media, acting with an aggressive nationalist agenda, with the same informal ban on any unauthorized public actions. The opposition was suppressed or bribed, the regime of the left imitation democracy was formed in China. Relations with the US and the USSR deteriorated markedly. The US, in response to counter-reforms, began a gradual withdrawal of investments and pushed its allies to jointly strengthen the Western military presence in Hong Kong, Macau and Taiwan, which China considers its own. The USSR in response to the counter-reforms called China a social fascist state, also increasing its military presence in the disputed territories with China.";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "The CCP, which lost the elections, was able to maintain the support of a large part of the population and unity in its ranks, and the party's line and strong support for the RCCK during the period of counter-reforms allowed it to remain in politics, becoming one of the legal opposition parties. The CCP continues its activities, voting in Parliament and through agitation in his favor, and organizing actions, strongly supporting the RCCK and only occasionally speaking with a criticism of some of its representatives.";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "The CCP, which lost the elections, was able to maintain the support of a part of the population and unity in its ranks, and the party's line and a decisive confrontation with the RCCK during the counter-reforms rallied the entire opposition around the CCP. However, in response, CPC's activities were severely limited by a number of court decisions and some of its leaders were arrested on various (and manifestly false) charges.";
					}
					else
					{
						fake_text += "The CCP, which lost the elections, was unable to maintain unity in its ranks, but at the same time lost the support of the population and broke up into four parties. During the counter-reforms, one of them supported the RCCK and three supported the opposition. The first joined the RCCK a few years later, the second merged with the third, restoring the CCP, and the fourth remained an independent party in opposition to the ruling regime.";
					}
				}
				else
				{
					if (GlobalScript.inst.gameState.data[14] < 4)
					{
						fake_text = "The new liberal democratic government of China has declared the victory over the old order and the liberalization of the regime as its primary and most important goal. The government carried out economic reforms towards free market, which dealt a serious blow to the economy, causing disruption in the collapse of old ties, however, the fight against corruption and fraud on the part of the young civil society in conjunction with loans and investments from the United States and the West eventually allowed to cope with the situation, went into a state of economic growth, which somewhat offsets its former decline, and even allows us to speak about certain successes in the field of economic growth and increasing social wealth, however, the vast majority of income is concentrated in the hands of a narrow group of individuals - the nascent oligarchy, while hundreds of thousands of people leave China, hoping to find a better life abroad. The DPC liquidates state control in all areas of public life, including political life, where all obstacles to the free activity of the opposition are eliminated. In the Democratic Republic of China, as the country is now called, a regime of liberal democracy is being formed. Relations with the US are becoming friendly, and with the USSR gradually deteriorating. The US is becoming the main economic partner of China, the main creditor and investor of a young participant in the world market, whose dependence on developed countries is increasing. СThe USSR is gradually breaking off trade relations with China and increasing its military presence on the Soviet-Chinese border. The new authorities are already beginning negotiations with Taiwan to restore the unity of the country, since all the contradictions between them have been eliminated.";
					}
					else
					{
						fake_text = "The new liberal democratic government of China has declared the strengthening and improvement of democracy to be its first and foremost goal. The government has kept the course for a free inside and open outside market, the economy continues to grow, but with a rather unstable GDP, because the crises strongly shake it from time to time and while most of the population is trying to fit into the market, a narrow group of people becomes only richer, and foreign investors continue to pump out of country resources. The DPC protects freedom in all areas of public life, including political life, creating conditions for the semi-free activity of the opposition, although in times of crisis there is strong administrative pressure on radical organizations. The Democratic Republic of China, as the country is now called, maintains a regime of liberal democracy. Relations with the US remain friendly, and with the USSR - rather hostile. The US remains the main economic partner of the democratic Republic of the Congo, the main creditor and investor of a young participant in the world market, whose dependence on developed countries is growing. The USSR gradually breaks off trade relations with China and increases its military presence on the Soviet-Chinese border.";
					}
					if (GlobalScript.inst.gameState.data[54] < 40 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "The CCP, which lost the election, was able to maintain the support of part of the population, especially the working class, and unity in its ranks, and the party line and a decisive confrontation with the Democrats during the power of the DPC rallied the entire opposition around the CCP. However, CPC's activities were severely limited by a number of court decisions, and several of its leaders were arrested on various (and manifestly false) charges.";
					}
					else if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text += "Lost the election, the CPC was able to retain the support of the population and the unity in its ranks, and the line of the party and some support the liberal policies of the DPC allowed the CCP to remain in politics as a 'constructive opposition' in a few years United with the DPC and the CZGP in the coalition block.";
					}
					else
					{
						fake_text += "The CCP, which lost the elections, was unable to maintain unity in its ranks, but at the same time lost the support of a large part of the population and suffered a split into three parties. During the period of power of the DPC, one of them supported the Democrats, and two - the opposition. The last few years have reunited, restoring the CCP, but before the full revival of the Chinese Communists is still very far...";
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
