using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Automatic Gun", menuName="Guns/Automatic")]
public class Automatic : Gun
{
    [Header("Fire Rate")]
    public float fireRate;
    private float _lastTimeFired;

    private void OnEnable() { _lastTimeFired = 0; }
    public override void OnMouseHold(Transform cameraPos)
    {
        if (Time.time - _lastTimeFired > 1 / fireRate)
        {
            _lastTimeFired = Time.time;
           // Debug.Log("fire auto");
            Fire(cameraPos);
        }
    }

    public override void OnRightMouseDown()
    {
        Scope();
    }
}
