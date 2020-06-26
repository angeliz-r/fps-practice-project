using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour, IDamageable
{
    public EnemyStats stats;
    private int _currentHealth;
     void Awake()
    {
        _currentHealth = stats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
    }

    public void DealDamage(int damage)
    {
        _currentHealth -= damage;
    }

    void CheckDeath()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }     
    }
}
