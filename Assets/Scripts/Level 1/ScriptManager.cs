using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    [Header("Scripts")]
    public BoatMovement BoatMovement;
    public DialogueManager DialogueManager;
    public DialogueManagerLevelOne dialogueManagerLevelOne;
    public CameraMoveTutorial cameraMoveTutorial;

    [Header("Camera")] 
    public Camera dialogCam;
    private Camera mainCam;


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
        
       /* if (DialogueManager.dialogueOn == false && cameraMoveTutorial.cameraFinished == true) // temp, remove camerafinished condition at some point to preserve modulated code
        {
            reactivateBoat();
        }
        if (DialogueManager.dialogueOn == true)
        {
            deactivateBoat();
        }

        //Level 1
        if (dialogueManagerLevelOne.dialogueOn == false) // temp, remove camerafinished condition at some point to preserve modulated code
        {
            reactivateBoat();
            Debug.Log("Test 1");
        }
        if (dialogueManagerLevelOne.dialogueOn == true)
        {
            deactivateBoat();
            Debug.Log("test 2");
        }*/
    }

    public void reactivateBoat()
    {
        BoatMovement.enabled = true;
        dialogCam.enabled = false;
        mainCam.enabled = true;
        Time.timeScale = 1;
    }

    public void deactivateBoat()
    {
        mainCam.enabled = false;
        dialogCam.enabled = true;
        BoatMovement.enabled = false;
        Time.timeScale = 0;
    }
}
