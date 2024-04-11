using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public enum QuestTracker
    {
        Started,
        Halfway,
        Ended
    }
    public enum QuestType
    {
        CollectFlower,
        CollectRune,

    }
    public QuestTracker tracker;
    public QuestType type;
    public InventoryManager inventory;
    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
        tracker = QuestTracker.Started;
    }
    void UpdateQuest()
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
        }
    }
}
