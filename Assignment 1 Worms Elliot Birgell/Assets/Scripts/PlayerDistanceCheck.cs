using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistanceCheck : MonoBehaviour
{
    public float distance = 0;
    public float maxDistance = 25;
    public Vector3 previousLocation;
    private SpawnManager _spawn;
    private StaminaBar _stamina;

    private void Awake()
    {
        _spawn = FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>();
        _stamina = FindObjectOfType<StaminaBar>().GetComponent<StaminaBar>();
    }

    private void Start()
    {
        previousLocation = transform.position;
    }

    void Update()
    {
        distance = Vector3.Distance (transform.position, previousLocation);

        var currentPlayer = _spawn.playerList[_spawn.currentPlayer];
        if (distance >= maxDistance)
        {
            currentPlayer.GetComponent<PlayerController>().plrControl = false;
            currentPlayer.GetComponent<InputHandler>().enabled = false; ;
        }

        var curStam = currentPlayer.GetComponent<PlayerDistanceCheck>();
        _stamina.UpdateStaminaBar(maxDistance,curStam.distance);
    }
}
