using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void AfterDialogueAction()
    {
        Debug.Log("THIS FUNCTION IS CALLED AFTER THE DIALOGUE IS OVER");

        AbstractAfterInteractionAction postAction = GetComponent<AbstractAfterInteractionAction>();
        if (postAction != null)
        {
            postAction.AfterInteractionAction();
        }
    }
}
