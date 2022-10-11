using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput ; 
    public CharacterController player; 
    public Dialog dialog;
    public float playerSpeed ; 
    public float playerSpeedFixed;
    public Camera mainCamera; 
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer ;
    public float gravity= 9.8f;

    public Animator animator;


    void Start()
    {
        player = GetComponent<CharacterController>();
        dialog = FindObjectOfType<Dialog>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialog.didDialogueStart){
            playerSpeed = 0f ; 
        }else{
            playerSpeed = playerSpeedFixed ;

        }

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove , 0 , verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput , 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        player.Move(movePlayer* playerSpeed * Time.deltaTime );

        if(playerInput.magnitude >=0.1f){
         animator.SetFloat("Blend", 1);
        }else{
            animator.SetFloat("Blend", 0 );
        }

    }

    void camDirection(){
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized ;
        camRight = camRight.normalized ; 

    }

    void SetGravity(){
        movePlayer.y = -gravity ;
    }
}

    
