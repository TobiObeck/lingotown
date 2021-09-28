using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorMovement
{
    // Start is called before the first frame update
    public OpenDoorMovement()
    {

    }

    public void OpenDoor(Transform door)
    {
        door.position = new Vector3(
            door.position.x,
            2 * door.position.y,
            door.position.z);
    }
}
