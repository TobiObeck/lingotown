using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public GameObject interactionPanelUI;
    private Collider otherInteractionObject;

    private bool isCurrentlyColliding = false;

    private CanvasManager canvasManager;

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
        canvasManager = FindObjectOfType<CanvasManager>();
        canvasManager.interactionPanelUI.SetActive(false);
    }

    private bool isDialogueStarted = false;

    private bool isInteractableHit = false;
    private RaycastHit interactableHit = new RaycastHit();

    public void Update()
    {
        CheckRayCastHitWithInteractable();

        if (IsAnyInteractionPossible())
        {
            SetActive();

            if (StateSingleton.GetState() == StateSingleton.State.Playing
                && isCurrentlyColliding == true
                && Input.GetKeyDown(KeyCode.E)
                && otherInteractionObject != null)
            {
                StartDialogue();
            }

            if (isInteractableHit == true && Input.GetKeyDown(KeyCode.E))
            {
                StartInteraction();
            }
        }
        else
        {
            SetInactive();
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

    private void StartDialogue()
    {
        isDialogueStarted = true;

        StateSingleton.SendEvent(StateSingleton.Event.StartTalking);

        isCurrentlyColliding = false;
        canvasManager.interactionPanelUI.SetActive(false);

        DialogueTrigger dialogueTrigger = otherInteractionObject.GetComponent<DialogueTrigger>();
        dialogueTrigger.TriggerDialogue();
    }

    private void StartInteraction()
    {
        AbstractAfterInteractionAction action = interactableHit.transform.GetComponent<AbstractAfterInteractionAction>();
        action.AfterInteractionAction();
    }

    // checks is raycast hit with gameobject tag "interactable" or 
    // or is colliding with trigger NPC
    private bool IsAnyInteractionPossible()
    {
        return isInteractableHit == true || otherInteractionObject != null;
    }

    private void CheckRayCastHitWithInteractable()
    {
        Transform direction = null;
        Transform player = transform.parent;
        foreach (Transform child in player)
        {
            if (child.CompareTag("MainCamera") == true)
            {
                direction = child.GetChild(0); // .name == "DirectionVectorForInteraction"
            }
        }

        // RaycastHit hit;
        Vector3 origin = direction.transform.position;
        Vector3 directionVec = direction.transform.forward;
        int maxDistance = 6;

        bool isHit = Physics.Raycast(origin, directionVec, out RaycastHit hit);        
        if (isHit)
        {            
            // Debug.Log(hit.transform.name);

            if (hit.transform.CompareTag("interactable") &&
                hit.distance <= maxDistance)
            {
                Debug.DrawRay(origin, directionVec, Color.green);
                isInteractableHit = true;
                interactableHit = hit;
            }
            else
            {
                Debug.DrawRay(origin, directionVec, Color.blue);
                isInteractableHit = false;
                interactableHit = new RaycastHit();
            }
        }
        else
        {
            Debug.DrawRay(origin, directionVec, Color.grey);
            isInteractableHit = false;
            interactableHit = new RaycastHit();
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
                isCurrentlyColliding = true;
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
                isCurrentlyColliding = false;
            }
        }
    }

    private void SetActive()
    {
        if (canvasManager.interactionPanelUI.activeSelf != true)
        {
            canvasManager.interactionPanelUI.SetActive(true);
        }
    }

    private void SetInactive()
    {
        canvasManager.interactionPanelUI.SetActive(false);
    }
}

