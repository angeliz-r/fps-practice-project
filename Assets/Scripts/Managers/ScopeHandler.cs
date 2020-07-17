using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScopeHandler : MonoBehaviour
{
    public static ScopeHandler instance;
    public Image scopeImg;
    private Camera _playerCam;

    private float initFOV;
    private float zoomFOV;
    void Awake()
    {
        instance = this;
        _playerCam = GetComponent<Camera>();
        initFOV = _playerCam.fieldOfView;
    }

    public void ToggleScope(bool isScoped, Sprite scopeSprite, GameObject gun, float scopeZoom, bool turnOffGun)
    {
        scopeImg.sprite = scopeSprite;
        if (isScoped)
        {
            StartCoroutine(OnScope(gun, scopeZoom, turnOffGun));
        }
        else
        {
            StartCoroutine(OffScope(gun));
            scopeImg.gameObject.SetActive(false);
            gun.SetActive(true);
        }

    }

    IEnumerator OnScope(GameObject gun, float scopeZoom, bool turnOffGun)
    {
        yield return new WaitForSeconds(.15f);
        if (turnOffGun)
            gun.SetActive(false);
        scopeImg.gameObject.SetActive(true);
        zoomFOV = initFOV / scopeZoom;
        _playerCam.fieldOfView = zoomFOV;
    }
    IEnumerator OffScope(GameObject gun)
    {
        yield return new WaitForSeconds(.15f);
        scopeImg.gameObject.SetActive(false);
        gun.SetActive(true);
        _playerCam.fieldOfView = initFOV;
        zoomFOV = initFOV;
    }
}
