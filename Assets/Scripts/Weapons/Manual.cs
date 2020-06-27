using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Manual Gun", menuName = "Guns/Manual")]
public class Manual : Gun
{
    public override void OnMouseDown(Transform cameraPos)
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
