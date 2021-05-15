using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color[] attackColors;

    public static GameManager SharedInstance;

    public const string playerTag = "Player";
    public const string enemyTag = "Enemy";

    public const string deathSceneName = "DeathScene";
    public const string mainSceneName = "MainScene";

    private void Awake()
    {
        SharedInstance = this;
    }
}
