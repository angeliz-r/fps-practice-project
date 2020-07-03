using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour, ILootable
{
    public Gun gun;

    public void OnEndLook()
    {

    }

    public void OnInteract()
    {
        WeaponHandler.instance.PickUpGun(gun);
        Destroy(gameObject);
    }

    public void OnStartLook()
    {

    }

}
