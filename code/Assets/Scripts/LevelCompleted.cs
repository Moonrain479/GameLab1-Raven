using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public void OnLevelOverviewButton()
    {
        FindObjectOfType<AudioManager>().Stop("CatEating");
        SceneManager.LoadScene(4);
    }

}
