using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip musicClip; // Assign your music clip in the inspector

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Assign the music clip to the audio source
        audioSource.clip = musicClip;
    }

    public void PlayMusic()
    {
        // Start playing the music
        audioSource.Play();
    }

    public void StopMusic()
    {
        // Stop the music
        audioSource.Stop();
    }

    public void RestartMusic()
    {
        // Restart the music from the beginning
        audioSource.Stop();
        audioSource.Play();
    }
}