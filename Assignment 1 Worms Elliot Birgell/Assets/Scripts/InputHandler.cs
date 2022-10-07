using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //private PlayerController playerScript;
    public Vector2 InputVector { get; private set; }
    public bool key_jump;

    private void Awake()
    {
       //playerScript = GetComponent<PlayerController>();
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        InputVector = new Vector2(h, v);

        key_jump = Input.GetKeyDown(KeyCode.Space);
    }
}