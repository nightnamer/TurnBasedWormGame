using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    private Vector3 _force;
    
    public bool hold = false;

    private Transform _playerHand;
    private SpawnManager _spawnManager;

    private float _forceMultiplier;

    [SerializeField] private float _damage;
    [SerializeField] private TrajectoryLine lineRenderer;

    private void Awake()
    {
        GetComponent<TrajectoryLine>().projectilePrefab = projectilePrefab;
        _spawnManager = FindObjectOfType<SpawnManager>();
        GetComponent<Billboard>()._camera = Camera.main;
    }

    public void FixedUpdate()
    {
        if (hold)
        {
            _playerHand = _spawnManager.playerList[_spawnManager.currentPlayer].transform.GetChild(6).transform;
            this.transform.position = _playerHand.position;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<LineRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            _forceMultiplier += 0.005f;
            _forceMultiplier = Mathf.Clamp(_forceMultiplier, 0.3f, 2f);
            _force = (transform.forward * 400f + transform.up * 200f + transform.right * 150f)*_forceMultiplier; 
            lineRenderer.DrawCurvedTrajectory(_force);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _forceMultiplier = 0f;
            GetComponent<LineRenderer>().enabled = false;
            
            Vector3 newForce = (transform.up*100f);
            for (int i = 0; i < 3; i++)
            {
                newForce *= 1.2f;
                GameObject missile = Instantiate(projectilePrefab,transform.GetChild(0).transform.position,transform.rotation);
                if (i < 2) missile.GetComponent<MissileBehaviour>()._dropExplo = false;
                missile.GetComponent<Rigidbody>().AddForce(_force+newForce);
                missile.GetComponent<MissileBehaviour>().damage = _damage;
                missile.GetComponent<MissileBehaviour>().triggerCooldown = 1f;
            }
        }
    }
}
