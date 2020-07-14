using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AmmoPickup : MonoBehaviour, ILootable
{
    public int ammoCount;
    public AmmoTypes ammoType;

    public void OnStartLook()
    {
        TooltipUI.instance.OnStartLook();
    }

    public void OnInteract()
    {
        AmmoManager.instance.AddAmmo(ammoCount, ammoType);
        Destroy(gameObject);
    }

    public void OnEndLook()
    {
        TooltipUI.instance.OnEndLook();
    }

}
