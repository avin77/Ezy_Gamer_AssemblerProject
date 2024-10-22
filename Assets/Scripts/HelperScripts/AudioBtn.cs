using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBtn : MonoBehaviour
{
    private static AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;  // Don't play on start
        audioSource.loop = false;
        audioSource.volume = 1.0f;
    }
    public static void PlayAudioOnClick()
    {
        if (audioSource.clip!=null)
        {
            audioSource.Play();
            Debug.Log("audio played...");
        }
    }
}
