using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    private Camera _playerCamera;

    void Awake()
    {
        _playerCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        transform.LookAt(transform.position + _playerCamera.transform.rotation * Vector3.forward, _playerCamera.transform.rotation * Vector3.up);
    }

}
