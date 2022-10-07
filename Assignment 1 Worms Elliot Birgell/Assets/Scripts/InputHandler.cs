using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //private PlayerController playerScript;
    public Vector2 InputVector { get; private set; }
    public bool keyJump;
    public bool key1;
    public bool key2;

    private GameObject _weapon1;
    private GameObject _weapon2;

    private void Awake()
    {
        _weapon1 = GameObject.Find("Launcher");
        _weapon2 = GameObject.Find("SuperLauncher");
    }

    private void Start()
    {
        _weapon2.SetActive(false);
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        InputVector = new Vector2(h, v);

        keyJump = Input.GetKeyDown(KeyCode.Space);
        key1 = Input.GetKeyDown(KeyCode.Alpha1);
        key2 = Input.GetKeyDown(KeyCode.Alpha2);

        if (key1)
        {
            _weapon1.SetActive(true);
            _weapon2.SetActive(false);
        }
        else if (key2)
        {
            _weapon1.SetActive(false);
            _weapon2.SetActive(true);
        }
    }
}