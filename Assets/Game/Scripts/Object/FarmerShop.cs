using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FarmerShop : MonoBehaviour
{
    PlayerHealth playerHealth;
    Inventory inventory;

    public bool healthUpgrade1;
    public bool healthUpgrade2;
    public bool healthUpgrade3;

    private bool insideShopBounds;
    private bool initialiseUpgrade;

    public GameObject priceCanvas;

    public GameObject item1;
    public TMP_Text price1txt;
    private int price1;

    public GameObject item2;
    public TMP_Text price2txt;
    private int price2;

    public void OnTriggerEnter()
    {
        priceCanvas.SetActive(true);

        insideShopBounds = true;
    }

    public void OnTriggerExit()
    {
        priceCanvas.SetActive(false);

        insideShopBounds = false;
    }

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        priceCanvas.SetActive(false);
        item1.SetActive(true);
        item2.SetActive(false); 

        healthUpgrade1 = true;
        healthUpgrade2 = false;
        healthUpgrade3 = false;

        initialiseUpgrade = true;
        insideShopBounds = false;
    }

    void Update()
    {
        if (initialiseUpgrade)
        {
            if (healthUpgrade1)
            {
                price1 = 2;
                price2 = 0;
            }
            else if (healthUpgrade2)
            {
                item2.SetActive(true);
                price1 = 4;
                price2 = 30;
            }
            else if (healthUpgrade3)
            {
                price1 = 6;
                price2 = 80;
            }

            price1txt.text = ("x" + price1);
            price2txt.text = ("x" + price2);

        }

        if (insideShopBounds)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Inventory.numGem >= price1 && Inventory.numTooth >= price2)
                {
                    playerHealth.IncreaseHealth();
                    if (healthUpgrade1)
                    {
                        healthUpgrade1 = false;
                        healthUpgrade2 = true;
                        inventory.SubtractFromInventory(3, price1);
                        inventory.SubtractFromInventory(0, price2);
                    }
                    else if (healthUpgrade2)
                    {
                        healthUpgrade2 = false;
                        healthUpgrade3 = true;
                        inventory.SubtractFromInventory(3, price1);
                        inventory.SubtractFromInventory(0, price2);
                    }
                    else if (healthUpgrade3)
                    {
                        healthUpgrade3 = false;
                        item1.SetActive(false);
                        item2.SetActive(false);
                        inventory.SubtractFromInventory(3, price1);
                        inventory.SubtractFromInventory(0, price2);
                        Debug.Log("All Health Upgrades Bought");
                    }
                }
                else
                {
                    Debug.Log("Not enough items");
                }
            }
        }
    }
}
