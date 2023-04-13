using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv3Triggers : MonoBehaviour
{
    [Header("Scripts")]
    private Lv3Manager manager;

    [Header("Type")]
    public bool isRaceTrigger;
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
                nextTrigger.SetActive(true);
                gameObject.SetActive(false);
            }
            else if (isDialogTrigger)
            {
                manager.StartRaceDialog();
            }
        }
        
    }
}
