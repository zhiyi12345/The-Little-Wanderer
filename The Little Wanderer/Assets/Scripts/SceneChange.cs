using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public Animator transition;

    //public float delay = 1f;

    public int sceneBuildIndex;
    public string exitPoint;
    private PlayerMovement thePlayer;
    

    // when interacting with the door, moves the player to the next scene


    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            print("Switching Scene to" + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            thePlayer.startPoint = exitPoint;
        }
    }

    public void LeaveShop()
    {
        
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        thePlayer.startPoint = exitPoint;
        

    }

    





    // IEnumerator Change(int levelIndex) 
    // {
    //     transition.SetTrigger("Start");

    //     yield return new WaitForSeconds(delay);

    //     SceneManager.LoadScene(levelIndex);

    // }
    // public void LoadScene(string sceneName)
    // {

    //     SceneManager.LoadScene(sceneName);
    // }
}