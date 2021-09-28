using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyDoor : AbstractAfterInteractionAction
{
    public Transform door;
    public string keyName = "key";

    public override void ExecuteAction()
    {
        if (FindObjectOfType<InventoryManager>().ContainsItem(keyName) == true)
        {
            new OpenDoorMovement().OpenDoor(door);
        }
        else{
            Debug.Log("You don't have a key!!!"); // TODO player needs feedback to know this
        }
    }
}
