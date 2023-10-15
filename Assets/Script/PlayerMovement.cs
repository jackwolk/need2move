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


    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;
    private float yRot;


    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float airSpeed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float Jumpforce;
    [SerializeField] private float speedLimit;
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

        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        //MovePlayerCamera();

        if (isFalling == true)
        {
            gravityMultiplier += gravityAdder;
        }
        else
        {
            gravityMultiplier = 1;
        }


    }

    private void MovePlayer()
    {

        PlayerBody.AddForce(Vector3.down * Time.deltaTime * 10, ForceMode.Force);

        if (PlayerBody.velocity.magnitude < speedLimit && isGrounded)
        {
            Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
            Vector3 Velocity = new Vector3(MoveVector.x, MoveVector.y, MoveVector.z);
            PlayerBody.AddForce(Velocity, ForceMode.Force);
        }
        else if(PlayerBody.velocity.magnitude < speedLimit && !isGrounded)
        {
           Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * airSpeed;
           Vector3 Velocity = new Vector3(MoveVector.x, MoveVector.y, MoveVector.z);
           PlayerBody.AddForce(Velocity, ForceMode.Force);
        }

        if(PlayerBody.velocity.magnitude > speedLimit && isGrounded)
        {
            PlayerBody.velocity = Vector3.ClampMagnitude(PlayerBody.velocity, speedLimit);
        }



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            PlayerBody.AddForce(Vector2.up * Jumpforce, ForceMode.Impulse);
        }



        //PlayerBody.AddForce(Vector3.down * gravity * gravityMultiplier , ForceMode.Force);

        if (PlayerBody.velocity.y < 0)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }



    }

}