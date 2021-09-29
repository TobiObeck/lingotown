using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : AbstractAfterInteractionAction
{

    public string itemName = "someitem";

    public int quantity = 1;

    public override void ExecuteAction()
    {
        FindObjectOfType<InventoryManager>().AddItem(itemName, quantity);
        Destroy(gameObject);
    }
}
