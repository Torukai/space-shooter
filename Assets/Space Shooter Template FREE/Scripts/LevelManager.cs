using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Player player1;
    public Player player2;

    //public static Player player1;
    //public static Player player2;
    //public Sprite SpaceShip;

    //public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("hello");
    }

    void Awake()
    {
        if (GameManager.Instance.index == 2)
		{
            player1.index = 2;
            player2.index = 1;
		}
        //player1 = GameObject.Find("Player 1").GetComponent<Player>();
        //player2 = GameObject.Find("Player 2").GetComponent<Player>();

    }

    // Update is called once per frame
    public void Update()
    {

        if (!player1.IsAlive() || !player2.IsAlive())
		{
            SceneManager.LoadScene(3);
		}
	}


	private void LateUpdate()
	{
        //if (!player1.IsAlive())
        //{
        //    player1.Defeat();
        //}
        //else if (!player2.IsAlive())
        //{
        //    player2.Defeat();
        //}
    }
}
