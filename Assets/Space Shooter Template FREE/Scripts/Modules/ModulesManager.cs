using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for  for keeping modules data for each player before they get assigned to them.
/// </summary>


public class ModulesManager : MonoBehaviour
{
    //private Modules playerModules;
    public static ModulesManager instance;

    //[SerializeField] private PlayerModules FirstPlayerModules;
    //[SerializeField] private PlayerModules SecondPlayerModules;

    //private PlayerModules player1;

    //private PlayerModules player2;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
		{
            instance = this;
        }
        else if (instance != this)
        {
            // If the instance reference has already been set, and this is not the
            // the instance reference, destroy this game object.
            Destroy(gameObject);
        }

        Debug.Log("AWAKEN");
        
        DontDestroyOnLoad(gameObject);
    }

 //   public PlayerModules Player1()
	//{
 //       return player1;
	//}
    //public PlayerModules Player2()
    //{
    //    return SecondPlayerModules;
    //}

    public void Equip1()
	{
        GameManager.Instance.player1.RemoveAllModules();

        //var properties = GameObject.Find("PlayerProperties").GetComponentsInChildren<PlayerProperties>();
        var modules1 = GameObject.Find("Canvas/Player mods 1/Body/WeaponModules").GetComponentsInChildren<ModuleSlot>();
        foreach (var m in modules1)
        {
            var module = m.Module as WeaponModule;
            //module.AddWeapon(GameManager.Instance.player1);
            // GameManager.Instance.player1.AddWeapon(module.damage, module.fireRate);
            //(WeaponModule)module.Weapon;
            GameManager.Instance.player1.modules.AddModule(m.Module);
            //GameManager.Instance.player1.weapon1 = module.weapon;
            module.AddWeapon(GameManager.Instance.player1);
        }

        modules1 = GameObject.Find("Canvas/Player mods 1/Body/DefenseModules").GetComponentsInChildren<ModuleSlot>();

        //var test = GameManager.Instance.player1.modules;

        foreach (var m in modules1)
		{
            //as ModifierModule;
            if (m.Module is ModifierModule)
			{
                var module = (ModifierModule)m.Module;
                GameManager.Instance.player1.modules.AddModule(module);
                module.Equip(GameManager.Instance.player1);
            }
        }

       

        //      for (int i =0; i<FirstPlayerModules.moduleSlots.Length; i++)
        //{

        //          //FirstPlayerModules.moduleList.Add(FirstPlayerModules.moduleSlots[i].Module);
        //          GameManager.Instance.player1.modules.AddModule(FirstPlayerModules.moduleSlots[i].Module);
        //      }
        //properties[0].myModules = FirstPlayerModules;
        //properties[0].SetModules();
        //PlayerSettings.modules = FirstPlayerModules;
        //player1 = FirstPlayerModules;
        //StaticModules.player1Mods = FirstPlayerModules;

    }
    public void Equip2()
    {
        GameManager.Instance.player2.RemoveAllModules();

        //var properties = GameObject.Find("PlayerProperties").GetComponentsInChildren<PlayerProperties>();
        var modules1 = GameObject.Find("Canvas/Player mods 2/Body/WeaponModules").GetComponentsInChildren<ModuleSlot>();
        foreach (var m in modules1)
        {
            var module = m.Module as WeaponModule;
            //module.AddWeapon(GameManager.Instance.player1);
            // GameManager.Instance.player1.AddWeapon(module.damage, module.fireRate);
            //(WeaponModule)module.Weapon;
            GameManager.Instance.player2.modules.AddModule(m.Module);
            //GameManager.Instance.player1.weapon1 = module.weapon;
            module.AddWeapon(GameManager.Instance.player2);
        }

        modules1 = GameObject.Find("Canvas/Player mods 2/Body/DefenseModules").GetComponentsInChildren<ModuleSlot>();

        //var test = GameManager.Instance.player1.modules;

        foreach (var m in modules1)
        {
            var module = m.Module as ModifierModule;
            GameManager.Instance.player2.modules.AddModule(module);
            module.Equip(GameManager.Instance.player2);

        }
    }
}
