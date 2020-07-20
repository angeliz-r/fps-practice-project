using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour, IDamageable
{
    public void DealDamage(int damage)
    {
        Destroy(gameObject);
    }
}
