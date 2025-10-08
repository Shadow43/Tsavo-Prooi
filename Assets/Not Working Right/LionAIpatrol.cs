using UnityEngine;
using UnityEngine.AI;

public class LionAIpatrol : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    //Patrol

    [SerializeField] Vector3 destPoint;
    bool patrolPointSet;
    [SerializeField] float walkRrange;
    [SerializeField] float destPointReached = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!patrolPointSet) SearchForDest();
        if (patrolPointSet) agent.SetDestination(destPoint);
        if(Vector3.Distance(transform.position, destPoint) < destPointReached) patrolPointSet = false;
    }

    void SearchForDest()
    {
        float z = Random.Range(-walkRrange, walkRrange);
        float x = Random.Range(-walkRrange, walkRrange);

        destPoint = transform.position + new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            patrolPointSet = true;
        }
    }
}
