using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLighthouse : MonoBehaviour
{
    LampController lamp;
    bool triggered = false;
    public List<GameObject> Enemies;
    

    void Start()
    {
        lamp = GetComponent<LampController>();
        if (Enemies.Count > 0)
        {
            Enemies.ForEach(x => x.SetActive(false));
        }
    }

    public void EnableEnemies()
    {
        if (!triggered)
        {
            triggered = true;
            if (Enemies.Count > 0)
            {
                Enemies.ForEach(x => x.SetActive(true));
            }
        }
    }
}
