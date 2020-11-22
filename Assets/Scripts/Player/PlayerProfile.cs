using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerSettings")]
public class PlayerProfile : ScriptableObject
{
	[SerializeField] private int index;
	[SerializeField] private float BaseHealth;
	[SerializeField] private float BaseShield;
	[SerializeField] private float BaseFireRate;
	[SerializeField] private float BaseShieldRecovery;

	public PlayerStat Health;
	public PlayerStat Shield;
	public PlayerStat FireRate;
	public PlayerStat ShieldRecovery;
	public Sprite spaceship;

	public PlayerModules Modules;
	public List<Weapon> weapons;
	public List<Module> myModules;

	public void Init()
	{
		Debug.Log("Profile Created " + index);
		Health = new PlayerStat(BaseHealth);
		Shield = new PlayerStat(BaseShield);
		FireRate = new PlayerStat(BaseFireRate);
		ShieldRecovery = new PlayerStat(BaseShieldRecovery);
		Modules = new PlayerModules();
		weapons = new List<Weapon>();
		myModules = Modules.moduleList;
	}
	public PlayerStat[] GetStats()
	{
		PlayerStat[] stats = new PlayerStat[] {Health, Shield, FireRate, ShieldRecovery};
		return stats;
	}

	public void AddModule(ModifierModule module)
	{
		module.Equip(this);
	}

	public void RemoveModule(ModifierModule module)
	{
		module.Unequip(this);
	}

	public void RemoveAllModules()
	{
		Health.RemoveAllModifiersFromSource(this);
		Shield.RemoveAllModifiersFromSource(this);
		FireRate.RemoveAllModifiersFromSource(this);
		ShieldRecovery.RemoveAllModifiersFromSource(this);
		Init();
	}
}
