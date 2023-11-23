using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Inventory inventory;

    public GameObject tooth;
    public GameObject stone;
    public GameObject wood;
    public GameObject gem;
    int item;

    bool itemPickedUp = true;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void InitialiseItemDropped(int itemCode)
    {
        item = itemCode;

        tooth.SetActive(false);
        stone.SetActive(false);
        wood.SetActive(false);
        gem.SetActive(false);   

        switch (itemCode)
        {
            case 0:
                {
                    tooth.SetActive(true);
                    break;
                }
            case 1:
                {
                    stone.SetActive(true);
                    break;
                }
            case 2:
                {
                    wood.SetActive(true);
                    break;
                }
            case 3:
                {
                    gem.SetActive(true);
                    break;
                }
        }
    }

    void OnTriggerEnter()
    {
        if (itemPickedUp)
        {
            itemPickedUp = false;
            inventory.AddToInventory(item, 1);
            Destroy(gameObject);
        }
    }


    void Update()
    {

    }
        
    
}
