using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI npcNameText;
    public TextMeshProUGUI dialogueTextForeign;
    public TextMeshProUGUI dialogueTextNative;

    public Animator animator;

    private Queue<string> sentencesForeign;
    private Queue<string> sentencesNative;

    private IEnumerator foreignCoroutine;
    private IEnumerator nativeCoroutine;

    private void Start()
    {
        sentencesForeign = new Queue<string>();
        sentencesNative = new Queue<string>();
    }

    private void Update()
    {

        if (StateSingleton.GetState() == StateSingleton.State.Talking)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.D))
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {

        PlayOpenDialogueBoxAnimation();
        DisplayNpcName(dialogue);
        InitializeSentenceQueues(dialogue);

        DisplayNextSentence();
    }

    private void PlayOpenDialogueBoxAnimation()
    {
        animator.SetBool("IsOpen", true);
    }

    private void DisplayNpcName(Dialogue dialogue)
    {
        npcNameText.text = dialogue.npcName;
    }

    private void InitializeSentenceQueues(Dialogue dialogue)
    {
        sentencesForeign.Clear();
        sentencesNative.Clear();

        foreach (string sentenceForeign in dialogue.sentencesForeign)
        {
            sentencesForeign.Enqueue(sentenceForeign);
        }
        foreach (string sentenceNative in dialogue.sentencesNative)
        {
            sentencesNative.Enqueue(sentenceNative);
        }

        if (sentencesForeign.Count != sentencesNative.Count)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif            
            string errorMsg = "" +
            "The number of sentences between native" +
            " and foreign is different in NPC: " + dialogue.npcName;
            throw new Exception(errorMsg);

            // TODO create error panel, to catch errors in built version
            // and append them to the panel for debugging info while playing
        }
    }

    public void DisplayNextSentence()
    {
        if (sentencesForeign.Count == 0)
        {
            EndDialogue();
            return;
        }

        string nextSentenceForeign = sentencesForeign.Dequeue();
        string nextSentenceNative = sentencesNative.Dequeue();

        // stops Animation in case user triggers already next sentence
        // these have to be member variables to ensure the same coroutine is stopped
        // or use StopAllCoroutines();

        if(foreignCoroutine != null) StopCoroutine(foreignCoroutine);
        if(nativeCoroutine != null) StopCoroutine(nativeCoroutine);

        foreignCoroutine = TypeSentenceForeign(nextSentenceForeign);
        nativeCoroutine = TypeSentenceNative(nextSentenceNative);

        StartCoroutine(foreignCoroutine);
        StartCoroutine(nativeCoroutine);        
    }

    IEnumerator TypeSentenceForeign(string nextSentence)
    {
        dialogueTextForeign.text = "";
        foreach (char letter in nextSentence.ToCharArray())
        {
            dialogueTextForeign.text += letter;
            yield return new WaitForSeconds(.01f);
        }
        yield return null; // waiting a single frame
    }

    IEnumerator TypeSentenceNative(string nextSentence)
    {
        dialogueTextNative.text = "";
        foreach (char letter in nextSentence.ToCharArray())
        {
            dialogueTextNative.text += letter;
            yield return new WaitForSeconds(.01f);
        }
        yield return null; // waiting a single frame
    }

    private void EndDialogue()
    {
        Debug.Log("end of convo");
        animator.SetBool("IsOpen", false);
        StateSingleton.SendEvent(StateSingleton.Event.EndTalking);
    }
}
