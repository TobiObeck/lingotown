using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuCanvas;

    [SerializeField]
    private GameObject dialogueCanvas;


    void Start()
    {
        StateSingleton.State state = StateSingleton.GetState();
        if(state == StateSingleton.State.MainMenu){
            mainMenuCanvas.SetActive(true);
            dialogueCanvas.SetActive(false);
        }
    }

    public void StartGameHandler(){
        StateSingleton.SendEvent(StateSingleton.Event.StartGame);
    }

    void Update()
    {
        StateSingleton.State state = StateSingleton.GetState();
        if(state == StateSingleton.State.Playing){
            Debug.Log("CHANGE PLAYING CHANGE PLAYING CHANGE PLAYING");
            mainMenuCanvas.SetActive(false);
            dialogueCanvas.SetActive(true);
        }
    }
}
