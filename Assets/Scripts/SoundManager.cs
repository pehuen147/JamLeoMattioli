using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip[] reflectShotSFX;
    public AudioClip[] changeColorSFX;

    // Player
    public AudioClip[] playerShotSFX;
    public AudioClip[] playerTakeDamageSFX;
    public AudioClip[] playerJumpSFX;
    public AudioClip[] playerFootstepsSFX;

    // Enemy
    public AudioClip[] enemyDeathSFX;
    public AudioClip[] enemyShotSFX;

    // Gameplay music
    public AudioClip corridorMusic;
    public AudioClip oneShotStartMusic;
    public AudioClip loopedGameMusic;

    public static SoundManager SharedInstance;

    private AudioSource playerASource;

    private void Awake()
    {
        SharedInstance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        playerASource = PlayerSingleton.Instance.GetComponent<AudioSource>();
    }

    public void PlayOneShot(AudioClip[] clips, AudioSource source)
    {
        AudioClip clip = clips[Random.Range(0, clips.Length)];

        source.loop = false;
        source.PlayOneShot(clip);
    }

    public void PlayOneShot(AudioClip clip, AudioSource source)
    {
        source.loop = false;
        source.PlayOneShot(clip);
    }

    public void PlayLooped(AudioClip clip, AudioSource source)
    {
        source.loop = true;
        source.clip = clip;
        audioSource.Play();
    }

    public void PlayOneShotPlayer(AudioClip clip)
    {
        if (playerASource)
            playerASource.PlayOneShot(clip);
    }

    public void PlayOneShotPlayer(AudioClip[] clips)
    {
        AudioClip clip = clips[Random.Range(0, clips.Length)];

        if (playerASource)
            playerASource.PlayOneShot(clip);
    }

    public void PlayReflectShot()
    {
        PlayOneShot(reflectShotSFX, playerASource);
    }

    public void PlayCorridorSong()
    {
        audioSource.loop = true;
        audioSource.clip = corridorMusic;
        audioSource.Play();
    }

    public void PlayGameMusic()
    {
        audioSource.loop = true;
        audioSource.clip = loopedGameMusic;
        audioSource.Play();
    }
}