using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lyndsey Narvaez
//allows the player to lose and gain health
//no UI yet, but can be seen in debug in unity
public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float startingHealth;

    private void Start()
    {
        health = startingHealth;
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if(health > maxHealth)
        {
            health = maxHealth;
        } 
        else if (health <= 0)
        {
            health = 0f;
            Debug.Log("player respawn");
        }
    }
}
