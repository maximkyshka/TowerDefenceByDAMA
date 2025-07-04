using UnityEngine;
using System.Collections;

public class TurretWeaponSystem : MonoBehaviour
{
    [SerializeField] private Transform[] _projectileSpawnPoints;
    [SerializeField] private float _reloadDuration = 1.0f;
    [SerializeField] private ParticleSystem[] _firingParticles;
    [SerializeField] private GameObject _projectilePrefab;

    private TurretController _turretController;
    private Transform _currentTarget;
    private bool _isReadyToFire = true;

    private void Awake()
    {
        if (_turretController == null)
        {
            _turretController = GetComponent<TurretController>();
        }
    }

    private void Update()
    {
        _currentTarget = _turretController.GetTarget();

        if (_currentTarget != null && _isReadyToFire)
        {
            Fire();
        }
    }

    private void Fire()
    {
        _isReadyToFire = false;

        foreach (var spawnPoint in _projectileSpawnPoints)
        {
            GameObject projectileInstance = Instantiate(_projectilePrefab, spawnPoint.position, spawnPoint.rotation);
            
            var bulletController = projectileInstance.GetComponent<BulletController>();
            if (bulletController != null)
            {
                bulletController.Launch(_currentTarget);
            }
            else
            {
                Debug.LogError("На префабі снаряда відсутній компонент BulletController!", projectileInstance);
            }
        }

        foreach (var particle in _firingParticles)
        {
            particle.Play();
        }
        
        StartCoroutine(ReloadCooldown());
    }

    private IEnumerator ReloadCooldown()
    {
        yield return new WaitForSeconds(_reloadDuration);
        _isReadyToFire = true;
    }
}