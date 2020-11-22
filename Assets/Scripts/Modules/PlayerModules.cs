using System.Collections.Generic;
using UnityEngine;

public class PlayerModules
{
	public List<Module> moduleList;
	public Transform itemsParent;
	public ModuleSlot[] moduleSlots;

	public PlayerModules()
	{
		moduleList = new List<Module>();
	}


	public void AddModule (Module module)
	{
		moduleList.Add (module);
	}

	private void OnValidate()
	{
		if (itemsParent != null)
		{
			moduleSlots = itemsParent.GetComponentsInChildren<ModuleSlot>();
		}

		RefreshUI();
	}

	public bool RemoveModule (Module module)
	{
		if (moduleList.Remove (module))
		{
			RefreshUI();
			return true;
		}
		return false;
	}

	private void RefreshUI()
	{
		int i = 0;

		for (; i< moduleList.Count && i< moduleSlots.Length; i++)
		{
			moduleSlots[i].Module = moduleList[i];
		}

		for (; i<moduleSlots.Length; i++)
		{
			moduleSlots[i].Module = null;
		}
	}
}

