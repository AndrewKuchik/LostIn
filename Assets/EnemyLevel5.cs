using UnityEngine;

public class EnemyLevel5 : MonoBehaviour
{
    public Transform Player;
    public float speed = 3f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }
}
