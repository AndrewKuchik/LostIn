using UnityEngine;
using UnityEngine.SceneManagement;

public class text_cutscene : MonoBehaviour
{
    public GameObject[] textObjects;  // Сюда закидываем все текстовые окна
    private int currentIndex = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ЛКМ
        {
            if (currentIndex < textObjects.Length)
            {
                textObjects[currentIndex].SetActive(true);
                currentIndex++;
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
