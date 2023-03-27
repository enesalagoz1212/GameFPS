using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    public void DeductHealth(int damage)
    {
        currentHealth = currentHealth - damage;
        Debug.Log("Playerýn caný azaldý" + currentHealth);
        if (currentHealth<=0)
        {
            killPlayer();
        }
    }

    private void killPlayer()
    {
        print("Player Öldü");
    }

    public void AddHealth(int value)
    {
        currentHealth = currentHealth + value;
        if (currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    // Update is called once per frame
   
}
