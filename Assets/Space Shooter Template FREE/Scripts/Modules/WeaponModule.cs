using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Class represents an equipable weapon module
[CreateAssetMenu(menuName ="Module/WeaponModule")]
public class WeaponModule : Module
{
	public float damage;

	public float fireRate;
	public Weapon weapon;
	public GameObject projectile;
	public void AddWeapon(PlayerProfile player)
	{
		//weapon = new Weapon(damage, fireRate);
		player.weapon1 = weapon;
	}
}
