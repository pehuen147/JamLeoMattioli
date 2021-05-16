using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundIterator : MonoBehaviour
{
    [SerializeField] AudioSource source;

    [SerializeField] AudioClip[] clips;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayOneShot()
    {
        AudioClip clip = clips[Random.Range(0, clips.Length)];

        source.PlayOneShot(clip);
    }
}
