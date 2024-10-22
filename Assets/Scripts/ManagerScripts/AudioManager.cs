using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip wrongClip;
    [SerializeField] private AudioSource audioSource;

    private void OnEnable()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;  // Don't play on start
        audioSource.loop = false;
        audioSource.volume = 1.0f;
    }

    public void PlayCorrectAudio()
    {
        audioSource.clip = correctClip;
        audioSource.Play();
    }
    public void PlayWrongAudio()
    {
        audioSource.clip = wrongClip;
        audioSource.Play();
    }

}
