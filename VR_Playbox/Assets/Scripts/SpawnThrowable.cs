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
        Instantiate(throwablePrefab, spawnPosition.position, spawnPosition.rotation, null);
    }
}
