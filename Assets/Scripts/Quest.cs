using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public enum QuestType
    {
        CollectFlower,
        CollectRune,
        CollectMedicine,
        CollectCoin,
        ColledctSword,
        FinalQuest
    }
    public enum QuestTracker
    {
        Started,
        Halfway,
        Ended
    }
    public QuestTracker tracker;
    public QuestType type;
    public QuestManager questManager;
    public InventoryManager inventory;
    public List<GameObject> collectables;
    public List<GameObject> states;
    public GameObject Scenetrans;
    public GameObject Medicine;
    
    // Start is called before the first frame update
    public void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        inventory = FindObjectOfType<InventoryManager>();
        Scenetrans.SetActive(false);
    }
    public void Update()
    {
        UpdateQuest();
        UpdateStates();
    }
    public void UpdateQuest()
    {
        switch (type)
        {
            case QuestType.CollectFlower:
                if (inventory.FlowersCount >= 1)
                {
                    tracker = QuestTracker.Halfway;
                }
                if (inventory.FlowersCount >= 5)
                {
                    tracker = QuestTracker.Ended;
                }
                break;
            case QuestType.CollectRune:
                if (inventory.RunesCount >= 1)
                {
                    tracker = QuestTracker.Halfway;
                }
                if (inventory.RunesCount >= 5)
                {
                    tracker = QuestTracker.Ended;
                    questManager.FinalCount  = 5;
                }
                break;
            case QuestType.CollectMedicine:
                if (inventory.MedicineCount > 1)
                {
                    tracker = QuestTracker.Halfway;
                }
                if (inventory.MedicineCount  == 1)
                {
                    tracker = QuestTracker.Ended;
                    Scenetrans.SetActive(true);
                }
                break;
            case QuestType.CollectCoin:
                if (inventory.CoinCount >= 1)
                {
                    tracker = QuestTracker.Halfway;
                }
                if (inventory.CoinCount >= 5)
                {
                    tracker = QuestTracker.Ended;
                }
                break;
            case QuestType.ColledctSword:
                if (inventory.SwordCount< 1)
                {
                    tracker = QuestTracker.Halfway;
                }
                if (inventory.SwordCount == 1)
                {
                    tracker = QuestTracker.Ended;
                    Scenetrans.SetActive(true);
                }
                break;
            case QuestType.FinalQuest:
             if(questManager.FinalCount > 1)
             {
                tracker = QuestTracker.Halfway;
             }
             if(questManager.FinalCount >= 5)
             {
                tracker = QuestTracker.Ended;
             }
                break;

        }
    }
    void UpdateStates()
    {
        foreach(GameObject state in states)
        {
            state.SetActive(false);
        }
        switch(tracker)
        {
            case QuestTracker.Started:
                states[0].SetActive(true);
                break;
            case QuestTracker.Halfway:
                states[1].SetActive(true);
                break;
            case QuestTracker.Ended:
                states[2].SetActive(true);
                break;
        }
    }
}
