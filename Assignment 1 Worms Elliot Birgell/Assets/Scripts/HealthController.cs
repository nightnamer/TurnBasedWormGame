using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private SpawnManager _spawn;
    [SerializeField] private HealthBar _healthBar;
    
    public float health;
    public float maxHealth = 10;

    private void Awake()
    {
        health = maxHealth;
        _spawn = FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>();
        
        _healthBar.UpdateHealthbar(maxHealth,health);
    }

    private void Update()
    {
        if (health <= 0)
        {
            ActivateDeath();
        }
    }

    private void ActivateDeath()
    {
        _spawn.playerList.Remove(GetComponent<PlayerController>());
        _spawn.playerAmount = _spawn.playerList.Count;
        Destroy(gameObject);
    }
}
