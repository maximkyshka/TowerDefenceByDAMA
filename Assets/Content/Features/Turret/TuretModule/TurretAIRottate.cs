using UnityEngine;
using System.Linq;

public class TurretAIRottate : MonoBehaviour
{
    private TurretCon _turretCon;
    
    Transform[] target;
    
    [Range(0, 100)] public int MaxDistance;
    [Range(0, 100)] public int MinDistance;

    private void Awake()
    {
        _turretCon = GetComponent<TurretCon>();
        InvokeRepeating("ReFind", 0, 1f);
    }

    void ReFind()
    {
        target = GameObject.FindGameObjectsWithTag("Zombie").Select(go => go.transform).ToArray();
    }

    void LateUpdate()
    {
        if (target != null && target.Length > 0)
        {
            Transform tTarget = null;
            float dis = MaxDistance;
            
            foreach (var t in target)
            {
                if (t == null) continue;
                
                float TDis = Vector3.Distance(transform.position, t.position);
                if (dis > TDis && TDis > MinDistance)
                {
                    dis = TDis;
                    tTarget = t;
                }
            }
                 
            if (tTarget != null)
            {
                Quaternion lookRotation = Quaternion.LookRotation(tTarget.position);
                _turretCon.Input((dis - MinDistance) / (MaxDistance - MinDistance) * 80, lookRotation.eulerAngles.y, tTarget); 
            }
            else
            {
                _turretCon.Input();
            }
        }
        else
        {
            _turretCon.Input();
        }
    }
}