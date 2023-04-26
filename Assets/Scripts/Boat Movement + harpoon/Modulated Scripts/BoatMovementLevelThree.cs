using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovementLevelThree : MonoBehaviour
{
    private Rigidbody _rb;

    [Header("Boat Properties")]
    [SerializeField] private float turnSpeed;
    public float moveSpeed;
    [SerializeField] private float maxMoveSpeed;

    [Header("Key Checks")]
    private bool moveForward = false;
    public bool moveBackward = false;
    private bool turnLeft = false;
    private bool turnRight = false;

    [Header("Key Inputs")]
    [SerializeField] private KeyCode forwardKey;
    [SerializeField] private KeyCode backKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private KeyCode leftKey;

    [Header("Audio")]
    [SerializeField] private AudioSource boatMovementAudio;

    [Header("Pause Menu")]
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    [Header("Race Check")]
    public RaceMovement isRacing;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MyInput();
        CheckSpeed();
        PauseMenu();
    }

    private void MyInput()
    {
        if (isRacing.startCounter == false)
        {
            if (Input.GetKey(forwardKey))
            {
                moveForward = true;
                boatMovementAudio.Play();
            }
            else
            {
                moveForward = false;
                boatMovementAudio.Stop();
            }

            if (Input.GetKey(backKey))
                moveBackward = true;
            else
                moveBackward = false;


            if (Input.GetKey(leftKey))
                turnLeft = true;
            else
                turnLeft = false;
            if (Input.GetKey(rightKey))
                turnRight = true;
            else
                turnRight = false;
        }

    }

    private void FixedUpdate()
    {
        Movement();
        Turning();
    }

    private void Movement()
    {
        if (moveForward)
        {
            _rb.AddForce(moveSpeed * transform.forward, ForceMode.Acceleration);
        }
        if (moveBackward)
        {
            _rb.AddForce(moveSpeed * -transform.forward, ForceMode.Acceleration);
        }

        if (isRacing.startCounter == true)
        {
            _rb.velocity = Vector3.zero;
        }
    }

    private void Turning()
    {
        if (turnLeft)
        {
            transform.Rotate(transform.up * -turnSpeed);
        }

        if (turnRight)
        {
            transform.Rotate(transform.up * turnSpeed);
        }
    }

    void PauseMenu()
    {
        if (Input.GetKeyDown("escape")) //&& triggeredDialogue.dialogueOn == false)
        {
            if (pauseMenu.activeSelf == true) //Unpause.
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                if (optionsMenu.activeSelf == true) //Pause menu closes from options menu.
                {
                    optionsMenu.SetActive(false);
                    Time.timeScale = 1;
                }
                else
                {
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
    }

    /// <summary>
    /// Checks current speed 
    /// If over max
    /// Reset speed to max
    /// </summary>
    private void CheckSpeed()
    {
        _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, maxMoveSpeed);

        /*if (_rb.velocity.magnitude > maxMoveSpeed && moveForward)
            _rb.velocity = transform.forward * maxMoveSpeed;
        else if (_rb.velocity.magnitude > maxMoveSpeed && moveBackward)
            _rb.velocity = -transform.forward * maxMoveSpeed;*/
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "goal")
        //{
        //    if (race.raceallowed == true)
        //    {
        //        getcomponent<dialoguetrigger>().triggerdialogue();
        //        wonrace = true;
        //    }

        //}

        if (other.tag == "Rubble Trigger")
        {
            /*if(rubbleTriggered == false)
            {
                rubbleTriggered = true;
                for (int i = 0; i < rubble.Length; i++)
                {
                    rubble[i].SetActive(true);
                }
            }*/

        }

        if (other.tag == "Bounce")
        {
            print("working");
            _rb.AddForce(100 * (moveSpeed * transform.up), ForceMode.Acceleration);
        }
    }
}