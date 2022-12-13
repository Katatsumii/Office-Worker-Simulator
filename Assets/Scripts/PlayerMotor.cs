using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerMotor : MonoBehaviour
{
    private CharacterController characterController;
    private Animator anim;
    private Vector3 playerVelocity;
    private Vector3 moveDirection;
    [SerializeField] private Transform groundCheck;
    private float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundMask;
    private bool isGrounded;

    [SerializeField]
    private bool isWalking = false;
 
    private float gravity = -9.81f;
    private float gravityMultiplier = 3.0f;
    private Vector3 velocity;
    private float speed = 5f;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        isGrounded=Physics.CheckSphere(groundCheck.position,groundCheckRadius,groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        ApplyGravity();
    }
    public void ProcessMove(Vector2 input)
    {
        moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        characterController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);


    }
    private void ApplyGravity()
    {
       
        velocity.y += gravity * gravityMultiplier * Time.deltaTime;
        characterController.Move(velocity*Time.deltaTime);
        
    }
}
