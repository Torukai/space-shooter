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

	[SerializeField] public PlayerStat Health;
	[SerializeField] public PlayerStat Shield;
	[SerializeField] public PlayerStat FireRate;
	[SerializeField] public PlayerStat ShieldRecovery;

	public PlayerModules modules;
	public List<Weapon> weapons;
	public List<Module> myModules;
	public Weapon weapon1;

	public void Init()
	{
		Debug.Log("Profile Created " + index);
		Health = new PlayerStat(BaseHealth);
		Shield = new PlayerStat(BaseShield);
		FireRate = new PlayerStat(BaseFireRate);
		ShieldRecovery = new PlayerStat(BaseShieldRecovery);
		modules = new PlayerModules();
		weapons = new List<Weapon>();
		myModules = modules.moduleList;
	}
	public PlayerStat[] GetStats()
	{
		PlayerStat[] stats = new PlayerStat[] {Health, Shield, FireRate, ShieldRecovery};
		return stats;
	}

	public void AddModule(ModifierModule module)
	{
		//var temp = (ModifierModule)module;
		module.Equip(this);
		//statPanel.UpdateStatValues();
	}

	public void AddWeapon(float damage, float firerate)
	{
		//weapons.Add(new Weapon(damage, firerate));
		//weapon1 = new Weapon(damage, firerate);
	}

	public void RemoveModule(ModifierModule module)
	{
		module.Unequip(this);
		///statPanel.UpdateStatValues();
	}

	public void RemoveAllModules()
	{
		bool removed = Health.RemoveAllModifiersFromSource(this);

		//Health = new PlayerStat(BaseHealth);
		removed= Shield.RemoveAllModifiersFromSource(this);
		removed = FireRate.RemoveAllModifiersFromSource(this);
		removed= ShieldRecovery.RemoveAllModifiersFromSource(this);
		//module.Unequip(this);
		///statPanel.UpdateStatValues();
		///
		Init();
	}
}
