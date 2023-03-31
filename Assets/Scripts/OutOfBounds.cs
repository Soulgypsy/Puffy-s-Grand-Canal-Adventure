using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public Transform startPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("PlayerBoat"))
        {
            other.transform.position = startPos.position;
        }
    }
}
