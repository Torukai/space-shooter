using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Player player1;
    public Player player2;

    void Awake()
    {
        if (GameManager.Instance.index == 2)
		{
            player1.index = 2;
            player2.index = 1;
		}
    }

    // Update is called once per frame
    public void Update()
    {

        if (!player1.IsAlive() || !player2.IsAlive())
		{
            SceneManager.LoadScene(3);
		}
	}
}
