using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AKA Inventory
public class PlayerModules : MonoBehaviour
{
	public List<Module> moduleList;
	public Transform itemsParent; // not sure about that
	public ModuleSlot[] moduleSlots;


	private void Awake()
	{
		//DontDestroyOnLoad(this.gameObject);
	}
	public PlayerModules()
	{
		moduleList = new List<Module>();
		//AddModule(new Module {type = ModuleType.Weapon });
	}

	//public PlayerModules(PlayerModules modules)
	//{
	//	moduleList = modules.moduleList;
	//	itemsParent = modules.itemsParent;
	//	moduleSlots = modules.moduleSlots;
	//	foreach (var n in moduleList)
	//	{
	//		AddModule(n);
	//	}
	//}

	public void AddModule (Module module)
	{
		moduleList.Add(module);
		//if (module.type == ModuleType.Weapon)
		//{
		//	Debug.Log("Weapon");
		//}
		
	}

	private void OnValidate()
	{
		if (itemsParent != null)
		{
			moduleSlots = itemsParent.GetComponentsInChildren<ModuleSlot>();
		}

		RefreshUI();
	}

	public bool RemoveModule(Module module)
	{
		if (moduleList.Remove(module))
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

