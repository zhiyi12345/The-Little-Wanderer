using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayerPrefs : MonoBehaviour
{
   public ShopItemSO[] shopItemSO;

    public void deleleAll()
    {
        PlayerPrefs.DeleteAll();
        Destroy(GameObject.Find("Main player"));
        PlayerMovement.playerExists = false;

        for (int i = 0; i < shopItemSO.Length; i ++)
        {
            shopItemSO[i].IsBoughtSO = false;
        }

    }

}
