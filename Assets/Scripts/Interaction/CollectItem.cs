using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : AbstractAfterInteractionAction
{

    public string itemName = "someitem";

    public override void ExecuteAction()
    {
        FindObjectOfType<InventoryManager>().AddItem(itemName);
        Destroy(gameObject);
    }
}
