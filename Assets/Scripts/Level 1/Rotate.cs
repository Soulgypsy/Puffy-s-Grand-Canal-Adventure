using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime * speed);
    }
}
