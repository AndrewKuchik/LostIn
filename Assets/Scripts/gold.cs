using System;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.GetComponent<Controller1>().UpdateGold(1);
            Destroy(gameObject);
        }
    }
}
