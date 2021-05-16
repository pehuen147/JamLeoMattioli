using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip oneShotMusic;
    [SerializeField] AudioClip loopedMusic;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(oneShotMusic);
    }

    void Update()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(loopedMusic);
    }
}