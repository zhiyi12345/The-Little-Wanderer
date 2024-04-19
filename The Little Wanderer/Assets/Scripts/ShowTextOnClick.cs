using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ShowTextOnClick : MonoBehaviour
{
    public GameObject Object;
    public int DisplayTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        Object.SetActive(false);
    }

    // Update is called once per frame
   public void OnClick()
    {
        Object.SetActive(true);
        StartCoroutine("Wait");
    }

    IEnumerator Wait() 
    {
        yield return new WaitForSeconds(DisplayTime);
        Object.SetActive(false);
    }

    
}
