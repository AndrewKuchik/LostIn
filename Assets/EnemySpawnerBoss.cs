using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnerBoss : MonoBehaviour
{
    public Transform Player;
    public float spawnTimer = 3f;
    public GameObject[] enemyPrefab;
    private void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length - 1)], transform.position,
                quaternion.identity);
            var e = enemy.GetComponent<EnemyLevel5>();
            e.Player = Player;
            yield return new WaitForSeconds(Random.Range((spawnTimer - 1.5f), (spawnTimer + 1.5f)));
        }    
    }
}
