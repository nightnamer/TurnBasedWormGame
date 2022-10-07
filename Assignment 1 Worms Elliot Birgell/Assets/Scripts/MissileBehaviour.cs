using System;
using System.Collections;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{
    //private SpawnManager _spawnManager;
    private HealthController _health;
    private float triggerCooldown = 0.5f;
    public float _damage;

    private CameraController _camera;
    private CinemachineVirtualCamera _cmCam;
    private SpawnManager _spawnManager;

    [SerializeField] private float explosionRadius = 3;
    [SerializeField] private GameObject explosionPrefab;

    private void Awake()
    {
        _spawnManager = FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>();

        _camera = FindObjectOfType<CameraController>().GetComponent<CameraController>();
        _cmCam = FindObjectOfType<CinemachineVirtualCamera>().GetComponent<CinemachineVirtualCamera>();
        _camera.followObject = gameObject.transform;
        _cmCam.Follow = _camera.followObject;
    }

    private void Start()
    {
        GetComponent<SphereCollider>().enabled = false;
        StartCoroutine(setSphereCollision(true));
    }

    private IEnumerator setSphereCollision(bool state)
    {
        yield return new WaitForSeconds(triggerCooldown);
        GetComponent<SphereCollider>().enabled = state;
    }
    
    //Check if hit another collision
    private void OnCollisionEnter(Collision other)
    {
        ExplodeMissile(transform.position,explosionRadius); //create explosion

        //camera
        _camera.followObject = explosionPrefab.transform;
        _cmCam.Follow = _camera.followObject;

        //Destroy
        Destroy(gameObject);
    }
    
    //Explosion Method
    void ExplodeMissile(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.GetComponentInParent<HealthController>())
            {
                var target = hitCollider.gameObject.GetComponentInParent<HealthController>();
                target.health -= _damage;
                target.GetComponentInChildren<HealthBar>().UpdateHealthbar(target.maxHealth,target.health);
                target.GetComponent<Rigidbody>().AddExplosionForce(30,transform.position,explosionRadius,10,ForceMode.Impulse);
            }
        }
        explosionPrefab = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        print("Draw");
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,3);
    }
    
}
