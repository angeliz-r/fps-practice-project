using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rocket Launcher", menuName = "Weapons/Rocket Launcher")]
public class RocketLauncher : Weapon
{
    [Header("Rocket Bullet")]
    public Grenade bullet;
    public GameObject spawnPos;

    private GameObject _spawn;

    public override void OnMouseDown(Transform cameraPos)
    {
        Launch(cameraPos);
    }

    public override void OnRightMouseDown()
    {

    }

    protected void Launch(Transform cameraPos)
    {
        _spawn = WeaponHandler.instance._currentGunPrefab.transform.GetChild(0).gameObject;

        if (AmmoManager.instance.UseAmmo(ammoType))
        {
            AudioManager.instance.PlayAudio(audioType, AudioSourceType.PLAYER_SRC);
            GameObject rocket = Instantiate(bullet.grenadePrefab, _spawn.transform.position, _spawn.transform.rotation);
            Rigidbody rb = rocket.GetComponent<Rigidbody>();
            rb.AddForce(_spawn.transform.forward * bullet.throwForce);
        }
        else //if there is no ammo
        {
            AmmoStatus.instance.StatusPopUp();
        }
    }
}
