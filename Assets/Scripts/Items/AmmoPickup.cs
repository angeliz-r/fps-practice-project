using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AmmoPickup : MonoBehaviour, ILootable
{
    public int ammoCount;
    public AmmoTypes ammoType;
    private GlowCheck _glowCheck;

    void Awake()
    {
        _glowCheck = GetComponent<GlowCheck>();
    }
    public void OnStartLook()
    {
        string ammoName = ammoType.ToString() + " AMMO";
        TooltipUI.instance.OnStartLook(ammoName);
        if (_glowCheck != null)
            _glowCheck.ToggleGlow(true);
    }

    public void OnInteract()
    {
        AmmoManager.instance.AddAmmo(ammoCount, ammoType);
        if (_glowCheck != null)
            _glowCheck.ToggleGlow(false);
        Destroy(gameObject);
    }

    public void OnEndLook()
    {
        TooltipUI.instance.OnEndLook();
        if (_glowCheck != null)
            _glowCheck.ToggleGlow(false);
    }

}
