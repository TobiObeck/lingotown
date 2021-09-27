using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public GameObject interactionPanelUI;
    private Collider otherInteractionObject;

    private bool isInteractionPossible = false;

    private void Start()
    {
        interactionPanelUI.SetActive(false);
    }

    public void Update()
    {
        if (StateSingleton.GetState() == StateSingleton.State.Playing
            && isInteractionPossible == true
            && Input.GetKeyDown(KeyCode.E)
            && otherInteractionObject != null)
        {
            StateSingleton.SendEvent(StateSingleton.Event.StartTalking);

            isInteractionPossible = false;
            interactionPanelUI.SetActive(false);

            DialogueTrigger dialogueTrigger = otherInteractionObject.GetComponent<DialogueTrigger>();
            dialogueTrigger.TriggerDialogue();
        }
    }


    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("NPC")) // more performant than other.gameObject.tag == "NPC"
        {
            if (StateSingleton.GetState() == StateSingleton.State.Playing)
            {
                otherInteractionObject = other;
                isInteractionPossible = true;
                if (interactionPanelUI.activeSelf != true)
                {
                    interactionPanelUI.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC")) // more performant than other.gameObject.tag == "NPC"
        {
            if (StateSingleton.GetState() == StateSingleton.State.Playing)
            {
                otherInteractionObject = null;
                isInteractionPossible = false;
                interactionPanelUI.SetActive(false);
            }
        }
    }
}
