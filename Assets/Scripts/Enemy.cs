using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Enemy : LivingThings
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] private float chaseLength = 0.5f;
    [SerializeField] private float pushRecoveryTime = 0.8f;
    [SerializeField] private Transform playerTransform;
   
    private Rigidbody2D myRigidbody2D;
    private bool beingPush = false;
    private float lastPush;
    
     
    

    protected void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        FreeToMove();
        Chase();
    }

    private void FreeToMove()
    {
        if (Time.time - lastPush > pushRecoveryTime)
        {
            beingPush = false;
        }
    }

    void Chase()
    {
        if (beingPush)
        {
            return;
        }

        
        // start chasing player when player is in range(chaseLength)
        if (Vector2.Distance(playerTransform.position, myRigidbody2D.transform.position) < chaseLength)
        {
            Vector3 delta = playerTransform.position - myRigidbody2D.transform.position;
            myRigidbody2D.velocity = new Vector2(delta.x, delta.y).normalized * speed;
        }
        

    }

    void ReceiveDamage(DamageData dmgData)
    {
        beingPush = true;
        lastPush = Time.time;
        //string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration
        FloatingDamageTextManager.instance.Show(dmgData.damage.ToString(), 20, new Color(1f, 0.8f, 0.17f), myRigidbody2D.transform.position, Vector3.up * 40, 1f);
        health -= dmgData.damage;
        if (health <= 0) 
        {
            Die();
        }
    }
    
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
