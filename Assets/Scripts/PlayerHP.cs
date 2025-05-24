using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public float hp = 100;
    public TextMeshProUGUI LightText;
    public AudioClip deathSound;
    

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
        if (LightText == null) return;
        
        hp -= 1f * Time.deltaTime;
        LightText.text = $"Light {hp.ToString("F1")}%";

        if (hp <= 0)
        {
            LightText.text = $"Light 0%";
            LightFader fader = GameObject.FindAnyObjectByType<LightFader>();
            if (fader != null)
            {
                StartCoroutine(fader.FadeLight(1, 0, transform));
                transform.GetComponent<Controller1>().enabled = false;
                transform.GetComponent<AudioSource>().PlayOneShot(deathSound);
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.gravityScale = 0;
                rb.linearVelocityY = 0;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
