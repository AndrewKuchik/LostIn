using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        rb.linearVelocity = transform.right * -speed;
        
        Destroy(gameObject,3f);
    }
}
