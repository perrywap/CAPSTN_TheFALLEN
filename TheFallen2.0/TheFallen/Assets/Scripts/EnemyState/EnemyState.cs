using System.Collections;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float jumpForce = 1.5f;
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform _groundCheck; // Transform for ground check position
    [SerializeField] private LayerMask _groundLayer; // LayerMask for the ground layer
    [SerializeField] private float patrolPauseDuration = 2f; // Duration to pause at patrol points

    private Rigidbody2D rb;
    private Transform player;
    private Transform currentPoint;
    private Animator anim;
    private bool isChasing = false;
    private bool isGrounded = false;
    private bool isPatrolling = true;
    private bool facingRight = true;

    void Start()
    {
        currentPoint = pointB?.transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (pointA == null || pointB == null)
        {
            Debug.LogError("Point A or Point B is not assigned in the Inspector");
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

        CheckGrounded();
        UpdateAnimation(); // Added this to ensure animation update is called
    }

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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

        Flip(direction.x);
    }

    private IEnumerator PatrolPause()
    {
        isPatrolling = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(patrolPauseDuration);
        isPatrolling = true;
    }

    private void ChasePlayer()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        if (isGrounded && ShouldJumpTowardsPlayer(direction))
        {
            Debug.Log("Jumping towards player!");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        Flip(direction.x);
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
    }

    private void UpdateAnimation()
    {
        if (rb.velocity.x != 0)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);
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
