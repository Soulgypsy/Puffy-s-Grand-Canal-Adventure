using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullableObject : MonoBehaviour
{
    public GameObject boat;
    public Transform startPosition;
    public float breakDistance;
    public float pullforce;
    public bool startMoving;
    private Rigidbody rb;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if(startMoving == true)
        {
            //Debug.Log("Hit");
        }
    }

    public void moveTowardsBoat()
    {

    }
}
