using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AmmoPickup : MonoBehaviour, ILootable
{
    public int ammoCount;
    public AmmoTypes ammoType;
    public TextMeshProUGUI tooltipText;

    public void OnStartLook()
    {
        //show tooltip ui
        tooltipText.gameObject.SetActive(true);
        tooltipText.text = "PRESS " + MovementInput.instance.interact.ToString() + " TO PICK UP " + ammoType.ToString().ToUpper();
    }

    public void OnInteract()
    {
        AmmoManager.instance.AddAmmo(ammoCount, ammoType);
        Destroy(gameObject);
    }

    public void OnEndLook()
    {
        //hide tooltip ui
        tooltipText.gameObject.SetActive(false);
    }

}
