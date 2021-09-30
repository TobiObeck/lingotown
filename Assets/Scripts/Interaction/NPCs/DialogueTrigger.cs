using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueSO dialogueSO;

    public void TriggerDialogue()
    {
        Dialogue tempDialogue = new Dialogue();
        tempDialogue.npcName = dialogueSO.npcName;

        // languages are switched, because I intended german players
        // as the main audience initially
        // TODO also dialogueSO.something should be renamed to the particular language
        // and then have a mechanism to select a languages dynamically
        tempDialogue.sentencesNative = dialogueSO.sentencesForeign;
        tempDialogue.sentencesForeign = dialogueSO.sentencesNative;
        // TODO remove Dialogue class here and in dialoguemanager.
        // Is not needed anymore. Was replaced by scriptable object
        FindObjectOfType<DialogueManager>().StartDialogue(tempDialogue);
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
