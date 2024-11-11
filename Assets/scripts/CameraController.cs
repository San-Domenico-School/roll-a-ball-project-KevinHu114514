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
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;        // The target the camera should follow
        public float smoothSpeed = 0.125f; // How smooth the camera movement will be
        public Vector3 offset;         // The offset of the camera relative to the target

        void FixedUpdate()
        {
            // Calculate the desired position with offset
            Vector3 desiredPosition = target.position + offset;

            // Smoothly move towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update camera position
            transform.position = smoothedPosition;

            // Optionally, make the camera always look at the target
            transform.LookAt(target);
        }
    }

 }

