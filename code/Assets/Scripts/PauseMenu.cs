using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool isPaused;


    void Start()
    {
        pauseMenu.SetActive(false);
    }


    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
    }

    public void PauseGame() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OnResumeButton()
    {
        ResumeGame();
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene(0);
        ResumeGame();
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
