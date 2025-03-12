using UnityEngine;

public class LampController : MonoBehaviour
{
    public GameObject Light;

    private void Start()
    {
        if (Light.activeSelf)
        {
            Light.SetActive(false);
        }
    }

    public void ToggleLamp()
    {
        if (!Light.activeSelf)
        {
            Light.SetActive(true);
        }
    }
}
