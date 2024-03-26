using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject interact = null;
    public InteractableOBJ Interactable = null;
    public TextMeshProUGUI nameText;
    [SerializeField] public GameObject InteractSymbol;
    // Start is called before the first frame update
    void Start()
    {
        InteractSymbol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interact == true)
        {
            Debug.Log("E pressed");
            if (Interactable.type == InteractableOBJ.Type.pickup)
            {
                Interactable.Pickup();
            }
            else if (Interactable.type == InteractableOBJ.Type.info)
            {
                Interactable.Info();
            }
            else if(Interactable.type == InteractableOBJ.Type.dialogue)
            {
                Interactable.Dialogue();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Interactable"))
        {
            InteractSymbol.SetActive(true);
            interact = other.gameObject;
            Interactable = other.GetComponent<InteractableOBJ>();
        }
        else if(other.gameObject.CompareTag("Info"))
        {
            InteractSymbol.SetActive(true);
            interact = other.gameObject;
            Interactable = other.GetComponent<InteractableOBJ>();
        }
        else if(other.gameObject.CompareTag("Dialogue"))
        {
            InteractSymbol.SetActive(true);
            interact = other.gameObject;
            Interactable = other.GetComponent<InteractableOBJ>();
            nameText.text = gameObject.name;
            Debug.Log(nameText.text);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        InteractSymbol.SetActive(false);
        if(other.gameObject.CompareTag("Interactable"))
        {
            interact = null;
            Interactable = null;
        }
    }
    void ExecuteInteractable()
    {

    }
}
