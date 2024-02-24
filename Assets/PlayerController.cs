using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fallVelocity = 0;

    private CharacterController _charactercontroller;
    private Animator _animator;

    private Vector3 _movevector;

    public float Gravity;
    public float JumpForce;
    public float Speed;

    private void Start()
    {
        _charactercontroller = GetComponent<CharacterController>();

        _animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        ///Movement
        _charactercontroller.Move(_movevector * Speed * Time.fixedDeltaTime);

        ///Fall&Jump
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _charactercontroller.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_charactercontroller.isGrounded) _fallVelocity = 0;
    }

    private void Update()
    {
        _movevector = Vector3.zero;

        ///Jump
        if (Input.GetKeyDown(KeyCode.Space) && _charactercontroller.isGrounded)
        {
            _fallVelocity = -JumpForce;
        }

        ///Movement
        if (Input.GetKey(KeyCode.W)) _movevector += transform.forward;
        if (Input.GetKey(KeyCode.A)) _movevector -= transform.right;
        if (Input.GetKey(KeyCode.S)) _movevector -= transform.forward;
        if (Input.GetKey(KeyCode.D)) _movevector += transform.right;
        
        if(_movevector == Vector3.zero)
        {
            _animator.SetBool("IsRunning", false);
        }
        else
        {
            _animator.SetBool("IsRunning", true);
        }
    }
}