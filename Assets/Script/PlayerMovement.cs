using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject Player;
    [Space]
    [Header("Checking Ground")]
    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Space]

    [Header("New Movement")]
    //FIXED STUFF
    public float horizontalInput;
    public float verticalInput;
    public Vector3 moveDirection;
    public Transform orientation;
    public float groundDrag = 5;
    public float speedLimit;
    public float airSpeedLimit;
    public KeyCode jumpKey;
    public float airMultiplier;
    public float jumpCooldown;

    [Space]
    [Header("Camera Stuff")]
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [Space]

    [Header("Jumping/Gravity")]
    [SerializeField] private float Speed;
    [SerializeField] private float airSpeed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float Jumpforce;
    [SerializeField] private float gravity;
    public bool canJump = true;
    
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


        if (Input.GetKey(jumpKey) && isGrounded && canJump == true)
        {
            canJump = false;

            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void Jump()
    {
        
        PlayerBody.velocity = new Vector3(PlayerBody.velocity.x, 0f, PlayerBody.velocity.z);
        PlayerBody.AddForce(transform.up * 20, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        canJump = true;
    }

    private void FixedMovedPlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (isGrounded)
        {

            PlayerBody.AddForce(moveDirection.normalized * Speed * 5f, ForceMode.Force);
        }
        else
        {
            PlayerBody.AddForce(moveDirection.normalized * Speed * 5f * airMultiplier, ForceMode.Force);
        }
    }

}