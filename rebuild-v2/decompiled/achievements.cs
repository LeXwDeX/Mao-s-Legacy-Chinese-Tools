using Steamworks;
using UnityEngine;

public class achievements : MonoBehaviour
{
	public bool[] ach_this = new bool[100];

	protected Callback<UserStatsReceived_t> m_UserStatsReceived;

	protected Callback<UserStatsStored_t> m_UserStatsStored;

	protected Callback<UserAchievementStored_t> m_UserAchievementStored;

	private bool m_bStoreStats;

	private bool m_bRequestedStats;

	private bool m_bStatsValid;

	private CGameID m_GameID;

	private void OnEnable()
	{
		if (GameObject.Find("SteamManager").GetComponent<SteamManager>().achivki_sosut)
		{
			return;
		}
		try
		{
			if (SteamManager.Initialized)
			{
				Debug.Log("------------ACHIVKI ACTIVIROVANI-------------------");
				m_GameID = new CGameID(SteamUtils.GetAppID());
				m_UserStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
				m_UserStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
				m_UserAchievementStored = Callback<UserAchievementStored_t>.Create(OnAchievementStored);
				m_bRequestedStats = false;
				m_bStatsValid = false;
			}
		}
		catch
		{
			Debug.Log("------------OSHIBKA PRO ACRIVACCI-------------------");
		}
	}

	public void Set(int number)
	{
		if (GlobalScript.inst.gameState.iron_and_blood)
		{
			Debug.Log("------------SET VISVAN-------------------");
			ach_this[number] = true;
		}
	}

	private void UnlockAchievement(string ach, bool clear)
	{
		if (GameObject.Find("SteamManager").GetComponent<SteamManager>().achivki_sosut)
		{
			return;
		}
		try
		{
			Debug.Log("------------UNLOCK ACHIVMENT VIS VAN BES OSHIPOK-------------------");
			if (clear)
			{
				SteamUserStats.ClearAchievement(ach);
			}
			else
			{
				Debug.Log("------------OTRKIVAEM  " + ach + "-------------------");
				SteamUserStats.SetAchievement(ach);
			}
			m_bStoreStats = true;
		}
		catch
		{
		}
	}

	private void Update()
	{
		if (GameObject.Find("SteamManager").GetComponent<SteamManager>().achivki_sosut)
		{
			return;
		}
		try
		{
			if (!SteamManager.Initialized)
			{
				return;
			}
			if (!m_bRequestedStats)
			{
				if (!SteamManager.Initialized)
				{
					m_bRequestedStats = true;
					return;
				}
				bool bRequestedStats = SteamUserStats.RequestCurrentStats();
				m_bRequestedStats = bRequestedStats;
			}
			if (!m_bStatsValid)
			{
				return;
			}
			for (int i = 1; i < ach_this.Length; i++)
			{
				if (ach_this[i])
				{
					Debug.Log("---------NASHL CHTO " + i + " TRUE=========");
					ach_this[i] = false;
					UnlockAchievement("ACH_" + i, clear: false);
				}
			}
			if (m_bStoreStats)
			{
				Debug.Log("------------STORESTATS VISIVAEM-------------------");
				bool flag = SteamUserStats.StoreStats();
				m_bStoreStats = !flag;
			}
		}
		catch
		{
		}
	}

	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
		if (SteamManager.Initialized && (ulong)m_GameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				m_bStatsValid = true;
				Debug.Log("------------POLUCHILI STATI-------------------");
			}
			else
			{
				Debug.Log("------------POLUCHENIE STATOV NE POLUICHILOS-------------------");
			}
		}
	}

	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
		if ((ulong)m_GameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				Debug.Log("------------STROE STATS SDELALI------------------");
			}
			else if (EResult.k_EResultInvalidParam == pCallback.m_eResult)
			{
				Debug.Log("------------YA NE ZNA U CHE ETO  NO  IZ STORESTST VIZIVAEM ON USERSTATSRECIVED CALLBACK------------------");
				OnUserStatsReceived(new UserStatsReceived_t
				{
					m_eResult = EResult.k_EResultOK,
					m_nGameID = (ulong)m_GameID
				});
			}
			else
			{
				Debug.Log("------------STORESTATS NE POLUCHILOS PITAEMSA ZANOVO-------------------");
			}
		}
	}

	private void OnAchievementStored(UserAchievementStored_t pCallback)
	{
		if ((ulong)m_GameID == pCallback.m_nGameID)
		{
			Debug.Log("-------Achievement " + pCallback.m_rgchAchievementName + " unlocked!------");
		}
	}
}
