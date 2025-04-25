using UnityEngine;

public class gold : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Controller1>().UpdateGold(1);
            Destroy(gameObject);
        }
    }
}
