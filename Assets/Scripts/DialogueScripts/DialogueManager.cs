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

    public ChardterController2D playerController;
    public Quest quest;
    public QuestManager questManager;  
    
    public Queue<string> sentences;

    public bool dialogueActive = false;

    // Start is called before the first frame update
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        quest = FindObjectOfType<Quest>();
        sentences = new Queue<string>();
        DialoguePanel.SetActive(false);
        player.GetComponent<ChardterController2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    public void StartDialogue(string[] dialogueSentence)
    {
        dialogueActive = true;
        sentences.Clear();
        Debug.Log("Started Dialogue");
        DialoguePanel.SetActive(true);


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
        dialogueActive = false;
        //player.GetComponent<ChardterController2D>().enabled = true;
    }
}

