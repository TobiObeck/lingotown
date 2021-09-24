using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public GameObject interactionPanelUI;
    private Collider otherInteractionObject;
    
    private void Start()
    {
        interactionPanelUI.SetActive(false);
    }

    public void Update(){
        if (interactionPanelUI.activeSelf == true && Input.GetKeyDown(KeyCode.E)){            
            if(otherInteractionObject != null){
                DialogueTrigger dialogueTrigger = otherInteractionObject.GetComponent<DialogueTrigger>();                
                dialogueTrigger.TriggerDialogue();
            }            
        }
    }


    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerStay(Collider other)
    {

        if(other.CompareTag("NPC")) // more performant than other.gameObject.tag == "NPC"
        {
            otherInteractionObject = other;
            interactionPanelUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other){
        
        if(other.CompareTag("NPC")) // more performant than other.gameObject.tag == "NPC"
        {
            otherInteractionObject = null;
            interactionPanelUI.SetActive(false);
        }
    }

}
