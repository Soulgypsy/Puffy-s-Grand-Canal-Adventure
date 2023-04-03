using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    [Header("Scripts")]
    public BoatMovement BoatMovement;
    public DialogueManager DialogueManager;

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
        if (DialogueManager.dialogueOn == false) // temp
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
