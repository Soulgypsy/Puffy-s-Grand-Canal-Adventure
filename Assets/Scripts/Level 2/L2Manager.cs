using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2Manager : MonoBehaviour
{
    [Header("Camera")]
    private Camera mainCam;
    public Camera dialogCam;
    private bool dialogOn;

    [Header("Objective")]
    private int stageNo;
    public int stage1Count;
    public GameObject[] stage1;
    public GameObject stage1FinishMarker;
    public GameObject exitBlocker;
    public UiManager ui;

    private void Awake()
    {
        mainCam = Camera.main;
        dialogCam.enabled = false;
    }

    private void Update()
    {
       /* if (dialogOn && Input.GetKeyDown("space")) // Temp
        {
            switchToMainCam();
            nextStage();
            dialogOn = false;
        }*/
    }

    public void CameraSwitch()
    {
        mainCam.enabled = false;
        dialogCam.enabled = true;
        Time.timeScale = 0;

        dialogOn = true;

        if(stageNo == 0) //Place for activating different dialogs
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
    }

    private void nextStage()
    {
        switch (stageNo)
        {
            case 0:
                spawnStageOneObjectives();
                break;

            case 1:
                Debug.Log("stage 2 quest");
                break;
        }
    }

    public void spawnStageOneObjectives()//Spawing cargo
    {
        for(int i = 0; i < stage1.Length; i++)
        {
            stage1[i].SetActive(true);
        }

        ui.counter.SetActive(true);
    }

    public void progressStage()
    {
        if (stageNo == 0)
        {
            stage1Count++;
            ui.cargoCounterChange(stage1Count);

            if (stage1Count == 3)
            {
                stage1FinishMarker.SetActive(true);
                stageNo++;
            }
        }
    }

    public void clearCargo()
    {
        ui.counter.SetActive(false);
        for (int i = 0; i < stage1.Length; i++)
        {
            stage1[i].GetComponent<Collectables>().Invisble();
        }
    }
    public void clearBlocker()
    {
        exitBlocker.SetActive(false);
    }
    public void exitScene()
    {
        SceneManager.LoadScene("Level Select");
    }
    public void exitDialog()
    {
        switchToMainCam();
        nextStage();
    }
}
