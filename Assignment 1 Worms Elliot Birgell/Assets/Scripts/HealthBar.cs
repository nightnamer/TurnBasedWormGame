using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _helthbarSprite;
    public void UpdateHealthbar(float maxHealth, float health)
    {
        _helthbarSprite.fillAmount = health / maxHealth;
    }
    
}
