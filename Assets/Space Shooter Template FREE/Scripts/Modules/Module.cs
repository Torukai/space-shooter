using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IModule
{
	string name { get; }
	Sprite icon { get; }
}

[Serializable]
[CreateAssetMenu(menuName ="Module")]
public class Module : ScriptableObject
{
	#region fields
	//public Weapon Weapon;
	public string ModuleName;
	public ModuleType type;
	//public float healthModValue;
	//public float shieldModValue;
	//public float fireRateModValue;
	//public float shieldRecoveryModValue;
	//public float weaponDamage;

	public Sprite icon;
	#endregion

	#region Equip
	public virtual void Equip(PlayerProfile player)
	{
		//if (type == ModuleType.Weapon)
		//{
		//	//Weapon = new Weapon(fireRateModValue, weaponDamage);
		//	//playerProperties.WeaponSlots.Add(Weapon);
		//}
		//else if (type == ModuleType.Modifier)
		//{
		//	if (healthModValue != 0)
		//	{
		//		player.Health.AddModifier(new StatModifier(healthModValue, StatModType.Flat, this));
		//	}
		//	else if (shieldModValue != 0)
		//	{
		//		player.Shield.AddModifier(new StatModifier(shieldModValue, StatModType.Flat, this));
		//	}
		//	else if (fireRateModValue != 0)
		//	{
		//		player.FireRate.AddModifier(new StatModifier(fireRateModValue, StatModType.Flat, this));
		//	}
		//	else if (shieldRecoveryModValue != 0)
		//	{
		//		player.ShieldRecovery.AddModifier(new StatModifier(shieldRecoveryModValue, StatModType.Flat, this));
		//	}
		//}
	}

	#endregion

	public static Module Default()
	{
		return new Module();
	}

}


