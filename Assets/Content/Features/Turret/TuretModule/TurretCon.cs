using UnityEngine;
using TypeTower;

[ExecuteAlways]
public class TurretCon : MonoBehaviour
{
    [SerializeField] private Tower tower;
    
    [SerializeField] private Transform turret;  
    [SerializeField] private Transform barrel;
    
    [SerializeField] private Transform target;
    
    [SerializeField, Range(0.0f, 360.0f)] private float yRotate;
    
    [SerializeField, Range(0.0f, 80.0f)] private float xRotate;
    [SerializeField] private bool useXRotate;
    
    [SerializeField] private float RotateSpeed;
    
    void LateUpdate()
    {
        Quaternion targetTurretRotation = Quaternion.Euler(0, yRotate, 0);
        turret.rotation = Quaternion.Lerp(turret.rotation, targetTurretRotation, Time.deltaTime * RotateSpeed);
        
        if (useXRotate)
        {
            Quaternion targetBarrelRotation = Quaternion.Euler(-xRotate, 0, 0);
            barrel.localRotation = Quaternion.Lerp(barrel.localRotation, targetBarrelRotation, Time.deltaTime * RotateSpeed);
        }
    }

    public void Input(float x = -1, float y = -1, Transform Target = null)
    {
        xRotate = x;
        yRotate = y;
        target = Target;
    }

    public Transform GetTarget()
    {
        return target;
    }
}