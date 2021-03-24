using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana_image : MonoBehaviour
{
    public Transform[] simages;

    void Awake()
    {
        simages = new Transform[transform.childCount];

        for (int i = 0; i < simages.Length; i++)
        {
            simages[i] = transform.GetChild(i);
        }
    }
}

// scritp utilisé pour gérer les photos de la fleur mais tu as le tiens donc ignore le