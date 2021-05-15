using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] PlayerData m_PlayerData;

    Color[] Colors;

    private int indexColor =-1;
    private Renderer rend;

    private float currentTime = 0;
    public float timeToChangeColor = 3;

    public bool useButton = true;
    
    // Start is called before the first frame update
    void Start()
    { 
        rend = GetComponent<Renderer>();
        Colors = GameManager.SharedInstance.attackColors;

        SetNewColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (useButton)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                SetNewColor();
            }
        }
        else
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timeToChangeColor)
            {
                SetNewColor();
                currentTime = 0;
            }
        }
    }
    
    void SetNewColor()
    {
        indexColor++;
        if (indexColor == Colors.Length)
        {
            indexColor = 0;
        }
        rend.material.SetColor("_Color", Colors[indexColor]);
        
        m_PlayerData.currentGunColor = Colors[indexColor];
    }

    public Color GetCurrentColor()
    {
        return Colors[indexColor];
    }

    public int GetIndexColor() { return indexColor; }
}
