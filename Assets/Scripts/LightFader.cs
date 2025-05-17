using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;



public class LightFader : MonoBehaviour
{
    public Light2D targetLight;
    public float fadeDuration = 5f;
    public float rotationSpeed = 180f;
    public float rotationDuration = 4f;
    public bool hasToRotate = false;
    void Start()
    {
        targetLight.intensity = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Controller1 playerController = collision.transform.GetComponent<Controller1>();
            
            if (playerController != null)
            {
                playerController.enabled = false;
                StartCoroutine(FadeLight(1f, 0f, playerController.transform));
            }
        }
    }

    public IEnumerator FadeLight(float startIntensity, float targetIntensity, Transform player)
    {
        float elapsedTime = 0f;
        targetLight.intensity = 1f;

        
        while (elapsedTime < fadeDuration)
        {
            if (hasToRotate)
            {
                float rotationStep = rotationSpeed * Time.deltaTime;
                player.Rotate(Vector3.forward, rotationStep);
            }
            targetLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetLight.intensity = targetIntensity;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
