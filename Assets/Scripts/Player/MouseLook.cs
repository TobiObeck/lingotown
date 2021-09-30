using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 5f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Update()
    {
        if (StateSingleton.GetState() == StateSingleton.State.Playing)
        {
            // https://answers.unity.com/questions/61414/mouse-sensitivity-changes-between-editor-and-built.html
            // Mouse movement is already framerate-independent to begin with. 
            // Multiplying it by Time.deltaTime makes it framerate-dependent. 
            // Say it takes you one second to move the mouse from one side of a mouse mat to the other...
            // it will always take one second to do this, regardless of the framerate of the game.
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // not needed  * Time.deltaTime
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; // not needed  * Time.deltaTime

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
