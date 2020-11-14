using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrownObjectStuff : MonoBehaviour
{
    public AudioClip impactAudioClip;
    private AudioSource audioSource;
    public float lifetime = 30;
    public SpawnThrowable spawnThrowable;

    private void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(DespawnInactive());
    }

    public void Release()
    {
        StartCoroutine(Despawn());
        spawnThrowable.Spawn();
    }

    public void Grab()
    {
        StopCoroutine(DespawnInactive());
        StopCoroutine(Despawn());
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if(impactAudioClip)
            audioSource.PlayOneShot(impactAudioClip);
    }*/

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
        spawnThrowable.spawnedObjects--;
    }

    IEnumerator DespawnInactive()
    {
        yield return new WaitForSeconds(lifetime*2);
        Destroy(this.gameObject);
        spawnThrowable.spawnedObjects--;
        
        if(spawnThrowable.spawnedObjects<1)
            spawnThrowable.Spawn();
    }
}
