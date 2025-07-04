using UnityEngine;

public class TurretStrike : MonoBehaviour
{
    private TurretCon _turretCon;
    
    [SerializeField] private ParticleSystem[] particle;
    
    [SerializeField] private Transform target;
    
    [SerializeField] private Transform[] SpawnPoint;
    
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
            foreach (var point in SpawnPoint)
            {
                GameObject temp = Instantiate(Bullet, point.position, point.rotation);
                temp.GetComponent<BulletCon>().Spawn(target);
            }

            foreach (var p in particle)
            {
                p.Play();
            }
            
            IsReload = false;
            Invoke("Reload", ReloadTime);
        }
    }
    
    void Reload()
    {
        IsReload = true;
    }
}
