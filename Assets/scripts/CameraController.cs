using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float deltaY = 1f;
    [SerializeField] private float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {

        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        //Calculate roate angle
        Vector3 playerPosition = player.position + new Vector3(0, deltaY, 0);
        transform.Rotate(Vector3.up, mouseX * rotationSpeed);

    }
    

 }

