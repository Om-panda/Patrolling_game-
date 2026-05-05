using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;

    // 🟢 Patrol points
    public Transform[] waypoints;
    private int nextWaypoint = 0;

    // 🔴 Player
    public Transform player;

    // 🔥 Detection
    public float detectionRange = 10f;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // 🔥 IMPORTANT for 2D
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = moveSpeed;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            // 🔴 Chase player
            agent.SetDestination(player.position);
        }
        else
        {
            // 🟢 Patrol
            Patrol();
        }
    }

    void Patrol()
    {
        if (waypoints.Length == 0 || waypoints[nextWaypoint] == null)
            return;

        agent.SetDestination(waypoints[nextWaypoint].position);

        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            nextWaypoint++;

            if (nextWaypoint >= waypoints.Length)
            {
                nextWaypoint = 0;
            }
        }
    }
}
