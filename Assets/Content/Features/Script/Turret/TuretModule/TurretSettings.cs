using UnityEngine;
using TypeTower;

[CreateAssetMenu(fileName = "TurretData", menuName = "Turret Data")]

public class TurretSettings : ScriptableObject
{
    [SerializeField] private Tower _tower;
    public Tower Tower => _tower;
    
    [SerializeField] private float _reloadDuration;
    public float ReloadDuration => _reloadDuration;
    
    [SerializeField] private GameObject _projectilePrefab;
    public GameObject ProjectilePrefab => _projectilePrefab;

    [SerializeField] private AudioClip Sound;
    public AudioClip SoundClip => Sound;

    [SerializeField, Range(0, 100)] private float _maxDistance;
    public float MaxDistance => _maxDistance;

    [SerializeField, Range(0, 100)] private float _minDistance;
    public float MinDistance => _minDistance;
    
    [SerializeField] private float _rotationSpeed;
    public float RotationSpeed => _rotationSpeed;
    
    [SerializeField] private bool _useYaw;
    public bool UseYaw => _useYaw;
    
    [SerializeField] private bool _usePitch;
    public bool UsePitch => _usePitch;
}
