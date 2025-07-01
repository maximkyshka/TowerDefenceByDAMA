using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelseCon : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int Helse;
    
    [SerializeField] private bool Doctor;
    [SerializeField] private float TimeRegen;
    
    void Start()
    {
        if (Doctor)
            InvokeRepeating("Regenerate", TimeRegen, TimeRegen);
    }
    
    private void Regenerate()
    {
        Helse += Random.Range(10, 15);
    }

    public void TakeDamage(int damage)
    {
        Helse -= damage;
        if (Helse <= 0)
        {
            Destroy(gameObject);
        }
    }
}
