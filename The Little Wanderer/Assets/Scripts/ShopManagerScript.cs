using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public ShopItemSO[] shopItemSO; 
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    public GameObject[] item;


    void Start() 
    {
        LoadPanels();
        CheckPurchasable();
        //ResetItemBought();
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemSO.Length; i++) 
        {
            shopPanels[i].ItemTxt.text = shopItemSO[i].Description;
            shopPanels[i].CostTxt.text = "Price: $" + shopItemSO[i].Price.ToString();

            if (shopItemSO[i].IsBoughtSO)
            {
                shopPanels[i].BuyBtn.SetActive(false);
                shopPanels[i].EquippedBtn.SetActive(true);
                item[i].SetActive(true);
            }

            else
            {
                shopPanels[i].BuyBtn.SetActive(true);
                shopPanels[i].EquippedBtn.SetActive(false);
            }
        }
    }

    public void CheckPurchasable()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (CoinsManager.coins >= shopItemSO[i].Price) //enough money
            {
                myPurchaseBtns[i].interactable = true;
            } 
            else
            {
                myPurchaseBtns[i].interactable = false;
            } 

        }
    }

    public void PurchaseItem(int btnNo)
    { 
        if (CoinsManager.coins >= shopItemSO[btnNo].Price)
        {
            CoinsManager.coins = CoinsManager.coins - shopItemSO[btnNo].Price;
            CoinsManager.UpdateCoins();
            CheckPurchasable();
            UpdateItem(btnNo);
        }
    }

    public void UpdateItem(int btnNo)
    {   
        shopItemSO[btnNo].IsBoughtSO = true;
        item[btnNo].SetActive(true);
        shopPanels[btnNo].BuyBtn.SetActive(false);
        shopPanels[btnNo].EquippedBtn.SetActive(true);
    }
} 
    
