using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggers : MonoBehaviour
{
    public BoatTutorial boatTutorial;
    public bool isHarpoonTrigger;
    public bool isExitTrigger;
    public bool isFirstTrigger;

    public void OnTriggerEnter(Collider other)
    {
        if (isHarpoonTrigger)
        {
            gameObject.SetActive(false);
            boatTutorial.equipHarpoon();
        }
        else if (isExitTrigger)
        {
            boatTutorial.exitTrigger();
        }
        else
        {
            if (other.tag == "PlayerBoat")
            {
                boatTutorial.partSelect();

                if (isFirstTrigger)
                    boatTutorial.moveBoat();
            }
        }
        
    }
}
