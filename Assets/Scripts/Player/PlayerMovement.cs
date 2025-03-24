using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header ("Movement")]
    public float playerSpeed;

    [Header("Inputs")]
    float verticalMovement;
    float horizontalMovement;
    float jumpMovement;

    [Header("Ground Check")]
    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


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
        //casts a ray to check if you are touching the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if(grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
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
        jumpMovement = Input.GetAxisRaw("Jump");
    }

    void playerMovement()
    {
        //takes the front and right side of orientation module, multiplies it by the movement inputs
        movementDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
        rb.AddForce(movementDirection.normalized * playerSpeed * 10f, ForceMode.Force);
    }

}
