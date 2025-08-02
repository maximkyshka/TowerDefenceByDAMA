using UnityEngine;
using UnityEngine.AI;

public class ZombieAIControler : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _targetPoint;
    private ZombieSpavnerControler _spavnerControler;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (_targetPoint != null)
        {
            _agent.SetDestination(_targetPoint.position);
        }
    }
    
    public void Setup(Transform targetPoint, ZombieSpavnerControler spavnerControler)
    {
        _targetPoint = targetPoint;
        
        _spavnerControler = spavnerControler;
    }
}
