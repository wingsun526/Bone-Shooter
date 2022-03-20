using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    private Rigidbody2D myRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ReceiveDamage(DamageData dmgData)
    {
        //string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration
        FloatingDamageTextManager.instance.Show(dmgData.damage.ToString(), 20, new Color(1f, 0.8f, 0.17f), myRigidbody2D.transform.position, Vector3.up * 40, 1f);
        health -= dmgData.damage;
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
