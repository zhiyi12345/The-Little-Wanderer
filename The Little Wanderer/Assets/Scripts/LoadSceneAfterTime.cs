using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterTime : MonoBehaviour
{
	public string sceneName;
	public float time;

	public void ButtonFunction()
	{
		StartCoroutine(DelaySceneLoad());
	}

	IEnumerator DelaySceneLoad()
	{
		yield return new WaitForSeconds(time); // Wait 3 seconds
		SceneManager.LoadScene(sceneName); // Change to the ID or Name of the scene to load
	}

	public void QuitGame()
    {
		Application.Quit();
    }
}