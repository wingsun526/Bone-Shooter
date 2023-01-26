using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int speed;
    private Transform playerTransform;
    private Vector2 directionToGo;

    void Update()
    {
        BulletFlying();
    }
    
    public void SetDirection(Vector2 direction)
    {
        directionToGo = direction;
    }
    private void BulletFlying()
    {
        //myRigidbody.velocity = directionToGo * speed;
        transform.position += new Vector3(directionToGo.x, directionToGo.y, 0) * (speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) return;
        if (other.gameObject.CompareTag("Enemy"))
        {
            var dmgData = new DamageData();
            dmgData.damage = damage;
            other.gameObject.SendMessage("ReceiveDamage", dmgData);
        }
        Destroy(gameObject);
    }
}
