using UnityEngine;
using UnityEngine.AI;

public class ZombieAIControler : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform[] _targetPoint;
    private int _targetPointIndex;
    private ZombieSpavnerControler _spavnerControler;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (_targetPoint != null)
        {
            _agent.SetDestination(_targetPoint[_targetPointIndex].position);
        
            if (Vector3.Distance(transform.position, _targetPoint[_targetPointIndex].position) < 0.5f)
            {
                _targetPointIndex++;
            }
        }
    }
    
    public void Setup(Transform[] targetPoint, ZombieSpavnerControler spavnerControler)
    {
        _targetPoint = targetPoint;
        
        _spavnerControler = spavnerControler;
    }
    
    public int GetCurentPointIndex()
    {
        return _targetPointIndex;
    }
}
