using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public enum QuestType
    {
        CollectFlower,
        CollectRune,
        CollectMedicine
    }
    public enum QuestTracker
    {
        Started,
        Halfway,
        Ended
    }
    public QuestTracker tracker;
    public QuestType type;
    public InventoryManager inventory;
    public List<GameObject> collectables;
    public List<GameObject> states;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
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
                }
                break;
            case QuestType.CollectMedicine:
                if (inventory.MedicineCount == 1)
                {
                    tracker = QuestTracker.Halfway;
                }
                if (inventory.MedicineCount >= 2)
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
