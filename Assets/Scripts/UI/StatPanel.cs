﻿using UnityEngine;

public class StatPanel : MonoBehaviour
{
	[SerializeField] StatDisplay[] statDisplays;
	[SerializeField] string[] statNames;

	private PlayerStat[] stats;

	private void OnValidate()
	{
		statDisplays = GetComponentsInChildren<StatDisplay>();
		UpdateStatNames();
	}

	public void SetStats(params PlayerStat[] playerStats)
	{
		stats = playerStats;

		if (stats.Length > statDisplays.Length)
		{
			Debug.LogError("Not Enough Stat Displays!");
			return;
		}

		for (int i = 0; i < statDisplays.Length; i++)
		{
			statDisplays[i].gameObject.SetActive(i < stats.Length);
		}
	}

	public void UpdateStatValues()
	{
		for (int i = 0; i < stats.Length; i++)
		{
			statDisplays[i].ValueText.text = stats[i].Value.ToString();
		}
	}

	public void UpdateStatNames()
	{
		for (int i = 0; i < statNames.Length; i++)
		{
			statDisplays[i].NameText.text = statNames[i];
		}
	}
}
