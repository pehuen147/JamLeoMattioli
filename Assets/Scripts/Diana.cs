using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana : Health
{
    Renderer rend;
    float disintegration = 0;
    bool disintegrate = false;
    float dissintegrateSpeed = 1;
    int m_ColorIndex;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (disintegrate)
        {
            if (disintegration < 1)
                disintegration += Time.deltaTime * dissintegrateSpeed;

            Debug.Log(disintegration);

            rend.material.SetFloat("_Weight", disintegration);
        }
    }

    public override void TakeDamage(float damage, int colorIndex)
    {
        if (colorIndex == m_ColorIndex)
        {
            Death();
        }
        else
        {
            SoundManager.SharedInstance.PlayReflectShot();
        }
    }

    public override void Death()
    {
        gameObject.SetActive(false);
    }

    public void SetColorIndex(int index)
    {
        m_ColorIndex = index;
    }
}
