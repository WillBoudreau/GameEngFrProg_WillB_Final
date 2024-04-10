using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int FlowersCount; 
    public int CoinsCount;
    public string ItemName;
    public int amount;
    public TextMeshProUGUI FlowersTXT;
    void Start()
    {
       FlowersCount = 0;
       CoinsCount = 0;
        UpdateItems(ItemName,amount);
    }
    public void UpdateItems(string ItemName, int amount)
    {
        this.ItemName = ItemName;
        this.amount = amount;
        Debug.Log(ItemName);
        Debug.Log(amount);
        switch(ItemName)
        {
            case "Flower":
            Debug.Log(FlowersCount);
            Debug.Log("Flower Added");
            FlowersCount += amount;
            break;
        }
        UpdateItems(ItemName,amount);
    }
}
