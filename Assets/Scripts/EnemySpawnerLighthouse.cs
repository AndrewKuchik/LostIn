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
        Enemies.ForEach(x => x.SetActive(false));
    }

    void Update()
    {

        if (lamp.Light.activeSelf && !triggered)
        {
            triggered = true;
            Enemies.ForEach(x => x.SetActive(true));
        }
    }
}
