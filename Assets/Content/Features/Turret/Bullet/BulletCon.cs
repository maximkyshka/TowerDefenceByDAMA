using UnityEngine;

public class BulletCon : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Rigidbody rb;
    [SerializeField, Range(0.0f, 100.0f)] private float timeLive = 5f;
    [SerializeField, Range(0, 100)] private int damage;
    [SerializeField, Range(0.0f, 100.0f)] private float speed;
    [SerializeField, Range(0.0f, 100.0f)] private float rotateSpeed;
    private Quaternion targetRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Spawn(Transform newTarget)
    {
        target = newTarget;
        Destroy(gameObject, timeLive);
        var direction = target.position - transform.position;  
        targetRotation = Quaternion.LookRotation(direction);
    }
    
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
        
        if (target == null)
        {
            return;
        }
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, 
            Time.fixedDeltaTime * rotateSpeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            other.gameObject.GetComponent<HelseConZombie>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}