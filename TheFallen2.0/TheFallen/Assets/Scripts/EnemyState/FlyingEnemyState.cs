using System.Collections;
using UnityEngine;

public class FlyingEnemyState : MonoBehaviour
{
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float patrolPauseDuration = 2f; // Duration to pause at patrol points

    private Transform player;
    private Transform currentPoint;
    private bool isChasing = false;
    private bool isPatrolling = true;
    private bool facingRight = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        currentPoint = pointB;

        if (pointA == null || pointB == null)
        {
            Debug.LogError("Point A or Point B is not assigned in the Inspector");
        }

        if (player == null)
        {
            Debug.LogError("Player not found. Ensure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        // Calculate distance to player
        float distanceToPlayer = player != null ? Vector2.Distance(transform.position, player.position) : Mathf.Infinity;

        Debug.Log($"Distance to Player: {distanceToPlayer}");

        if (distanceToPlayer <= attackRange && player != null)
        {
            Debug.Log("Player within attack range.");
            // Attack player if within attack range
            AttackPlayer();
        }
        else if (distanceToPlayer <= detectionRange && player != null)
        {
            Debug.Log("Player within detection range.");
            // Chase player if within detection range
            isChasing = true;
            ChasePlayer();
        }
        else
        {
            // Stop chasing if player is out of detection range
            isChasing = false;
            if (isPatrolling)
            {
                Patrol();
            }
        }
    }

    private void Patrol()
    {
        if (currentPoint == null) return;

        Vector2 direction = (currentPoint.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            currentPoint = currentPoint == pointB ? pointA : pointB;
            StartCoroutine(PatrolPause());
        }

        Flip(direction.x);
    }

    private IEnumerator PatrolPause()
    {
        isPatrolling = false;
        yield return new WaitForSeconds(patrolPauseDuration);
        isPatrolling = true;
    }

    private void ChasePlayer()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        Flip(direction.x);
    }

    private void AttackPlayer()
    {
        Debug.Log("Attacking player!");
    }

    private void Flip(float directionX)
    {
        if (directionX > 0 && !facingRight || directionX < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.DrawWireSphere(pointA.position, 0.5f);
            Gizmos.DrawWireSphere(pointB.position, 0.5f);
            Gizmos.DrawLine(pointA.position, pointB.position);
        }
    }
}
