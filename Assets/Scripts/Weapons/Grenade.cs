using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Grenade", menuName = "Weapons/Grenade")]
public class Grenade : Weapon
{
    [Header("Grenade Overview")]
    public GameObject grenadePrefab;
    public GameObject explosionEffect;
    [Space]
    [Header("Grenade Stats")]
    public float delay;
    public float blastRadius;
    public float explosionForce;
    public float throwForce;

    private Vector3 _worldPos;
    public override void OnMouseDown(Transform cameraPos)
    {
        Throw(cameraPos);
    }

    public override void OnRightMouseDown()
    {

    }

    protected void Throw(Transform cameraPos)
    {
        if (AmmoManager.instance.UseAmmo(ammoType))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                _worldPos = hit.point;
                GameObject grenade = Instantiate(grenadePrefab,_worldPos, cameraPos.rotation);
                Rigidbody rb = grenade.GetComponent<Rigidbody>();
                rb.AddForce(cameraPos.forward * throwForce, ForceMode.VelocityChange);
            }

            //if there are no more grenades
            if (!AmmoManager.instance.UseAmmo(ammoType))
            {
                WeaponHandler.instance.EquipWeaponInInventory(1);
                WeaponHandler.instance.gunList[0] = null;

            }
        }
    }


}
