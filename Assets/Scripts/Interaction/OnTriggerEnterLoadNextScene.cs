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
                // reseting player position on scene change
                // disabling the character controller is needed otherwise it would
                // overrite this manual resetting of the position 
                GameObject player = GameObject.Find("Player");
                CharacterController charController = player.GetComponent<PlayerMovement>().controller;
                charController.enabled = false;
                charController.transform.position = new Vector3(0, 0, 0);
                charController.enabled = true;

                SceneManager.LoadScene("SecondScene");
            }
        }
    }
}
