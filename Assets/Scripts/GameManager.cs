using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// </summary>
public class GameManager : MonoBehaviour
{
	public PlayerProfile player1, player2;
	public int index=1;

    public static GameManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			Instance = this;
			player1.Init();
			player2.Init();
		}
        DontDestroyOnLoad(this);
    }
}
