using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenKeyDoor : AbstractAfterInteractionAction
{
    public Transform door;
    public string keyName = "key";

    public override void ExecuteAction()
    {
        if (FindObjectOfType<InventoryManager>().ContainsItem(keyName) == true)
        {
            Debug.Log("Abstract AfterDialogueCallback");
            Debug.Log(door + " " + door.position);
            door.position = new Vector3(
                door.position.x,
                2 * door.position.y,
                door.position.z);

            SceneManager.LoadScene("SecondScene");
        }
        else{
            Debug.Log("You don't have a key!!!"); // TODO player needs feedback to know this
        }
    }
}
