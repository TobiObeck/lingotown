using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private const int INFINITE = -1;
    // private const int NEVER = 0;
    private const int ONCE = 1;
    // private const int TWICE = 2;
    public int howOftenAfterDialogueAction = 1;

    private int afterDialogueActionCount = 0;


    public void TriggerDialogue()
    {
        // TODO make dialoguemanager a singleton
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void AfterDialogueAction()
    {
        Debug.Log("THIS FUNCTION IS CALLED AFTER THE DIALOGUE IS OVER");

        if (afterDialogueActionCount < howOftenAfterDialogueAction
            || howOftenAfterDialogueAction == -1)
        {
            AbstractPostDialogueAction postAction = GetComponent<AbstractPostDialogueAction>();
            if (postAction != null)
            {
                afterDialogueActionCount++;
                postAction.AfterDialogueAction();
            }
        }
    }
}
