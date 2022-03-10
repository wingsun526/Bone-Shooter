using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Enemy : LivingThings
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] private float chaseLength = 0.5f;
    [SerializeField] private Transform playerTransform;
   
    //private Rigidbody2D myRigidbody2D;

    protected override void Start()
    {
        base.Start();

    }

    
    void Update()
    {
        
        //chase();
    }
    
    void chase()
    {   
        // start chasing player when player is in range(chaseLength)
        if (Vector2.Distance(playerTransform.position, myRigidbody2D.transform.position) < chaseLength)
        {
            Vector3 delta = playerTransform.position - myRigidbody2D.transform.position;
            myRigidbody2D.velocity = new Vector2(delta.x, delta.y).normalized * speed;
        }
        else
        {
            myRigidbody2D.velocity = Vector2.zero;
        }

    }
}
