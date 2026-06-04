namespace ReqEventsDLC02;

public class ReqEventForDLC05
{
	public static bool RequrementsDLC07(ref int this_num_event, GameState a)
	{
		if (a.data[19] >= 4 && a.data[20] >= 2 && a.data[21] >= 1976 && !a.event_done[457])
		{
			this_num_event = 457;
			return true;
		}
		return false;
	}
}
