using System.Collections;
using UnityEngine;

public class EnemyAI : EnemyBaseClass
{
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float jumpForce = 1.5f; 
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private Transform _groundCheck; // Transform for ground check position
    [SerializeField] private LayerMask _groundLayer; // LayerMask for the ground layer
    [SerializeField] private float patrolPauseDuration = 2f; // Duration to pause at patrol points

    private Rigidbody2D rb;
    private Transform player;
    private Transform currentPoint;
    private bool isChasing = false;
    private bool isGrounded = false;
    private bool isPatrolling = true; // To check if the enemy is patrolling

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        currentPoint = pointB?.transform;
        rb = GetComponent<Rigidbody2D>();

        if (pointA == null || pointB == null)
        {
            Debug.LogError("Point A or Point B is not assigned in the Inspector");
        }

        if (player == null)
        {
            Debug.LogError("Player not found. Ensure the player has the 'Player' tag.");
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found. Ensure the object has a Rigidbody2D component.");
        }

        if (_groundCheck == null)
        {
            Debug.LogError("_groundCheck is not assigned in the Inspector");
        }
    }

    protected override void Update()
    {
        if (HP <= 0)
        {
            Die();
            return;
        }

        float distanceToPlayer = player != null ? Vector2.Distance(transform.position, player.position) : Mathf.Infinity;

        if (distanceToPlayer <= attackRange && player != null)
        {
            AttackPlayer();
        }
        else if (distanceToPlayer <= detectionRange && player != null)
        {
            isChasing = true;
            ChasePlayer();
        }
        else
        {
            isChasing = false;
            if (isPatrolling)
            {
                Patrol();
            }
        }

        CheckGrounded();
    }

    private void Patrol()
    {
        if (currentPoint == null) return;

        Vector2 direction = (currentPoint.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            currentPoint = currentPoint == pointB.transform ? pointA.transform : pointB.transform;
            StartCoroutine(PatrolPause());
        }
    }

    private IEnumerator PatrolPause()
    {
        isPatrolling = false; 
        rb.velocity = Vector2.zero; // Stop enemy movement
        yield return new WaitForSeconds(patrolPauseDuration); 
        isPatrolling = true; 
    }

    private void ChasePlayer()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        // Check if the enemy needs to jump to reach the player
        if (isGrounded && ShouldJumpTowardsPlayer(direction))
        {
            Debug.Log("Jumping towards player!");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool ShouldJumpTowardsPlayer(Vector2 direction)
    {
        return direction.y > 0.5f;
    }

    private void CheckGrounded()
    {
        isGrounded = IsGrounded();
        Debug.Log($"Is Grounded: {isGrounded}");
    }

    private bool IsGrounded()
    {
        bool grounded = Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
        Debug.Log($"Ground Check: {grounded}");
        return grounded;
    }

    private void AttackPlayer()
    {
        Debug.Log("Attacking player!");
        // Add your attack logic here
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
    }

    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
            Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
            Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
        }

        if (_groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_groundCheck.position, 0.2f);
        }
    }
}
