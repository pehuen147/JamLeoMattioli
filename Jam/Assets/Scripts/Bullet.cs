using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] PlayerData m_PlayerData;
    private Renderer rend;
    public float speed = 1;
    public Bullet(float _speed)
    {
        speed = _speed;
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        SetBulletColor();
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
}