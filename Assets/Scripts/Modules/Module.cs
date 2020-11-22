using UnityEngine;
using System;

public enum ModuleType
{
	Weapon,
	Modifier
}

[Serializable]
//[CreateAssetMenu(menuName ="Module")]
public class Module : ScriptableObject
{
	#region fields
	public string ModuleName;
	public ModuleType type;
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


