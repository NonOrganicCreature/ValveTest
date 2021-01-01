using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FPVMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;

    private float mouseXAxis = 0f;
    private float mouseYAxis = 0f;
    
    [SerializeField] public float lookSpeedX = 2f;
    [SerializeField] public float lookSpeedY = 2f;

    private Vector3 cameraStartRotation;


    private void Awake()
    {
        cameraStartRotation = transform.eulerAngles;
    }

    void FixedUpdate()
    {
        Vector3 move = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
            move += Vector3.forward * moveSpeed;
        if (Input.GetKey(KeyCode.S))
            move -= Vector3.forward * moveSpeed;
        if (Input.GetKey(KeyCode.D))
            move += Vector3.right * moveSpeed;
        if (Input.GetKey(KeyCode.A))
            move -= Vector3.right * moveSpeed;
        if (Input.GetKey(KeyCode.E))
            move += Vector3.up * moveSpeed;
        if (Input.GetKey(KeyCode.Q))
            move -= Vector3.up * moveSpeed;
        transform.Translate(move);
 

        if (Input.GetMouseButton(1))
        {
            mouseXAxis += lookSpeedX * Input.GetAxis("Mouse X");
            mouseYAxis -= lookSpeedY * Input.GetAxis("Mouse Y");
     
            transform.eulerAngles = new Vector3(mouseYAxis, cameraStartRotation.y + mouseXAxis, 0f);
        }

    }
}
