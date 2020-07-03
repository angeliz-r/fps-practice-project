using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipUI : MonoBehaviour, ILootable
{
    public static TooltipUI instance;
    void Awake()
    {
        instance = this;
    }
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
