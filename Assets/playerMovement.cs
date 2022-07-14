using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //VARIABLES

    [SerializeField] Transform orientation;

    public healthBar healthBar;

    public Transform player;
    public int Health = 60;

    public float movementSpeed;
    public float jumpHeight = 2f;
    public float doubleJumpCounter = 0f;

    public float normalSpeed = 6f;
    public float sprintingSpeed;
    public float crouchingSpeed;

    public float normalHeight = 1.8f;
    public float crouchedHeight = 1.25f;

    public float gravity = -9.81f;
    public float VelY = 0;

    public CharacterController controller;

    public LayerMask groundMask;
    public Transform groundDetection;

    bool isGrounded;
    bool isCrouching;
    bool isSprinting;
    bool enableMovement = true;

    Vector3 velocity;

    //VARIABLES

   

    void Start()
    {
        controller.GetComponent<CharacterController>();
        healthBar.SetMaxHealth(Health);
    }

    
    // Update is called once per frame
    void Update()
    {
        sprintingSpeed = normalSpeed + 6f;
        crouchingSpeed = normalSpeed - 3f;
        if (enableMovement == true)
        {
            CharacterMovement();
        }
        if (Health <= 0)
        {
            YouDied();
        }
        if (player.position.y < -3f)
        {
            YouDied();
        }

     

    }

    void CharacterMovement()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");

        checkIsGrounded();


        //ISGROUNDED


        if (isGrounded == false)
        {
            VelY += gravity * Time.deltaTime;
        }

        else if (isGrounded)
        {
            VelY = -2f;
            doubleJumpCounter = 0;
        }

        //JUMPMECHANICS

        if (Input.GetButtonDown("Jump") && doubleJumpCounter != 1)
        {
            doubleJumpCounter += 1;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        //SPRINTING 

        if (Input.GetButton("Shift"))
        {
            isSprinting = true;
        }

        else
        {
            isSprinting = false;
        }

        //CROUCHING

        if (Input.GetButton("Crouch"))
        {
            isCrouching = true;
        }

        else
        {
            isCrouching = false;
        }


        //MOVEMENTSPEED

        if (isSprinting == true)
        {
            movementSpeed = sprintingSpeed;
        }

        if (isCrouching == true)
        {
            movementSpeed = crouchingSpeed;
        }

        if (isCrouching == false && isSprinting == false)
        {
            movementSpeed = normalSpeed;
        }

        //CROUCHED

        if (isCrouching)
        {
            controller.height = crouchedHeight;
        }

        else
        {
            controller.height = normalHeight;
        }


        //MOVING

        Vector3 move = transform.right * X + transform.forward * Y;

        controller.Move(move * movementSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void checkIsGrounded()
    {
        Collider[] cols = Physics.OverlapSphere(groundDetection.position, 0.05f, groundMask);

        if (cols.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Virus")
        {
            Health -= 20;
            healthBar.SetHealth(Health);
        }
        if (collisionInfo.collider.name == "Plane")
        {
            normalSpeed += 3f;
        }

        if (collisionInfo.collider.name == "void")
        {
            YouDied();
        }

        if (collisionInfo.collider.name == "covidVaccine")
        {
            FindObjectOfType<GameControl>().WinGame();
            enableMovement = false;
        }

    }

    void YouDied()
    {
        FindObjectOfType<GameControl>().EndGame();
        enableMovement = false;
    }




}