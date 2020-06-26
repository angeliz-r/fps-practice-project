using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    private MovementInput _input;
    public float rayLength;
    void Awake()
    {
        _input = transform.parent.gameObject.GetComponent<MovementInput>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastCheck();
    }

    void RaycastCheck()
    {
        if (Input.GetMouseButtonDown(_input.shoot))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, rayLength ))
            {  
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.DealDamage(10);
                }

            }
        }
    }
}
