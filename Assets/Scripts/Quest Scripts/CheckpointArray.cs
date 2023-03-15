using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckpointArray : MonoBehaviour
{
    public List<CheckpointScript> checkpointArray;
    private int nextCheckpointIndex;
    public Transform agentGoal;
    public Transform checkpointTransform;

    private void Awake()
    {
        Transform checkpointTransform = transform.Find("Checkpoints");
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        foreach (Transform checkpointSingleTransform in checkpointTransform)
        {
            Debug.Log(checkpointSingleTransform);
            CheckpointScript checkpoint = checkpointSingleTransform.GetComponent<CheckpointScript>();
            checkpoint.SetTrackCheckpoint(this);
            checkpointArray.Add(checkpoint);
        }

        nextCheckpointIndex = 0;
    }

    public void Update()
    {
        if (nextCheckpointIndex != checkpointArray.Count)
        {
            checkpointArray[nextCheckpointIndex].meshRenderer.enabled = true;
        }
    }

    public void PlayerThroughCheckpointTransform(CheckpointScript checkpoint)
    {
        if (checkpointArray.IndexOf(checkpoint) == nextCheckpointIndex)
        {
            //correct checkpoint
            Debug.Log("Correct");
            checkpointArray[nextCheckpointIndex].meshRenderer.enabled = false;
            nextCheckpointIndex++;
            if (nextCheckpointIndex == checkpointArray.Count)
            {
                Debug.Log("win");
            }
        }
        else
        {
            //incorrect checkpoint
            Debug.Log("Incorrect");
        }
    }

}
