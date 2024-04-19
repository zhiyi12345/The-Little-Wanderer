using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginBefore : MonoBehaviour
{
    
    public string InGameScene;
    public GameObject enterNameUI;
    public GameObject MainMenuUI;

    public string theName;
    public GameObject inputField;
    public GameObject textDisplay1;
    public GameObject textDisplay2;
    public Button changeName;


    public void Start()
    {
        changeName.interactable = false;

        
        if (PlayerPrefs.GetInt("counter", 0) > 0)
        {
            PlayerPrefs.SetString("playerAdventure", PlayerPrefs.GetString("playerName", "") + "'s Adventure");
            changeName.interactable = true;


        }

        textDisplay2.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString("playerAdventure", "");
        

    }


    public void StoreName()
    {
        theName = inputField.GetComponent<TMPro.TextMeshProUGUI>().text;
        PlayerPrefs.SetString("playerName", theName);
        textDisplay1.GetComponent<TMPro.TextMeshProUGUI>().text = "Welcome " + theName;


    }


    public void PlayGame()
    {
        if (PlayerPrefs.GetInt("counter", 0) > 0)
        {
            StartCoroutine(DelaySceneLoad());
        }
        else
        {
            PlayerPrefs.SetInt("counter", PlayerPrefs.GetInt("counter", 0) + 1);
            MainMenuUI.SetActive(false);
            enterNameUI.SetActive(true);

        }

        
        




    }



    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(0.5f); // Wait 3 seconds
        SceneManager.LoadScene("InsideHouse");
        

    }









}
