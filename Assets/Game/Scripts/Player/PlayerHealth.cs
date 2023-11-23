using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float currentHealth;
    private float maxHealth = 12;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i + 1 <= currentHealth/4 )
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i + 1 <= currentHealth / 4 + 0.5)
            {
                hearts[i].sprite = halfHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < maxHealth/4) 
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        //healthBarObject.SetActive(true);
        currentHealth -= damage;
        //healthbar.UpdateHealthBar(currentHealth, maxHealth);
        Debug.Log("Player health is " + currentHealth);
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void IncreaseHealth()
    {
        maxHealth += 4;
        currentHealth = maxHealth;
    }
}
