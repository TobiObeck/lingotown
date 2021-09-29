using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public GameObject mother;
    public GameObject motherAfterSuccess;

    private string questState = "open";

    public override void Awake()
    {
        base.Awake();
        InventoryManager.OnItemCollectedEvent += ProcessInventoryChange;
    }

    void OnDestroy()
    {
        InventoryManager.OnItemCollectedEvent -= ProcessInventoryChange;
    }

    void ProcessInventoryChange(object somestuff)
    {
        // when more quests exist...
        // if in quest XY...
        if (questState == "open")
        {
            ProcessSuccessfullAppleCollectQuest();
        }
        // but there is currently only this one quest
    }

    void ProcessSuccessfullAppleCollectQuest()
    {
        int collectedAppleCount = FindObjectOfType<InventoryManager>().GetCount("apple");

        if (collectedAppleCount >= 5)
        {
            Instantiate(
                motherAfterSuccess, mother.transform.position, mother.transform.rotation
            );
            Destroy(mother);
            questState = "solved";
        }
    }
}
