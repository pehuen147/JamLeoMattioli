using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] PlayerData m_PlayerData;
    [SerializeField] float destroyTime = 5;
    private Renderer rend;
    public float speed = 1;

    IEnumerator destroyCoroutine;

    public Bullet(float _speed)
    {
        speed = _speed;
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        SetBulletColor();
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

    void SetBulletColor()
    {
        rend.material.SetColor("_Color", m_PlayerData.currentGunColor);
    }

    private void OnTriggerEnter(Collider other)
    {

        this.gameObject.SetActive(false);

        if (other.CompareTag(GameManager.playerTag) || other.CompareTag(GameManager.enemyTag))
        {
            if (other.tag != this.tag)
                other.GetComponent<Health>().TakeDamage(10);
        }
    }
    
    IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Debug.Log("hola");
        this.gameObject.SetActive(false);
    }
}