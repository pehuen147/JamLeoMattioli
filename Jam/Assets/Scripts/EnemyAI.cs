using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    [SerializeField] EnemyData data;

    private void Update()
    {
        Vector3 diff = transform.position - player.position;
        Vector3 dir = diff.normalized;

        transform.position += transform.forward * data.speed * Time.deltaTime;

        transform.LookAt(player);
    }
}
