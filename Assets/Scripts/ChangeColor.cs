using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] PlayerData m_PlayerData;
    [SerializeField] Renderer hands;

    Color[] Colors;

    private int indexColor =-1;
    private Renderer rend;
    
    private float currentTime = 0;
    public float timeToChangeColor = 3;

    public bool useButton = true;

    //nuevo
    //public Animator animator;
    
    
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
                //animator.SetTrigger("Reload");
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
        rend.material.SetColor("_EmissionColor", Colors[indexColor]);
        hands.material.SetColor("_EmissionColor", Colors[indexColor]);
    }

    public int GetCurrentColor()
    {
        return indexColor;
    }

    public int GetIndexColor() { return indexColor; }

   
}

