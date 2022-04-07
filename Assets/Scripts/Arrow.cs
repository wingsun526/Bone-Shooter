using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    
    private Rigidbody2D myRigidbody;
    private Transform playerTransform;
    private Vector2 directionToGo;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        SetUpArrow();
    }
    
    void Update()
    {
        FireArrow();
        
    } 

    private void FireArrow()
    {
        myRigidbody.velocity = directionToGo * speed;
    }

    private void SetUpArrow()
    {
        directionToGo = (playerTransform.position - myRigidbody.transform.position).normalized;
        var arrowRotateAngle = Vector2.Angle(myRigidbody.position, playerTransform.position);
        transform.up = directionToGo;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var dmgData = new DamageData();
            dmgData.damage = damage;
            other.gameObject.SendMessage("ReceiveDamage", dmgData);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
