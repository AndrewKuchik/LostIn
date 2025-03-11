using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D col;
    public float speedDivider = 3;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        col = transform.GetComponent<BoxCollider2D>();
        col.isTrigger = true;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocityY = 0f;
            //col.isTrigger = true;
        }

        if (collision.tag == "Player")
        {
            Controller1 player = collision.GetComponent<Controller1>();
            
            if(player != null)
            {
                Debug.Log("Player Slowed");
                player.speed = player.maxSpeed / speedDivider;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Controller1 player = collision.GetComponent<Controller1>();

            if (player != null)
            {
                player.speed = player.maxSpeed;
            }
        }
    }
}
