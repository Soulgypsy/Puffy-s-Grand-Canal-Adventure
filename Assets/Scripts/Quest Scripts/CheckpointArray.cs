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
        //Transform checkpointTransform = transform.Find("Checkpoints");
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

    public void PlayerThroughCheckpointTransform(CheckpointScript checkpoint)
    {
        if (checkpointArray.IndexOf(checkpoint) == nextCheckpointIndex)
        {
            //correct checkpoint
            Debug.Log("Correct");
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
    public void AgentThroughCheckpointTransform(CheckpointScript checkpoint)
    {
        if (checkpointArray.IndexOf(checkpoint) == nextCheckpointIndex)
        {
            //correct checkpoint
            Debug.Log("Correct");
            nextCheckpointIndex++;
            agentGoal.position = checkpoint.gameObject.transform.position;
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
