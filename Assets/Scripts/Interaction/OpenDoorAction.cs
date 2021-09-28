using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenDoorAction : AbstractAfterInteractionAction
{
    public Transform door;
    
    public override void ExecuteAction()
    {
        Debug.Log("Abstract AfterDialogueCallback");
        Debug.Log(door + " " + door.position);
        door.position = new Vector3(
            door.position.x,
            2 * door.position.y,
            door.position.z);
    }
}
