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
		for(int i = 0; i < plates.Length; i++)
        {
            if (plates[i].gameObject.transform.localScale.x >= 7.0f)
            {
                plates[i].gameObject.transform.localScale += new Vector3(-0.1f, 0, -0.1f);
            }
            else if (plates[i].gameObject.transform.localScale.x <= 0.5f)
            {
                plates[i].gameObject.transform.localScale += new Vector3(0.1f, 0, 0.1f);
            }
            else
            {
                float j = Random.Range(-100f,100f);
                j = j * 0.0005f;
                plates[i].gameObject.transform.localScale += new Vector3(j, 0, j);
            }
        }
	}
}
