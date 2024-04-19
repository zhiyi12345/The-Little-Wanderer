using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scriptable Objects/New Shop Item", order = 1)]
public class ShopItemSO :  ScriptableObject
{
   public string Description;
   public int Price;
   public bool IsBoughtSO;
}

