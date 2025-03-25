using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform followingTarget; 
    [SerializeField, Range(0f, 1f)] private float parallaxStrength = 0.1f;
    [SerializeField] private bool disableVerticalParallax;
    
    private Vector3 targetPreviousPosition;

    void Start()
    {
        if (!followingTarget)
            followingTarget = Camera.main.transform;
        
        targetPreviousPosition = followingTarget.position;
    }

    void Update()
    {
        Vector3 deltaVector3 = followingTarget.position - targetPreviousPosition;
        
        if (disableVerticalParallax)
            deltaVector3.y = 0; 
        
        transform.position += deltaVector3 * parallaxStrength;
        targetPreviousPosition = followingTarget.position;
    }
}