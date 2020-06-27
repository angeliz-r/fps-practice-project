using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthUI : MonoBehaviour
{
    public Slider healthBar;
    public Image healthFill;
    public Color maxHealthColor;
    public Color zeroHealthColor;

    private EnemyHealth _enemyHealth;
    private int _maxHealth;
   
    void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _maxHealth = _enemyHealth.GetMaxHealth();
        healthBar.maxValue = _maxHealth;
        healthBar.value = _enemyHealth.GetCurrentHealth();

    }

    void Start () => SetHealthBarUI();
    

    public void SetHealthBarUI ()
    {
        float healthPercentage = CalculateHealthPercentage();
        healthBar.value = healthPercentage;
        healthFill.color = Color.Lerp(zeroHealthColor, maxHealthColor, healthPercentage / 100);
    }

    private float CalculateHealthPercentage()
    {
        return ((float)_enemyHealth.GetCurrentHealth() /(float) _maxHealth) * 100;
    }

}