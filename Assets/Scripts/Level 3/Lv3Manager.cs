using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv3Manager : MonoBehaviour
{
    [Header("Camera")]
    private Camera mainCam;
    public Camera dialogCam;
    private bool dialogOn;

    [Header("Objective")]
    private int stageNo;
    public bool raceTrigger = false;

    private void Awake()
    {
        mainCam = Camera.main;
        dialogCam.enabled = false;
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
}
