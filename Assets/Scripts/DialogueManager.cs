using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI npcNameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        PlayOpenDialogueBoxAnimation();
        InitializeSentenceQueue(dialogue);
        DisplayNextSentence();
    }

    private void PlayOpenDialogueBoxAnimation(){
        animator.SetBool("IsOpen", true);
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
        StopAllCoroutines(); // stops Animation in case user triggers already next sentence
        StartCoroutine(TypeSentence(nextSentence));
    }

    IEnumerator TypeSentence(string nextSentence){
        dialogueText.text = "";
        foreach(char letter in nextSentence.ToCharArray()){
            dialogueText.text += letter;
            yield return null; // waiting a single frame
        }
    }

    private void EndDialogue(){
        Debug.Log("end of convo");
        animator.SetBool("IsOpen", false);
    }
}
