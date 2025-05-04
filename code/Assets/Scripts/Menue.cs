using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menue : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnLevelOverviewButton()
    {
        SceneManager.LoadScene(4);
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
