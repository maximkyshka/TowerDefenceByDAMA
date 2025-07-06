using UnityEngine;
using UnityEngine.AI;

public class ZombieAIControler : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Transform[] _targetPoint;
    private int _targetPointIndex;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        _agent.SetDestination(_targetPoint[_targetPointIndex].position);
        
        if (Vector3.Distance(transform.position, _targetPoint[_targetPointIndex].position) < 0.5f)
        {
            _targetPointIndex++;
        }
    }
}
