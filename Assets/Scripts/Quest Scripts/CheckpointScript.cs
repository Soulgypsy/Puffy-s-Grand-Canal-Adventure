using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckpointScript : MonoBehaviour
{
    private CheckpointArray checkpointArray;
    public MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    private void Start()
    {
        //Hide();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBoat")
        {
            checkpointArray.PlayerThroughCheckpointTransform(this);
            gameObject.SetActive(false);
        }
    }

    public void SetTrackCheckpoint(CheckpointArray checkpointArray)
    {
        this.checkpointArray = checkpointArray;
    }

    public void Hide()
    {
        meshRenderer.enabled = false;
    }
    public void Show()
    {
        meshRenderer.enabled = true;
    }
}
