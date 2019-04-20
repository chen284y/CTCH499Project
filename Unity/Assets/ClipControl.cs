using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Valve.VR;


public class ClipControl : MonoBehaviour {

    public SteamVR_Input_Sources LeftInputSource = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources RightInputSource = SteamVR_Input_Sources.RightHand;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private Slider mainSlider;

    [SerializeField]
    public TextMeshProUGUI valueText, rangeText;
    // Use this for initialization
    Vector3 camt;
    private AudioSource source;
    public AudioClip walking;
    public AudioClip Idle = null;

    bool playing = false;

    void Start () {
        source = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {

        playing = false;
        if (GlobalVariables.ShortTermExcitement <= 0.40f)
        {
        
            if (camera.farClipPlane <= 40)
                camera.farClipPlane = camera.farClipPlane + 0.01f;
        }
        else if(GlobalVariables.ShortTermExcitement >= 0.80f)
        {
            if(camera.farClipPlane >= 10)
                camera.farClipPlane = camera.farClipPlane - 0.01f;
        }
        mainSlider.value = GlobalVariables.ShortTermExcitement;
        valueText.text = GlobalVariables.ShortTermExcitement.ToString();
        rangeText.text = camera.farClipPlane.ToString();
        camt = camera.transform.forward;
        Debug.Log("Received: " + GlobalVariables.ShortTermExcitement);
        move();

        if(GlobalVariables.PublicStatus == 1 && camera.GetComponent<BloomAndFlares>().bloomThreshold <= 10)
        {
            camera.GetComponent<BloomAndFlares>().bloomThreshold += 0.001f;     
        }

        if (playing && source.clip != walking)
        {
            source.clip = walking;
            source.Play();
        }
        else if (!playing && source.clip != Idle)
        {
            source.clip = Idle;
            source.Play();
        }
        
    }


    void move()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(camt.x*0.07f*(Time.deltaTime / 0.025f),0f,camt.z*0.04f * (Time.deltaTime / 0.025f));
            playing = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(camt.x * -0.04f * (Time.deltaTime / 0.025f), 0f, camt.z * -0.025f * (Time.deltaTime / 0.025f));
            playing = true;
        }

        if (SteamVR_Actions._default.Squeeze.GetAxis(RightInputSource) > 0.03f)
        {
            transform.Translate(camt.x * 0.07f * (Time.deltaTime / 0.025f), 0f, camt.z * 0.04f * (Time.deltaTime / 0.025f));
            playing = true;
        }

        if (SteamVR_Actions._default.Squeeze.GetAxis(LeftInputSource) > 0.03f)
        {
            transform.Translate(camt.x * -0.04f * (Time.deltaTime / 0.025f), 0f, camt.z * -0.025f * (Time.deltaTime / 0.025f));
            playing = true;
        }


        if (Input.GetKey(KeyCode.R))
        {
            GlobalVariables.PublicStatus = 0;
            camera.GetComponent<BloomAndFlares>().bloomThreshold = 0;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
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
