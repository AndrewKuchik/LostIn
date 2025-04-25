using UnityEngine;

public class LampController : MonoBehaviour
{
    public GameObject Light;
    public GameObject InteractionKey;
    public GameObject HealText;
    public GameObject GoldText;
    public int ActivatePrice = 5;
    private EnemySpawnerLighthouse spawner;

    public bool isActiveNow = false;

    private void Start()
    {
        spawner = GetComponent<EnemySpawnerLighthouse>();
        ToggleText(isActiveNow);
    }

    public void ToggleLamp()
    {
        if (!isActiveNow)
        {
            isActiveNow = true;
            spawner.EnableEnemies();
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
