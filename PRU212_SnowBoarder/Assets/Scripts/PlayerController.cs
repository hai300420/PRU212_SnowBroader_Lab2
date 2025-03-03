using System;
using UnityEngine;

/// <summary>
/// Player Controller
/// </summary>
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float spinTorque = 20f;
    [SerializeField] float boostSpeed = 30f; 
    [SerializeField] float baseSpeed = 20f; 

    bool canMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the "Rigidbody2D" Component
        rb2d = GetComponent<Rigidbody2D>();

        // Get the "SurfaceEffector2D" Component
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }
    
    /// <summary>
    /// Disable player controls
    /// </summary>
    public void DisableControls()
    { 
        // Set "Can Move" to "False"
        canMove = false;
    }
    
    /// <summary>
    /// Rotate the player
    /// </summary>
    void RotatePlayer()
    {
        // If the "Space" Key is "Pressed"
        if (Input.GetKey(KeyCode.Space))
        {
            // "Apply" a "Force" to "Spin" the "Player"
            rb2d.AddTorque(spinTorque);
        }

        // Otherwise, If the "Left Arrow" Key is "Pressed"
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // "Apply" a "Force" to "Rotate Left" the "Player"
            rb2d.AddTorque(torqueAmount);
        }
        
        // Otherwise, If the "Right Arrow" Key is "Pressed"
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // "Apply" a "Force" to "Rotate Right" the "Player"
            rb2d.AddTorque(-torqueAmount);
        }
    }

    /// <summary>
    /// Respond to the player boosting
    /// </summary>
    void RespondToBoost()
    {
        // If the "Up Arrow" Key is "Pressed"
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // "Access" the "Surface Effector 2D" Component
            surfaceEffector2D.speed = boostSpeed;
        }
 
        // Otherwise, If the "Up Arrow" Key is "Not Pressed"
        else
        {
            // "Access" the "Surface Effector 2D" Component
            surfaceEffector2D.speed = baseSpeed;
        }       
    }
}
