using System.Collections;
using System.Collections.Generic;

using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class BaseSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] Image Image;
	[SerializeField] ModuleTooltip tooltip;
	[SerializeField] Module _module;

	//public event Action<BaseSlot> OnPointerEnterEvent;
	//public event Action<BaseSlot> OnPointerExitEvent;

	private Color normalColor = Color.white;
	private Color disabledColor = new Color(1, 1, 1, 0);
	public Module Module
	{
		get { return _module; }
		set
		{
			_module = value;
			if (_module == null)
			{
				Image.color = disabledColor;
			}
			else
			{
				Image.sprite = _module.icon;
				Image.color = normalColor;
			}
		}
	}

	//public void OnDrag(PointerEventData eventData)
	//{
	//	throw new NotImplementedException();
	//}

	public void OnPointerEnter(PointerEventData eventData)
	{
		//if (_module is ModifierModule)
		//{
		//	tooltip.ShowTooltip((ModifierModule)_module);
		//}
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			tooltip.HideTooltip();
		}
		else
		{
			tooltip.ShowTooltip(_module);
		}
		
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	
		tooltip.HideTooltip();
	}

	protected virtual void OnValidate()
	{
		if (Image == null)
		{
			
			Image = GetComponentInChildren<Image>();
		}

		if (tooltip == null)
		{
			tooltip = FindObjectOfType<ModuleTooltip>();
		}
	}
}
