using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
    
    [Header("Knight")]
    [SerializeField] private Sword sword;

    [SerializeField] private float attackChargeForce = 10f;

    //private Animator myAnimator;
    private Animator swordAnimator;
    private CapsuleCollider2D myCapsuleCollider2D;
    private float attackLength = 0.5f;

    private bool actionInProgress = false;
    protected override void Start()
    {
        base.Start();
        swordAnimator = sword.GetComponent<Animator>();
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
    }

    protected override void IndividualAction()
    {
        if (beingPush) return;
    
        if (actionInProgress) return;
        
        myAnimator.SetBool("isMoving", true);
        myRigidbody2D.velocity = (playerTransform.position - myRigidbody2D.transform.position).normalized * speed;
        
        if (Vector2.Distance(playerTransform.position, myRigidbody2D.transform.position) < attackLength)
        {
            actionInProgress = true;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        myAnimator.SetBool("isMoving", false);
        swordAnimator.SetTrigger("chargeWeapon");
        yield return new WaitForSeconds(1);

        lockSpriteFlip = true; // no sprite flip when in action
        Vector3 delta = playerTransform.position - myRigidbody2D.transform.position;
        myRigidbody2D.AddForce(delta.normalized * attackChargeForce, ForceMode2D.Impulse);
        swordAnimator.SetTrigger("swingWeapon");
        
        yield return new WaitForSeconds(2);

        lockSpriteFlip = false;
        actionInProgress = false;
        
    }

}
