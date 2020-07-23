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
    private GameObject _spawn;

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
            _spawn = WeaponHandler.instance._currentGunPrefab.transform.GetChild(0).gameObject;
            GameObject grenade = Instantiate(grenadePrefab, _spawn.transform.position, _spawn.transform.rotation);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(cameraPos.transform.forward * throwForce, ForceMode.VelocityChange);
            //if there are no more grenades
            if (!AmmoManager.instance.UseAmmo(ammoType))
            {
                WeaponHandler.instance.EquipWeaponInInventory(1);
                WeaponHandler.instance.gunList[0] = null;
            }
        }
        else //if there is no ammo
        {
            AmmoStatus.instance.StatusPopUp();
        }
    }
}

