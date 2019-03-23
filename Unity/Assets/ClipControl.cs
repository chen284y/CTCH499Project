using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClipControl : MonoBehaviour {

    [SerializeField]
    private Camera camera;
    // Use this for initialization
    Vector3 camt;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(camera.farClipPlane <= 30)
        camera.farClipPlane = camera.farClipPlane + 0.01f;
        camt = camera.transform.forward;

        move();
    }


    void move()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
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
