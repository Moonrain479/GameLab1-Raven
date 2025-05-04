using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class HealthBar : MonoBehaviour
{
    public Health Health;
    public Image fillImage;
    private Slider slider;

    
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    
    void Update()
    {
        float fillValue = Health.currentHealth/Health.maxHealth;

        slider.value = fillValue;

        if (Health.currentHealth <= Health.maxHealth/2)
            {
                fillImage.color = new Color(255,154,0);
            }
        if (Health.currentHealth <= Health.maxHealth / 3)
        {
            fillImage.color = Color.red;
        }

    }
}
