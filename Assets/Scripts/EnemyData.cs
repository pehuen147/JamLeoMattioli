using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyData", order = 2)]
public class EnemyData : ScriptableObject
{
    public float speed;
    public float maxHealth;
    public float damage;
    public float shotCooldown;
    public float animationWaitAfterShooting;
    public float waitToChangeColor;
    public float minimumShootingDistance;
    public float minimumStopDistance;
}

