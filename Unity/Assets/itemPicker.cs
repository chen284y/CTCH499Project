using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class itemPicker : MonoBehaviour {

    [SerializeField]
    private Camera camera1;

    void OnTriggerEnter(Collider collider)
    {
        print("Enter!");
        camera1.GetComponent<EdgeDetectionColor>().enabled = false;
        camera1.GetComponent<BloomAndFlares>().enabled = true;
        camera1.GetComponent <VignetteAndChromaticAberration>().enabled = true;
        GlobalVariables.PublicStatus = 1;
        Destroy(gameObject);
    }
}
