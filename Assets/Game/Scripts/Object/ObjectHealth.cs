using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public float maxHealth = 5;
    private float currentHealth;

    [SerializeField] HealthBar healthbar;

    public GameObject healthBarObject;
    public GameObject itemCanvas;

    public int itemCode;
    public Transform objectTransform;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar = GetComponentInChildren<HealthBar>();
        healthBarObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        healthBarObject.SetActive(true);
        currentHealth -= damage;
        healthbar.UpdateHealthBar(currentHealth, maxHealth);
        Debug.Log("health is " + currentHealth);
        if (currentHealth <= 0)
        {
            GameObject item = Instantiate(itemCanvas, objectTransform.position, Quaternion.Euler(0,0,0));
            item.GetComponent<PickUpItem>().InitialiseItemDropped(itemCode);

            if (gameObject.tag == "Enemy")
            {
                Death();
            }
            else { Deactivate(); }
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
