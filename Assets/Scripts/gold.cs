using UnityEngine;

public class gold : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        // Check if the other object has a PlayerController2D component
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        

    }
}
