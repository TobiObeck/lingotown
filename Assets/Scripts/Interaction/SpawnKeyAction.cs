using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKeyAction : AbstractAfterInteractionAction
{
    public Transform keySpawnPosition;

    public GameObject keyPrefab;

    public override void ExecuteAction()
    {
        Instantiate(keyPrefab, keySpawnPosition.position, Quaternion.identity);
    }
}
