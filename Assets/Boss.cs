using System;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int currentHP;
    public int maxHP;
    
    private void Start()
    {
        currentHP = maxHP;
    }

    public void ReceiveDamag(int dmg)
    {
        currentHP -= (int)MathF.Abs(dmg);
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Boss HP: " + currentHP);
    }
}
