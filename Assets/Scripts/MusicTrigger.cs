using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] GameMusic music;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(GameManager.playerTag))
            return;

        switch (music)
        {
            case GameMusic.corridor:
                SoundManager.SharedInstance.PlayCorridorSong();
                break;
            case GameMusic.oneShotStart:

                break;
            case GameMusic.looped:
                SoundManager.SharedInstance.PlayGameMusic();
                break;
        }

        Destroy(this.gameObject);
    }
}

public enum GameMusic { corridor, oneShotStart, looped };
