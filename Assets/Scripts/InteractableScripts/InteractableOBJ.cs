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
        MessageText.text = null;
    }
    void Nothing()
    {

    }
    public void Pickup()
    {
        Debug.Log("You picked up..." + gameObject.name);
        this.gameObject.SetActive(false);
        if(gameObject.name == "Coin")
        {
            Debug.Log("Hello!");
        }
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
