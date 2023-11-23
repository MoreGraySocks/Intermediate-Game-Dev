using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// This could probably be refined but I'm too lazy at this point
/// </summary>
public class Inventory : MonoBehaviour
{
    static public int numTooth;    //the number of (item) in the players inventory
    static public int numStone;
    static public int numWood;
    static public int numGem;
    static public int numCoin;

    public TMP_Text toothCounter;       //text object to display amount of (item) in inventory
    public TMP_Text stoneCounter;
    public TMP_Text woodCounter;
    public TMP_Text gemCounter;
    public TMP_Text coinCounter;

    void Start()
    {
        numTooth = 0; 
        numStone = 0;
        numWood = 0; 
        numGem = 0;
        numCoin = 0;
    }

    void Update()
    {
        toothCounter.text = ("x" + numTooth);
        stoneCounter.text = ("x" + numStone);
        woodCounter.text = ("x" + numWood);
        gemCounter.text = ("x" + numGem);
        coinCounter.text = ("x" + numCoin);
    }

    public void AddToInventory(int itemCode, int numOfItem)
    {
        switch (itemCode)
        {
            case 0:
                {
                    numTooth += numOfItem;
                    break;
                }
            case 1:
                {
                    numStone += numOfItem;
                    break;
                }
            case 2:
                {
                    numWood += numOfItem;
                    break;
                }
            case 3:
                {
                    numGem += numOfItem;
                    numStone += 2;  //breaking a boulder will also give 2 stone for now
                    break;
                }
            case 4:
                {
                    numCoin += numOfItem;
                    break;
                }
        }
    }

    public void SubtractFromInventory(int itemCode, int numOfItem)
    {
        switch (itemCode)
        {
            case 0:
                {
                    numTooth -= numOfItem;
                    break;
                }
            case 1:
                {
                    numStone -= numOfItem;
                    break;
                }
            case 2:
                {
                    numWood -= numOfItem;
                    break;
                }
            case 3:
                {
                    numGem -= numOfItem;
                    break;
                }
            case 4:
                {
                    numCoin -= numOfItem;
                    break;
                }
        }
    }
}
