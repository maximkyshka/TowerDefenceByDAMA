using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptForHealthToMainTower : MonoBehaviour
{

    [SerializeField] private float maxHealth = 1000f;
    [SerializeField] private float currentHealth;
    [SerializeField] private Slider healthBar;
    [SerializeField] private bool DEBUG;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth; 
        }
        else if (DEBUG)
        {
            Debug.LogWarning("Health Bar �� ��������� �� �������!");
        }
    }
}
