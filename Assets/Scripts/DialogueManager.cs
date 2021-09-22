using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI npcNameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        InitializeSentenceQueue(dialogue);
        DisplayNextSentence();
    }

    private void InitializeSentenceQueue(Dialogue dialogue){        
        sentences.Clear();

        npcNameText.text = dialogue.npcName;

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
        // Debug.Log(nextSentence);
        dialogueText.text = nextSentence;
    }

    private void EndDialogue(){
        Debug.Log("end of convo");
    }
}
