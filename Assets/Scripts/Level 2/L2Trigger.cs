using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Trigger : MonoBehaviour
{
    [Header("Bool Identifier")]
    public bool isDialogTrigger;

    [Header("Manager")]
    private L2Manager manager;

    public void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<L2Manager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBoat")
        {
            if (isDialogTrigger)
            {
                manager.CameraSwitch();
                gameObject.SetActive(false);       
            }
        }       
    }
}
