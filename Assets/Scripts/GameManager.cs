using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;

    public const string playerTag = "Player";
    public const string playerBulletTag = "PlayerBullet";
    public const string enemyTag = "Enemy";
    public const string enemyBulletTag = "EnemyBullet";


    private void Awake()
    {
        SharedInstance = this;
    }
}
