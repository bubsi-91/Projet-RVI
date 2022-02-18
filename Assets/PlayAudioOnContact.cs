using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnContact : MonoBehaviour
{
    public AudioSource audioSourceLeft;
    public AudioSource audioSourceRight;
    public AudioClip audioClip;
    public float timeBetweenSounds = 0.2f;
    float timer;
    
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void TriggerSound()
    {
        if (timer > timeBetweenSounds)
        {
            audioSourceLeft.PlayOneShot(audioClip);
            audioSourceRight.PlayOneShot(audioClip);
            timer = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        TriggerSound();
    }
}
