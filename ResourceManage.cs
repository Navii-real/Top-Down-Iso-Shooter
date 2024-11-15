using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManage : MonoBehaviour
{
    
    public GameObject player;
    
    public string resourceName;
    private float resourceValue;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        resourceValue = player.GetComponent<ResourceManager>().GetResourceValue(resourceName);
        GetComponent<RectTransform>().sizeDelta = new Vector2(resourceValue*100,100);
    }
}
