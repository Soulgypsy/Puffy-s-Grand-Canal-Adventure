using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveTutorial : MonoBehaviour
{
    public DialogueManager cameraMove;
    public bool cameraFinished;
    private bool cameraReturn;
   [SerializeField] private bool timerEnabled;
    public Camera cameraTutorial;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        cameraFinished = false;
        cameraReturn = false;
        timer = 0;
        timerEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMove.cameraMovement == true)
        {
            if (timerEnabled == true)
            {
                timer += Time.deltaTime;
                
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
                cameraTutorial.transform.Rotate(0.2f, -0.5f, -0.05f);
                cameraTutorial.transform.Translate(0, 0.15f, 0);
            }
            else if (timer <= 0.5 && cameraReturn == true)
            {
                cameraTutorial.transform.Rotate(-0.2f, 0.5f, 0.05f);
                cameraTutorial.transform.Translate(0, -0.15f, 0);
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
