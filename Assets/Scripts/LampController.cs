using UnityEngine;

public class LampController : MonoBehaviour
{
    public GameObject Light;
    public GameObject InteractionKey;
    public GameObject HealText;
    public GameObject GoldText;
    public int ActivatePrice = 5;
    private EnemySpawnerLighthouse spawner;
    
    private AudioSource audioSource;
    
    BossDamage bossDamage;

    public bool isActiveNow = false;

    private void Start()
    {
        bossDamage = GetComponent<BossDamage>();
        spawner = GetComponent<EnemySpawnerLighthouse>();
        audioSource = GetComponent<AudioSource>();  
        ToggleText(isActiveNow);
    }

    public void ToggleLamp()
    {
        if (!isActiveNow)
        {
            isActiveNow = true;
            spawner.EnableEnemies();
            if (bossDamage != null)
            {
                bossDamage.HitBoss();
            }

            if (!audioSource.isPlaying && isActiveNow)
            {
                audioSource.Play();
            }
            
            ToggleText(isActiveNow);
        }
    }

    private void ToggleText(bool b)
    {
        Light.SetActive(b);
        InteractionKey.SetActive(!b);
        HealText.SetActive(b);
        GoldText.SetActive(!b);
    }
}
