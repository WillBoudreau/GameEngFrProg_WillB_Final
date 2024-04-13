using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;
    public List<GameObject> collectables;
    public List<GameObject> FinishItems;
    bool dialogueEnd;
    public int FinalCount;
    // Start is called before the first frame update

    void Start()
    {
        FinalCount = 0;
        quests = new List<Quest>();
        quests.AddRange(FindObjectsOfType<Quest>());
        foreach(Quest quest in quests)
        {
            quest.UpdateQuest();
        }

    }
    // public enum QuestTracker
    // {
    //     Started,
    //     Halfway,
    //     Ended
    // }
    // public QuestTracker tracker;
    // public List<GameObject> states;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     tracker = QuestTracker.Started;
    //     UpdateStates();
    // }

    // // Update is called once per frame
    // void Update()
    // {

    //     switch (tracker)
    //     {
    //         case QuestTracker.Started: 
    //         if(collectables.Count > 1)
    //         {
    //             Debug.Log("Collectables collected");
    //             tracker = QuestTracker.Halfway;
    //             UpdateStates();
    //         }
    //             break; 
    //         case QuestTracker.Halfway:
    //             if (collectables.Count >= 5)
    //             {
    //                 tracker = QuestTracker.Ended;
    //                 UpdateStates();
    //             }
    //             break; 
    //         case QuestTracker.Ended:
    //             break;
    //     }
    // }
   
    // }
}
