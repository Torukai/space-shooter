using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void PlayGame()
	{
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}

	public void ModulesMenu()
	{
		SceneManager.LoadScene(2, LoadSceneMode.Single);
	}
}
