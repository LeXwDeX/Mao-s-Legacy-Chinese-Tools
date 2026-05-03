using UnityEngine;

public class authores : MonoBehaviour
{
	public TextMesh text1;

	public TextMesh text2;

	public TextMesh text3;

	public TextMesh text4;

	private void Awake()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			text1.text = "<size=20><b>China: Mao's Legacy</b></size>";
			text4.text = "<size=20>Vasiliy Vladimirovich Kostilev\nMaxim Olegovich Chornobuk</size>";
			text4.text += "\n\n<size=22>Also in the development took part:\nMaxim Kositsyn\nIllarion Soldaev\nVladimir Gridasov\n\nAuthor's music:\nNikita Mishkevich\nIn blessed memory of Nikita Mishkevich (27.02.1993-22.01.2023)</size>";
			text4.text += "\n\n<size=20>https://nostal.games</size>";
			text3.text = "Александр Егоров: stihi.ru/avtor/hhypest; Антон Максимов: vk.com/mash2525\nЛейба: vk.com/leiba_anninsky и Дегтерёв: mayor-dgt.diary.ru\nДанил Чемулов: vk.com/niceguy1331 и Денис Роев: vk.com/id252659138\nNikolai Aamand: Comrade Nikolai#0370; Югослав: vk.com/yugoslav1943\nMattia Tuccelli: GattoNero#0161; Валентин Потоцкий: vk.com/zerosensey\nВлад Фомин: vk.com/vologodsky_pyotr_vasilevich; Anthony Cawdrey\nИван Елисеев: steamcommunity.com/id/eliseev999/\nАнатолий Garlic AAZ: youtube.com/user/AAZspb\nЛеонид Чижиков: leonid.chizhikov@gmail.com; Роман Мальков\nВасилий Андреев: vk.com/brutalpin; Максим Юрченко: vk.com/kiberhelim";
			text2.text = "Special thanks: Кузнецов Илья - vk.com/id276119505\nДаниил Чумаков; Виктор Гордеев; Денис Хистяев\nГеоргий Коршиков: vk.com/id455054985\nСтанислав Волкович: vk.com/volkovichstanislav\nАлександр Кучкин: vk.com/sachasaha\nhttps://steamcommunity.com/id/VERZERRTEST/\nScharfschutze: vk.com/id437154684\nЕгор Клюев: vk.com/trallshaman\nDavid52522; KeTsarl; GenosseNG; Taran Wood\nДмитрий Иванов: vk.com/kratos999god\nГеоргий Емельянов: vk.com/gogaa24\nГригорий Грибан: vk.com/id257939411";
		}
		else
		{
			text1.text = "<size=20><b>Китай: Наследие Мао</b></size>";
			text4.text = "<size=20>Василий Владимирович Костылев\nМаксим Олегович Чорнобук</size>";
			text4.text += "\n\n<size=20>В разработке проекта также участвовали:\nМаксим Косицын\nИлларион Солдаев\nВладимир Гридасов\n\nАвторская музыка:\nНикита Мишкевич\nСветлой памяти Никиты Мишкевича (27.02.1993-22.01.2023)</size>";
			text4.text += "\n\n<size=20>https://nostal.games</size>";
			text3.text = "Александр Егоров: stihi.ru/avtor/hhypest; Антон Максимов: vk.com/mash2525\nЛейба: vk.com/leiba_anninsky и Дегтерёв: mayor-dgt.diary.ru\nДанил Чемулов: vk.com/niceguy1331 и Денис Роев: vk.com/id252659138\nNikolai Aamand: Comrade Nikolai#0370; Югослав: vk.com/yugoslav1943\nMattia Tuccelli: GattoNero#0161; Валентин Потоцкий: vk.com/zerosensey\nВлад Фомин: vk.com/vologodsky_pyotr_vasilevich; Anthony Cawdrey\nИван Елисеев: steamcommunity.com/id/eliseev999/\nАнатолий Garlic AAZ: youtube.com/user/AAZspb\nЛеонид Чижиков: leonid.chizhikov@gmail.com; Роман Мальков\nВасилий Андреев: vk.com/brutalpin; Максим Юрченко: vk.com/kiberhelim";
			text2.text = "Особое спасибо: Кузнецов Илья - vk.com/id276119505\nДаниил Чумаков; Виктор Гордеев; Денис Хистяев\nГеоргий Коршиков: vk.com/id455054985\nСтанислав Волкович: vk.com/volkovichstanislav\nАлександр Кучкин: vk.com/sachasaha\nhttps://steamcommunity.com/id/VERZERRTEST/\nScharfschutze: vk.com/id437154684\nЕгор Клюев: vk.com/trallshaman\nDavid52522; KeTsarl; GenosseNG; Taran Wood\nДмитрий Иванов: vk.com/kratos999god\nГеоргий Емельянов: vk.com/gogaa24\nГригорий Грибан: vk.com/id257939411";
		}
	}
}
