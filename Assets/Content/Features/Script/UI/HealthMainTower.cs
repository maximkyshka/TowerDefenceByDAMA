using UnityEngine;
using UnityEngine.UI;

public class HealthMainTower : MonoBehaviour
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
    }
}
