using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour
{
    public Gun currentGun;
    public Image currentIcon;
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
}
