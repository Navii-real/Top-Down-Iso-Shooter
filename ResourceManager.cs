using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Dictionary to store resources and their values
    private Dictionary<string, float> resourceValues = new Dictionary<string, float>();

    void Start()
    {
        // Initialize resource values
        InitializeResourceValues();
    }

    void InitializeResourceValues()
    {
        // Add resource names and initial values to the dictionary
        resourceValues["health"] = 1.0f;
        resourceValues["stamina"] = 1.0f;
        // Add more resources as needed
    }

    // Method to access resource value by name
    public float GetResourceValue(string resourceName)
    {
        if (resourceValues.ContainsKey(resourceName))
        {
            return resourceValues[resourceName];
        }
        else
        {
            Debug.LogWarning("Resource '" + resourceName + "' does not exist.");
            return 0.0f;
        }
    }

    // Method to set resource value by name
    public void SetResourceValue(string resourceName, float value)
    {
        if (resourceValues.ContainsKey(resourceName))
        {
            resourceValues[resourceName] = value;
        }
        else
        {
            Debug.LogWarning("Resource '" + resourceName + "' does not exist.");
        }
    }
}

