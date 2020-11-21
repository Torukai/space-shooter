using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleSlotUI : MonoBehaviour
{

	[SerializeField] Image image;

    public Module module;
	public ModuleType type;

	public Module Module
	{
		get { return module; }
		set
		{
			module = value;

			if (module == null)
			{
				image.enabled = false;
			}
			else
			{
				image.sprite = module.icon;
				image.enabled = true;
			}
		}
	}

	private void Awake()
	{
		module = Module.Default();
	}

	public void SetModule(string name)
	{
		switch (name)
		{
			case "Weapon A":
				module = new Module();
				break;
			case "Weapon B":
				module = new Module();
				break;
			case "Weapon C":
				module = new Module();
				break;
			case "Defense A":
				module = new Module();
				break;
			case "Defense B":
				module = new Module();
				break;
			case "Defense C":
				module = new Module();
				break;
			case "Defense D":
				module = new Module();
				break;
			default:
				module = Module.Default();
				break;
		}
	}
}
