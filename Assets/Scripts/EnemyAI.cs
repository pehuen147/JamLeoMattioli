using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    [SerializeField] EnemyData data;

    IEnumerator coroutine;
    bool isStopped = false;

    private void Start()
    {
        player = PlayerSingleton.Instance.transform;
    }

    private void Update()
    {
        if (!isStopped)
        {
            Vector3 diff = transform.position - player.position;
            Vector3 dir = diff.normalized;

            transform.position += transform.forward * data.speed * Time.deltaTime;

            transform.LookAt(player);
        }
    }

    public EnemyData GetData()
    {
        return data;
    }

    public void StopWhileShooting()
    {
        isStopped = true;
        coroutine = WaitAndShoot(data.animationWaitAfterShooting);
        StartCoroutine(coroutine);
    }

    IEnumerator WaitAndShoot(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        isStopped = false;
    }
}
