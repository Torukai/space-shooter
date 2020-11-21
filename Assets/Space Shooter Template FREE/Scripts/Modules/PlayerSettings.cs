using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class PlayerSettings
{
	private static int index { get; set; }
	private static float BaseHealth { get; set; }
	private static float BaseShield { get; set; }
	private static float BaseFireRate { get; set; }
	private static float BaseShieldRecovery { get; set; }

	public static PlayerStat Health { get; set; }
	public static PlayerStat Shield { get; set; }
	public static PlayerStat FireRate { get; set; }
	public static PlayerStat ShieldRecovery { get; set; }

	public static PlayerModules modules { get; set; }

	public static StatPanel statPanel { get; set; }

	//private static List<Module> myModulesList;
	//private static PlayerModules myModules;

	//public static PlayerModules player1Mods
	//{
	//	get
	//	{
	//		return player1;
	//	}

	//	set
	//	{
	//		player1 = value;
	//	}
	//}

	//public static PlayerModules player2Mods
	//{
	//	get
	//	{
	//		return player2;
	//	}

	//	set
	//	{
	//		player1 = value;
	//	}
	//}

}
