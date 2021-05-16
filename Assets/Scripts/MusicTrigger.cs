using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] GameMusic music;

    [SerializeField] GameObject hordeManager;

    [SerializeField] GameObject door;

    [SerializeField] GameObject radio;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(GameManager.playerTag))
            return;

        switch (music)
        {
            case GameMusic.corridor:
                SoundManager.SharedInstance.PlayCorridorSong();

                radio.SetActive(false);
                break;
            case GameMusic.oneShotStart:

                break;
            case GameMusic.looped:
                SoundManager.SharedInstance.PlayGameMusic();

                hordeManager.SetActive(true);
                door.SetActive(true);
                break;
        }

        Destroy(this.gameObject);
    }
}

public enum GameMusic { corridor, oneShotStart, looped };
