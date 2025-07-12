using UnityEngine;
using TypeTower;

public class TowerSelector : MonoBehaviour
{
    [SerializeField] private Tower _selectedTower;
    public Tower SelectedTower => _selectedTower;

    public void SelectTower(Tower tower)
    {
        _selectedTower = tower;
        ReLoad();
    }
    
    public void DeSelectTower()
    {
        _selectedTower = Tower.None;
        ReLoad();
    }
    
    public void ReLoad()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TowerPlacementController>()._towerToBuild = _selectedTower;
    }
}