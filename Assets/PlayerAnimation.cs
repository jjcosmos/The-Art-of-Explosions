using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D playerRB;
    public Animator animator;
    
    float horizontalMove;
    public bool facingRight;
    bool falling;
    bool jumping;
    public Player_Movement mover;
    void Start()
    {
        falling = false;
        jumping = false;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0.001)
        {
            facingRight = true;
            transform.localScale = new Vector2(1, 1);
        }
        else if(Input.GetAxis("Horizontal")< - .001)
        {
            facingRight = false;
            transform.localScale = new Vector2(-1, 1);
        }


        if (Input.GetButtonDown("Jump") && !jumping && mover.isGrounded)
        {
            animator.SetBool("isJumping", true);
            jumping = true;
        }
        if(playerRB.velocity.y < -1.1f && !falling)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
            falling = true;
            jumping = false;
        }

        if (playerRB.velocity.y < 0f && mover.isGrounded)
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", false);
            falling = false;
            jumping = false;
        }


        if (falling && playerRB.velocity.y >= 0)
        {
            falling = false;
            animator.SetBool("isFalling", false);
            
        }
        

        horizontalMove = playerRB.velocity.x;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if(playerRB.velocity.magnitude < 0.01f)
        {
            animator.speed = 1;
        }
        else
        {
            animator.speed = Mathf.Clamp(playerRB.velocity.magnitude * .25f, .5f, 1.3f);
        }
    }
}
