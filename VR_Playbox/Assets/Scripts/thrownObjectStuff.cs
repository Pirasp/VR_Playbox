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
    }

    public void Release()
    {
        StartCoroutine(Despawn());
        spawnThrowable.Spawn();
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
}
