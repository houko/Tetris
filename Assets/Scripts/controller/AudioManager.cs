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

        // 这里音效播完有很长一段静音，所以不判断是否在播放中
//        if (audioSource.isPlaying)
//        {
//            return;
//        }

        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
