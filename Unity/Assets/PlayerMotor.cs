using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private GameObject cam;

    Animator anim;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camrotation = Vector3.zero;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void camRotate(Vector3 _camrotation)
    {
        camrotation = _camrotation;
    }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
            anim.SetInteger("condition", 1);
        }
        else
        {
            anim.SetInteger("condition", 0);
        }
    }

    void PerformRotation()
    {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation) );
        if(cam != null)
        {
            cam.transform.Rotate(-camrotation);
        }
    }
    


}
