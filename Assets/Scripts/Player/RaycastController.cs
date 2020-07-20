using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    [Range(0,500)]
    public float raycastLength;

    private ILootable _currentTarget;
    private MovementInput _input;
    void Awake()
    {
        _input = transform.parent.gameObject.GetComponent<MovementInput>();
    }

    void Update()
    {
        HandleRaycast();
        Interact();
    }

    void Interact()
    {
        if (Input.GetKeyDown(_input.interact))
        {
            if (_currentTarget != null)
            {
                _currentTarget.OnInteract();
            }
        }
        if (Input.GetKeyDown(_input.drop))
        {
            WeaponHandler.instance.DropGun();
        }
    }
    void HandleRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLength))
        {
            ILootable lootable = hit.collider.GetComponent<ILootable>();

            //START FOR LOOTABLE
            if (lootable != null)
            {
                if (lootable == _currentTarget)
                {
                    return;
                }
                else if (_currentTarget != null)
                {
                    _currentTarget.OnEndLook();
                    _currentTarget = lootable;
                    _currentTarget.OnStartLook();
                }
                else
                {
                    _currentTarget = lootable;
                    _currentTarget.OnStartLook();
                }
            }
            else
            {
                if (_currentTarget != null)
                {
                    _currentTarget.OnEndLook();
                    _currentTarget = null;
                }
            }
            //END FOR LOOTABLE

        }
        else
        {
            if (_currentTarget != null)
            {
                _currentTarget.OnEndLook();
                _currentTarget = null;
            }
        }
    }
}
