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
    //[SerializeField] private float pushRecoveryTime = 0.3f;
    [SerializeField] private float pushRecoveryAmount = 0.2f;


    [Header("Weapon")] 
    //[SerializeField] private float weaponDamage = 1.0f;
    [SerializeField] private float weaponPushForce = 5.0f;
    [SerializeField] private float weaponReloadTime = 1.0f;
    //[SerializeField] private ParticleSystem weaponFiring;
    
    
    private Vector2 moveInput;
    private Animator myAnimator;
    private Animator myWeaponAnimator;
    private Rigidbody2D myRigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    private Transform myTransform;
    private Transform myWeapon;

    internal bool beingPush = false;
    private Vector2 mouseWorldPosition;
    private float lastPush;
    private bool Attacking = false;

    private Vector3 playerCurrentVelocity;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myTransform = GetComponent<Transform>();
        myWeapon = myTransform.Find("Weapon");
        myWeaponAnimator = myWeapon.GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        playerCurrentVelocity = myRigidbody2D.velocity;
    }

    void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        FreeToMove();
        Run();
        FlipSprite();
        RotateWeapon();
    }

    private void FreeToMove()
    {
        // player lose control when being pushed by force, gains back control when velocity smaller than a certain amount
        if (Math.Abs(myRigidbody2D.velocity.x) + Math.Abs(myRigidbody2D.velocity.y)  < pushRecoveryAmount)//(Time.time - lastPush > pushRecoveryTime)
        {
            beingPush = false;
            Attacking = false;
            myAnimator.SetBool("isPushing", false);
        }
    }

    private void RotateWeapon()
    {
        
        Vector2 direction = (mouseWorldPosition - (Vector2) myWeapon.position).normalized;
        myWeapon.up = direction;
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnFire(InputValue value)
    {
        Attacking = true;
        PushPlayer();
        
    }
    void PushPlayer()
    {
        if (Time.time - lastPush > weaponReloadTime)
        {
            beingPush = true;
            lastPush = Time.time;
            myWeaponAnimator.SetTrigger("fireNow");
            //weaponFiring.Play();
            // shoot the player to the direction with a force
            // difference Forcemode are available
            /*  ForceMode.Force - Applies a gradual force on the Object, taking mass into account.
                    This is a literal pushing motion where the bigger the mass of the Object, the slower it will speed up.
                ForceMode.Impulse - Applies an instant force on the Object, taking mass into account. This pushes the Object 
                    using the entire force in a single frame. Again, the bigger the mass of the Object, the less effect this will have. Great for recoil or jump functions.
                ForceMode.Acceleration - Same as ForceMode.Force except that it doesn't take mass into account. 
                    No matter how big the mass of the object, it will accelerate at a constant rate.
                ForceMode.VelocityChange - Same as ForceMode.Impulse and again, doesn't take mass into account. 
                    It will literally add the force to the Object's velocity in a single frame.*/
            // rigidbody drag will act on this force over time.
            myRigidbody2D.AddForce(-(mouseWorldPosition - (Vector2)myRigidbody2D.transform.position).normalized * weaponPushForce, ForceMode2D.Impulse);
            myAnimator.SetBool("isPushing", true);
        }
    }

    // push when being damaged
    internal void DamagePush(Vector2 pushDirection)
    {
        beingPush = true;
        myRigidbody2D.AddForce(pushDirection, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!Attacking) return;
        if(other.gameObject.CompareTag("Enemy") )
        {
            // Damage based on the velocity
            int momentumDamage = (int)Math.Floor(Math.Abs(playerCurrentVelocity.x) + Math.Abs(playerCurrentVelocity.y));
            DamageData dmgData = new DamageData();
            dmgData.damage = momentumDamage;
            other.gameObject.SendMessage("ReceiveDamage", dmgData);

        }
    }

    private void Run()
    {
        

        if (!beingPush)
        {
            
            Vector2 playerVelocity = new Vector2(moveInput.x, moveInput.y) * speed;
            myRigidbody2D.velocity = playerVelocity;
        
    
    
            // For starting up the move animation
            bool playerIsMoving = Mathf.Abs(moveInput.x) + Mathf.Abs(moveInput.y) > Mathf.Epsilon;
            myAnimator.SetBool("isMoving", playerIsMoving);
            
        }

        
        
    }
    private void FlipSprite()
    {
        if (mouseWorldPosition.x > myRigidbody2D.position.x)
        {
            myTransform.localScale = new Vector3(1, 1, 1);
        }
        else if (mouseWorldPosition.x < myRigidbody2D.position.x)
        {
            myTransform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
