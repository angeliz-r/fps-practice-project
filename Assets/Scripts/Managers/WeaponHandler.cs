using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Gun currentGun;
    public List<Gun> gunList = new List<Gun>();

    private Transform _camTransform;
    private GameObject _currentGunPrefab;
    private int _gunListNum;
    void Awake()
    {
        _camTransform = Camera.main.transform;
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
            currentGun = gunList[0];

        }
        else if (scroll < 0f)
        {
            Destroy(_currentGunPrefab);
            _currentGunPrefab = Instantiate(gunList[1].gunPrefab, transform);
            currentGun = gunList[1];
        }
    }
}
