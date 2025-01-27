﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager instance;
    public TextMeshProUGUI ammoText;
    public bool isInfinite;

    
    //dictionary: a collection of keys & values
    //this example: a collection of ammoTypes & int (num of ammo left per ammo type)
    //cannot be debugged on inspector
    private Dictionary<AmmoTypes, int> ammoCounts = new Dictionary<AmmoTypes, int>();

    void Awake()
    {
        instance = this;
        //UpdateAmmoText();
    }

    void Update()
    {
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
        ammoCounts[ammoType] += ammoAmt;
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        if (isInfinite)
            ammoText.text = "99";
        else
        {
            AmmoTypes type = WeaponHandler.instance.currentGun.ammoType;
            if (ammoCounts[type] == 0)
                ammoText.text = "000";
            else
                ammoText.text = ammoCounts[type].ToString();
        }
    }


}
