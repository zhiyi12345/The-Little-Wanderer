using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class PauseResume : MonoBehaviour
{
    public static bool isPaused;
 
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
 
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("Main player"));
        PlayerMovement.playerExists = false;
    }
}