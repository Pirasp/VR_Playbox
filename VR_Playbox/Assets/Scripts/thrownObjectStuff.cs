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
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if(impactAudioClip)
            audioSource.PlayOneShot(impactAudioClip);
    }*/

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(lifetime);
        ThrowManager.instance.curballs--;
        Destroy(this.gameObject);
    }

    IEnumerator DespawnInactive()
    {
        yield return new WaitForSeconds(lifetime*2);
        ThrowManager.instance.curballs--;
        spawnThrowable.Spawn();
        Destroy(this.gameObject);
    }
}
