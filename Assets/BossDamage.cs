using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public Boss boss;
    public int damage = 35;

    public void HitBoss()
    {
        boss.ReceiveDamag(damage);
    }
    
}
