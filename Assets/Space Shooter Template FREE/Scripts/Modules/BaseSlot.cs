using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSlot : MonoBehaviour
{
	[SerializeField] Image Image;

	[SerializeField] Module _module;
	public Module Module
	{
		get { return _module; }
		set
		{
			_module = value;
			if (_module == null)
			{
				Image.enabled = false;
			}
			else
			{
				Image.sprite = _module.icon;
				Image.enabled = true;
			}
		}
	}

	protected virtual void OnValidate()
	{
		if (Image == null)
		{
			
			Image = GetComponentInChildren<Image>();
		}
	}
}
