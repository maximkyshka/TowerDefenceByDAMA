using UnityEngine;

public class BulletCon : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    Rigidbody rb;
    
    [SerializeField, Range(0, 100)] private float Speed;
    [SerializeField] private float RotateSpeed;
    public void Spawn(Transform Target)
    {
        target = Target;
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rb.velocity = transform.forward * Speed;
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * RotateSpeed);
    }
}
