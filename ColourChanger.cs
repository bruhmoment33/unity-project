using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ColourChanger : MonoBehaviour
{
    System.Random random = new System.Random();
    public bool rapidSwitch = false;
    void Update()
    {
        if (Input.GetKey("c") || rapidSwitch)
        {
            GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
