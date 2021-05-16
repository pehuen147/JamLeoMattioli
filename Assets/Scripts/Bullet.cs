using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] PlayerData m_PlayerData;
    [SerializeField] float destroyTime = 5;
    private Renderer rend;
    public float speed = 1;

    float damage;

    int colorIndex = 0;

    IEnumerator destroyCoroutine;

    public Bullet(float _speed)
    {
        speed = _speed;
    }

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void OnEnable()
    {
        destroyCoroutine = WaitToDestroy(destroyTime);
        StartCoroutine(destroyCoroutine);
    }

    void Update()
    {
        MovBullet();
    }

    void MovBullet()
    {
        Vector3 forwardVec= transform.forward;
        transform.position += (forwardVec * Time.deltaTime * speed);
    }

    public void SetBulletColor(int index)
    {
        colorIndex = index;
        rend.material.SetColor("_EmissionColor", GameManager.SharedInstance.attackColors[colorIndex]);
        rend.material.SetColor("_Color", GameManager.SharedInstance.attackColors[colorIndex]);
    }

    private void OnTriggerEnter(Collider other)
    {

        this.gameObject.SetActive(false);

        if (other.CompareTag(GameManager.playerTag) || other.CompareTag(GameManager.enemyTag))
        {
            if (other.tag != this.tag)
                other.GetComponent<Health>().TakeDamage(damage, colorIndex);
        }
    }
    
    IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        this.gameObject.SetActive(false);
    }

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }
}