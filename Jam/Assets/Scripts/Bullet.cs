using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Velocity = 1 ;
    // Update is called once per frame
    void Update()
    {
        MovBullet();
    }

    void MovBullet()
    {
        Vector3 forwardVec= Vector3.forward;
        transform.position += (forwardVec * Time.deltaTime * Velocity);
    }
}