using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeName : MonoBehaviour
{

    public GameObject inputField;
    public string theName;
    public GameObject textDisplay1;


    

    public void changeName()
    {
        
        theName = inputField.GetComponent<TMPro.TextMeshProUGUI>().text;
        
        PlayerPrefs.SetString("playerName", theName);
        
        textDisplay1.GetComponent<TMPro.TextMeshProUGUI>().text = "Do you wish to change your name to " + theName;
        
    }
}
