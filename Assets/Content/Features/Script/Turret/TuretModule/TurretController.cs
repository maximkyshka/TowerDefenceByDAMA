using UnityEngine;
using TypeTower;

[ExecuteAlways]
public class TurretController : MonoBehaviour
{
    [SerializeField] private TurretSettings _settings;
    
    [SerializeField] private Transform _turret;
    [SerializeField] private Transform _barrel;
    
    [SerializeField, Range(0.0f, 80.0f)] private float _pitch;
    [SerializeField, Range(0.0f, 360.0f)] private float _yaw;
    
    private Transform _target;
    
    private void LateUpdate()
    {
        if(_settings.UseYaw)
        {
            var targetTurretRotation = Quaternion.Euler(0, _yaw, 0);
            _turret.rotation = Quaternion.Lerp(_turret.rotation, targetTurretRotation, Time.deltaTime * _settings.RotationSpeed);
        }
           
        if (_settings.UsePitch)
        {
            var targetBarrelRotation = Quaternion.Euler(-_pitch, 0, 0);
            _barrel.localRotation = Quaternion.Lerp(_barrel.localRotation, targetBarrelRotation, Time.deltaTime * _settings.RotationSpeed);
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

    public TurretSettings GetSettings()
    {
        return _settings;   
    }
}