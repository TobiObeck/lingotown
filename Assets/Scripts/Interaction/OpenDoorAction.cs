using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenDoorAction : AbstractAfterInteractionAction
{
    public Transform door;
    
    public override void ExecuteAction()
    {
        new OpenDoorMovement().OpenDoor(door);
    }
}
