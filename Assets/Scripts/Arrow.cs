using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody2D myRigidbody;
    private Transform playerTransform;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        myRigidbody.transform.Rotate(new Vector3(0, 0, 90));
    }
    
    void Update()
    {
        myRigidbody.velocity = new Vector2(1, 1) * speed;
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
