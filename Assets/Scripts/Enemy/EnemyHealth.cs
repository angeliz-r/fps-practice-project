using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour, IDamageable
{
    public EnemyStats stats;
    private int _currentHealth;
    private EnemyHealthUI _healthUI;
     void Awake()
    {
        _healthUI = GetComponent<EnemyHealthUI>();
        _currentHealth = stats.maxHealth;
    }

    void Update() => CheckDeath();

    public void DealDamage(int damage)
    {
        _currentHealth -= damage;
        _healthUI.SetHealthBarUI();
    }

    void CheckDeath()
    {
        if (_currentHealth <= 0)
        {
            Destroy(transform.parent.gameObject);
        }     
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    public int GetMaxHealth()
    {
        return stats.maxHealth;
    }
}
