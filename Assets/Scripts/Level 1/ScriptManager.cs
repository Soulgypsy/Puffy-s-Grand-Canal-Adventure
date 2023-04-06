using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    [Header("Scripts")]
    public BoatMovement BoatMovement;
    public DialogueManager DialogueManager;
    public CameraMoveTutorial cameraMoveTutorial;

    [Header("Camera")] 
    public Camera dialogCam;
    private Camera mainCam;

    [Header("Objects")]
    public GameObject bg;


    private void Start()
    {
        mainCam = Camera.main;
        mainCam.enabled = false;
        dialogCam.enabled = true;
        BoatMovement.enabled = false;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (DialogueManager.dialogueOn == false && cameraMoveTutorial.cameraFinished == true) // temp, remove camerafinished condition at some point to preserve modulated code
        {
            reactivateBoat();
        }
        if (DialogueManager.dialogueOn == true)
        {
            deactivateBoat();
        }
    }

    private void reactivateBoat()
    {
        BoatMovement.enabled = true;
        dialogCam.enabled = false;
        mainCam.enabled = true;
        bg.SetActive(false);
        Time.timeScale = 1;
    }

    private void deactivateBoat()
    {
        mainCam.enabled = false;
        dialogCam.enabled = true;
        BoatMovement.enabled = false;
        Time.timeScale = 0;
    }
}
