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
        tracker = QuestTracker.Started;
        UpdateStates();
    }

    // Update is called once per frame
    void Update()
    {
        switch (tracker)
        {
            case QuestTracker.Started: 
            if(collectables.Count > 1)
            {
                Debug.Log("Collectables collected");
                tracker = QuestTracker.Halfway;
                UpdateStates();
            }
                break; 
            case QuestTracker.Halfway:
                if (collectables.Count >= 5)
                {
                    tracker = QuestTracker.Ended;
                    UpdateStates();
                }
                break; 
            case QuestTracker.Ended:
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
