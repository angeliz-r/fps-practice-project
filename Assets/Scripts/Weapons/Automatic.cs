using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Automatic Gun", menuName="Guns/Automatic")]
public class Automatic : Gun
{
    public float fireRate;
    private float _lastTimeFired;
    public override void OnMouseHold(Transform cameraPos)
    {
        if (Time.time - _lastTimeFired > 1 / fireRate)
        {
            _lastTimeFired = Time.time;
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
