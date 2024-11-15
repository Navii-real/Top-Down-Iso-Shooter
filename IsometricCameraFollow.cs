using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCameraFollow : MonoBehaviour
{
    public Transform target; // The target GameObject to follow
    public float followSpeed = 5.0f; // The speed at which the camera will follow the target

    private Vector3 initialOffset; // Initial offset from the target to the camera
    private Vector3 adjustmentOffset;

    private float currentZoomLevel;

    void Start()
    {

        adjustmentOffset = new Vector3(2f, 0f , -23f);

        if (target == null)
        {
            Debug.LogError("No target assigned for the camera to follow.");
            return;
        }

        // Store the initial offset from the target to the camera
        initialOffset = transform.position - target.position + adjustmentOffset;
        currentZoomLevel = initialOffset.magnitude;

    }

    void Update()
    {
        if (target == null) return;

        // Handle zoom input
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        if (zoomInput != 0)
        {
            Zoom(zoomInput * 5.0f); // Adjust 5.0f to control the zoom speed
        }

        // Calculate the new camera position based on the target position and initial offset
        Vector3 desiredPosition = target.position + initialOffset.normalized * currentZoomLevel;

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

    }

    public void Zoom(float zoomAmount)
    {

         // Adjust the position based on the zoom amount along the camera's forward axis
        transform.position += transform.forward * zoomAmount;

        currentZoomLevel -= zoomAmount;

        float minDistance = 10.0f;
        float maxDistance = 50.0f;
        currentZoomLevel = Mathf.Clamp(currentZoomLevel, minDistance, maxDistance);
        initialOffset = initialOffset.normalized * currentZoomLevel;
    }
}
