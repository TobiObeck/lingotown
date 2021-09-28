using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerEnterLoadNextScene : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.CompareTag("Player"));
        if (other.CompareTag("Player")) // more performant than other.gameObject.tag == "NPC"
        {
            if (StateSingleton.GetState() == StateSingleton.State.Playing)
            {
                SceneManager.LoadScene("SecondScene");
            }
        }
    }
}
