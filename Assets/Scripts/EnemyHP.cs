using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    private float health;
    public int maxHealth = 100;
    public TMP_Text hpBar;


    private void Start()
    {
        health = maxHealth;
    }

    public void ReceiveDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);

        //Debug.Log("Hit");
        
        health = Mathf.Clamp(health, 0, maxHealth);

        float healthPercent = (health / maxHealth) * 100;
        //Debug.Log(health);
        //Debug.Log($"{healthPercent}% - perc");

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (hpBar != null)
        {
            int roundedHealth = Mathf.RoundToInt((health / maxHealth) * 100);
            hpBar.text = $"HP: {roundedHealth}%";
        }
    }


}
