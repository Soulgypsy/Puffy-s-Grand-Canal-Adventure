using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Transform harpoonLink;
    public Transform boatLink;
    public bool isVisable;

    void Update()
    {
        if (isVisable)
        {
            Vector3 midPoint = (harpoonLink.position + boatLink.position) / 2f;
            transform.position = midPoint;

            float distance = Vector3.Distance(harpoonLink.position, boatLink.position);
            transform.localScale = new Vector3(0.1f, distance / 2, 0.1f);

            transform.up = transform.position - harpoonLink.position;
        } 
    }

    public void makeInvisble()
    {
        GetComponent<MeshRenderer>().enabled = false;
        isVisable = false;
    }

    public void makeVisable()
    {
        GetComponent<MeshRenderer>().enabled = true;
        isVisable = true;
    }
}
