using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Victoria Garcia
//Used for the healthbar in the menu
public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Gradient healthGradient;
    public Image healthFill;


    //Sets the max health of the bar
    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;

        healthFill.color = healthGradient.Evaluate(1f);
    }

    //Sets the health of the bar and color 
    public void SetHealth(float health)
    {
        healthSlider.value = health;

        healthFill.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}
