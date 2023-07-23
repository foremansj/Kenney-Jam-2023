using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody playerRigidbody;
    Animator playerAnimator;
    CollisionHandler collisionHandler;
    //bool isTouchingGround;
    
    
    [Header("Movement")]
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpHeight = 10f;
    Vector3 moveInput;
    bool isJumping;
    
    [Header("Ground Check")]
    [SerializeField] GameObject orientor;
    //[SerializeField] float groundCheckDistance = 2f; 
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        collisionHandler = GetComponent<CollisionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, moveInput.x * rotateSpeed * Time.deltaTime, 0);
        ProcessRunning();
        ProcessJumping();
        //GroundCheck();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        isJumping = !isJumping;
    }

    void ProcessRunning()
    {
        if(Input.GetKey(KeyCode.W))
        {
            ApplyMovement(moveSpeed);
            playerAnimator.SetBool("isRunning", true);
            playerAnimator.SetFloat("Direction", 1);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            ApplyMovement(-moveSpeed);
            playerAnimator.SetBool("isRunning", true);
            playerAnimator.SetFloat("Direction", -1);
        }

        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
    }

    void ApplyMovement(float movementThisFrame)
    {
        playerRigidbody.transform.Translate(Vector3.forward * movementThisFrame * Time.deltaTime);
        //playerRigidbody.velocity += Vector3.forward * movementThisFrame * Time.deltaTime;
    }

    void ProcessJumping()
    {
        if(isJumping)
        {
            playerAnimator.SetBool("isJumping", true);
            playerRigidbody.transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
            //playerRigidbody.velocity += Vector3.up * jumpHeight * Time.deltaTime;
        }
        
        else
        {
            playerAnimator.SetBool("isJumping", false);
        }
    }

    public void ChangeMoveSpeed(bool fast)
    {
        if(fast)
        {
            moveSpeed = 75f;
        }

        if(!fast)
        {
            moveSpeed = 15f;
        }
    }

    public void ChangeJumpHeight(bool keanu)
    {
        if(keanu)
        {
            jumpHeight = 100f;
        }

        if(!keanu)
        {
            jumpHeight = 10f;
        }
    }

    /*void GroundCheck()
    {
        if(Physics.Raycast(orientor.transform.position, Vector3.down, groundCheckDistance))
        {
            isTouchingGround = true;
            Debug.Log("Ray hit");
        }

        else
        {
            isTouchingGround = false;
            Debug.Log("Ray missss");
        }
    }*/

}
