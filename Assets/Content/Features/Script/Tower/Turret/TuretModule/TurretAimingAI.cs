using UnityEngine;
using System.Linq;

public class TurretAimingAI : MonoBehaviour
{
    private TurretSettings _settings;
    
    private TurretController _turretController;
    
    [SerializeField] private Transform[] _potentialTargets;

    private void Awake()
    {
        _turretController = GetComponent<TurretController>();
        _settings = _turretController.GetSettings();
        InvokeRepeating(nameof(FindTargets), 0, 1f);
    }

    private void FindTargets()
    {
        _potentialTargets = GameObject.FindGameObjectsWithTag("Zombie").Select(go => go.transform).ToArray();
    }

    private void LateUpdate()
    {
        if (_potentialTargets == null || _potentialTargets.Length == 0)
        {
            _turretController.SetAim();
            return;
        }

        Transform bestTarget = null;
        float closestDistance = _settings.MaxDistance;
        
        foreach (var potentialTarget in _potentialTargets)
        {
            if (potentialTarget == null) continue;
            
            float distanceToTarget = Vector3.Distance(transform.position, potentialTarget.position);
            if (distanceToTarget < closestDistance && distanceToTarget > _settings.MinDistance)
            {
                closestDistance = distanceToTarget;
                bestTarget = potentialTarget;
            }
        }
             
        if (bestTarget != null)
        {
            var direction = bestTarget.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            
            float pitch = (closestDistance - _settings.MinDistance) / (_settings.MaxDistance - _settings.MinDistance) * 80f;
            float yaw = lookRotation.eulerAngles.y;
            
            _turretController.SetAim(pitch, yaw, bestTarget); 
        }
        else
        {
            _turretController.SetAim();
        }
    }
}