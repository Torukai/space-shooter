using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Image containerImage;
	public Image receivingImage;
	public ModuleSlot slot;
	private Color normalColor;
	public Color highlightColor = Color.yellow;
	
	public void OnEnable ()
	{
		if (containerImage != null)
			normalColor = containerImage.color;
	}
	
	public void OnDrop(PointerEventData data)
	{
		containerImage.color = normalColor;
		
		if (receivingImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		ModuleType temp = GetModuleType(data);
		if (dropSprite != null && temp == slot.type)
		{
			
			receivingImage.overrideSprite = dropSprite;
			slot.Module = GetModule(data);
		}
		else
		{
			Debug.Log("empty");
		}

		//{
		//	ModuleType temp = GetModuleType(data);
		//	if (temp == ModuleType.Weapon)
		//	{
		//		receivingImage.overrideSprite = dropSprite;
		//	}
		//}
	}

	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			containerImage.color = highlightColor;
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		containerImage.color = normalColor;
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;
		
		var dragMe = originalObj.GetComponent<DragMe>();
		if (dragMe == null)
			return null;
		
		var srcImage = originalObj.GetComponent<Image>();
		if (srcImage == null)
			return null;
		
		return srcImage.sprite;
	}

	private Module GetModule(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		//if (originalObj == null)
		//	return null;

		var BaseSlot = originalObj.GetComponent<BaseSlot>();
		if (BaseSlot == null)
		{

		}
		else
		{
			return BaseSlot.Module;
		}


		return null;
	}

	private ModuleType GetModuleType(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		//if (originalObj == null)
		//	return null;

		var module = originalObj.GetComponent<BaseSlot>().Module;
		if (module == null)
		{

		}
		else
		{
			return module.type;
		}


		return ModuleType.Modifier;
	}
}
