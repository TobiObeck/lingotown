using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    
    public void TriggerDialogue(){
        // TODO make dialoguemanager a singleton
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}