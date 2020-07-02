using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoCount;
    public AmmoTypes ammoType;
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>() != null)
        {
            AmmoManager.instance.AddAmmo(ammoCount, ammoType);
            Destroy(gameObject);
        }
    }
}
