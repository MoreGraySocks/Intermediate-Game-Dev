using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateHealthBar(float currentHP, float maxHP)
    {
        slider.value = 1 - (currentHP / maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
