using UnityEngine;
using System.Collections;

public class TurretWeaponSystem : MonoBehaviour
{
    private TurretSettings _settings;
    
    [SerializeField] private Transform[] _projectileSpawnPoints;
    
    [SerializeField] private ParticleSystem[] _firingParticles;
    
    [SerializeField] private AudioSource[] _audioSource;

    private TurretController _turretController;
    private Transform _currentTarget;
    private bool _isReadyToFire = false;

    private void Awake()
    {
        _turretController = GetComponent<TurretController>();
        _settings = _turretController.GetSettings();
        
        StartCoroutine(ReloadCooldown());
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
            GameObject projectileInstance = Instantiate(_settings.ProjectilePrefab, spawnPoint.position, spawnPoint.rotation);
            
            var bulletController = projectileInstance.GetComponent<BulletController>();
            
            if (bulletController != null)
            {
                bulletController.Launch(_currentTarget);
            }
        }

        foreach (var Source in _audioSource)
        {
            Source.clip = _settings.SoundClip;
            Source.Play();
        }

        foreach (var particle in _firingParticles)
        {
            particle.Play();
        }
        
        StartCoroutine(ReloadCooldown());
    }

    private IEnumerator ReloadCooldown()
    {
        yield return new WaitForSeconds(_settings.ReloadDuration);
        _isReadyToFire = true;
    }
}