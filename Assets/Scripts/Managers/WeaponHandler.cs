using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour
{
    public static WeaponHandler instance;

    public Weapon currentGun;
    public Image currentIcon;
    public List<Weapon> gunList = new List<Weapon>();

    private Transform _camTransform;
    [HideInInspector]public GameObject _currentGunPrefab;
    private int _gunListNum;

    void Awake()
    {
        _camTransform = Camera.main.transform;
        instance = this;
    }

    void Start()
    {
        currentGun = gunList[0];
        _currentGunPrefab = Instantiate(gunList[0].gunPrefab, transform);
    }

   
    void Update()
    {
        WeaponSelect();
    }

    public void EquipWeaponInInventory(int gunListIndex)
    {
        Destroy(_currentGunPrefab);
        _currentGunPrefab = Instantiate(gunList[gunListIndex].gunPrefab, transform);
        currentIcon.sprite = gunList[gunListIndex].gunIcon;
        currentGun = gunList[gunListIndex];
    }

    void WeaponSelect()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f && gunList[0] != null && gunList[1] != null)
        {
            EquipWeaponInInventory(0);
        }
        else if (scroll < 0f && gunList[1] != null && gunList[0] != null)
        {

            EquipWeaponInInventory(1);
        }
    }

    public void PickUpGun(Weapon gun)
    {
        // gunlist 0 - light, gunlist 2 - med/heavy
        if (gun.ammoType == AmmoTypes.Light || gun.ammoType == AmmoTypes.Grenade)
        {
            if (gun.ammoType == AmmoTypes.Grenade)
            {
                //auto add 1 ammo grenade on picking up a grenade
                AmmoManager.instance.AddAmmo(1, AmmoTypes.Grenade);
            }
            if (gunList[0] != null)
            {
                //throw old gun
                Instantiate(gunList[0].gunPickup, transform.position + transform.forward, Quaternion.identity);
                Destroy(_currentGunPrefab);
            }
            else
            {
                //destroy current gun visual equipped
                Destroy(_currentGunPrefab);
            }
            gunList[0] = gun;
            currentGun = gunList[0];
            _currentGunPrefab = Instantiate(gun.gunPrefab, transform);
            currentIcon.sprite = gun.gunIcon;
        }
        else if (gun.ammoType == AmmoTypes.Medium || gun.ammoType == AmmoTypes.Heavy)
        {
            if (gunList[1] != null)
            { 
                //throw old gun
                Instantiate(gunList[1].gunPickup, transform.position + transform.forward, Quaternion.identity);
                //destroy current gun visual equipped
                Destroy(_currentGunPrefab);
            }
            else
            {   //destroy current gun visual equipped
                Destroy(_currentGunPrefab);
            }
            gunList[1] = gun;
            currentGun = gunList[1];
            _currentGunPrefab = Instantiate(gun.gunPrefab, transform);
            currentIcon.sprite = gun.gunIcon;
        }
    }

    public void DropGun()
    {
        if (currentGun != null)
        {
            //look for gun to remove
            foreach (Weapon weapon in gunList)
            {
                if (currentGun.gunName == weapon.gunName)
                {
                    _gunListNum = gunList.IndexOf(weapon);
                }
            }
            //throw gun to the ground and destroy
            Instantiate(currentGun.gunPickup, transform.position + transform.forward, Quaternion.identity);
            //remove gun fron list
            gunList[_gunListNum] = null;
            //auto switch weapon to the available one left
            switch (_gunListNum)
            {
                case 0:
                    EquipWeaponInInventory(1);
                    break;
                case 1:
                    EquipWeaponInInventory(0);
                    break;
            }
        }

    }
}
