using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IMoveable
{
    [Header("Movement Props")]
    // Movement variables
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _jumpForce = 10f;
    [SerializeField] float _acceleration = 10f;
    [SerializeField] float _deceleration = 10f;

    // Coyote time variables
    [SerializeField] float _coyoteTimeDuration = 0.2f;
    private float _coyoteTimeCounter;

    // Jump buffer variables
    [SerializeField] float _jumpBufferDuration = 0.2f;
    private float _jumpBufferCounter;

    // Jump cut variables
    [SerializeField] float _jumpCutMultiplier = 0.5f;
    private bool _isJumping;

    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Collider2D _coll;

    [Header("Ground Check")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundCheckRadius;
    [SerializeField] LayerMask _groundLayer;
    private bool _isGrounded;

    void Update()
    {
        Move();
    }

    public void Move()
    {
        // Handle horizontal movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        float targetSpeed = moveInput * _moveSpeed;
        float speedDifference = targetSpeed - _rb.velocity.x;
        
        float accelerationRate = Mathf.Abs(moveInput) > 0.1f ? _acceleration : _deceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDifference) * accelerationRate, 0.9f) * Mathf.Sign(speedDifference);
        
        _rb.velocity = new Vector2(_rb.velocity.x + movement * Time.deltaTime, _rb.velocity.y);

        // Ground check
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

        // Handle coyote time
        if (_isGrounded)
        {
            _coyoteTimeCounter = _coyoteTimeDuration;
        }
        else
        {
            _coyoteTimeCounter -= Time.deltaTime;
        }

        // Handle jump buffer
        if (Input.GetButtonDown("Jump"))
        {
            _jumpBufferCounter = _jumpBufferDuration;
        }
        else
        {
            _jumpBufferCounter -= Time.deltaTime;
        }

        // Handle jumping
        if (_jumpBufferCounter > 0f && (_isGrounded || _coyoteTimeCounter > 0f))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _jumpBufferCounter = 0f;
            _isJumping = true;
        }

        // Handle jump cut
        if (Input.GetButtonUp("Jump") && _isJumping)
        {
            if (_rb.velocity.y > 0)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * _jumpCutMultiplier);
            }
            _isJumping = false;
        }
    }
}
