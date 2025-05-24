using TMPro;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public Boss boss;
    public int damage = 35;
    public GameObject platformsCurrent;
    public GameObject platformsNext;
    public GameObject lightHouseNext;

    public void HitBoss()
    {
        boss.ReceiveDamag(damage);
        if (lightHouseNext != null && platformsNext != null)
        {
            platformsNext.SetActive(true);
            lightHouseNext.SetActive(true);
        }
        
        platformsCurrent.SetActive(false);
    }
}
