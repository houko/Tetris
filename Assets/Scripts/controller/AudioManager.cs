using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip cursor;

    public AudioClip fall;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayCursor()
    {
        PlayAudio(cursor);
    }


    public void PlayerFall()
    {
        PlayAudio(fall);
    }


    public void PlayAudio(AudioClip audioClip)
    {
        if (GameContext.Mute)
        {
            return;
        }

        if (audioSource.isPlaying)
        {
            return;
        }

        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
