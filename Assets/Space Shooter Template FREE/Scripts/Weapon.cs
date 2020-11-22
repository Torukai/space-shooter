using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
	public int index;
	public float fireRate { get; set; }	
	public float damage { get; set; }

	public GameObject projectile;

	public Weapon (float fireRate, float damage, GameObject projectile, int index)
	{
		this.fireRate = fireRate;
		this.damage = damage;
		this.projectile = projectile;
		this.index = index;
	}
}
