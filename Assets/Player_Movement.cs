﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Movement related variables
    public float moveSpeed;  //Our general move speed. This is effected by our
                             //InputManager > Horizontal button's Gravity and Sensitivity
                             //Changing the Gravity/Sensitivty will in turn result in more loose or tighter control

    public float sprintMultiplier;   //How fast to multiply our speed by when sprinting
    public float sprintDelay;        //How long until our sprint kicks in
    private float sprintTimer;       //Used in calculating the sprint delay
    private bool jumpedDuringSprint; //Used to see if we jumped during our sprint

    //Jump related variables
    public float initialJumpForce;       //How much force to give to our initial jump
    public float extraJumpForce;         //How much extra force to give to our jump when the button is held down
    public float maxExtraJumpTime;       //Maximum amount of time the jump button can be held down for
    public float delayToExtraJumpForce;  //Delay in how long before the extra force is added
    private float jumpTimer;             //Used in calculating the extra jump delay
    private bool playerJumped;           //Tell us if the player has jumped
    private bool playerJumping;          //Tell us if the player is holding down the jump button
    public Transform groundChecker;      //Gameobject required, placed where you wish "ground" to be detected from
    public bool isGrounded;             //Check to see if we are grounded
    public bool isGrounded2;             //Check to see if we are grounded
    private Rigidbody2D rigidbody2D;
    public Transform groundCaster;
    float StartingGravMod;
    float StartingDragMod;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (CP_Manager.currentCP_Position != null)
        {
            transform.position = CP_Manager.currentCP_Position;
        }
        StartingGravMod = rigidbody2D.gravityScale;
    }
    void Update()
    {
        //Casts a line between our ground checker gameobject and our player
        //If the floor is between us and the groundchecker, this makes "isGrounded" true
        isGrounded2 = Physics2D.Linecast(groundCaster.position, groundChecker.position, 1 << LayerMask.NameToLayer("Floor"));
        isGrounded = Physics2D.OverlapCircle(groundCaster.position, .18f, 1 << LayerMask.NameToLayer("Floor"));

        isGrounded = isGrounded || isGrounded2;


        if(!isGrounded && rigidbody2D.velocity.y < 0 && Input.GetButton("Jump"))
        {
            rigidbody2D.gravityScale = StartingGravMod * .3f;
            rigidbody2D.drag = StartingDragMod * 10;
        }
        else
        {
            rigidbody2D.gravityScale = StartingGravMod;
            rigidbody2D.drag = StartingDragMod;
        }
        //If our player hit the jump key, then it's true that we jumped!
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Try Jump");
            playerJumped = true;   //Our player jumped!
            playerJumping = true;  //Our player is jumping!
            jumpTimer = Time.time; //Set the time at which we jumped
        }

        //If our player lets go of the Jump button OR if our jump was held down to the maximum amount...
        if (Input.GetButtonUp("Jump") || Time.time - jumpTimer > maxExtraJumpTime)
        {
            playerJumping = false; //... then set PlayerJumping to false
        }

        //If our player hit a horizontal key...
        if (Input.GetButtonDown("Horizontal"))
        {
            sprintTimer = Time.time;  //.. reset the sprintTimer variable
            jumpedDuringSprint = false;  //... change Jumped During Sprint to false, as we lost momentum
        }
    }

    void FixedUpdate()
    {

        //If our player is holding the sprint button, we've held down the button for a while, and we're grounded...
        //OR our player jumped while we were already sprinting...
        if (Input.GetButton("Sprint") && Time.time - sprintTimer > sprintDelay && isGrounded || jumpedDuringSprint)
        {
            //... then sprint
            rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime * sprintMultiplier, rigidbody2D.velocity.y);

            //If our player jumped during our sprint...
            if (playerJumped)
            {
                jumpedDuringSprint = true; //... tell the game that we jumped during our sprint!
                                           //This is a tricky one. Basically, if we are already sprinting and our player jumps, we want them to hold their
                                           //momentum. Since they are no longer grounded, we would not longer return true on a regular sprint because
                                           //the build-up of sprint requires the player to be grounded. Likewise, if our player presses another horizontal
                                           //key, the jumpedDuringSprint would be set to false in our Update() function, thus causing a "loss" in momentum.
            }
        }
        else
        {
            //If we're not sprinting, then give us our general momentum
            rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, rigidbody2D.velocity.y);
        }

        //If our player pressed the jump key...
        if (playerJumped)
        {
            Debug.Log("Player Jump");
            if(true || rigidbody2D.velocity.y < 0)
            {
                rigidbody2D.velocity = Vector2.Scale(rigidbody2D.velocity, new Vector2(1, 0));
            }
            rigidbody2D.AddForce(new Vector2(0, initialJumpForce)); //"Jump" our player up in the air!
            playerJumped = false; //Our player already jumped, so no need to jump again just yet
        }

        //If our player is holding the jump button and a little bit of time has passed...
        if (playerJumping && Time.time - jumpTimer > delayToExtraJumpForce)
        {
            rigidbody2D.AddForce(new Vector2(0, extraJumpForce)); //... then add some additional force to the jump
        }
    }
    }



