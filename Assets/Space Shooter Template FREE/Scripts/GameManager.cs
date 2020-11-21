using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This object keeps track of profiles for each player. It is available across all scenes.
/// </summary>
public class GameManager : MonoBehaviour
{
	public PlayerProfile player1, player2;

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
			

			//player1 = ScriptableObject.CreateInstance<PlayerProfile>();
			//player2 = ScriptableObject.CreateInstance<PlayerProfile>();

			player1.Init();
			player2.Init();
			//Instantiate(player2);
		}

		//if (Instance == null)
		//{
  //          Instance = this;
		//}

        

        DontDestroyOnLoad(this);
    }
}
