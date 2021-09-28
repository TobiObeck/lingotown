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
        tempDialogue.sentencesNative = dialogueSO.sentencesNative;
        tempDialogue.sentencesForeign = dialogueSO.sentencesForeign;
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
