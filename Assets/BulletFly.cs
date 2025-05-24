using System;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public  Transform player;
    private Rigidbody2D rb;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();   
        
        Vector2 direction = (player.position - transform.position).normalized;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        transform.up = direction;
        rb.linearVelocity = transform.up * 5f; 
    }

    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHP>().hp -= 10;
        }
        
        Destroy(gameObject);
    }
}
