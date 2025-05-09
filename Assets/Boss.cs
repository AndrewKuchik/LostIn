using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    private int currentHP;
    public int maxHP;
    public GameObject bossPath;
    public float speed = 5f;
    
    public List<Transform> bossWaypoints = new List<Transform>();
    private Transform currentWaypoint;
    
    private void Start()
    {
        currentHP = maxHP;

        
        foreach (Transform position in bossPath.transform)
        {   
            bossWaypoints.Add(position);
        }
        
        ChooseRandomWaypoint();
    }

    public void ReceiveDamag(int dmg)
    {
        currentHP -= (int)MathF.Abs(dmg);
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Boss HP: " + currentHP);
    }

    private void Update()
    {
        if (currentWaypoint == null || bossWaypoints.Count == 0)
        {
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f && !isPicking)
        {
            StartCoroutine(PickWaypoint());
        }
    }

    bool isPicking = false;
    IEnumerator PickWaypoint()
    {
        isPicking = true;
        yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        ChooseRandomWaypoint();
        isPicking = false;
    }

    private void ChooseRandomWaypoint()
    {
        int index = Random.Range(0, bossWaypoints.Count);
        speed = Random.Range(2f, 20f);
        currentWaypoint = bossWaypoints[index];
    }
}
