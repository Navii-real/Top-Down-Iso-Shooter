using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeScrollCamera : MonoBehaviour
{
    public float scrollSpeed = 10.0f; // Speed of the camera movement
    public float edgeSize = 10.0f; // Size of the screen edge (in pixels) where scrolling will happen

    public float minX = -50.0f; // Minimum x position of the camera
    public float maxX = 50.0f; // Maximum x position of the camera
    public float minZ = -50.0f; // Minimum z position of the camera
    public float maxZ = 50.0f; // Maximum z position of the camera

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 movement = Vector3.zero;

        if (mousePosition.x < edgeSize)
        {
            movement.x = -scrollSpeed * Time.deltaTime;
        }
        else if (mousePosition.x > Screen.width - edgeSize)
        {
            movement.x = scrollSpeed * Time.deltaTime;
        }

        if (mousePosition.y < edgeSize)
        {
            movement.z = -scrollSpeed * Time.deltaTime;
        }
        else if (mousePosition.y > Screen.height - edgeSize)
        {
            movement.z = scrollSpeed * Time.deltaTime;
        }

        Vector3 newPosition = transform.position + movement;

        // Clamp the new position within the specified bounds
        // newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        // newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        transform.position = newPosition;
    }
}

