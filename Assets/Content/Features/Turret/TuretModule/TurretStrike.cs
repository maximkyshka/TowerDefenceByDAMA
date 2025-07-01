using UnityEngine;

public class TurretStrike : MonoBehaviour
{
    private TurretCon _turretCon;
    
    [SerializeField] private ParticleSystem particle;
    
    [SerializeField] private Transform target;
    
    [SerializeField] private Transform SpawnPoint;
    
    [SerializeField] private float ReloadTime;
    
    [SerializeField] private bool IsReload;

    [SerializeField] private GameObject Bullet;
    
    private void Awake()
    {
        _turretCon = GetComponent<TurretCon>();
        IsReload = true;
    }
    
    void Update()
    {
        target = _turretCon.GetTarget();

        if (target != null)
        {
            Strike();
        }
    }
    
    void Strike()
    {
        if (IsReload)
        {
            GameObject temp = Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
            temp.GetComponent<BulletCon>().Spawn(target);
            particle.Play();
            IsReload = false;
            Invoke("Reload", ReloadTime);
        }
    }
    
    void Reload()
    {
        IsReload = true;
    }
}
