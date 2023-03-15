using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovementForRecordings : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(83, 10, -30);

    }

    // Update is called once per frame
    public float speed = 1;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
