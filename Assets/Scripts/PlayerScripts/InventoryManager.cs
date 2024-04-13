using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int FlowersCount; 
    public int RunesCount;
    public int MedicineCount;
    public int CoinCount;
    public int SwordCount;
    public TextMeshProUGUI CoinsTXT;
    public TextMeshProUGUI FlowersTXT;
    public TextMeshProUGUI RunesTXT;
    public TextMeshProUGUI MedicineTXT;
    public TextMeshProUGUI SwordTXT;
    public QuestManager questManager;  
    // Start is called before the first frame update
    void Start()
    {
       FlowersCount = 0;
       RunesCount = 0;
       MedicineCount = 0;
       CoinCount = 0;
       SwordCount = 0;

       questManager = FindObjectOfType<QuestManager>();
       FlowersTXT.text = FlowersCount.ToString();
       RunesTXT.text = RunesCount.ToString();
       MedicineTXT.text = MedicineCount.ToString();
       CoinsTXT.text = CoinCount.ToString();
       SwordTXT.text = SwordCount.ToString();
    }
    public void UpdateItems(string ItemName, int amount)
    {

        switch(ItemName)
        {
            case "Flower":
            FlowersCount += amount;
            FlowersTXT.text = FlowersCount.ToString();
            break;
            case "Rune":
            RunesCount += amount;
            RunesTXT.text = RunesCount.ToString();
            break;
            case "Medicine":
            MedicineCount += amount;
            MedicineTXT.text = MedicineCount.ToString();
            break;
            case "Coin":
            CoinCount += amount;
            CoinsTXT.text = CoinCount.ToString();
            break;
            case "Sword":
            SwordCount += amount;
            SwordTXT.text = SwordCount.ToString();
            break;
        }
    }
}
