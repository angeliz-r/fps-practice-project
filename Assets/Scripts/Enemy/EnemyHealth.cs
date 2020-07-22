using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour, IDamageable
{
    public EnemyStats stats;

    [Header("Damage Text")]
    public GameObject dmgText;

    private int _currentHealth;
    private EnemyHealthUI _healthUI;

    private EnemyDeath _materialChanger;
     void Awake()
    {
        _healthUI = GetComponent<EnemyHealthUI>();
        _currentHealth = stats.maxHealth;
        _materialChanger = GetComponent<EnemyDeath>();
    }

    public void DealDamage(int damage)
    {
        _currentHealth -= damage;
        Instantiate(dmgText, transform.parent.position, Quaternion.identity).GetComponent<DamageTextDisplay>().Initialize(damage);

        CheckDeath();
        _healthUI.SetHealthBarUI();
    }

    void CheckDeath()
    {
        if (_currentHealth <= 0)
        {
            ScoreManager.instance.AddScore(1);
            _materialChanger.ToggleMaterialChange(true);
            StartCoroutine(Dissolve());
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

    IEnumerator Dissolve()
    {
        yield return new WaitForSeconds(1);
        Destroy(transform.parent.gameObject);
        StopCoroutine(Dissolve());
    }
}
