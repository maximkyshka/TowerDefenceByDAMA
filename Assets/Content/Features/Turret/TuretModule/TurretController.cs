using UnityEngine;
using TypeTower;

[ExecuteAlways]
public class TurretController : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    
    [SerializeField] private Transform _turret;  
    [SerializeField] private Transform _barrel;
    
    [SerializeField, Range(0.0f, 360.0f)] private float _yaw;
    
    [SerializeField, Range(0.0f, 80.0f)] private float _pitch;
    [SerializeField] private bool _usePitch;
    
    [SerializeField] private float _rotationSpeed;
    
    private Transform _target;
    
    private void LateUpdate()
    {
        var targetTurretRotation = Quaternion.Euler(0, _yaw, 0);
        _turret.rotation = Quaternion.Lerp(_turret.rotation, targetTurretRotation, Time.deltaTime * _rotationSpeed);
        
        if (_usePitch)
        {
            var targetBarrelRotation = Quaternion.Euler(-_pitch, 0, 0);
            _barrel.localRotation = Quaternion.Lerp(_barrel.localRotation, targetBarrelRotation, Time.deltaTime * _rotationSpeed);
        }
    }

    public void SetAim(float pitch = -1, float yaw = -1, Transform target = null)
    {
        _pitch = pitch;
        _yaw = yaw;
        _target = target;
    }

    public Transform GetTarget()
    {
        return _target;
    }
}