using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public enum QuestTracker
    {
        Started,
        Halfway,
        Ended
    }
    public QuestTracker tracker;
    public List<GameObject> states;
    public List<GameObject> collectables;
    // Start is called before the first frame update
    void Start()
    {
        states = new List<GameObject>();
        tracker = QuestTracker.Started;
    }

    // Update is called once per frame
    void Update()
    {
        switch (tracker)
        {
            case QuestTracker.Started: 
                break; 
            case QuestTracker.Halfway:
                if (collectables.Count >= 5)
                {
                    tracker = QuestTracker.Ended;
                }
                break; 
            case QuestTracker.Ended:
                break;
        }
    }
}
