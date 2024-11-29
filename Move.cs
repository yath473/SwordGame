using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Animator animator;

    Rigidbody2D rb;
    Vector2 move;
    Vector2 jump;
    Boolean FacingLeft;
    Vector3 scale;

    public Boolean canJump = true;
    public int jumpy = 0;
    public Boolean dead = false;
    public int speed = 50;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        move = new Vector2();
        jump = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        jump.y = Input.GetAxis("Vertical");

        if (move.x != 0)
        {
            animator.SetBool("Run", true);
        }
        else 
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpy++;

            if (canJump == true && jumpy <= 2)
            {
                animator.SetBool("Jump", true);
                rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            }
            else 
            {
                canJump= false;
            }
            
        }
        else 
        {
            animator.SetBool("Jump", false);
            
        }
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
          //  animator.SetBool("Run", true);
            //animator.SetBool("Jump", true);
        }
        scale = transform.localScale;

        if (Input.GetKeyDown(KeyCode.D) && scale.x >0)
        {
            FacingLeft = false;
            scale.x *= -1;
            transform.localScale = scale;
        }
        if (Input.GetKeyDown(KeyCode.A) && scale.x < 0)
        {
            FacingLeft = true;
            scale.x *= -1;
            transform.localScale = scale;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Crouch", true);
            speed = 30;
        }
        else 
        {
            animator.SetBool("Crouch", false);
            speed = 50;
        }
       
    }
    private void FixedUpdate()
    {
        rb.AddForce(move*speed);
        //rb.AddForce(jump*10);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        canJump= true;
        jumpy = 0;
        
        /*Debug.Log("Colliding");
        if (collision.gameObject.name == "Death Pit") 
        {
            dead = true;
        }*/
    }
}
