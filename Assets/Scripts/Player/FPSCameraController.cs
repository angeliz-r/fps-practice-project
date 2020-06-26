using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    [Range(0.0f, 10f)]
    public float lookSensitivity;
    [Range(0.0f, 10f)]
    public float smoothing;

    private GameObject _player;
    private Vector2 _lerpVelocity;
    private Vector2 _currentViewPos;
    void Start()
    {
        _player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        //get axis to move
        Vector2 inputValues = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //combine input values with look sensitivity and smoothing
        inputValues = Vector2.Scale(inputValues, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));

        //smooth movements via lerp
        _lerpVelocity.x = Mathf.Lerp(_lerpVelocity.x, inputValues.x, 1f / smoothing);
        _lerpVelocity.y = Mathf.Lerp(_lerpVelocity.y, inputValues.y, 1f / smoothing);

        _currentViewPos += _lerpVelocity;

        //up down
        transform.localRotation = Quaternion.AngleAxis(-_currentViewPos.y, Vector3.right);

        //l & r
        _player.transform.localRotation = Quaternion.AngleAxis(_currentViewPos.x, _player.transform.up);

        //clamp
        _currentViewPos.y = Mathf.Clamp(_currentViewPos.y, -80f, 80f);
    }

}
