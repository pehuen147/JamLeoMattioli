using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public float speed;
    public float sprintSpeed;
    public float jumpHeight;
    public float movementBarSpeed;
}
