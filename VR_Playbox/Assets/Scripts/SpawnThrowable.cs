using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThrowable : MonoBehaviour
{
    public GameObject throwablePrefab;
    public Transform spawnPosition;
    public int spawnedObjects = 1;

    public void Spawn()
    {
        GameObject o = Instantiate(throwablePrefab, spawnPosition.position, spawnPosition.rotation, null);
        o.GetComponent<thrownObjectStuff>().spawnThrowable = this.GetComponent<SpawnThrowable>();
        spawnedObjects++;
    }
}
