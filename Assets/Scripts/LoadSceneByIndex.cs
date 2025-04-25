using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour
{
    public GameObject MainMenuTab;
    public GameObject SelectLevelTab;
    
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void SelectLevel()
    {
        MainMenuTab.SetActive(false);
        SelectLevelTab.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SelectLevelTab.SetActive(false);
        MainMenuTab.SetActive(true);
    }


}

