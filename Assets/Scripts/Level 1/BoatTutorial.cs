using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatTutorial : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject[] waypointsP1;
    public GameObject[] waypointsP2;
    public GameObject[] waypointsP3;
    public GameObject dialogueTrigger;
    public GameObject harpoonTrigger;
    public GameObject endBarrier;
    private int currentWaypoint;

    [Header("Parts")]
    public bool part1Done;
    public bool part2Done;
    public bool part3Done;

    [Header("Boat Movement")]
    public EvironmentBoat environmentBoat;

    public void Awake()
    {
        waypointsP1[currentWaypoint].gameObject.SetActive(true);
    }

    public void changeWaypointP1()
    {
        waypointsP1[currentWaypoint].gameObject.SetActive(false);
        currentWaypoint = 0;
        dialogueTrigger.gameObject.SetActive(true);
    }

    public void changeWaypointP2()
    {
        currentWaypoint = currentWaypoint + 1;

        if (currentWaypoint != waypointsP2.Length)
        {
            waypointsP2[currentWaypoint - 1].gameObject.SetActive(false);
            waypointsP2[currentWaypoint].gameObject.SetActive(true);
        }
        else //End of part
        {
            waypointsP2[currentWaypoint - 1].gameObject.SetActive(false);
            harpoonTrigger.SetActive(false);
            part2Done = true;
        }

    }

    public void changeWaypointP3()
    {
            currentWaypoint = currentWaypoint + 1;

            if (currentWaypoint != waypointsP3.Length)
            {
                waypointsP3[currentWaypoint - 1].gameObject.SetActive(false);
                waypointsP3[currentWaypoint].gameObject.SetActive(true);
            }
            else //End of part
            {
                waypointsP3[currentWaypoint - 1].gameObject.SetActive(false);
                endBarrier.SetActive(false);
                part3Done = true;
            }
    }

    public void partSelect()
    {
        if (part1Done == false)
        {
            changeWaypointP1();
        }
        else
        {
            changeWaypointP2();
        }
        if (part2Done == false)
        {
            changeWaypointP2();
        }
        else
        {
            changeWaypointP3();
        }
    }

    public void equipHarpoon()
    {
        Debug.Log("harpoon Equiped");
        waypointsP3[currentWaypoint].gameObject.SetActive(true);
    }

    public void exitTrigger()
    {
        Debug.Log("Exit");
        SceneManager.LoadScene("Level Select");
    }

    public void moveBoat()
    {
        environmentBoat.isMoving = true;
    }
    public void dialogueTriggered()
    {
        GetComponent<DialogueTriggerLevelOne>().TriggerDialogue();
        dialogueTrigger.gameObject.SetActive(false);
        waypointsP2[currentWaypoint].gameObject.SetActive(true);
        part1Done = true;
    }
}
