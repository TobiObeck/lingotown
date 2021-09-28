using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : AbstractAfterInteractionAction
{

    public string keyName = "key";

    public override void ExecuteAction()
    {
        FindObjectOfType<InventoryManager>().AddItem(keyName);
        Destroy(gameObject);
    }
}
