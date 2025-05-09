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
    


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        health = maxHealth;

        if (randomHP)
        {
            health = Random.Range(3, 7);
        }
    }

    public void ReceiveDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy HP: " + health);
        if (health <= 0)
        {

            Destroy(gameObject,0.7f);

            if (animator != null)
            {
                animator.SetBool("dead", true);
            }
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
