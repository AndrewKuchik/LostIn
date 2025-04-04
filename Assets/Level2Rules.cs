using UnityEngine;

public class Level2Rules : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerHP playerHp;
    public float limitVelocity = -15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHp = GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocityY <= Mathf.Abs(limitVelocity) * -1)
        {
            rb.linearVelocityY = Mathf.Abs(limitVelocity) * -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.layer == LayerMask.NameToLayer("DamageObstacles"))
        {
            Debug.Log("Hitted");
            playerHp.hp -= Random.Range(15,30);
        }
    }
}
