using UnityEngine;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    public float hp = 100;
    public TextMeshProUGUI LightText;

   public void healPlayer(float amount)
    {
        hp += amount;
        if (hp > 100)
        {
            hp = 100;
        }
    }

    void Update()
    {
        hp -= 1f * Time.deltaTime;
        LightText.text = $"Light {hp.ToString("F1")}%";

        if (hp <= 0)
        {
            LightText.text = $"Light 0%";
            LightFader fader = GameObject.FindAnyObjectByType<LightFader>();
            if (fader != null)
            {
                StartCoroutine(fader.FadeLight(1, 0, transform));
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.gravityScale = 0;
                rb.linearVelocityY = 0;
            }
        }
    }
}
