using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public static event Action<object> OnItemCollectedEvent;
 
    private static readonly Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(string name, int quantity = 1)
    {
        if (!items.ContainsKey(name))
        {
            items.Add(name, quantity);
        }
        else
        {
            items[name] += 1;
        }
        OnItemCollectedEvent?.Invoke(null);
    }

    public void RemoveItem(string name)
    {
        if (items.ContainsKey(name))
        {
            int quantity = items[name];
            if (quantity == 1)
            {
                items.Remove(name);
            }
            else
            {
                items[name] = quantity - 1;
            }
        }
    }

    public int GetCount(string name){
        if(ContainsItem(name) == true){
            return items[name];
        }
        return 0;
    }

    public bool ContainsItem(string name){
        return items.ContainsKey(name);
    }
}
