using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private bool isDead = false;

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
        if (isDead) return;

        bossCurrentHits++;
        bossHitsText.text = $"{bossCurrentHits} / {bossMaxHits}";
        currentHP -= Mathf.Abs(dmg);
        Debug.Log("Boss HP: " + currentHP);

        if (currentHP <= 0)
        {
            StartCoroutine(HandleDeath());
        }
    }

    private IEnumerator HandleDeath()
    {
        isDead = true;

        // Отключаем визуальную часть босса
        HideBossVisuals();

        // Воспроизводим звук смерти
        audioSource.PlayOneShot(bossDeathSound);
        Debug.Log("Boss death sound playing...");

        // Ждём звук или минимум 0.1 сек
        yield return new WaitForSeconds(Mathf.Max(0.1f, bossDeathSound.length));

        // Ждём ещё 2 секунды «осознания победы»
        yield return new WaitForSeconds(2f);

        // Загружаем следующую сцену
        SceneManager.LoadScene("EndingScene");
    }

    private void HideBossVisuals()
    {
        // Отключаем все рендереры в дочерних объектах
        foreach (var renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }

        // Можно отключить коллайдеры, чтобы его нельзя было больше бить
        foreach (var collider in GetComponentsInChildren<Collider>())
        {
            collider.enabled = false;
        }

        // Можно отключить физику, если нужно
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true;
    }

    private void Update()
    {
        if (isDead) return;

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