using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] private PlayerMovement player;
    private Rigidbody2D myRigidbody2D;
    
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        chase();
    }

    void chase()
    {
        Vector3 delta = player.transform.position - myRigidbody2D.transform.position;
        myRigidbody2D.velocity = new Vector2(delta.x, delta.y).normalized* speed;
        Debug.Log(myRigidbody2D.velocity);
        
    }
}
