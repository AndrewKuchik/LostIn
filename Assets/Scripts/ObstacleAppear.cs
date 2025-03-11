using System.Collections.Generic;
using UnityEngine;

public class ObstacleAppear : MonoBehaviour
{
    public List<GameObject> objectsToAppear;

    void Start()
    {
        objectsToAppear.ForEach(x => x.SetActive(false));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            objectsToAppear.ForEach(x => x.SetActive(true));
        }
    }
}
