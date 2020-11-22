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

    //time for a new shot
    [HideInInspector] public float nextFire;


    [Tooltip("current weapon power")]
    [Range(1, 4)]       //change it if you wish
    public int weaponPower = 1; 

    public Guns guns;
    bool shootingIsActive = true; 
    [HideInInspector] public int maxweaponPower = 4;
    //public static PlayerShooting instance;
    public bool Forward = true;

    public List<Weapon> weapon;

    private void Awake()
    {
        fireRate = GetComponent<Player>().fireCooldown;
        AssignWeapons();
        //if (instance == null)
        //    instance = this;
    }

    private void AssignWeapons()
	{
        weapon = new List<Weapon>();
        int index = GetComponent<Player>().index;
        
        if (index == 1)
		{
            int weaponCount = 1;
            foreach (Module w in GameManager.Instance.player1.modules.moduleList)
            {

                //as WeaponModule;
                if (w is WeaponModule)
                {
                    WeaponModule temp = (WeaponModule)w;
                    //weapon.Add(temp.weapon);
                    weapon.Add(new Weapon(temp.fireRate * fireRate, temp.damage, temp.projectile, weaponCount));
                    weaponCount++;
                }

            }
        } else if (index == 2)
		{
            int weaponCount = 1;
            foreach (Module w in GameManager.Instance.player2.modules.moduleList)
            {

                //as WeaponModule;
                if (w is WeaponModule)
                {
                    WeaponModule temp = (WeaponModule)w;
                    //weapon.Add(temp.weapon);
                    weapon.Add(new Weapon(temp.fireRate * fireRate, temp.damage, temp.projectile, weaponCount));
                    weaponCount++;
                }

            }
        }
        

  //      for (int i = 0; i < weapon.Count; i++)
		//{
  //          weapon[i].index = i + 1;
		//}
	}


    private void Start()
    {
        var n = GetComponent<Player>().WeaponSlots;

  //      if (n.Count == 2) 
		//{
  //          Debug.Log("First gun");
            
  //      }
        guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();
        guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();


        foreach (Weapon w in weapon)
        {
            StartCoroutine(Shoot(w));
        }
        //receiving shooting visual effects components
        //guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();
        //guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();
        //guns.centralGunVFX = guns.centralGun.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        //if (shootingIsActive)
        //{
        //    if (Time.time > nextFire)
        //    {
        //        MakeAShot();                                                         
        //        nextFire = Time.time + 1 / fireRate;
        //    }
        //}
      

    }

    //method for a shot
    void MakeAShot(Weapon weapon) 
    {
        switch (weapon.index) // according to weapon power 'pooling' the defined anount of projectiles, on the defined position, in the defined rotation
        {
            case 0:
				CreateLazerShot(weapon.projectile, weapon.damage, guns.centralGun.transform.position, Vector3.zero);
				guns.centralGunVFX.Play();
				break;

            case 1:
                CreateLazerShot(weapon.projectile, weapon.damage, guns.rightGun.transform.position, Vector3.zero);
                //CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
				guns.rightGunVFX.Play();
				break;
            case 2:
                //CreateLazerShot(projectileObject, guns.rightGun.transform.position, Vector3.zero);
                
                CreateLazerShot(weapon.projectile, weapon.damage, guns.leftGun.transform.position, Vector3.zero);
                guns.leftGunVFX.Play();
                break;
            //case 3:
            //    //CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
            //    CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
            //    guns.leftGunVFX.Play();
            //    CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
            //    guns.rightGunVFX.Play();
            //    break;
            //case 4:
            //   // CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
            //    CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
            //    guns.leftGunVFX.Play();
            //    CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
            //    guns.rightGunVFX.Play();
            //    CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 15));
            //    CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -15));
            //    break;
        }
    }

	IEnumerator Shoot(Weapon weapon)
	{
        //      switch (weapon.index)
        //{
        //          case 1: CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero); break;
        //          case 2: CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero); break;
        //          default: break;
        //      }
        //      CreateLazerShot(weapon.projectile, guns.rightGun.transform.position, new Vector3(0, 0, -5));
       
        while (shootingIsActive)
		{
            MakeAShot(weapon);


            yield return new WaitForSeconds(weapon.fireRate);
        }
    }

	void CreateLazerShot(GameObject lazer, float damage, Vector3 pos, Vector3 rot) //translating 'pooled' lazer shot to the defined position in the defined rotation
    {
        if (Forward)
		{
            projectileObject = Instantiate(lazer, pos, Quaternion.Euler(rot));
            //projectileObject.transform.SetParent(transform, true);
            //projectileObject.tag = transform.name;
            projectileObject.GetComponent<Projectile>().SetParent(transform);
            projectileObject.GetComponent<Projectile>().SetDamage(damage);
            //projectileObject.transform.parent = transform;
        }
        else
		{
            projectileObject = Instantiate(lazer, pos, Quaternion.Euler(new Vector3(rot.x, rot.y, 180f)));
            //projectileObject.
            //projectileObject.transform.SetParent(transform, true);
            projectileObject.GetComponent<Projectile>().SetParent(transform);
            projectileObject.GetComponent<Projectile>().SetDamage(damage);
        }
    }
}


//void MakeAShot(Weapon weapon)
//{
//    switch (weapon.index) // according to weapon power 'pooling' the defined anount of projectiles, on the defined position, in the defined rotation
//    {
//        case 1:
//            //CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
//            //guns.centralGunVFX.Play();
//            break;
//        case 2:
//            CreateLazerShot(projectileObject, guns.rightGun.transform.position, Vector3.zero);
//            guns.leftGunVFX.Play();
//            CreateLazerShot(projectileObject, guns.leftGun.transform.position, Vector3.zero);
//            guns.rightGunVFX.Play();
//            break;
//        case 3:
//            //CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
//            CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
//            guns.leftGunVFX.Play();
//            CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
//            guns.rightGunVFX.Play();
//            break;
//        case 4:
//            // CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
//            CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
//            guns.leftGunVFX.Play();
//            CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
//            guns.rightGunVFX.Play();
//            CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 15));
//            CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -15));
//            break;
//    }
//}