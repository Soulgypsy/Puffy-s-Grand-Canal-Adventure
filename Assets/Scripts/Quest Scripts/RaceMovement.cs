using UnityEngine;
using UnityEngine.AI;

public class RaceMovement : MonoBehaviour
{
    public Transform goal;
    public GameObject dialogueBoat;
    public GameObject speedBoat;
    public Transform[] checkPoints;
    public int currentTarget;
    public Lv3Manager isRacing;
    public bool isDone;
    public Transform transformPlayer;
    public bool startCounter;
    public bool navStart;
    public float countdown = 5f;
    public int countdownInt;
    public UiManager raceUI;

    [Header("Finished")]
    public bool hasWon;
    public bool hasFinished;

    private void Start()
    {
        navStart = false;
        speedBoat.SetActive(true);
        dialogueBoat.SetActive(false);

        gameObject.transform.position = new Vector3(529, -18, -59);
        gameObject.transform.eulerAngles = new Vector3(0, 228, 0);
        transformPlayer.position = new Vector3(521, -16, -37);
        transformPlayer.eulerAngles = new Vector3(0, -132, 0);
        startCounter = true;
    }

    public void Update()
    {

        if (startCounter == true)
        {
            raceUI.countdownRace.enabled = true;
            if (countdown >= 0)

                countdown -= Time.deltaTime;
            countdownInt = Mathf.RoundToInt(countdown);
            raceUI.countdownRace.text = "Race starts in... " + countdownInt.ToString() + "!";
            if (countdown <= 0)
            {
                startCounter = false;
                navStart = true;
            }
        }
        else
        {
            countdown = 5;
            raceUI.countdownRace.enabled = false;
            if (navStart == true)
            {
                GetNavAgent();
            }
            navStart = false;
        }

        float distance = Vector3.Distance(goal.position, transform.position);

        if (startCounter == false)
        {
            if (distance < 5f && isDone == false) //Distance between boat and target.
            {
                currentTarget++;

                if (currentTarget >= checkPoints.Length)
                {
                    Debug.Log("Reached end of race");
                    isDone = true;
                    if (isRacing.playerBoatwon == false)
                    {
                        hasWon = true;
                        GetComponent<DialogueTriggerLevelThree>().TriggerDialogue();
                        navStart = true;
                    }
                    else
                    {
                        hasFinished = true;
                    }
                }
            }
            else
            {
                goal.position = checkPoints[currentTarget].position;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }


            if (isDone == true)
            {
                if (hasWon == true)
                {
                    if (navStart == true)
                    {
                        GetNavAgent();
                    }

                    gameObject.transform.position = new Vector3(529, -18, -59);
                    gameObject.transform.eulerAngles = new Vector3(0, 228, 0);
                    transformPlayer.position = new Vector3(521, -16, -37);
                    transformPlayer.eulerAngles = new Vector3(0, -132, 0);
                    startCounter = true;
                    isDone = false;
                    hasWon = false;
                }
            }
        }
    }

    public void GetNavAgent()
    {
        goal.position = checkPoints[0].position;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}
