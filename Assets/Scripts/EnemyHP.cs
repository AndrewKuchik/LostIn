using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float health;
    public int maxHealth = 100;
    private SpriteRenderer sr;
    public Animator animator;
    
    public bool randomHP = false;
    public AudioClip deathSound;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        health = maxHealth;

        if (randomHP)
        {
            health = Random.Range(3, 7);
        }
    }

    
    bool isDead = false;
    IEnumerator KillGhost()
    {
        isDead = true;
        transform.GetComponent<AudioSource>().PlayOneShot(deathSound);
        transform.GetComponent<EnemyController>().enabled = false;
        
        if (animator != null)
        {
            animator.SetBool("dead", true);
        }
        
        yield return new WaitForSeconds(0.7f);
        
        sr.enabled = false;
        transform.GetComponent<BoxCollider2D>().enabled = false;
        
        yield return new WaitForSeconds(deathSound.length - 0.7f);
        
        Destroy(gameObject);
    }
    
    
    public void ReceiveDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy HP: " + health);
        if (health <= 0)
        {
            if(!isDead)
                StartCoroutine(KillGhost());
        }


        //Debug.Log("Hit");
        
        health = Mathf.Clamp(health, 0, maxHealth);

        float healthPercent = (health / maxHealth);
        //Debug.Log(health);
        Debug.Log($"{healthPercent}% - perc");

        UpdateEnemyColor(healthPercent);
        
        
    }

    private void UpdateEnemyColor(float currentHp)
    {
        // sr.color = Color.Lerp(sr.color, Color.red, currentHp);
        // sr.color = Color.Lerp(Color.white, Color.red, currentHp);
        sr.color = Color.Lerp(Color.red, Color.white, currentHp);
       
    }

    private void UpdateHealthBar()
    {
        // if (hpBar != null)
        // {
        //     int roundedHealth = Mathf.RoundToInt((health / maxHealth) * 100);
        //     hpBar.text = $"HP: {roundedHealth}%";
        // }
    }


}
