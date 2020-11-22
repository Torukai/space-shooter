using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//guns objects in 'Player's' hierarchy
[System.Serializable]
public class Guns
{
    public GameObject rightGun, leftGun, centralGun;
    [HideInInspector] public ParticleSystem leftGunVFX, rightGunVFX, centralGunVFX; 
}

public class PlayerShooting : MonoBehaviour {

    [Tooltip("shooting frequency. the higher the more frequent")]
    public float fireRate;

    [Tooltip("projectile prefab")]
    public GameObject projectileObject;

    public Guns guns;
    bool shootingIsActive = true; 
    ///[HideInInspector] public int maxweaponPower = 4;
    public bool Forward = true;

    public List<Weapon> weapon;

    private void Awake()
    {
        fireRate = GetComponent<Player>().fireCooldown;
        AssignWeapons();
    }

    private void AssignWeapons()
	{
        weapon = new List<Weapon>();
        int index = GetComponent<Player>().index;
        
        if (index == 2)
		{
            int weaponCount = 1;
            foreach (Module w in GameManager.Instance.player1.Modules.moduleList)
            {
                if (w is WeaponModule)
                {
                    WeaponModule temp = (WeaponModule)w;
                    weapon.Add(new Weapon(temp.fireRate * fireRate, temp.damage, temp.projectile, weaponCount));
                    weaponCount++;
                }
            }
        } else if (index == 1)
		{
            int weaponCount = 1;
            foreach (Module w in GameManager.Instance.player2.Modules.moduleList)
            {
                if (w is WeaponModule)
                {
                    WeaponModule temp = (WeaponModule)w;
                    weapon.Add (new Weapon (temp.fireRate * fireRate, temp.damage, temp.projectile, weaponCount));
                    weaponCount++;
                }
            }
        }
	}

    private void Start()
    {
        guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();
        guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();

        foreach (Weapon w in weapon)
        {
            StartCoroutine(Shoot(w));
        }
    }

    void MakeAShot(Weapon weapon) 
    {
        switch (weapon.index)
        {
            case 0:
				CreateLazerShot(weapon.projectile, weapon.damage, guns.centralGun.transform.position, Vector3.zero);
				guns.centralGunVFX.Play();
				break;
            case 1:
                CreateLazerShot(weapon.projectile, weapon.damage, guns.rightGun.transform.position, Vector3.zero);
				guns.rightGunVFX.Play();
				break;
            case 2:
                CreateLazerShot(weapon.projectile, weapon.damage, guns.leftGun.transform.position, Vector3.zero);
                guns.leftGunVFX.Play();
                break;
        }
    }

	IEnumerator Shoot(Weapon weapon)
	{
        while (shootingIsActive)
		{
            MakeAShot(weapon);
            yield return new WaitForSeconds(weapon.fireRate);
        }
    }

	void CreateLazerShot(GameObject lazer, float damage, Vector3 pos, Vector3 rot)
    {
        if (Forward)
		{
            projectileObject = Instantiate(lazer, pos, Quaternion.Euler(rot));
            projectileObject.GetComponent<Projectile>().SetParent(transform);
            projectileObject.GetComponent<Projectile>().SetDamage(damage);
        }
        else
		{
            projectileObject = Instantiate(lazer, pos, Quaternion.Euler(new Vector3(rot.x, rot.y, 180f)));
            projectileObject.GetComponent<Projectile>().SetParent(transform);
            projectileObject.GetComponent<Projectile>().SetDamage(damage);
        }
    }
}