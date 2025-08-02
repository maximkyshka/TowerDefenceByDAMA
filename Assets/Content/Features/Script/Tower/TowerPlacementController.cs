using System;
using UnityEngine;
using TypeTower;

public class TowerPlacementController : MonoBehaviour
{
    [SerializeField, Range(0.0f, 600.0f)] private float _placementRayDistance = 100f;
    
    [SerializeField] private LayerMask _placementLayerMask;

    [SerializeField] private GameObject[] _towerPrefabs;
    
    [SerializeField] public Tower _towerToBuild;
    
    private TowerSelector _towerSelector;

    private void Awake()
    {
        _towerSelector = gameObject.GetComponent<TowerSelector>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandlePlacement();
        }
    }

    private void HandlePlacement()
    {
        if (_towerToBuild != Tower.None)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hit, _placementRayDistance, _placementLayerMask))
            {
                if (hit.collider.CompareTag("PlaneForSpawn"))
                {
                    GameObject towerPrefab = GetPrefabForType(_towerToBuild);
                    if (towerPrefab != null)
                    {
                        _towerSelector.DeSelectTower();
                        
                        Transform tileTransform = hit.transform;
                        Instantiate(towerPrefab, tileTransform.position, tileTransform.rotation);

                        tileTransform.gameObject.SetActive(false);
                    }
                }
            }
        }
        
    }
    
    private GameObject GetPrefabForType(Tower towerType)
    {
        int prefabIndex = (int)towerType;

        if (prefabIndex >= 0 && prefabIndex < _towerPrefabs.Length)
        {
            return _towerPrefabs[prefabIndex];
        }
        
        return null;
    }
}