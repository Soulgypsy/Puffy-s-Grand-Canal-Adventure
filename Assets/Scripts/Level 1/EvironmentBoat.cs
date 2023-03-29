using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvironmentBoat : MonoBehaviour
{
    [Header("Boat Movement")]
    public Transform boatfinish;
    public bool isMoving;
    public float speed;

    void Update()
    {
        if (isMoving)
        {
            float distance = Vector3.Distance(transform.position, boatfinish.position);
            transform.position = Vector3.MoveTowards(transform.position, boatfinish.position, speed * Time.deltaTime);

            if (distance < 0.02)
            {
                isMoving = false;
            }
        }
        
    }
}
