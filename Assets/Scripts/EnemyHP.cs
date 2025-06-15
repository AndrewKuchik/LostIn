using System.Collections;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float health;
    public int maxHealth = 100;
    public bool randomHP = false;

    public Animator animator;
    public AudioClip deathSound;
    public GameObject goldCoin;

    private SpriteRenderer sr;
    private bool isDead = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        health = randomHP ? Random.Range(3, 7) : maxHealth;
    }

    public void ReceiveDamage(float damage)
    {
        if (isDead) return;

        health -= damage;
        Debug.Log($"Enemy HP: {health}");

        if (health <= 0)
        {
            StartCoroutine(KillGhost());
        }

        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateEnemyColor(health / maxHealth);
    }

    IEnumerator KillGhost()
    {
        isDead = true;

        // 1) Отключаем контроллер, чтобы враг замер.
        EnemyController en = GetComponent<EnemyController>();
        if (en) en.enabled = false;

        // 2) Запускаем анимацию смерти.
        if (animator) animator.SetBool("dead", true);

        // 3) Сразу спавним монетку!
        if (goldCoin) Instantiate(goldCoin, transform.position, Quaternion.identity);

        // 4) Проигрываем звук смерти (если есть AudioSource).
        AudioSource audio = GetComponent<AudioSource>();
        if (audio && deathSound) audio.PlayOneShot(deathSound);

        // 5) Дожидаемся конца анимации и звука.
        yield return new WaitForSeconds(0.7f); // анимация
        sr.enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // ждём остаток звука (если был)
        if (audio && deathSound)
            yield return new WaitForSeconds(deathSound.length - 0.7f);

        Destroy(gameObject);
    }

    void UpdateEnemyColor(float hpPercent)
    {
        sr.color = Color.Lerp(Color.red, Color.white, hpPercent);
    }
}