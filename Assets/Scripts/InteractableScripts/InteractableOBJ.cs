using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractableOBJ : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI MessageText;
    [SerializeField] public string Message;
    [SerializeField] public string[] sentence;
    public GameObject[] gameObjects;
    public Dialogue dialogue;
    public InventoryManager Inventory;
    public float Delay = 5f;
    public enum Type
    {
        nothing,
        pickup,
        dialogue,
        info
    }
    public Type type;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = FindObjectOfType<Dialogue>();
        Inventory = FindObjectOfType<InventoryManager>();
        sentence = dialogue.sentences;
        Debug.Log(Inventory.FlowersCount);
        Debug.Log(dialogue.sentences);
        MessageText.text = null;
    }
    void Nothing()
    {

    }
    public void Pickup()
    {
        Debug.Log(gameObject.name);
        switch(gameObject.name)
        {
            case "Flower":
            Debug.Log(gameObject.name);
            Inventory.UpdateItems("Flower",1);
            Debug.Log(Inventory.FlowersCount);
            break;
        }
        MessageText.text = Message;
    }
    public void Dialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(sentence);
        Debug.Log("Started Dialogue");
    }
    public void Info()
    {
        Debug.Log(Message);
        StartCoroutine(InfoDisplay(5f,Message));
    }
    IEnumerator InfoDisplay(float Delay, string messageText)
    {
        MessageText.text = Message;
        yield return new WaitForSeconds(Delay);
        MessageText.text = null;
    }
}
