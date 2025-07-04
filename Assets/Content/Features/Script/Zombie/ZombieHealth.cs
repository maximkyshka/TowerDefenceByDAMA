using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int _health;
    
    [SerializeField] private bool _canRegenerate;
    [SerializeField] private float _regenerationInterval;
    
    private void Start()
    {
        if (_canRegenerate)
            InvokeRepeating(nameof(Regenerate), _regenerationInterval, _regenerationInterval);
    }
    
    private void Regenerate()
    {
        _health += Random.Range(10, 15);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}