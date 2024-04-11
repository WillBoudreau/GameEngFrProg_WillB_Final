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
    public enum PickupType
    {
        None,
        Flower,
        Rune
    }
    public PickupType pickupType;
    public Type type;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
        dialogue = FindObjectOfType<Dialogue>();
        Inventory = FindObjectOfType<InventoryManager>();
        sentence = dialogue.sentences;
        MessageText.text = null;
    }
    void Nothing()
    {

    }
    public void Pickup()
    {
        Debug.Log(gameObject.name);
        if(pickupType == PickupType.Flower)
        {
            Debug.Log(gameObject.name + "Picked up");
            FindObjectOfType<InventoryManager>().UpdateItems("Flower",1);
        }
        Debug.Log(gameObject.name);
        // if(gameObject.name == "Flower")
        // {
        //     Debug.Log(gameObject.name + "Picked up");
        //     FindObjectOfType<InventoryManager>().UpdateItems("Flower",1);
        //     Debug.Log("Count: " + Inventory.FlowersCount);
        // }
        // else if(gameObject.name == "Rune")
        // {
        //     Inventory.UpdateItems("Rune",1);
        //     Debug.Log("Count: " + Inventory.RunesCount);
        // }
        
        // Debug.Log(gameObject.name);
        gameObject.SetActive(false);
        // MessageText.text = Message;
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
