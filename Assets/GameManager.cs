using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;

    // Update is called once per frame
    private void Start()
    {
        pausePanel.SetActive(false);
    }

    bool isPuased = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPuased = !isPuased;

            if (isPuased)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; 
        pausePanel.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
}
