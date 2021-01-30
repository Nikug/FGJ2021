using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveTo : MonoBehaviour
{

    NavMeshAgent agent;
    public float radius;
    public bool enableAgentOnTouch = false;
    public string floorTag;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(RandomNavmeshLocation(radius));

    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.enabled) return;

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    agent.SetDestination(RandomNavmeshLocation(radius));
                }
            }
        }
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public void DisableAgent()
    {
        agent.enabled = false;
    }

    public void EnableAgent()
    {
        agent.enabled = true;
        agent.Warp(transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (agent is null) return;

        if (!agent.enabled && enableAgentOnTouch)
        {
            if (collision.gameObject.tag == floorTag)
            {
                EnableAgent();
                enableAgentOnTouch = false;
            }
        }
    }
}
