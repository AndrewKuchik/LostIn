using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject Player;
    public float speed = 10;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");    
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            EnemyHP enemyHp = GetComponent<EnemyHP>();
            if(enemyHp.health>0){
                PlayerHP playerHp = collision.transform.GetComponent<PlayerHP>();
                playerHp.hp -= 25;

                //if (playerHp.hp <= 0)
                //{
                //    Destroy(collision.gameObject);
                //}
            }
            
        }
    }
}
