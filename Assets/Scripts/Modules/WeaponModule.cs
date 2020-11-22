using UnityEngine;


// Class represents an equipable weapon module
[CreateAssetMenu(menuName ="Module/Weapon module")]
public class WeaponModule : Module
{
	public float damage;
	public float fireRate;
	public Weapon weapon;
	public GameObject projectile;
}
