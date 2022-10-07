using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    private SpawnManager _spawn;
    private StaminaBar _staminaBar;
    
    public float stamina;
    public float maxStamina = 25;

    private void Awake()
    {
        _staminaBar = FindObjectOfType<StaminaBar>().GetComponent<StaminaBar>();
        
        stamina = maxStamina;
        _staminaBar.UpdateStaminaBar(maxStamina,stamina);
    }
}
