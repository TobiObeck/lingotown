using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StateSingleton : MonoBehaviour
{
    public static event Action<State> OnStateEvent;

    private static StateSingleton _instance;
    private static State state = State.Initial;

    public static StateSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StateSingleton>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<StateSingleton>();
                }
            }
            return _instance;
        }
    }

    // ensure only one singleton exists in the scene
    private void Awake()
    {
        if(_instance != null){
            Destroy(this);
        }
        DontDestroyOnLoad(this); // dont destroy when changing scenes
    }

    private void Start(){
        SendEvent(StateSingleton.Event.EnterMainMenu);
    }

    public static State GetState()
    {
        return state;
    }


    public static void SendEvent(Event event_) // event is a C# keyword therefore event_
    {

        switch (state)
        {
            case State.Initial:
                if (event_ == Event.EnterMainMenu){
                    state = State.MainMenu;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            case State.MainMenu:
                if (event_ == Event.StartGame)
                {
                    state = State.Playing;
                    
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    LoadFirstLevel();
                }
                break;
            case State.Playing:
                if (event_ == Event.StartTalking)
                {
                    state = State.Talking;

                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                if (event_ == Event.TogglePause)
                {
                    state = State.Pause;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            case State.Talking:
                if (event_ == Event.EndTalking)
                {
                    state = State.Playing;

                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            case State.Pause:
                if (event_ == Event.TogglePause)
                {
                    state = State.Playing;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                if (event_ == Event.EnterMainMenu)
                {
                    state = State.MainMenu;
                    // LoadMainMenu();
                }
                break;
        }

        Debug.Log("State: " + state);

        OnStateEvent?.Invoke(state);
    }

    private static void LoadFirstLevel()
    {
        // SceneManager.LoadScene("SampleScene");
    }

    public enum Event
    {
        StartGame,
        EnterMainMenu,
        TogglePause,
        StartTalking,
        EndTalking
    }

    public enum State
    {
        Initial,
        MainMenu,
        Playing,
        Talking,
        Pause
    }
}
