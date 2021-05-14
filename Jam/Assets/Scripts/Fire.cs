using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject SpawnBulletPoint;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(BulletPrefab, SpawnBulletPoint.transform.position,Quaternion.Euler(0,0,0) );
        }
    }
}