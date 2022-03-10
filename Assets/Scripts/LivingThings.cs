using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LivingThings : MonoBehaviour
{
    [SerializeField] private float health;

    protected Rigidbody2D myRigidbody2D;
    protected virtual void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void ReceiveDamage(int damage)
    {
        Debug.Log("I got hit by the player");
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
