using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private Transform myParentTransform;
    
    private Transform myTransform;
   
    
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var dmgData = new DamageData();
            dmgData.damage = damage;
            dmgData.damageDirection = ((Vector2)other.gameObject.transform.position - (Vector2)myParentTransform.transform.position).normalized;
            other.gameObject.SendMessage("ReceiveDamage", dmgData);
        }
    }
}
