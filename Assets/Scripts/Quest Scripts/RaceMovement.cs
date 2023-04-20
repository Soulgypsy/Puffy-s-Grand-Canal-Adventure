using UnityEngine;
using UnityEngine.AI;

public class RaceMovement : MonoBehaviour
{
    public Transform goal;
    public Transform[] checkPoints;
    public int currentTarget;
    public Lv3Manager isRacing;
    public bool isDone;

    [Header("Finished")]
    public bool hasWon;
    public bool hasFinished;

    private void Start()
    {
        goal.position = checkPoints[0].position;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    public void Update()
    {
        float distance = Vector3.Distance(goal.position, transform.position);

        if (distance < 5f && isDone == false) //Distance between boat and target.
        {
            currentTarget++;
            if(currentTarget >= checkPoints.Length)
            {
                Debug.Log("Reached end of race");
                isDone = true;
            }
            else
            {
                goal.position = checkPoints[currentTarget].position;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }
            
        }  
    }
}
