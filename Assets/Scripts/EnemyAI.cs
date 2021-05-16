using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private Animator anim;

    [SerializeField] EnemyData data;

    Renderer rend;

    IEnumerator waitShotCoroutine;
    IEnumerator changeColorCoroutine;

    Color[] attackColors;

    int colorIndex;

    bool isStopped = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        if (waitShotCoroutine != null)
            StopCoroutine(waitShotCoroutine);

        if (changeColorCoroutine != null)
            StopCoroutine(changeColorCoroutine);

        isStopped = true;
    }

    private void OnEnable()
    {
        changeColorCoroutine = WaitToChangeColor(data.waitToChangeColor);
        StartCoroutine(changeColorCoroutine);

        isStopped = false;
    }

    private void Start()
    {
        player = PlayerSingleton.Instance.transform;

        rend = GetComponentInChildren<Renderer>();
        agent = GetComponent<NavMeshAgent>();

        attackColors = GameManager.SharedInstance.attackColors;
        colorIndex = Random.Range(0, attackColors.Length);

        rend.material.SetColor("_EmissionColor", attackColors[colorIndex]);
    }

    private void Update()
    {
        Vector3 diff = transform.position - player.position;

        agent.isStopped = isStopped;

        if (!isStopped)
        {
            isStopped = (diff.magnitude < data.minimumStopDistance);

            agent.SetDestination(player.position);
        }

        transform.LookAt(player);

        UpdateAnimation();
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

    void UpdateAnimation()
    {
        if (isStopped == anim.GetBool("IsWalking"))
            anim.SetBool("IsWalking", !isStopped);
    }
}
