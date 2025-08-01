using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ZombieHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField, Range(0, 1000)] private int _health;
    
    [SerializeField] private bool _canRegenerate;
    [SerializeField] private float _regenerationInterval;

    private Transform _cam;
    
    private void Start()
    {
        if (_canRegenerate)
            InvokeRepeating(nameof(Regenerate), _regenerationInterval, _regenerationInterval);
        
        _cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        
        _slider.maxValue = _health;
        
        ReLoadSlider();
    }
    
    private void Regenerate()
    {
        _health += Random.Range(10, 15);
        ReLoadSlider();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        
        ReLoadSlider();
        
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void ReLoadSlider()
    {
        _slider.value = _health;
    }

    private void Update()
    {
        if(_cam != null)
            _slider.transform.LookAt(_cam);
    }
}