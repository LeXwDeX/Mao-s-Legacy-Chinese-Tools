using KGFocus;
using KGWars;

namespace Focuses;

internal static class USSRFocuses
{
	public static void Init()
	{
		FocusTree focusTree = FocusManager.CreateTree("开始聚焦");
		focusTree.AddLayer();
		focusTree.AddFocus("大会继续进行").USSR.Historical().USSR.NotAgressive().USSR.Reformost().USSR.AddToRight(1).USSR.AddToPolitician(3, 1).USSR.AddModify(13);
		focusTree.AddFocus("新的旧物").USSR.Agressive().USSR.AddToLeft(1).USSR.AddToPolitician(3, -2).USSR.AddModify(14);
		focusTree.AddFocus("纠正错误").USSR.Conservative().USSR.AddToLeft(1).USSR.AddToPolitician(2, 2).USSR.AddToPolitician(1, -1).USSR.AddToPolitician(3, -1).USSR.AddInfluence(-15).World.AddToPartiesConnection(15).USSR.AddModify(18);
		focusTree.AddLayer();
		focusTree.AddFocus("铁元帅").USSR.Conservative().Expr.USSR.Weaker(0).USSR.Stronger(2).End.USSR.AddToLeft(1).USSR.AddToPolitician(2, 2).USSR.AddToPolitician(1, 1).USSR.AddModify(15);
		focusTree.AddFocus("新元帅").USSR.NotAgressive().Expr.USSR.Stronger(0).USSR.Stronger(2).End.USSR.AddToPolitician(2, 1).USSR.AddModify(16);
		focusTree.AddFocus("红元帅").USSR.Agressive().Expr.USSR.Weaker(0).USSR.Weaker(2).End.USSR.AddToLeft(1).USSR.AddToPolitician(3, 1).China.AddInfluence(-10).USSR.AddModify(17);
		focusTree.AddLayer();
		focusTree.AddFocus("赫尔辛基集团").USSR.Historical().Expr.USSR.Stronger(2).USSR.Stronger(0).End.USSR.AddToRight(1).USSR.AddToPolitician(2, 1).USSR.AddInfluence(-10);
		focusTree.AddFocus("赫尔辛基帮").USSR.Agressive().USSR.PoliticianPowerMore(3, 7).Expr.USSR.Weaker(2).USSR.Weaker(0).End.USSR.AddToLeft(1).USSR.AddToPolitician(3, 1).USSR.AddToPolitician(4, 1);
		focusTree.AddLayer();
		focusTree.AddFocus("别季奇之死").USSR.Historical().Expr.USSR.Weaker(0).USSR.Weaker(2).End.USSR.NotAgressive();
		focusTree.AddFocus("克里姆林宫之手").USSR.Agressive().Expr.USSR.Stronger(0).USSR.Stronger(2).End.USSR.AddInfluence(10).USSR.AddToPolitician(3, -1).USSR.AddToPolitician(1, -1);
		focusTree.AddLayer();
		focusTree.AddFocus("总统终局").USSR.Historical().USSR.PoliticianPowerMore(3, 8).Expr.USSR.LeftEqual(0).USSR.RightEqual(2).End.Expr.USSR.Stronger(0).USSR.Stronger(2).End.USSR.AddToRight(2).USSR.AddToPolitician(3, 2).USSR.AddToPolitician(2, 1);
		focusTree.AddFocus("正如当初那样").USSR.PoliticianPowerLess(3, 3).Expr.USSR.Weaker(0).USSR.Weaker(2).End.USSR.AddToPolitician(1, 1).USSR.AddToPolitician(2, -1);
		focusTree.AddFocus("苏联势力").USSR.Agressive().Expr.USSR.PoliticianPowerMore(3, 2).USSR.PoliticianPowerLess(3, 5).End.Expr.USSR.Weaker(0).USSR.Weaker(2).End.USSR.AddToLeft(1).USSR.AddToPolitician(3, -3).USSR.AddModify(19);
		focusTree.AddLayer();
		focusTree.AddFocus("反对侵略者").USSR.Historical().Expr.USSR.PoliticianPowerMore(3, 9).USSR.Stronger(0).End.USSR.NotAgressive().World.DecleredWar(Wars.O);
		focusTree.AddFocus("不搞侵略").USSR.NotAgressive().Expr.China.Weaker(0).China.Weaker(1).End.USSR.AddInfluence(-10).AddResult(GlobalScript.inst.new_texts[94]).CreateActive(delegate
		{
			Wars.O.AttackerInfluence(30);
		})
			.World.DecleredWar(Wars.O);
		focusTree.AddFocus("打败侵略者").Expr.World.WarIsGoing(Wars.O).USSR.Agressive().End.Expr.World.WarIsGoing(Wars.O).USSR.Stronger(0).USSR.Stronger(2).End.World.WarEnds(Wars.O);
		focusTree.AddLayer();
		focusTree.AddFocus("也门陷落").USSR.Historical().USSR.Weaker(0).USSR.NotAgressive().SYemen.EstablishLiberalism();
		focusTree.AddFocus("新也门").USSR.Agressive().Expr.China.Stronger(0).China.Stronger(1).End.SYemen.EstablishSocialism().Yemen.EstablishSocialism().USSR.AddInfluence(10);
		focusTree.AddLayer();
		focusTree.AddFocus("People").USSR.Historical().AddReq(GlobalScript.inst.new_texts[98]).CreateCondition(() => GlobalScript.inst.gameState.empires[1].leaders[3].support + GlobalScript.inst.gameState.empires[1].leaders[6].support + GlobalScript.inst.gameState.empires[1].leaders[5].support + GlobalScript.inst.gameState.empires[1].leaders[4].support > GlobalScript.inst.gameState.empires[1].leaders[2].support)
			.USSR.AddToRight(2).USSR.AddToPolitician(3, 1).USSR.AddToPolitician(4, 1).USSR.AddToPolitician(6, 1).USSR.AddToPolitician(5, 1).USSR.AddToPolitician(2, 1);
		focusTree.AddFocus("People").USSR.Agressive().USSR.LeftStrongerRight().AddReq(GlobalScript.inst.new_texts[98]).CreateCondition(() => GlobalScript.inst.gameState.empires[1].leaders[3].support + GlobalScript.inst.gameState.empires[1].leaders[6].support + GlobalScript.inst.gameState.empires[1].leaders[5].support + GlobalScript.inst.gameState.empires[1].leaders[4].support < GlobalScript.inst.gameState.empires[1].leaders[2].support)
			.USSR.AddToLeft(1).USSR.AddToRight(-1).USSR.AddToPolitician(1, 1).USSR.AddToPolitician(2, 2);
		GlobalScript.inst.gameState.empires[1].active_tree = "开始聚焦";
	}
}
