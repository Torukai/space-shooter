using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public float fireRate { get; set; }	
	public float damage { get; set; }
	

	public Weapon ( float fireRate, float damage)
	{
		this.fireRate = fireRate;
		this.damage = damage;
	}
}
