using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleetankController : MonoBehaviour
{

    public Animator m_Animator;

    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float clockwise = 100.0f;
    public float counterClockwise = -100.0f;

    public bool hasTeleported = false;
    
    

    private void Start()
    {   
        m_Animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        controller.center = new Vector3(0, 1, 0);
        controller.detectCollisions = true;
        
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        } 
        
    Move();
    Rotate();
    Jump();

    Attack1();
    Attack2();
    
    }



    void Move(){

        float vertical = Input.GetAxis ("Vertical");

        Vector3 move = new Vector3(0, 0, vertical);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasVerticalInput;
        bool isRunning = hasVerticalInput;

        if(vertical > 0){
            controller.Move(transform.forward * Time.deltaTime * playerSpeed);
            playerSpeed = 5.0f;
            m_Animator.SetBool ("isWalking", isWalking);
        } else if (vertical < 0){
            controller.Move(-transform.forward * Time.deltaTime * playerSpeed);
            playerSpeed = 1.3f;
            m_Animator.SetBool ("isWalkingBackwards", isWalking);
            
        }

    }

    void Rotate(){
        float horizontal = Input.GetAxis ("Horizontal");
        bool hasHorizontalInput = Mathf.Approximately (horizontal, 0f);
        
        if (horizontal < 0)
        {
            transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
        } else if (horizontal > 0){
            transform.Rotate(0, Time.deltaTime * clockwise, 0);
        }
    }

    void Jump(){

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            m_Animator.SetBool("isWalking", false);
                    
        } 

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }


    void Attack1(){
        if(Input.GetButtonDown("Fire1")){
            m_Animator.SetTrigger("Attack1");
        } 
    }

    void Attack2(){
        if(Input.GetButtonDown("Fire2")){
            m_Animator.SetTrigger("Attack2");
        } 
    }

  


}