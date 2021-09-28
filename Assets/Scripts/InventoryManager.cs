using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    private readonly Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(string name)
    {
        if (!items.ContainsKey(name))
        {
            int quantity = 1;
            items.Add(name, quantity);
        }
        else
        {
            int quantity = items[name];
            items[name] += quantity + 1;
        }

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

    public bool ContainsItem(string name){
        return items.ContainsKey(name);
    }
}
