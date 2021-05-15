using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    [SerializeField] EnemyData data;

    private void Start()
    {
        player = PlayerSingleton.Instance.transform;
    }

    private void Update()
    {
        Vector3 diff = transform.position - player.position;
        Vector3 dir = diff.normalized;

        transform.position += transform.forward * data.speed * Time.deltaTime;

        transform.LookAt(player);
    }

    public EnemyData GetData()
    {
        return data;
    }
}
