using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(0.0f,10f)]
    public float speed;
    [Range(0.0f, 20f)]
    public float runSpeed;
    [Range(0.0f, 10f)]
    public float jumpForce;

    public GameObject _playerCamera;

    private float _actualSpeed;
    private float _rayLength = 1.1f;
    private Rigidbody _rb;
    private MovementInput _input;
    private Animator _animator;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<MovementInput>();
        _actualSpeed = speed;
        _animator = _playerCamera.GetComponent<Animator>();
    }

    void Update() => Jump();

    void FixedUpdate() //not dependent on framerate
    {
        if (!GameManager.instance.isPaused)
        {
            Move();
            Run();
        }
        else
        {
            _animator.SetBool("isWalk", false);
            _animator.SetBool("isRun", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(_input.jump) && !GameManager.instance.isPaused)
        {
            _animator.SetBool("isWalk", false);
            _animator.SetBool("isRun", false);
            if (IsGrounded())
                _rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _rayLength);
    }

    private void Move()
    {
        //_animator.SetBool("isWalk", true);
        //_animator.SetBool("isRun", false);
        float hAxis = Input.GetAxisRaw(_input.hAxis);
        float vAxis = Input.GetAxisRaw(_input.vAxis);

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * _actualSpeed * Time.fixedDeltaTime;

        Vector3 newPos = _rb.position + _rb.transform.TransformDirection(movement);

        _rb.MovePosition(newPos);
    }

    private void Run()
    {
        //Debug.Log(_actualSpeed);
        if (Input.GetKey(_input.sprint))
        {
            _actualSpeed = runSpeed;
            _animator.SetBool("isRun", true);
            _animator.SetBool("isWalk", false);
        }
        else if (Input.GetKeyUp(_input.sprint))
        {
            _actualSpeed = speed;
            _animator.SetBool("isRun", false);
            _animator.SetBool("isWalk", true);
        }
    }
  
}
