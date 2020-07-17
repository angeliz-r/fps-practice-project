using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour
{
    public static WeaponHandler instance;

    public Gun currentGun;
    public Image currentIcon;
    public List<Gun> gunList = new List<Gun>();

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

    void WeaponSelect()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            Destroy(_currentGunPrefab);
            _currentGunPrefab = Instantiate(gunList[0].gunPrefab, transform);
            currentIcon.sprite = gunList[0].gunIcon;
            currentGun = gunList[0];

        }
        else if (scroll < 0f)
        {
            Destroy(_currentGunPrefab);
            _currentGunPrefab = Instantiate(gunList[1].gunPrefab, transform);
            currentIcon.sprite = gunList[1].gunIcon;
            currentGun = gunList[1];
        }
    }

    public void PickUpGun(Gun gun)
    {
        // gunlist 0 - light, gunlist 2 - med/heavy

        if (gun.ammoType == AmmoTypes.Light)
        {
            if (gunList[0] != null)
            {
                Instantiate(gunList[0].gunPickup, transform.position + transform.forward, Quaternion.identity);
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
                Instantiate(gunList[1].gunPickup, transform.position + transform.forward, Quaternion.identity);
                Destroy(_currentGunPrefab);
            }
            gunList[1] = gun;
            currentGun = gunList[1];
            _currentGunPrefab = Instantiate(gun.gunPrefab, transform);
            currentIcon.sprite = gun.gunIcon;
        }
    }
}
