using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThrowable : MonoBehaviour
{
    public GameObject throwablePrefab;
    public Transform spawnPosition;

    private void OnTriggerExit(Collider other)
    {
        if (ThrowManager.instance.curballs < ThrowManager.instance.maxballs)
        {
            Instantiate(throwablePrefab, spawnPosition.position, spawnPosition.rotation, null);
            ThrowManager.instance.curballs++;
        }
    }
}
