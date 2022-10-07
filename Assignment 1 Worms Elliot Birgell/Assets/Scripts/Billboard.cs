using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] public Camera _camera;
    
    public bool lookAway;


    private void Awake()
    {
        if (_camera == null) _camera = Camera.main;
    }

    private void LateUpdate()
    {
        if (!lookAway)
        {
            transform.LookAt(_camera.transform);
        }
        else
        {
            Vector3 direction = transform.position - _camera.transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        transform.rotation = Quaternion.Euler(0f,transform.rotation.eulerAngles.y,0f);
    }
}
