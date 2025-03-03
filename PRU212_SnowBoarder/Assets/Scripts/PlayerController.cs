using System;
using UnityEngine;

/// <summary>
/// Player Controller
/// </summary>
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    // The amount of torque applied to the player for rotation
    [SerializeField] float torqueAmount = 10f;  
    // The speed when the player is boosted
    [SerializeField] float boostSpeed = 30f;  
    // The normal movement speed of the player
    [SerializeField] float baseSpeed = 20f;  
    // The force applied when the player jumps
    [SerializeField] float jumpForce = 10f;  
    // Reference to the GroundCheck transform, used to detect if the player is on the ground
    [SerializeField] Transform groundCheck;  
    // The layer mask that defines what is considered ground
    [SerializeField] LayerMask groundLayer;  
    // The radius of the ground check area, determining how far to check for ground contact
    [SerializeField] float groundCheckRadius = 0.5f;  

    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

        if (groundCheck == null)
        {
            groundCheck = transform.Find("GroundCheck");
        }

        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck object not found! Make sure it exists in the hierarchy.");
            enabled = false;
        }
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
            Jump();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
        }
    }

    /// <summary>
    /// Check if the player is grounded
    /// </summary>
    /// <returns></returns>
    bool IsGrounded()
    {
        if (groundCheck == null) return false;

        bool grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckRadius, grounded ? Color.green : Color.red);
        Debug.Log($"IsGrounded: {grounded}");

        return grounded;
    }


    /// <summary>
    /// Respond to boost
    /// </summary>
    void RespondToBoost()
    {
        // If the player is not on a surface effector, return
        if (surfaceEffector2D == null) return;

        // If the player is on a surface effector, respond to boost
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        // If the player is not pressing the up arrow key, set the speed back to the base speed
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
