﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;


public class ClipControl : MonoBehaviour {

    [SerializeField]
    private Camera camera;
    // Use this for initialization
    Vector3 camt;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GlobalVariables.ShortTermExcitement <= 0.70f)
        {
            if (camera.farClipPlane <= 30)
                camera.farClipPlane = camera.farClipPlane + 0.01f;
        }
        else if(GlobalVariables.ShortTermExcitement >= 0.70f)
        {
            if(camera.farClipPlane >= 10)
                camera.farClipPlane = camera.farClipPlane - 0.01f;
        }
        camt = camera.transform.forward;
        Debug.Log("Received: " + GlobalVariables.ShortTermExcitement);
        move();

        if(GlobalVariables.PublicStatus == 1)
        {
            camera.GetComponent<BloomAndFlares>().bloomThreshold += 0.001f;     
        }
    }


    void move()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(camt.x*0.04f,0f,camt.z*0.04f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(camt.x * -0.025f, 0f, camt.z * -0.025f);
        }
        /*
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.1f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.1f, 0f, 0f);
        }
        */
    }
}
