using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveTutorial : MonoBehaviour
{
    public DialogueManagerLevelOne cameraMove;
    public bool cameraFinished;
    private bool cameraReturn;
   [SerializeField] private bool timerEnabled;
    public Camera cameraTutorial;
    public Camera cameraObjective;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        cameraFinished = false;
        cameraReturn = false;
        timer = 0;
        timerEnabled = true;
        cameraObjective.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMove.cameraMovement == true)
        {
            if (timerEnabled == true)
            {
                timer += Time.unscaledDeltaTime;
                
            }
            if (timerEnabled == false && Input.GetKeyDown("space"))// temp
            {
                timer = 0;
                timerEnabled = true;
                cameraReturn = true;
            }
            print(timer);

            if (timer <= 0.5 && cameraReturn == false)
            {
                cameraTutorial.enabled = false;
                cameraObjective.enabled = true;
            }
            else if (timer <= 0.5 && cameraReturn == true)
            {
                cameraTutorial.enabled = true;
                cameraObjective.enabled = false;
            }

            if (timer > 0.5 && cameraReturn == false)
            {
                timerEnabled = false;
            }
            else if (timer > 0.5 && cameraReturn == true)
            {
                timerEnabled = false;
                cameraFinished = true;
                this.enabled = false;
            }
        }

    }
}
