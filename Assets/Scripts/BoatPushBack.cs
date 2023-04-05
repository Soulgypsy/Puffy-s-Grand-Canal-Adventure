using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatPushBack : MonoBehaviour
{
    [Header("Force")]
    public Transform forceDir;
    public float forcePower;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerBoat")
        {          
            other.GetComponent<Rigidbody>().AddForce(forceDir.forward * forcePower * Time.deltaTime, ForceMode.Acceleration);
        }
        
    }


}
