using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextOnTrigger : MonoBehaviour
{
    public GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        Object.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
         print ("Trigger Entered");

        if (other.tag == "Player")
        {
            Object.SetActive(true);
            //StartCoroutine("WaitForSec");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
         print ("Trigger Exit");

        if (other.tag == "Player")
        {
            Object.SetActive(false);
            //StartCoroutine("WaitForSec");
        }
    }
}
