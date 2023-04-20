using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lv3Manager : MonoBehaviour
{
    [Header("Camera")]
    private Camera mainCam;
    public Camera dialogCam;
    private bool dialogOn;

    [Header("Objective")]
    public RaceMovement raceBoat;
    private int stageNo;
    public bool raceTrigger = false;
    public GameObject raceEndDialogTrigger;
    public bool raceBoatWon;
    public bool playerBoatwon;

    [Header("Race Dialog")]
    public Transform raceBoatPosition;
    public Camera raceEndCamera;

    private void Awake()
    {
        mainCam = Camera.main;
        dialogCam.enabled = false;
    }

    private void Update()
    {
        
    }

    public void CameraSwitch()
    {
        mainCam.enabled = false;
        dialogCam.enabled = true;
        Time.timeScale = 0;

        dialogOn = true;

        if (stageNo == 0) //Place for activating different dialogs
        {
            Debug.Log("Dialog One");
        }
        else if (stageNo == 1)
        {
            Debug.Log("Dialog Two");
        }

    }
    public void switchToMainCam()
    {
        mainCam.enabled = true;
        dialogCam.enabled = false;
        Time.timeScale = 1;
        dialogOn = false;
    }
    public void exitDialog()
    {
        switchToMainCam();
        raceTrigger = true;
    }

    public void PlayerBoatFinished()
    {
        if(raceBoatWon == false) //  Player won.
        {
            Debug.Log("Player Won");
            playerBoatwon = true;
            raceBoat.gameObject.transform.position = raceBoatPosition.position;
            NavMeshAgent agent = raceBoat.GetComponent<NavMeshAgent>();
            agent.enabled = false ;
            raceEndCamera.enabled = true;
        }
        else if(raceBoatWon == true) // Player lost.
        {
            Debug.Log("Player Lost");
        }
    }

    public void RaceBoatWon()
    {
        if (playerBoatwon == false)
        {
            raceBoatWon = true;
        }
    }
}
