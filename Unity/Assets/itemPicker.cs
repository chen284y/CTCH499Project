using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPicker : MonoBehaviour {

    [SerializeField]
    private Camera camera1;
    [SerializeField]
    private Camera camera2;

    void OnTriggerEnter(Collider collider)
    {
        print("Enter!");
        camera2.enabled = true;
        camera1.enabled = false;
        
        Destroy(gameObject);
    }
}
