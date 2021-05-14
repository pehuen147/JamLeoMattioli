using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1 ;

    public Bullet(float _speed)
    {
        speed = _speed;
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
}