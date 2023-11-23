using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlacksmithShop : MonoBehaviour
{
    Inventory inventory;

    public bool bowUpgrade1;
    public bool bowUpgrade2;
    public bool bowUpgrade3;

    private bool insideShopBounds;
    private bool initialiseUpgrade;

    public GameObject priceCanvas;

    public GameObject item1;
    public TMP_Text price1txt;
    int price1;

    public GameObject item2;
    public TMP_Text price2txt;
    int price2;

    public GameObject item3;
    public TMP_Text price3txt;
    int price3;

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
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        Arrow.damage = 1;

        priceCanvas.SetActive(false);
        item1.SetActive(true);
        item2.SetActive(true);
        item3.SetActive(false);

        bowUpgrade1 = true;
        bowUpgrade2 = false;
        bowUpgrade3 = false;

        initialiseUpgrade = true;
        insideShopBounds = false;
    }

    void Update()
    {
        if (initialiseUpgrade)
        {
            if (bowUpgrade1)
            {
                price1 = 15;
                price2 = 5;
            }
            else if (bowUpgrade2)
            {
                item3.SetActive(true);
                price1 = 30;
                price2 = 20;
                price3 = 10;
            }
            else if (bowUpgrade3)
            {
                price1 = 50;
                price2 = 40;
                price3 = 20;
            }

            price1txt.text = ("x" + price1);
            price2txt.text = ("x" + price2);
            price3txt.text = ("x" + price3);

        }

        if (insideShopBounds)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Inventory.numWood >= price1 && Inventory.numStone >= price2 && Inventory.numTooth >= price3)
                {
                    if (bowUpgrade1)
                    {
                        bowUpgrade1 = false;
                        bowUpgrade2 = true;
                        Arrow.damage = 2;
                        inventory.SubtractFromInventory(2, price1);
                        inventory.SubtractFromInventory(1, price2);
                        inventory.SubtractFromInventory(0, price3);

                    }
                    else if (bowUpgrade2)
                    {
                        bowUpgrade2 = false;
                        bowUpgrade3 = true;
                        Arrow.damage = 4;
                        inventory.SubtractFromInventory(2, price1);
                        inventory.SubtractFromInventory(1, price2);
                        inventory.SubtractFromInventory(0, price3);
                    }
                    else if (bowUpgrade3)
                    {
                        bowUpgrade3 = false;
                        Arrow.damage = 8;
                        item1.SetActive(false);
                        item2.SetActive(false);
                        item3.SetActive(false);
                        inventory.SubtractFromInventory(2, price1);
                        inventory.SubtractFromInventory(1, price2);
                        inventory.SubtractFromInventory(0, price3);
                        Debug.Log("All Bow Upgrades Bought");
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
