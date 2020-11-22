using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public GameObject destructionFX;
    public Sprite sprite;
    //public static Player instance;
    //public Modules playerModules;
    //public Shield playerShield;
    //public PlayerModules modules;
    //public PlayerProperties properties;
    //public GameObject propertiesParent;

    public int index;
    //public List<Module> myModules;

    //public PlayerStat healthMod;
    //public PlayerStat shieldMod;
    //public PlayerStat fireRateMod;
    //public PlayerStat shieldRecoveryMod;

    public List<Weapon> WeaponSlots;

    public float health = 100;
    public float shield = 0;
    public float shieldRecoverySpeed = 1;
    public int fireCooldown = 1;

    private void Awake()
    {
        //propertiesParent = GameObject.Find("PlayerProperties");
        
        //properties = propertiesParent.GetComponentInChildren<PlayerProperties>();
        //if (instance == null)
        //	instance = this;
        if (index == 1)
		{
            
            //modules = ModulesManager.instance.Player1();//StaticModules.player1Mods; //ModulesManager.instance.Player1();
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BlueSpaceship");
            
            // TODO:   
   //         foreach (var w in GameManager.Instance.player1.weapons)
			//{
   //             WeaponSlots.Add(w);
			//}

            health = GameManager.Instance.player1.Health.Value;
            shield = GameManager.Instance.player1.Shield.Value;
            shieldRecoverySpeed = GameManager.Instance.player1.ShieldRecovery.Value;
        }
        else if (index == 2)
		{
			//modules = ModulesManager.instance.Player2();
			GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("RedSpaceship");
            health = GameManager.Instance.player2.Health.Value;
            shield = GameManager.Instance.player2.Shield.Value;
            shieldRecoverySpeed = GameManager.Instance.player2.ShieldRecovery.Value;
        }

        //DontDestroyOnLoad(this);
		//playerModules = new Modules();
        
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(float damage)   
    {
        if (shield > 0)
		{
            shield -= damage;
            Debug.Log("Shield: " + shield);
        }
		else
		{
            health -= damage;
            Debug.Log("Health: " + health);
        }
        
    }

    public void setShield(float shieldAmount)
	{
        shield = shieldAmount;
	}

    public bool IsAlive()
	{
        return health > 0;
	}

    public void Defeat()
	{
        Destruction();
    }

    //'Player's' destruction procedure
    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        Destroy(gameObject);
    }
}
















