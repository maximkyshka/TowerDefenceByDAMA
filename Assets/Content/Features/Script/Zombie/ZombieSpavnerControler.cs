using System.Collections;
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
    
    private Random _random = new Random();
    
    [SerializeField, Range(1, 3)] private int waveLevel = 1;
    private int wavePercent = 0;

    private void Awake()
    {
        _targetPoints = _way.Points;
    }

    private void Start()
    {
        Debug.Log("2");
        UpdateVictoryBar();
        switch (waveLevel)
        {
            case 1:
                StartCoroutine(wave1());
                Debug.Log("20");
                break;
            case 2:
                StartCoroutine(wave2());
                Debug.Log("200");
                break;
            case 3:
                StartCoroutine(wave3());
                Debug.Log("2000");
                break;
        }
        Debug.Log("2");
    }

    private void SpawnZombie(int id = -1)
    {
        GameObject temp = Instantiate(_zombiePrefab[id == -1 ? _random.Next(0, _zombiePrefab.Length) : id], transform);
        temp.GetComponent<ZombieAIControler>().Setup(_targetPoints, this);
        _zombie.Add(temp);
    }
    
    private void UpdateVictoryBar(int Add = 0)
    {
        wavePercent += Add;
        Debug.Log(wavePercent);
        _victoryBarControler.ReLoadSlideBar(wavePercent);
        Debug.Log(wavePercent);
    }

    public int GetPointCount()
    {
        return _targetPoints.Length;
    }

    IEnumerator wave1()
    {
        for (int i = 0; i < 5; i++)
        {
            UpdateVictoryBar(5);
            SpawnZombie(0);
            yield return new WaitForSeconds(_random.Next(7, 13));
        }
        
        yield return new WaitForSeconds(_random.Next(15, 20));
        
        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(5);
            SpawnZombie(_random.Next(0, 1));
            yield return new WaitForSeconds(_random.Next(7, 13));
        }
        
        yield return new WaitForSeconds(_random.Next(15, 20));
        
        for (int i = 0; i < 5; i++)
        {
            UpdateVictoryBar(5);
            SpawnZombie(1);
            yield return new WaitForSeconds(_random.Next(10, 15));
        }
    }
    
    IEnumerator wave2()
    {
        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(2);
            SpawnZombie(0);
            yield return new WaitForSeconds(_random.Next(7, 13));
        }
        
        yield return new WaitForSeconds(_random.Next(15, 20));
        
        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(5);
            SpawnZombie(_random.Next(0, 1));
            yield return new WaitForSeconds(_random.Next(10, 15));
        }
        
        yield return new WaitForSeconds(_random.Next(15, 20));
        
        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(3);
            SpawnZombie(1);
            yield return new WaitForSeconds(_random.Next(7, 13));
        }
    }
    
    IEnumerator wave3()
    {
        for (int i = 0; i < 20; i++)
        {
            UpdateVictoryBar(1);
            SpawnZombie(0);
            yield return new WaitForSeconds(_random.Next(5, 10));
        }
        
        yield return new WaitForSeconds(_random.Next(10, 15));
        
        for (int i = 0; i < 50; i++)
        {
            UpdateVictoryBar(1);
            SpawnZombie(_random.Next(0, 1));
            yield return new WaitForSeconds(_random.Next(3, 5));
        }
        
        yield return new WaitForSeconds(_random.Next(15, 25));
        
        for (int i = 0; i < 30; i++)
        {
            UpdateVictoryBar(1);
            SpawnZombie(1);
            yield return new WaitForSeconds(_random.Next(8, 14));
        }
    }
}
