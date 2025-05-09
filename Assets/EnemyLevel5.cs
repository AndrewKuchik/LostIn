using UnityEngine;

public class EnemyLevel5 : MonoBehaviour
{
    public Transform Player;
    public float speed = 3f;
    
    void Start()
    {
        speed = Random.Range(1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }
}
