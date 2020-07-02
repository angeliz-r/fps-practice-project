using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour, ILootable
{
    public Gun gun;

    public void OnEndLook()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract()
    {
        throw new System.NotImplementedException();
    }

    public void OnStartLook()
    {
        throw new System.NotImplementedException();
    }

}
