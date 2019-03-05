using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {


    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSens = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();

    }

    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHori = transform.right * xMov;
        Vector3 moveVert = transform.forward * zMov;

        Vector3 velocity = (moveHori + moveVert).normalized * speed;

        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        float t = transform.eulerAngles.z;

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSens;

        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 camrotation = new Vector3(xRot, 0f, 0f) * lookSens;

        motor.camRotate(camrotation);
    }

}
