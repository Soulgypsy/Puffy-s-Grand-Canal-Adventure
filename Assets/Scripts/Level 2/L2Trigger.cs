using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Trigger : MonoBehaviour
{
    [Header("Bool Identifier")]
    public bool isDialogTrigger;
    public bool isNavTrigger;
    public bool isQuest2Finish;
    public bool isExit;
    public bool isLast;

    [Header("Manager")]
    private L2Manager manager;

    [Header("Nav Requirment")]
    public GameObject nextNavMarker;

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
                if (isQuest2Finish)
                {
                    manager.clearCargo();
                    nextNavMarker.SetActive(true);
                }

                manager.CameraSwitch();
                GetComponent<DialogueTrigger>().TriggerDialogue();
                gameObject.SetActive(false);
            }
            else if (isNavTrigger)
            {
                nextNavMarker.SetActive(true);
                gameObject.SetActive(false);
            }
            else if (isLast)
            {
                manager.clearBlocker();
            }
            else if (isExit)
            {
                manager.exitScene();
            }
            else
                Debug.Log("No type set");
        }       
    }
}
