using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swirl : MonoBehaviour {

    [SerializeField]
    private GameObject[] plates;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 7; i++)
        {
            float j = Random.Range(-0.1f,0.1f);
            plates[i].gameObject.transform.localScale += new Vector3(j, 0, j);
        }
	}
}
