using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int FlowersCount; 
    public int RunesCount;
    public TextMeshProUGUI FlowersTXT;
    public TextMeshProUGUI RunesTXT;
    public QuestManager questManager;  
    // Start is called before the first frame update
    void Start()
    {
       FlowersCount = 0;
       RunesCount = 0;
       questManager = FindObjectOfType<QuestManager>();
       FlowersTXT.text = FlowersCount.ToString();
       RunesTXT.text = RunesCount.ToString();
    }
    public void UpdateItems(string ItemName, int amount)
    {

        switch(ItemName)
        {
            case "Flower":
            FlowersCount += amount;
            questManager.collectables.Add(gameObject);
            FlowersTXT.text = FlowersCount.ToString();
            break;
            case "Rune":
            RunesCount += amount;
            RunesTXT.text = RunesCount.ToString();
            break;
        }
    }
}
