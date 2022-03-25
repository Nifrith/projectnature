using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleetankController : MonoBehaviour
{

    public Animator m_Animator;

    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool groundedPlayer;
    private bool isRunning = false;
    private float playerSpeed;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float clockwise = 100.0f;
    public float counterClockwise = -100.0f;

    // Flag to know if character has been teleported or not
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
        // Check if run key is pressed
        isRunning = Run();


        Move(isRunning);
        Rotate();
        Jump();

        Attack1();
        Attack2();
    
    }



    void Move(bool isRunning){

        float vertical = Input.GetAxis ("Vertical");
        Vector3 move = new Vector3(0, 0, vertical);
        Input.GetKeyDown(KeyCode.J);
        if(isRunning){
            playerSpeed = 6.0f;
            controller.Move(transform.forward * Time.deltaTime * playerSpeed);
            m_Animator.SetFloat("speed", playerSpeed);
        } else { 
            if(vertical > 0){

            playerSpeed = 3.0f;
            controller.Move(transform.forward * Time.deltaTime * playerSpeed);
            m_Animator.SetFloat ("speed", playerSpeed);

            
            } else if (vertical < 0){

            playerSpeed = 1.7f;
            controller.Move(-transform.forward * Time.deltaTime * playerSpeed);
            m_Animator.SetFloat ("speed", playerSpeed);

             } else {
            m_Animator.SetFloat("speed", 1);
            }
        }
        

        if(vertical > 0){
            controller.Move(transform.forward * Time.deltaTime * playerSpeed);
            playerSpeed = 5.0f;
            m_Animator.SetFloat ("speed", playerSpeed);

            
        } else if (vertical < 0){
            controller.Move(-transform.forward * Time.deltaTime * playerSpeed);
            playerSpeed = 1.7f;
            m_Animator.SetFloat ("speed", playerSpeed);

        } else {
            m_Animator.SetFloat("speed", 1);
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
                    
        } 

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }


    void Attack1(){
        if(Input.GetButtonDown("Fire1")){
            m_Animator.SetFloat("attack", 1f);
        } 
    }

    void Attack2(){
        if(Input.GetButtonDown("Fire2")){
            m_Animator.SetFloat("attack", 2f);
        } 
    }

    private bool Run(){

            if (Input.GetButtonDown("Run")) {
              isRunning = true;
            }
            else if (Input.GetButtonUp("Run")) {
              isRunning = false;
            }

            return isRunning;
    }


}