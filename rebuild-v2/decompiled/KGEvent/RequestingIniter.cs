using System;

namespace KGEvent;

[Serializable]
internal static class RequestingIniter
{
	public static void CreateQueryMinors<T>(T target) where T : RequestingMinor<T>, IRequesting<T>
	{
		target.World = new QueryWorld<T>(target);
		target.NATO = new QueryMinor<T>(target, 0);
		target.Poland = new QueryMinor<T>(target, 2);
		target.Czechoslovakia = new QueryMinor<T>(target, 3);
		target.Hungary = new QueryMinor<T>(target, 4);
		target.Romania = new QueryMinor<T>(target, 5);
		target.Bulgaria = new QueryMinor<T>(target, 6);
		target.Iran = new QueryMinor<T>(target, 8);
		target.Mongolia = new QueryMinor<T>(target, 9);
		target.NorthKorea = new QueryMinor<T>(target, 10);
		target.Vietnam = new QueryMinor<T>(target, 11);
		target.Afghanistan = new QueryMinor<T>(target, 12);
		target.Libya = new QueryMinor<T>(target, 13);
		target.Iraq = new QueryMinor<T>(target, 14);
		target.Yugoslavia = new QueryMinor<T>(target, 15);
		target.GDR = new QueryMinor<T>(target, 16);
		target.FRG = new QueryMinor<T>(target, 17);
		target.Cuba = new QueryMinor<T>(target, 18);
		target.India = new QueryMinor<T>(target, 19);
		target.Albania = new QueryMinor<T>(target, 20);
		target.France = new QueryMinor<T>(target, 21);
		target.Laos = new QueryMinor<T>(target, 22);
		target.Cambodia = new QueryMinor<T>(target, 23);
		target.Yemen = new QueryMinor<T>(target, 24);
		target.SYemen = new QueryMinor<T>(target, 25);
		target.Finland = new QueryMinor<T>(target, 26);
		target.Austria = new QueryMinor<T>(target, 27);
		target.Sweden = new QueryMinor<T>(target, 28);
		target.Ireland = new QueryMinor<T>(target, 29);
		target.Egypt = new QueryMinor<T>(target, 30);
		target.Pakistan = new QueryMinor<T>(target, 31);
		target.Bangladesh = new QueryMinor<T>(target, 32);
		target.Myanmar = new QueryMinor<T>(target, 33);
		target.Thailand = new QueryMinor<T>(target, 34);
		target.Syria = new QueryMinor<T>(target, 35);
		target.Kuwait = new QueryMinor<T>(target, 36);
		target.Israel = new QueryMinor<T>(target, 37);
		target.Taiwan = new QueryMinor<T>(target, 38);
		target.Switzerland = new QueryMinor<T>(target, 39);
		target.Algeria = new QueryMinor<T>(target, 40);
		target.Ethiopia = new QueryMinor<T>(target, 41);
		target.Somalia = new QueryMinor<T>(target, 42);
		target.Nepal = new QueryMinor<T>(target, 43);
		target.Japan = new QueryMinor<T>(target, 44);
		target.Greece = new QueryMinor<T>(target, 45);
		target.RepublicOfKorea = new QueryMinor<T>(target, 46);
		target.Philippines = new QueryMinor<T>(target, 47);
		target.SouthAfrica = new QueryMinor<T>(target, 48);
		target.Malaysia = new QueryMinor<T>(target, 49);
		target.Indonesia = new QueryMinor<T>(target, 50);
		target.Rhodesia = new QueryMinor<T>(target, 52);
		target.Sudan = new QueryMinor<T>(target, 53);
		target.Morocco = new QueryMinor<T>(target, 54);
		target.Tunisia = new QueryMinor<T>(target, 55);
		target.Niger = new QueryMinor<T>(target, 56);
		target.Chad = new QueryMinor<T>(target, 57);
		target.Mali = new QueryMinor<T>(target, 58);
		target.Mauritania = new QueryMinor<T>(target, 59);
		target.Nigeria = new QueryMinor<T>(target, 60);
		target.UpperVolta = new QueryMinor<T>(target, 61);
		target.Benin = new QueryMinor<T>(target, 62);
		target.Ghana = new QueryMinor<T>(target, 63);
		target.CoteDIvoire = new QueryMinor<T>(target, 64);
		target.CAR = new QueryMinor<T>(target, 65);
		target.Cameroon = new QueryMinor<T>(target, 66);
		target.Liberia = new QueryMinor<T>(target, 67);
		target.Guinea = new QueryMinor<T>(target, 68);
		target.Tibet = new QueryMinor<T>(target, 69);
		target.Uyghuristan = new QueryMinor<T>(target, 70);
	}
}
