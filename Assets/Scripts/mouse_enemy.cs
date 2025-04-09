using UnityEngine;

public class mouse_enemy : MonoBehaviour
{
    private GameObject Player;
    

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerHP playerHp = collision.transform.GetComponent<PlayerHP>();
            playerHp.hp -= 25;

            //if (playerHp.hp <= 0)
            //{
            //    Destroy(collision.gameObject);
            //}
        }
    }
}
