using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager instance;
    public int ammoCount;
    public TextMeshProUGUI ammoText;
    public bool isInfinite;

    //dictionary: a collection of keys & values
    //this example: a collection of ammoTypes & int (num of ammo left per ammo type)
    //cannot be debugged on inspector
    private Dictionary<AmmoTypes, int> ammoCounts = new Dictionary<AmmoTypes, int>();

    void Awake()
    {
        instance = this;
        UpdateAmmoText();
    }

    void Start()
    {
        for (int i = 0; i < Enum.GetNames(typeof(AmmoTypes)).Length; i++)
        {
            ammoCounts.Add((AmmoTypes)i, 0); // get all enums and put it into a dictionary
        }

    }
    public bool UseAmmo(AmmoTypes ammoType)
    {
        if (isInfinite)
        {
            return true;
        }
        else
        {
            if (ammoCounts[ammoType] > 0)
            {
                ammoCounts[ammoType]--;
                UpdateAmmoText();
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    public void AddAmmo(int ammoAmt, AmmoTypes ammoType)
    {
        //ammoCount += ammoAmt;
        UpdateAmmoText();
        ammoCounts[ammoType] += ammoAmt;
    }

    private void UpdateAmmoText()
    {
        if (isInfinite)
            ammoText.text = "99";
        else
            ammoText.text = ammoCount.ToString();
    }

}
