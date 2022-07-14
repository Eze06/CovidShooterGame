//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WallRun : MonoBehaviour
//{
//    public LayerMask wall;

//    public Transform playerCam;
//    public Transform orientation;

//    [Header("WallRunMechanics")]
//    public float wallRunForce;
//    public float MaxWallRunTime;
//    public float maxWallSpeed;

//    bool isWallRight;
//    bool isWallLeft;
//    bool isWallRunning;

//    [Header("FOV")]
//    public float maxWallRunCameraTilt;
//    public float wallRunCameraTilt;

//    Rigidbody rb;

//    void start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    void Update()
//    {
//        CheckForWall();
//        WallRunInput();

//        if (isWallRunning)
//        {
//            if (isWallRight || isWallLeft && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) rb.AddForce(-orientation.up * jumpForce * 1f);
//            if (isWallRight && Input.GetKey(KeyCode.A)) rb.AddForce(-orientation.right * jumpForce * 3.2f);
//            if (isWallLeft && Input.GetKey(KeyCode.D)) rb.AddForce(orientation.right * jumpForce * 3.2f);
//        }

//    }

//    private void WallRunInput()
//    {
//        if (Input.GetKey(KeyCode.D) && isWallRight)
//        {
//            StartWallRun();
//        }

//        if (Input.GetKey(KeyCode.A) && isWallLeft)
//        {
//            StartWallRun();
//        }


//    }

//    private void StartWallRun()
//    {
//        rb.useGravity = false;
//        isWallRunning = true;

//        if (rb.velocity.magnitude <= maxWallSpeed)
//        {
//            rb.AddForce(orientation.forward * wallRunForce * Time.deltaTime);

//            if (isWallRight)
//            {
//                rb.AddForce(orientation.right * wallRunForce / 5 * Time.deltaTime);
//            }
//            else
//            {
//                rb.AddForce(-orientation.right * wallRunForce / 5 * Time.deltaTime);
//            }
//        }


//    }
    
//    private void StopWallRun()
//    {
//        rb.useGravity = true;
//        isWallRunning = false;
//    }

//    private void CheckForWall()
//    {
//        isWallRight = Physics.Raycast(transform.position, orientation.right, 1f, wall);
//        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 1f, wall);

//        if (!isWallLeft && !isWallRight)
//        {
//            StopWallRun();
//        }

//    }

//}