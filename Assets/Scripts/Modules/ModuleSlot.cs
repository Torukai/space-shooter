using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModuleSlot : BaseSlot
{
	public ModuleType type;

	protected override void OnValidate()
	{
		base.OnValidate();
		gameObject.name = type.ToString() + " slot";
	}
}
