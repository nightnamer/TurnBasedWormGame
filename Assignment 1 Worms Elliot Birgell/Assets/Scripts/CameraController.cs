using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera cmCam;

    [SerializeField] public Transform followObject;
    [SerializeField] private float clampYaxis = 75f;
    private Vector2 turn;

    private void Start()
    {
        cmCam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        var m_h = Input.GetAxis("Mouse X");
        var m_v = Input.GetAxis("Mouse Y");
        turn.x += m_h;
        turn.y += m_v;
        turn.y = Mathf.Clamp(turn.y, -clampYaxis, clampYaxis);

        if (followObject == null)
        {
            FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>().NextPlayer();
            Debug.LogWarning("Report");
            return;
        }
        followObject.transform.localRotation = Quaternion.Euler(-turn.y,turn.x,0f);
    }
}
