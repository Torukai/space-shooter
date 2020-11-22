using UnityEngine;


/// <summary>
/// 
/// </summary>

public class ModulesManager : MonoBehaviour
{
    public static ModulesManager instance;

    public void AssignSettings()
	{
        EquipBlueSpaceshipModules();
        EquipRedSpaceshipModules();
	}

    public void EquipBlueSpaceshipModules()
	{
        GameManager.Instance.player1.RemoveAllModules();

        var modules1 = GameObject.Find ("Canvas/Player mods 1/Body/WeaponModules").GetComponentsInChildren<ModuleSlot>();
        foreach (var m in modules1)
        {
            var module = m.Module as WeaponModule;
            GameManager.Instance.player1.Modules.AddModule(m.Module);
        }

        modules1 = GameObject.Find ("Canvas/Player mods 1/Body/DefenseModules").GetComponentsInChildren<ModuleSlot>();
        foreach (var m in modules1)
		{
            if (m.Module is ModifierModule)
			{
                var module = (ModifierModule)m.Module;
                GameManager.Instance.player1.Modules.AddModule (module);
                module.Equip (GameManager.Instance.player1);
            }
        }
    }

    public void EquipRedSpaceshipModules ()
    {
        GameManager.Instance.player2.RemoveAllModules();

        var modules1 = GameObject.Find ("Canvas/Player mods 2/Body/WeaponModules").GetComponentsInChildren<ModuleSlot>();
        foreach (var m in modules1)
        {
            var module = m.Module as WeaponModule;
            GameManager.Instance.player2.Modules.AddModule (m.Module);
        }

        modules1 = GameObject.Find ("Canvas/Player mods 2/Body/DefenseModules").GetComponentsInChildren<ModuleSlot>();

        foreach (var m in modules1)
        {
            var module = m.Module as ModifierModule;
            GameManager.Instance.player2.Modules.AddModule (module);
            module.Equip (GameManager.Instance.player2);
        }
    }
}
