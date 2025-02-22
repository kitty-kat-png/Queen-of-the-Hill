using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Header("Horizontal Movement Setings")]
    [SerializeField] private float walkSpeed = 1;

    [Header("Vertical Movement Settings")]
    [SerializeField] private float jumpForce = 45;
    private int jumpBufferCounter = 0;
    [SerializeField] private int jumpBufferFrames;
    private float coyoteTimeCounter = 0;
    [SerializeField] private float coyoteTime;
    private int airJumpCounter = 0;
    [SerializeField] private int maxAirJumps;

    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckY = 0.2f;
    [SerializeField] private LayerMask whatisGround;
    [SerializeField] private float groundCheckX = 0.5f;

    PlayerStateList pState;
    private Rigidbody2D rb;
    private float xAxis;
    Animator anim;

    public static PlayerController Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pState = GetComponent<PlayerStateList>();

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        UpdateJumpVariables();
        Move();
        Jump();
        Flip();
    }

    void GetInputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    void Flip()
    {
        if (xAxis < 0)
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (xAxis > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }
    private void Move()
    {
        rb.velocity = new Vector2(walkSpeed * xAxis, rb.velocity.y);
        anim.SetBool("Walking", rb.velocity.x != 0 && Grounded());
    }
    public bool Grounded()
    {

        if (Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatisGround)
            || Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatisGround)
            || Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatisGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Jump()
    {
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);

            pState.jumping = false;
        }
        if (!pState.jumping)
        {
            if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce);

                pState.jumping = true;
            }
            else if (!Grounded() && airJumpCounter < maxAirJumps && Input.GetButtonDown("Jump"))
            {
                pState.jumping = true;
                airJumpCounter++;
                rb.velocity = new Vector3(rb.velocity.x, jumpForce);
            }
        }

        anim.SetBool("Jumping", !Grounded());
    }
    void UpdateJumpVariables()
    {
        if (Grounded())
        {
            pState.jumping = false;
            coyoteTimeCounter = coyoteTime;
            airJumpCounter = 0;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferFrames;
        }
        else
        {
            jumpBufferCounter--;
        }
    }
}
