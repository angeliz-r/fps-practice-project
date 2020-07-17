using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    [Header("Gun Overview")]
    public string gunName;
    public GameObject gunPrefab;
    public GameObject gunPickup;
    public Sprite gunIcon;
    public Sprite scope;
    [Space]
    [Header("Gun Stats")]
    public AmmoTypes ammoType;
    public AudioTypes audioType;
    public int minDamage;
    public int maxDamage;
    public float maxRange;
    [Space]
    [Header("Scope")]
    public bool hasScope;
    public bool turnOffGun;
    public float scopeZoom;

    //semi
    public virtual void OnMouseDown(Transform cameraPos) { }
    //auto
    public virtual void OnMouseHold(Transform cameraPos) { }
    //scope
    public virtual void OnRightMouseDown() { }

    protected void Scope ()
    {
        if (hasScope)
        {
            Animator anim = WeaponHandler.instance._currentGunPrefab.GetComponent<Animator>();
            GameObject gun = WeaponHandler.instance._currentGunPrefab;
            if (anim.GetBool("isScoped"))
            {
                anim.SetBool("isScoped", false);
            }
            else
            {
                anim.SetBool("isScoped", true);
            }
            ScopeHandler.instance.ToggleScope(anim.GetBool("isScoped"), scope, gun, scopeZoom, turnOffGun);
        }

    }

    protected void Fire(Transform cameraPos)
    {
        if (AmmoManager.instance.UseAmmo(ammoType))
        {
            AudioManager.instance.PlayAudio(audioType, AudioSourceType.PLAYER_SRC);
            RaycastHit hit;
            if (Physics.Raycast(cameraPos.position, cameraPos.transform.forward, out hit, Mathf.Infinity))
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    float normalizedDistance = hit.distance / maxRange;
                    if (normalizedDistance <= 1) //check if it reaches
                    {
                        //compute damage
                        damageable.DealDamage(Mathf.RoundToInt(Mathf.Lerp(maxDamage, minDamage, normalizedDistance)));
                    }

                }


            }
        }
        else //if there is no ammo
        {
            AmmoStatus.instance.StatusPopUp();
        }
    }
}
