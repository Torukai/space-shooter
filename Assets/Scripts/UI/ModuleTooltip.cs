using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ModuleTooltip : MonoBehaviour
{

	[SerializeField] Text ModuleNameText;
	[SerializeField] Text ModuleTypeText;
	[SerializeField] Text ModuleStatText;

	private StringBuilder sb = new StringBuilder();
	public void ShowTooltip (Module module)
	{
		if (module == null)
			return;

		ModuleNameText.text = "Name: " + module.name;

		ModuleTypeText.text = "Type: " + module.type.ToString();

		if (module is WeaponModule)
		{
			var temp = (WeaponModule)module;
			sb.Length = 0;
			AddStat (temp.damage, "Damage");
			AddStat (temp.fireRate, "Fire rate");
		}
		else if (module is ModifierModule)
		{
			var temp = (ModifierModule)module;
			sb.Length = 0;
			AddStat (temp.healthMod, "Health");
			AddStat (temp.shieldMod, "Shield");
			AddStat (temp.fireRateMod, "Firerate");
			AddStat (temp.ShieldRecoveryMod, "Shield recovery");

			AddStat (temp.healthPercentMod, "Health", isPercent: true);
			AddStat (temp.shieldPercentMod, "Shield", isPercent: true);
			AddStat (temp.fireRatePercentMod, "Firerate", isPercent: true);
			AddStat (temp.ShieldRecoveryPercentMod, "Shield recovery", isPercent: true);
		}
		ModuleStatText.text = sb.ToString();
		gameObject.SetActive (true);
	}

	public void HideTooltip()
	{
		gameObject.SetActive (false);
	}

	private void AddStat (float value, string statName, bool isPercent = false)
	{
		if (value != 0)
		{
			if (sb.Length > 0)
			{
				sb.AppendLine();
			}

			if (value > 0)
			{
				sb.Append ("+");
			}

			if (isPercent)
			{
				sb.Append (value * 100);
				sb.Append ("% ");
			}
			else
			{
				sb.Append (value);
				sb.Append (" ");
			}

			sb.Append (statName);
		}
	}
}
