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
			if (GameManager.Instance.index == 1)
				SetBlueSpaceship();

			if (GameManager.Instance.index == 2)
				SetRedSpaceship();
		}
	}

	public void SetRedSpaceship()
	{
		GameManager.Instance.index = 2;
		statPanel.SetStats(GameManager.Instance.player2.GetStats());
		statPanel.UpdateStatValues();
	}

	public void SetBlueSpaceship()
	{
		GameManager.Instance.index = 1;
		statPanel.SetStats(GameManager.Instance.player1.GetStats());
		statPanel.UpdateStatValues();
	}
}
