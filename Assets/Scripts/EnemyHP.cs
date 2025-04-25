using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    private float health;
    public int maxHealth = 100;
    private SpriteRenderer sr;
    public Animator animator;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        health = maxHealth;
    }

    public void ReceiveDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        
            Destroy(gameObject);
            
        
            
            
        
        

        //Debug.Log("Hit");
        
        health = Mathf.Clamp(health, 0, maxHealth);

        float healthPercent = (health / maxHealth);
        //Debug.Log(health);
        Debug.Log($"{healthPercent}% - perc");

        UpdateEnemyColor(healthPercent);
        //animator.SetBool("dead", true);
        
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
