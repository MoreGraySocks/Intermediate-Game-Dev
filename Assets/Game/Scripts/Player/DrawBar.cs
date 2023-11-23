using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateDrawBar(float drawtime)
    {
        slider.value = 2 - (drawtime);
    }

    //public void DeactiveDrawBar()
    //{
        
    //}

    //public void ActivateDrawBar()
    //{
        
    //}
}
