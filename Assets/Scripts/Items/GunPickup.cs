using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour, ILootable
{
    public Gun gun;

    public void OnStartLook()
    {
        TooltipUI.instance.OnStartLook();
    }

    public void OnInteract()
    {
        WeaponHandler.instance.PickUpGun(gun);
        Destroy(gameObject);
    }

    public void OnEndLook()
    {
        TooltipUI.instance.OnEndLook();
    }


}
