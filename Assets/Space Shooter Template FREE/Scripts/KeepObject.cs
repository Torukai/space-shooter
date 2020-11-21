using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObject : MonoBehaviour
{

	public static KeepObject instance;
	// Start is called before the first frame update
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			// If the instance reference has already been set, and this is not the
			// the instance reference, destroy this game object.
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		
	}

	private void OnLevelWasLoaded(int level)
	{
		if (level == 0)
		{

			//Debug.Log("Modules count : " + PlayerSettings.modules.moduleList.Count);
		}
	}
}
