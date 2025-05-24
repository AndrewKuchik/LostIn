using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public int bossMaxHits = 3;
    private int bossCurrentHits = 0;
    public TextMeshProUGUI bossHitsText;
    public AudioClip bossDeathSound;
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentHP = maxHP;
        bossHitsText.text = $"{bossCurrentHits} / {bossMaxHits}";
        
        foreach (Transform position in bossPath.transform)
        {   
            bossWaypoints.Add(position);
        }
        
        ChooseRandomWaypoint();
    }

    public void ReceiveDamag(int dmg)
    {
        bossCurrentHits++;
        bossHitsText.text = $"{bossCurrentHits} / {bossMaxHits}";
        currentHP -= (int)MathF.Abs(dmg);
        if(currentHP <= 0)
        {
            audioSource.PlayOneShot(bossDeathSound);
            Destroy(gameObject,2f );
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
