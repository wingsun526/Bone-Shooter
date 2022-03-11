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
        //string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration
        FloatingDamageTextManager.instance.Show(damage.ToString(), 20, new Color(1f, 0.8f, 0.17f), myRigidbody2D.transform.position, Vector3.up * 40, 1f);
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
