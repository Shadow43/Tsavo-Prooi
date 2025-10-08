using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class AILionPatrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float range;

    [SerializeField] private Transform centrePoint;

    [SerializeField] private bool playerInRange;
    [SerializeField] private bool playerDead;
    [SerializeField] private bool stalkingRange;
    [SerializeField] private bool huntingRange;

    [SerializeField] private Transform player;
    [SerializeField] private float viewAngle;
    [SerializeField] private float viewDistance;
    [SerializeField] private int numberOfRays;
    [SerializeField] private Transform raycastStart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AIRandomMovement();
        CheckForplayerInCone();
        if (playerDead)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
    }


    //function that controls the random ai patrol movement
    public void AIRandomMovement()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, UnityEngine.Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }

    }
    void CheckForplayerInCone()
    {
        float halfAngle = viewAngle / 2f;
        float angleIncrement = viewAngle / (numberOfRays - 1);

        for (int i = 0; i < numberOfRays; i++)
        {
            float currentAngle = -halfAngle + (i * angleIncrement);
            Vector3 rayDirection = Quaternion.Euler(0, currentAngle, 0) * transform.forward;

            RaycastHit hit;
            if (Physics.Raycast(raycastStart.transform.position, rayDirection, out hit, viewDistance))
            {
                // Handle what the ray hits (e.g., check for player, obstacles)
                Debug.DrawRay(raycastStart.transform.position, rayDirection * hit.distance, UnityEngine.Color.red);
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player detected!");
                    // Trigger AI actions
                }
            }
            else
            {
                Debug.DrawRay(raycastStart.transform.position, rayDirection * viewDistance, UnityEngine.Color.green);
            }
        }
    }

bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
