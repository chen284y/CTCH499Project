﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class itemPicker : MonoBehaviour {

    [SerializeField]
    private Camera camera1;
    public Canvas canvas1;

    void OnTriggerEnter(Collider collider)
    {
        print("Enter!");
        camera1.GetComponent<EdgeDetectionColor>().enabled = false;
        camera1.GetComponent<BloomAndFlares>().enabled = true;
        camera1.GetComponent <VignetteAndChromaticAberration>().enabled = true;
        camera1.farClipPlane = 2000;
        GlobalVariables.PublicStatus = 1;
        canvas1.enabled = false;
        Destroy(gameObject);
    }
}
