using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [Header ("Movement")]
    public float playerSpeed;

    [Header("Inputs")]
    float verticalMovement;
    float horizontalMovement;
    

    [Header("Ground Check")]
    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Grass Check")]
    public LayerMask whatIsGrass;
    bool touchingGrass;

    [Header("Jump")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    bool canJump;


    public Transform orientation;

    Vector3 movementDirection;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //updates player movement via inputs
        playerInput();

        //updates the player's movement speed
        speedControl();

        //casts a ray to check if you are touching the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        touchingGrass = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGrass);

        if (grounded)
        {
            rb.linearDamping = groundDrag;
            canJump = true;
        }
        else
        {
            rb.linearDamping = 0;
            canJump = false;
        }

        if(touchingGrass && !grounded)
        {
            SceneManager.LoadScene("FailMenu_grass");
        }
    }

    private void FixedUpdate()
    {
        playerMovement();
    }

    void playerInput()
    {
        //assigns unity inputs to float variables
        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if(Input.GetKey(KeyCode.Space) && canJump && grounded)
        {
            canJump = false;

            jump();

            Invoke(nameof(resetJump), jumpCooldown);
        }
    }

    void playerMovement()
    {
        //takes the front and right side of orientation module, multiplies it by the movement inputs
        movementDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
        //when the player is grounded
        if (grounded)
        {
            rb.AddForce(movementDirection.normalized * playerSpeed * 10f, ForceMode.Force);
        }

        //when player is airborne
        else if (!grounded)
        {
            rb.AddForce(movementDirection.normalized * playerSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //checks if flat velocity is higher than player speed
        if(flatVel.magnitude > playerSpeed)
        {
            //limits the player's speed if needed
            Vector3 limitedVel = flatVel.normalized * playerSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void jump()
    {
        //reset the y velocity
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump()
    {
        canJump = true;
    }
}
