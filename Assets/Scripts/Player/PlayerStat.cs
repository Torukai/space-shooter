using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;
using System;

[Serializable]
public class PlayerStat
{
    public float BaseValue;
    private bool IsModified = true;
    private float lastBaseValue = float.MinValue;
    [SerializeField] private float _value;

    public float Value
    {
        get
        {
            if (IsModified || BaseValue != lastBaseValue)
            {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValie();
                IsModified = false;
            }
            return _value;
        }
    }
    private readonly List<StatModifier> statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public PlayerStat()
    {
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    public PlayerStat (float baseValue) : this()
	{
        BaseValue = baseValue;
	}

    public void AddModifier (StatModifier mod)
	{
        IsModified = true;
        statModifiers.Add (mod);
        statModifiers.Sort (CompareModifierOrder);
	}

    public bool RemoveAllModifiersFromSource (object source)
	{
        bool IsRemoved = false;

        for (int i = statModifiers.Count-1; i >= 0; i--)
		{
            if (statModifiers[i].Source == source)
			{
                IsModified = true;
                IsRemoved = true;
                statModifiers.RemoveAt (i);
			}
		}
        return IsRemoved;
	}

    private int CompareModifierOrder (StatModifier a, StatModifier b)
	{
        if (a.Order < b.Order)
        {
            return -1;
        }
        else if (a.Order > b.Order)
            return 1;
        return 0;
	}

    public bool RemoveModifier (StatModifier mod)
	{

        if (statModifiers.Remove (mod))
		{
            IsModified = true;
            return true;

        }
        return false;
	}

    private float CalculateFinalValie()
	{
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for (int i =0; i< statModifiers.Count; i++)
		{
            StatModifier mod = statModifiers[i];
            if (mod.Type == StatModType.Flat)
			{
                finalValue += mod.Value;
            }
            else if (mod.Type == StatModType.PercentAdd)
            {
                sumPercentAdd += mod.Value;
                if (i + 1 >= statModifiers.Count || statModifiers[i+1].Type != StatModType.PercentAdd)
				{
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
				}
            }
            else if (mod.Type == StatModType.PercentMult)
			{
                finalValue *= 1 + mod.Value;
			}
		}
        return (float)Math.Round (finalValue, 1);
	}
}
