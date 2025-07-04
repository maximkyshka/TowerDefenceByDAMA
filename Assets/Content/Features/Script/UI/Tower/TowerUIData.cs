using UnityEngine;
using TypeTower;

[CreateAssetMenu(fileName = "TowerUIData", menuName = "Tower UI Data")]

public class TowerUIData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name => _name;
    
    [SerializeField] private Sprite _image;
    public Sprite Image => _image;
    
    [SerializeField] private Tower _tower;
    public Tower Tower => _tower;
    
    [SerializeField, Range(0, 100)] private int _price;
    public int Price => _price;
}