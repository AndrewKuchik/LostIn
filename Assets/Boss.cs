using System;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int currentHP;
    public int currentHPMax;

    private void Start()
    {
        currentHP = currentHPMax;
    }

    public void ReceiveDamag(int dmg)
    {
        currentHP -= (int)MathF.Abs(dmg);
    }
    
    
}
