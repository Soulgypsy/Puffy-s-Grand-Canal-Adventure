using UnityEngine;
using UnityEngine.AI;

public class RaceMovement : MonoBehaviour
{
    public Transform goal;
    public Transform[] checkPoints;
    public int currentTarget;
    public Lv3Manager isRacing;

    private void Start()
    {
        goal.position = checkPoints[0].position;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    public void Update()
    {
        float distance = Vector3.Distance(goal.position, transform.position);

        if (distance < 5f) //Distance between boat and target.
        {
            currentTarget++;
            goal.position = checkPoints[currentTarget].position;
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position;
        }  
    }
}
