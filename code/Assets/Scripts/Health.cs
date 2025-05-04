using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public float currentHealth;

    
    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage(int amount) 
    {
        FindObjectOfType<AudioManager>().Play("CatDamage");
        currentHealth -= amount;

        if (currentHealth <= 0) 
        {
            SceneManager.LoadScene(2);//Gameover XD
        }
    }
}
