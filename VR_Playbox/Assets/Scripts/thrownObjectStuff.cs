using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrownObjectStuff : MonoBehaviour
{
    public AudioClip impactAudioClip;
    private AudioSource audioSource;
    public float lifetime = 30;

    private void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(Despawn());
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
