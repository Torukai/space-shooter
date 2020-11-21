using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TODO: Testing variant of assigning stats values to panel. Works fine but it's ugly and something needs to be done with this...
/// </summary>
public class Setting : MonoBehaviour
{
    public int index;
	public StatPanel statPanel;

	private void OnLevelWasLoaded(int level)
	{
		if (level == 0)
		{
			SetBlueSpaceship();
		}
	}

	public void SetRedSpaceship()
	{
		statPanel.SetStats(GameManager.Instance.player2.GetStats());
		statPanel.UpdateStatValues();
	}

	public void SetBlueSpaceship()
	{
		statPanel.SetStats(GameManager.Instance.player1.GetStats());
		statPanel.UpdateStatValues();
	}
}
