using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class encapsulates all the attribute values of Player character
/// </summary>

public class PlayerProperties : MonoBehaviour
{

    public float BaseHealth;
    public float BaseShield;
    public float BaseFireRate;
    public float BaseShieldRecovery;

    public PlayerStat Health;
    public PlayerStat Shield;
    public PlayerStat FireRate;
    public PlayerStat ShieldRecovery;

    [SerializeField] PlayerModules modules;
    [SerializeField] StatPanel statPanel;

    public List<Module> myModulesList;
    public PlayerModules myModules;

    private void Awake()
	{
        Health = new PlayerStat(BaseHealth);
        Shield = new PlayerStat(BaseShield);
        FireRate = new PlayerStat(BaseFireRate);
        ShieldRecovery = new PlayerStat(BaseShieldRecovery);
        myModules = new PlayerModules();
        //statPanel.SetStats(Health, Shield, FireRate, ShieldRecovery);
        //statPanel.UpdateStatValues();

        DontDestroyOnLoad(this);
	}

	private void OnLevelWasLoaded(int level)
	{
        if (level == 0)
		{
           // statPanel = GameObject.Find("Canvas/Player info/").GetComponentInChildren<StatPanel>();
        }
        //statPanel.UpdateStatValues();
    }

    public PlayerModules GetModules()
	{
        return myModules;
	}

	public bool SetModules()
	{
        foreach(var m in myModules.moduleList)
		{
            if (m.type == ModuleType.Modifier)
			{
                //this.AddModule(m);
            }
            
		}
        //modules = ModulesManager.instance.Player1();
        //statPanel.UpdateStatValues();

        return true;
    }

	//public void AddModule(Module module)
	//{
	//	module.Equip(this);
	//	//statPanel.UpdateStatValues();
	//}

	public void UpdatePanel()
	{
        statPanel.UpdateStatValues();
    }

	public void RemoveModule(ModifierModule module)
	{
        //module.Unequip(this);
        statPanel.UpdateStatValues();
	}
}
