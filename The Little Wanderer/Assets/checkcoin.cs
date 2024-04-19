using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkcoin : MonoBehaviour
{
    private int coins;

   public void press() 
   {
    coins = CoinsManager.coins;
    print(coins);
   }
}
