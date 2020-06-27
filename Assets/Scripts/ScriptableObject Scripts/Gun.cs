using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    [Header("Gun")]
    public string gunName;
    public GameObject gunPrefab;
    public GameObject scope;
    [Space]
    [Header("Gun Stats")]
    public int minDamage;
    public int maxDamage;
    public float maxRange;
    public bool hasScope;

    public virtual void OnMouseDown(Transform cameraPos)
    {

    }
    
    public virtual void OnMouseHold(Transform cameraPos)
    {

    }
}
