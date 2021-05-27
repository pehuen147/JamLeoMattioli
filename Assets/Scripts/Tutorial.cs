using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] dianas;
    [SerializeField] GameObject door;

    private void Start()
    {
        Color[] colors = GameManager.SharedInstance.attackColors;

        for (int i = 0; i < dianas.Length; i++)
        {
            Renderer rend = dianas[i].GetComponent<Renderer>();
            rend.material.SetColor("_Color", colors[i]);
            dianas[i].GetComponent<Diana>().SetColorIndex(i);
        }
    }

    void Update()
    {
        for (int i = 0; i < dianas.Length; i++)
            if (dianas[i].activeInHierarchy)
                return;

        OpenDoor();
    }

    void OpenDoor()
    {
        door.SetActive(false);
    }
}
