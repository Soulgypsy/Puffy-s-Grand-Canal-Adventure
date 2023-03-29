using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatTutorial : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject[] waypointsP1;
    public GameObject[] waypointsP2;
    public GameObject harpoonTrigger;
    public GameObject endBarrier;
    private int currentWaypoint;

    [Header("Parts")]
    public bool part1Done;

    [Header("Boat Movement")]
    public EvironmentBoat environmentBoat;

    public void Awake()
    {
        waypointsP1[currentWaypoint].gameObject.SetActive(true);
    }

    public void changeWaypointP1()
    {
        currentWaypoint = currentWaypoint + 1;

        if (currentWaypoint != waypointsP1.Length)
        {
            waypointsP1[currentWaypoint - 1].gameObject.SetActive(false);
            waypointsP1[currentWaypoint].gameObject.SetActive(true);
        }
        else //End of part
        {
            waypointsP1[currentWaypoint - 1].gameObject.SetActive(false);
            part1Done = true;
            currentWaypoint = 0;
            harpoonTrigger.SetActive(true);
        }

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
            endBarrier.SetActive(false);
            part1Done = true;
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
    }

    public void equipHarpoon()
    {
        Debug.Log("harpoon Equiped");
        waypointsP2[currentWaypoint].gameObject.SetActive(true);
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
}
