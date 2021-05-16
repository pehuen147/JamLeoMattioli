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

    bool waitShotIsRunning = false;

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

        bool isClose = (diff.magnitude < data.minimumStopDistance);

        if (!isClose && !waitShotIsRunning)
            isStopped = false;

        if (!isStopped)
        {
            isStopped = isClose;

            agent.SetDestination(player.position);
        }
        else
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
        waitShotIsRunning = true;

        yield return new WaitForSeconds(waitTime);

        waitShotIsRunning = false;
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
