using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedModules : MonoBehaviour
{
	[SerializeField] Transform equipedModulesParent;
	[SerializeField] ModuleSlot[] moduleSlots;

	private void OnValidate()
	{
		moduleSlots = equipedModulesParent.GetComponentsInChildren<ModuleSlot>();
	}

	public bool AddModule(Module module)
	{
		for (int i =0; i < moduleSlots.Length; i++)
		{
			if (moduleSlots[i].type == module.type)
			{
				moduleSlots[i].Module = module;
				return true;
			}
		}

		return false;
	}
	
	// Probably not needed
	public bool RemoveModule(Module module)
	{
		for (int i = 0; i < moduleSlots.Length; i++)
		{
			if (moduleSlots[i].type == module.type)
			{
				moduleSlots[i].Module = module;
				return true;
			}
		}

		return false;
	}
}
