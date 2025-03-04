using UnityEngine;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    public int hp = 100;
    public TextMeshProUGUI LightText;

   

    void Update()
    {
        LightText.text = $"Light {hp}%";
    }
}
