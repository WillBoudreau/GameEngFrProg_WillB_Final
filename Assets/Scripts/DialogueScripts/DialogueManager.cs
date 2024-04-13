using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject DialoguePanel;
    public Dialogue dialogue;
    public GameObject player;
    public Quest quest;
    public QuestManager questManager;  
    
    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        quest = FindObjectOfType<Quest>();
        sentences = new Queue<string>();
        DialoguePanel.SetActive(false);
    }
    public void StartDialogue(string[] dialogueSentence)
    {
        sentences.Clear();
        Debug.Log("Started Dialogue");
        DialoguePanel.SetActive(true);

        player.GetComponent<ChardterController2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        foreach(string sentence in dialogueSentence)
        {
                Debug.Log(sentence);
                sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        nameText.text = dialogue.name;
        Debug.Log(dialogue.name);
    }
    public void EndDialogue()
    {
        sentences.Clear();
        DialoguePanel.SetActive(false);
        player.GetComponent<ChardterController2D>().enabled = true;
    }
}

