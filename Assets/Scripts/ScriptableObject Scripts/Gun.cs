using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    [Header("Gun Overview")]
    public string gunName;
    public GameObject gunPrefab;
    public Sprite gunIcon;
    public GameObject scope;
    [Space]
    [Header("Gun Stats")]
    public AmmoTypes ammoType;
    public int minDamage;
    public int maxDamage;
    public float maxRange;
    public bool hasScope;

    //semi
    public virtual void OnMouseDown(Transform cameraPos) { }
    //auto
    public virtual void OnMouseHold(Transform cameraPos) { }
    //scope
    public virtual void OnRightMouseDown() { }
    
    protected void Fire(Transform cameraPos) 
    {
        if (AmmoManager.instance.UseAmmo(ammoType))
        {
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
    }
}
