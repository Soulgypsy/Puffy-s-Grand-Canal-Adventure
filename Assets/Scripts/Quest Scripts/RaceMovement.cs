using UnityEngine;
using UnityEngine.AI;

public class RaceMovement : MonoBehaviour
{
    public Transform goal;

    private void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}
