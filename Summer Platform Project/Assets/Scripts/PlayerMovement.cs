using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    
    public float movementSpeed;
    public Rigidbody2D rb;

    public float jumpForce = 20f;
    private float JumpTimeCounter;
    public float JumpTime;
    private bool isJumping;
    
    public Transform feet;
    public LayerMask groundLayers;

    public float mx; //Movement X

    private AudioSource Steps;
    private bool IsMoving;
    public bool unlockedDoubleJump;

    private int extraJumps;
    public int extraJumpsValue;

    private void Start()
    {
        extraJumps = extraJumpsValue;
        Steps = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        if (mx != 0) {transform.localScale = new Vector3(mx, 1f, 1f); }

        animator.SetFloat("Speed", Mathf.Abs(mx));
        
        //Jumping Script
        Jumping();
        
        animator.SetBool("IsJumping", rb.velocity.y > 0.01);
        animator.SetBool("IsFalling", rb.velocity.y < -0.01);
        animator.SetBool("IsGrounded", IsGrounded());
    }

    void Jumping()
    {
        if(unlockedDoubleJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                isJumping = true;
                JumpTimeCounter = JumpTime / 2;
                extraJumps--;
                FindObjectOfType<AudioManager>().Play("Jump Sound Effect");
            }
        }
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            isJumping = true;
            JumpTimeCounter = JumpTime; 
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jump Sound Effect");
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (JumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                JumpTimeCounter -= Time.deltaTime; 
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false; 
        }

    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        
        rb.velocity = movement;
        if (rb.velocity != default)
        {
            if (IsGrounded())
            {
                if (!Steps.isPlaying)
                {
                    Steps.Play();
                }
            }
        }

        if (IsGrounded())
        {
            extraJumps = extraJumpsValue;
        }
    }

    public bool IsGrounded()
    {
        var groundCheck = Physics2D.OverlapCircle(feet.position, 0.1f, groundLayers);
        
        if (groundCheck.gameObject != null)
        {
            return true;
        }
        
        return false; 
    }
}
