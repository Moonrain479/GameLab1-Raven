using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverview : MonoBehaviour
{

    public void OnTutorialButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OnLevel1Button()
    {
        SceneManager.LoadScene(5);
    }
    public void OnLevel2Button()
    {
        SceneManager.LoadScene(6);
    }
    public void OnLevel3Button()
    {
        SceneManager.LoadScene(7);
    }
    public void OnBackButton()
    {
        SceneManager.LoadScene(0);
    }

}
