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

    private float _actualSpeed;
    private float _rayLength = 1.1f;
    private Rigidbody _rb;
    private MovementInput _input;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<MovementInput>();
        _actualSpeed = speed;
    }

    void Update() => Jump();

    void FixedUpdate() //not dependent on framerate
    {
        if (!GameManager.instance.isPaused)
        {
            Move();
            Run();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(_input.jump) && !GameManager.instance.isPaused)
        {
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
        }
        else if (Input.GetKeyUp(_input.sprint))
        {
            _actualSpeed = speed;
        }
    }
  
}
