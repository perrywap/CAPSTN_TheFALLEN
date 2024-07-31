using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;

    Vector2 moveDirection;

    [Header("Dash Settings")]
    [SerializeField] private float _dashingSpeed = 25f;
    [SerializeField] private float dashingCooldown = 1f;
    [SerializeField] private float dashingDuration = 0.5f;
    private Vector2 _dashingDir;
    private bool _isDashing;
    private bool _canDash;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDashing)
            return;
        float moveX = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(moveX, 0f).normalized;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (_isDashing)
            return;

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); ;
    }

    private IEnumerator Dash()
    {
        _isDashing = true;
        Debug.Log("Is dashing");
        rb.velocity = new Vector2(moveDirection.x * _dashingSpeed, 0f);
        yield return new WaitForSeconds(dashingDuration);
        _isDashing = false;
    }
}
