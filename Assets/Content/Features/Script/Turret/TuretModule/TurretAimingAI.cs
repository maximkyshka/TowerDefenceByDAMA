using UnityEngine;
using System.Linq;

public class TurretAimingAI : MonoBehaviour
{
    private TurretController _turretController;
    
    private Transform[] _potentialTargets;
    
    [SerializeField, Range(0, 100)] private float _maxDistance = 50f;
    [SerializeField, Range(0, 100)] private float _minDistance = 5f;

    private void Awake()
    {
        _turretController = GetComponent<TurretController>();
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
        float closestDistance = _maxDistance;
        
        foreach (var potentialTarget in _potentialTargets)
        {
            if (potentialTarget == null) continue;
            
            float distanceToTarget = Vector3.Distance(transform.position, potentialTarget.position);
            if (distanceToTarget < closestDistance && distanceToTarget > _minDistance)
            {
                closestDistance = distanceToTarget;
                bestTarget = potentialTarget;
            }
        }
             
        if (bestTarget != null)
        {
            var direction = bestTarget.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            
            float pitch = (closestDistance - _minDistance) / (_maxDistance - _minDistance) * 80f;
            float yaw = lookRotation.eulerAngles.y;
            
            _turretController.SetAim(pitch, yaw, bestTarget); 
        }
        else
        {
            _turretController.SetAim();
        }
    }
}