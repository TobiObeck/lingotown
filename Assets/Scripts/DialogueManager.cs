using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        Debug.Log("Starting conversation" + dialogue.npcName);        

        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string nextSentence = sentences.Dequeue();
        Debug.Log(nextSentence);
    }

    private void EndDialogue(){
        Debug.Log("end of convo");
    }
}
