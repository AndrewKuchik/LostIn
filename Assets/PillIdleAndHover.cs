using UnityEngine;

public class PillIdleAndHover : MonoBehaviour
{
    private Vector3 originalScale;

    [Header("Idle (постоянная пульсация)")]
    public float idleWobbleAmount = 0.05f;
    public float idleWobbleSpeed = 1f;

    [Header("Hover (при наведении)")]
    public float hoverScaleFactor = 1.1f;
    public float hoverSpeed = 5f;

    private bool isHovered = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        isHovered = true;
    }

    void OnMouseExit()
    {
        isHovered = false;
    }

    void Update()
    {
        // Idle пульсация
        float idleWobble = 1 + Mathf.Sin(Time.time * idleWobbleSpeed) * idleWobbleAmount;

        // Target Scale: Idle Scale * Hover Scale
        Vector3 targetScale = originalScale * idleWobble;

        if (isHovered)
        {
            targetScale *= hoverScaleFactor;
        }

        // Плавно подгоняем Scale к нужному
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * hoverSpeed);
    }
}