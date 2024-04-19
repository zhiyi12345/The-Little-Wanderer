using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI CountDown;

    public GameObject CountdownUI;
    public GameObject GameUI;

    void Start()
    {
        StartCoroutine(Countdown(3));
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {

            // display something...
            yield return new WaitForSeconds(1);
            count--;
            CountDown.text = count.ToString();
        }

        // count down is finished...
        CountdownUI.SetActive(false);
        GameUI.SetActive(true);
    }

}