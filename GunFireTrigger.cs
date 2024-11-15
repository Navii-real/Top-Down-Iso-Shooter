using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireTrigger : MonoBehaviour
{
    
    public GameObject player;
    GameObject gunfire;

    // Start is called before the first frame update
    void Start()
    {
        gunfire = transform.Find("gunfire").gameObject;
        gunfire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Animator>().GetBool("isFiring")) {
            gunfire.SetActive(true);
        }
        else {
            gunfire.SetActive(false);
        }

    }
}

