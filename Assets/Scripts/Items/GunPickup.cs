using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour, ILootable
{
    public Weapon gun;
    private GlowCheck _glowCheck;
    void Awake()
    {
        _glowCheck = GetComponent<GlowCheck>();
    }
    public void OnStartLook()
    {
        TooltipUI.instance.OnStartLook(gun.gunName);
        if (_glowCheck != null)
            _glowCheck.ToggleGlow(true);
    }

    public void OnInteract()
    {
        WeaponHandler.instance.PickUpGun(gun);
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
