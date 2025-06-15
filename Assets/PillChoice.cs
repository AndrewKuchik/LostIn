using UnityEngine;
using UnityEngine.SceneManagement;

public class PillChoice : MonoBehaviour
{
    [Header("Что показать")]
    public GameObject imageToShow;
    public GameObject Background;

    [Header("Какую сцену загрузить после")]
    public string sceneToLoad = "menu";

    [Header("Сколько ждать перед загрузкой")]
    public float delayBeforeLoad = 5f;

    void OnMouseDown()
    {
        Debug.Log("Нажали на: " + gameObject.name);

        // Показать нужную картинку
        if (imageToShow != null)
        {
            imageToShow.SetActive(true);
        }
        else
        {
            Background.SetActive(false);
        }

        // Запустить таймер на загрузку сцены
        Invoke("LoadNextScene", delayBeforeLoad);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}