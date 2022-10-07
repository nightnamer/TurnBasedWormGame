using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public InputHandler _input;
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerBody;
    [SerializeField] public Camera mainCam;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private float gravity = -5f;
    [SerializeField] private LayerMask _layerMask;

    private bool _keyJump;
    private bool _grounded;
    private bool _jumping;
    private float _newJumpHeight;
    
    public bool plrControl = false;

    private float _jumpBuffer;

    public Vector3 targetVector;
    private void Awake()
    {
        mainCam = FindObjectOfType<CinemachineBrain>().GetComponent<Camera>();
        _input = FindObjectOfType<InputHandler>().GetComponent<InputHandler>();
    }

    private void Update()
    {
        targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        //_grounded = (Physics.Raycast(playerBody.transform.position, Vector3.down, 0.5f,1 << LayerMask.NameToLayer("Ground")));
        //int c = 0 | 192;
        _grounded = (Physics.Raycast(playerBody.transform.position, Vector3.down, (playerBody.transform.localScale.y/2f)+0.4f,_layerMask));
        if (_input.key_jump)
        {
            _jumpBuffer = 80f;
        }
        if (_jumpBuffer > 0f) _jumpBuffer -= 1.0f;

        if (_grounded)
        {
            _jumping = false;
        }
    }
    
    void FixedUpdate()
    {
        if (plrControl)
        {
            //Move
            MoveTowardTarget(targetVector);
            //Jump
            Jump();
        }
        
        rb.AddForce(0f,gravity,0f, ForceMode.Acceleration);
    }

    private void Jump()
    {
        if (_jumpBuffer > 0 && !_jumping)
        {
            _newJumpHeight = Mathf.Sqrt(_jumpHeight * -2f * gravity);
            rb.velocity = new Vector3(rb.velocity.x,_newJumpHeight,rb.velocity.z);
            _jumpBuffer = 0f;
            _jumping = true;
        }
        
        if (rb.velocity.y > 0) _jumpBuffer = 0f;
    }

    private void MoveTowardTarget(Vector3 direction)
    {
        var speed = moveSpeed * Time.fixedDeltaTime;
        direction = Quaternion.Euler(0, mainCam.gameObject.transform.eulerAngles.y, 0) * direction;
        Vector3 norm = direction.normalized;
        direction = (direction.magnitude > norm.magnitude) ? norm : direction;

        if (targetVector.magnitude > 0.1f)
        {
            var rotation = Quaternion.LookRotation(direction);
            playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, rotation, 7.0f);
        }
        rb.velocity = new Vector3(direction.x * speed,rb.velocity.y,direction.z * speed);
    }
    
}