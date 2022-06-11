using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent = default;
    private int destinationAttempts = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (TargetReached())
        {
            SetDestination();
        }
    }

    private bool TargetReached()
    {
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void SetDestination()
    {
        Vector3 destination = transform.position + RandomPointOnCircleEdge(3, 5);

        NavMeshPath path = new NavMeshPath();
        navMeshAgent.CalculatePath(destination, path);
        if (path.status == NavMeshPathStatus.PathComplete)
        {
            destinationAttempts = 0;
            navMeshAgent.SetDestination(destination);
        }
        else
        {
            if (destinationAttempts == 10)
            {
                Debug.LogError("Destination " + destination.ToString() + "was not reachable for " + gameObject.name + " 10 times!");
                return;
            }

            destinationAttempts++;
            Debug.LogWarning("Destination " + destination.ToString() + " was not reachable for " + gameObject.name);

            SetDestination();
        }
    }

    public static Vector3 RandomPointOnCircleEdge(float minRadius, float maxRadius)
    {
        var vector3 = Random.insideUnitSphere.normalized;
        var randomDistance = Random.Range(minRadius, maxRadius);
        return new Vector3(vector3.x, 0f, vector3.z) * randomDistance;
    }
}
