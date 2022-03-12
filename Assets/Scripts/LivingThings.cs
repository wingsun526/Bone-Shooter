using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LivingThings : MonoBehaviour
{
    [SerializeField] protected float health;

    protected Rigidbody2D myRigidbody2D;

    //protected bool beingPush = false;
    protected virtual void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    

    protected virtual void Die()
    {
        
    }
}
