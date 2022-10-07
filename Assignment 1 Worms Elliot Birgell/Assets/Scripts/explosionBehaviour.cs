using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class explosionBehaviour : MonoBehaviour
{
    private float _triggerCooldown = 2;

    private CameraController _camera;
    private CinemachineVirtualCamera _cmCam;
    private SpawnManager _spawnManager;
    
    private void Awake()
    {
        StartCoroutine(DestroyMyself());
        
        _spawnManager = FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>();
        _camera = FindObjectOfType<CameraController>().GetComponent<CameraController>();
        _cmCam = FindObjectOfType<CinemachineVirtualCamera>().GetComponent<CinemachineVirtualCamera>();
    }

    private IEnumerator DestroyMyself()
    {
        yield return new WaitForSeconds(_triggerCooldown);
        
        _camera.followObject = _spawnManager.playerList[_spawnManager.currentPlayer].transform.GetChild(0).transform;
        _cmCam.Follow = _camera.followObject;
        
        FindObjectOfType<SpawnManager>().SendMessage("NextPlayer"); //Next turn
        
        Destroy(gameObject);
    }
}
