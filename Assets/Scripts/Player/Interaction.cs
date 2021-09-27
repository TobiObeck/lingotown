using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public GameObject interactionPanelUI;
    private Collider otherInteractionObject;

    private bool isInteractionPossible = false;

    void Awake()
    {
        StateSingleton.OnStateEvent += HandleStateEvent;
    }

    void OnDestroy()
    {
        StateSingleton.OnStateEvent -= HandleStateEvent;
    }

    private void Start()
    {
        interactionPanelUI.SetActive(false);
    }

    private bool isDialogueStarted = false;

    public void Update()
    {
        if (StateSingleton.GetState() == StateSingleton.State.Playing
            && isInteractionPossible == true
            && Input.GetKeyDown(KeyCode.E)
            && otherInteractionObject != null)
        {
            isDialogueStarted = true;

            StateSingleton.SendEvent(StateSingleton.Event.StartTalking);

            isInteractionPossible = false;
            interactionPanelUI.SetActive(false);

            DialogueTrigger dialogueTrigger = otherInteractionObject.GetComponent<DialogueTrigger>();
            dialogueTrigger.TriggerDialogue();
        }

    }

    // eventuall perform an action after the dialogue ends
    private void HandleStateEvent(StateSingleton.State state)
    {
        // TODO this is a bit of an messy implementation. It is not 
        // It is not necessarily the dialoogue state we are coming from.
        // Could be pausing while player interaction collides with NPC then unpausing...
        if (isDialogueStarted == true && state == StateSingleton.State.Playing)
        {
            DialogueTrigger dialogueTrigger = otherInteractionObject.GetComponent<DialogueTrigger>();
            dialogueTrigger.AfterDialogueAction();
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
