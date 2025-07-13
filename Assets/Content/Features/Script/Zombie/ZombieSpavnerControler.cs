using System;
using UnityEngine;
using System.Collections.Generic;
using Random = System.Random;

public class ZombieSpavnerControler : MonoBehaviour
{
    [SerializeField] private VictoryBarControler _victoryBarControler;
    
    [SerializeField] private ZombieWay _way;
    
    private Transform[] _targetPoints;
    
    [SerializeField] private GameObject[] _zombiePrefab;

    [SerializeField] private List<GameObject> _zombie = new List<GameObject>();
    
    [SerializeField, Range(0, 30f)] private float _spawnInterval;
    
    private Random _random = new Random();

    private void Awake()
    {
        _targetPoints = _way.Points;
    }

    private void Start()
    {
        InvokeRepeating("SpawnZombie", 0, _spawnInterval);
        InvokeRepeating("UpdateVictoryBar", 1, 0.25f);
    }

    private void SpawnZombie()
    {
        GameObject temp = Instantiate(_zombiePrefab[_random.Next(0, _zombiePrefab.Length)], transform);
        temp.GetComponent<ZombieAIControler>().Setup(_targetPoints, this);
        _zombie.Add(temp);
    }
    
    private void UpdateVictoryBar()
    {
        int MaxPoint = 0;
        
        foreach (var zombie in _zombie)
        {
            int t = zombie.GetComponent<ZombieAIControler>().GetCurentPointIndex();
            
            if (t > MaxPoint)
            {
                MaxPoint = t;
            }
        }
        _victoryBarControler.ReLoadSlideBar(MaxPoint);
    }

    public int GetPointCount()
    {
        return _targetPoints.Length;
    }
}
