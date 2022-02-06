using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    
    private Vector2 moveInput;
    private Animator myAnimator;
    private Rigidbody2D myRigidbody;
    private SpriteRenderer mySpriteRenderer;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log("Hello, this message is from the playermovement script");
    }

    
    void Update()
    {
        Run();
        FlipSprite();
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    private void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
        myRigidbody.velocity = playerVelocity;
        
        // For starting up the move animation
        bool playerIsMoving = Mathf.Abs(moveInput.x) + Mathf.Abs(moveInput.y) > Mathf.Epsilon;
        myAnimator.SetBool("isMoving", playerIsMoving);
        
    }
    private void FlipSprite()
    {
        if (moveInput.x < 0)
        {
            mySpriteRenderer.flipX = true;
        }
        else if (moveInput.x > 0)
        {
            mySpriteRenderer.flipX = false;
        }
    }

}
