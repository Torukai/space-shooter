using System.Collections.Generic;
using UnityEngine;

public class ModulesMenu : MonoBehaviour
{
	public List<Module> moduleList;
	public Transform itemsParent;
	public BaseSlot[] moduleSlots;

	private void OnValidate()
	{
		if (itemsParent != null)
		{
			moduleSlots = itemsParent.GetComponentsInChildren<BaseSlot>();
		}

		RefreshUI();
	}

	private void RefreshUI()
	{
		int i = 0;

		for (; i < moduleList.Count && i < moduleSlots.Length; i++)
		{
			moduleSlots[i].Module = moduleList[i];
		}

		for (; i < moduleSlots.Length; i++)
		{
			moduleSlots[i].Module = null;
		}
	}
}
