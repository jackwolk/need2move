using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;



    //FIXED STUFF
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    public Transform orientation;
    float groundDrag = 5;
    [SerializeField] float speedLimit;
    [SerializeField] float airSpeedLimit;
    [SerializeField] KeyCode jumpKey;


    public GameObject Player;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float airSpeed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float Jumpforce;
    [SerializeField] private float gravity;
    public bool isFalling;
    float gravityMultiplier = 1;
    public float gravityAdder;
    public bool isDead;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        MyInput();

        if (isGrounded)
        {
            PlayerBody.drag = groundDrag;
        }
        else
        {
            PlayerBody.drag = 0;
        }
        //MovePlayer();
        //MovePlayerCamera();

        if (isFalling == true)
        {
            gravityMultiplier += gravityAdder;
        }
        else
        {
            gravityMultiplier = 1;
        }

        if(Input.GetKey(jumpKey) && isGrounded)
        {
            Jump();
        }

    }



    private void FixedUpdate()
    {
        FixedMovedPlayer();
        FixedSpeedLimit();

    }

    private void FixedSpeedLimit()
    {
        Vector3 flatVel = new Vector3(PlayerBody.velocity.x, 0f, PlayerBody.velocity.z);

        if(flatVel.magnitude > speedLimit)
        {
            Vector3 limitedVel = new Vector3(0,0,0);

            if(isGrounded == true)
            {

                limitedVel = flatVel.normalized * speedLimit;
            }
            if(isGrounded == false)
            {
                limitedVel = flatVel.normalized * airSpeedLimit;
            }

            PlayerBody.velocity = new Vector3(limitedVel.x, PlayerBody.velocity.y, limitedVel.z);
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void Jump()
    {
        PlayerBody.velocity = new Vector3(PlayerBody.velocity.x, 0f, PlayerBody.velocity.z);
        PlayerBody.AddForce(transform.up * Jumpforce, ForceMode.Impulse);
    }

    private void FixedMovedPlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        PlayerBody.AddForce(moveDirection.normalized * Speed * 5f, ForceMode.Force);
    }

}