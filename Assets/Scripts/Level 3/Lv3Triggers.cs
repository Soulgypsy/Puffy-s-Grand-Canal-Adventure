using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv3Triggers : MonoBehaviour
{
    [Header("Scripts")]
    private Lv3Manager manager;

    [Header("Type")]
    public bool isRaceTrigger;
    public bool islast;
    public bool isDialogTrigger;
    public bool isEndTrigger;

    [Header("Race")]
    public GameObject nextTrigger;
    public RaceMovement raceCheck;

    [Header("GameObjects")]
    public GameObject endText;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Lv3Manager>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBoat")
        {
            if (raceCheck.isActiveAndEnabled == true)
            {
                if (isRaceTrigger)
                {
                    gameObject.SetActive(false);
                    if (islast)
                    {
                        manager.PlayerBoatFinished();
                    }
                    else
                    {
                        nextTrigger.SetActive(true);
                    }
                }
            }
            if (isDialogTrigger)
            {
                GetComponent<DialogueTriggerLevelThree>().TriggerDialogue();
                gameObject.SetActive(false);
            }
            else if (isEndTrigger)
            {
                endText.SetActive(true);
            }

        }

        if(other.tag == "RaceAgent")
        {
            if (isDialogTrigger)
            {
                other.GetComponent<DialogueTriggerLevelThree>().TriggerDialogue();
            }
        }
    }
}
