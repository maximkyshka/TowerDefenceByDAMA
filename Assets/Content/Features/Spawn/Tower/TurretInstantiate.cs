using UnityEngine;
using TypeTower;

public class TurretInstantiate : MonoBehaviour
{
    [SerializeField, Range(0.0f, 100.0f)] private float rayDistance;
    [SerializeField] private LayerMask raycastLayers;

    [SerializeField] private GameObject[] TowerGameObject;
    
    void Update()
    {
        Ray rayMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(rayMouse.origin, rayMouse.direction * rayDistance, Color.red, 0.01f);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(rayMouse, out hit, rayDistance, raycastLayers))
            {
                if (hit.collider.CompareTag("PlaneForSpawn"))
                {
                    var tower = TowerToGameObject(Tower.Turret00);   // тут вибір обєкта ДОРОБИТИ
                    Instantiate(tower, hit.collider.transform.position, hit.collider.transform.rotation);
                    hit.collider.gameObject.active = false;
                }
            }
        }
    }

    private GameObject TowerToGameObject(Tower tower)
    {
        var temp = TowerGameObject[(int)tower];
        return temp;
    }
}
