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

    public int index = GameManager.Instance.index;

    //public List<Weapon> WeaponSlots;

    public float health;
    public float shield;
    public float shieldRecoverySpeed;
    public int fireCooldown;

    private void Awake()
    {
 
        PlayerProfile data = new PlayerProfile();
        if (index == 1)
		{
            data = GameManager.Instance.player1;
            index = 2;
		}
        else if (index == 2)
		{
            data = GameManager.Instance.player2;
            index = 1;
		}

        GetComponent<SpriteRenderer>().sprite = data.spaceship;
        health = data.Health.Value;
        shield = data.Shield.Value;
        shieldRecoverySpeed = data.ShieldRecovery.Value;  
    }

    //method for damage proceccing by 'Player'
    public void GetDamage (float damage)   
    {
        if (shield > 0)
		{
            shield -= damage;
            Debug.Log ("Shield: " + shield);
        }
		else
		{
            health -= damage;
            Debug.Log ("Health: " + health);
        }
    }

    public void setShield (float shieldAmount)
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
        //generating destruction visual effect and destroying the 'Player' object
        Instantiate(destructionFX, transform.position, Quaternion.identity); 
        Destroy(gameObject);
    }
}