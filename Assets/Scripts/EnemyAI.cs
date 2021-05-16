using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    [SerializeField] EnemyData data;

    Renderer rend;

    IEnumerator waitShotCoroutine;
    IEnumerator changeColorCoroutine;

    Color[] attackColors;

    int colorIndex;

    bool isStopped = false;

    private void OnDisable()
    {
        if (waitShotCoroutine != null)
            StopCoroutine(waitShotCoroutine);

        if (changeColorCoroutine != null)
            StopCoroutine(changeColorCoroutine);

        isStopped = false;
    }

    private void OnEnable()
    {
        changeColorCoroutine = WaitToChangeColor(data.waitToChangeColor);
        StartCoroutine(changeColorCoroutine);
    }

    private void Start()
    {
        player = PlayerSingleton.Instance.transform;

        rend = GetComponentInChildren<Renderer>();

        attackColors = GameManager.SharedInstance.attackColors;
        colorIndex = Random.Range(0, attackColors.Length);

        rend.material.SetColor("_EmissionColor", attackColors[colorIndex]);
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
        waitShotCoroutine = WaitAndShoot(data.animationWaitAfterShooting);
        StartCoroutine(waitShotCoroutine);
    }

    IEnumerator WaitAndShoot(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        isStopped = false;
    }

    IEnumerator WaitToChangeColor(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            colorIndex = Random.Range(0, GameManager.SharedInstance.attackColors.Length);

            if (colorIndex >= attackColors.Length)
                colorIndex = 0;

            rend.material.SetColor("_EmissionColor", attackColors[colorIndex]);
        }
    }

    public int GetCurrentColor()
    {
        return colorIndex;
    }
}
