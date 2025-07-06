using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Rigidbody _rigidbody;
    [SerializeField, Range(0.0f, 100.0f)] private float _lifeTime = 5f;
    [SerializeField, Range(0, 100)] private int _damage;
    [SerializeField, Range(0.0f, 100.0f)] private float _speed;
    [SerializeField, Range(0.0f, 100.0f)] private float _rotationSpeed;
    private Quaternion _targetRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Launch(Transform newTarget)
    {
        _target = newTarget;
        Destroy(gameObject, _lifeTime);
        var direction = _target.position - transform.position;  
        _targetRotation = Quaternion.LookRotation(direction);
    }
    
    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.forward * _speed;
        
        if (_target == null)
        {
            return;
        }
        
        _rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, _targetRotation, 
            Time.fixedDeltaTime * _rotationSpeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            if (other.gameObject.TryGetComponent<ZombieHealth>(out var zombieHealth))
            {
                zombieHealth.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}