using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuCanvas;

    [SerializeField]
    private GameObject dialogueCanvas;

    void Awake(){
        StateSingleton.OnStateEvent += HandleStateEvent;
    }

    void OnDestroy(){
        StateSingleton.OnStateEvent -= HandleStateEvent;
    }

    void Start()
    {
        StateSingleton.State state = StateSingleton.GetState();
        if(state == StateSingleton.State.MainMenu){

        }
    }

    public void StartGameHandler(){
        StateSingleton.SendEvent(StateSingleton.Event.StartGame);
    }

    public void QuitGameHandler(){
        Application.Quit();
    }

    private void HandleStateEvent(StateSingleton.State state){
        if(state == StateSingleton.State.MainMenu){
            mainMenuCanvas.SetActive(true);
            dialogueCanvas.SetActive(false);
        }
        if(state == StateSingleton.State.Playing){
            mainMenuCanvas.SetActive(false);
            dialogueCanvas.SetActive(true);
        }
    }
}
