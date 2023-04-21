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

    [Header("Race")]
    public GameObject nextTrigger;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Lv3Manager>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBoat")
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
            if (isDialogTrigger)
            {
                GetComponent<DialogueTriggerLevelThree>().TriggerDialogue();
                gameObject.SetActive(false);
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
