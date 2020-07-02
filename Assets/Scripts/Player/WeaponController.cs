using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //public float rayLength;
    private MovementInput _input;
    private WeaponHandler _weapon;
    void Awake()
    {
        _weapon = FindObjectOfType<WeaponHandler>();
        _input = transform.parent.gameObject.GetComponent<MovementInput>();
    }

    void Update() => InputCheck();

    void InputCheck()
    {
        if (Input.GetMouseButtonDown(_input.shoot))
        {
            _weapon.currentGun.OnMouseDown(this.transform);
        }
        if (Input.GetMouseButton(_input.shoot))
        {
            _weapon.currentGun.OnMouseHold(this.transform);
        }
        if (Input.GetMouseButtonDown(_input.scope))
        {
            _weapon.currentGun.OnRightMouseDown();
        }
    }
}
