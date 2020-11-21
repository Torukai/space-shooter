using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class represents a pure stat modifier module
[CreateAssetMenu]
public class ModifierModule : Module
{
	public int healthMod;
	public int shieldMod;
	public int fireRateMod;
	public int ShieldRecoveryMod;

	public float healthPercentMod;
	public float shieldPercentMod;
	public float fireRatePercentMod;
	public float ShieldRecoveryPercentMod;
	
	public void Equip(PlayerProfile player)
	{
		if (healthMod != 0)
			player.Health.AddModifier(new StatModifier(healthMod, StatModType.Flat, this));
		if (shieldMod != 0)
			player.Shield.AddModifier(new StatModifier(shieldMod, StatModType.Flat, this));
		if (fireRateMod != 0)
			player.FireRate.AddModifier(new StatModifier(fireRateMod, StatModType.Flat, this));
		if (ShieldRecoveryMod != 0)
			player.ShieldRecovery.AddModifier(new StatModifier(ShieldRecoveryMod, StatModType.Flat, this));

		if (healthPercentMod != 0)
			player.Health.AddModifier(new StatModifier(healthPercentMod, StatModType.PercentMult, this));
		if (shieldPercentMod != 0)
			player.Shield.AddModifier(new StatModifier(shieldPercentMod, StatModType.PercentMult, this));
		if (fireRatePercentMod != 0)
			player.FireRate.AddModifier(new StatModifier(fireRatePercentMod, StatModType.PercentMult, this));
		if (ShieldRecoveryPercentMod != 0)
			player.ShieldRecovery.AddModifier(new StatModifier(ShieldRecoveryPercentMod, StatModType.PercentMult, this));
	}

	public void Unequip(PlayerProfile player)
	{
		player.Health.RemoveAllModifiersFromSource(this);
		player.Shield.RemoveAllModifiersFromSource(this);
		player.FireRate.RemoveAllModifiersFromSource(this);
		player.ShieldRecovery.RemoveAllModifiersFromSource(this);
	}
}
