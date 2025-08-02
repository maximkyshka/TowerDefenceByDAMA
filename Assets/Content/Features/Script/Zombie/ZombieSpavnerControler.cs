using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Random = System.Random;

public class ZombieSpavnerControler : MonoBehaviour
{
    [SerializeField] private WaveBarControler _victoryBarControler;
    
    [SerializeField] private ZombieWay _way;
    
    private Transform[] _targetPoints;
    
    [SerializeField] private GameObject[] _zombiePrefab;

    [SerializeField] private List<GameObject> _zombie;
    
    private Random _random = new Random();
    
    [SerializeField, Range(1, 3)] private int waveLevel = 1;
    private int wavePercent = 0;
    
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _targetPoints = _way.Points;
        _particleSystem = GetComponent<ParticleSystem>();
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
        GameObject temp = Instantiate(_zombiePrefab[id == -1 ? _random.Next(0, _zombiePrefab.Length) : id], transform.position, Quaternion.identity, transform);
        temp.GetComponent<ZombieAIControler>().Setup(_targetPoints, this);
        _zombie.Add(temp);
        _particleSystem.Play();
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
        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(2);
            SpawnZombie(0);
            yield return new WaitForSeconds(_random.Next(4, 7));
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
            UpdateVictoryBar(6);
            SpawnZombie(_random.Next(0, 2));
            yield return new WaitForSeconds(_random.Next(10, 15));
        }
        
        while (true)
        {
            END();
            yield return new WaitForSeconds(1);
        }
    }
    
    IEnumerator wave2()
    {
        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(2);
            SpawnZombie(_random.Next(0, 2) == 2 ? 4 : _random.Next(0, 1));;
            yield return new WaitForSeconds(_random.Next(3, 5));
        }
        
        yield return new WaitForSeconds(_random.Next(15, 20));
        
        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(5);
            SpawnZombie(_random.Next(0, 1) == 0 ? 0 : 2);
            yield return new WaitForSeconds(_random.Next(5, 7));
        }
        
        yield return new WaitForSeconds(_random.Next(15, 20));
        
        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(3);
            SpawnZombie(_random.Next(0, 1) == 0 ? 1 : 5);
            yield return new WaitForSeconds(_random.Next(4, 6));
        }
        
        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(3);
            SpawnZombie(_random.Next(0, 4));
            if (i == 6)
            {
                for (int j = 0; j < 2; j++)
                {
                    yield return new WaitForSeconds(_random.Next(4, 10));
                    SpawnZombie(4);
                }
            }
            yield return new WaitForSeconds(_random.Next(4, 6));
        }
        
        while (true)
        {
            END();
            yield return new WaitForSeconds(1);
        }
    }
    
    IEnumerator wave3()
    {
        for (int i = 0; i < 20; i++)
        {
            UpdateVictoryBar(1);
            SpawnZombie(_random.Next(0, 1) == 0 ? 0 : 2);
            yield return new WaitForSeconds(_random.Next(2, 4));
        }
        
        yield return new WaitForSeconds(_random.Next(10, 15));
        
        for (int i = 0; i < 50; i++)
        {
            UpdateVictoryBar(1);
            SpawnZombie(_random.Next(4, 5));
            yield return new WaitForSeconds(_random.Next(3, 5));
        }
        
        yield return new WaitForSeconds(_random.Next(15, 25));
        
        for (int i = 0; i < 30; i++)
        {
            UpdateVictoryBar(1);
            SpawnZombie(_random.Next(1, 3));
            if (i == 6)
            {
                for (int j = 0; j < 6; j++)
                {
                    yield return new WaitForSeconds(_random.Next(4, 10));
                    SpawnZombie(4);
                }
            }
            yield return new WaitForSeconds(_random.Next(4, 6));
        }

        while (true)
        {
            END();
            yield return new WaitForSeconds(1);
        }
    }

    void END()
    {
        int t = 0;

        foreach (var zombie in _zombie)
        {
            t += zombie == null ? 0 : 1;
        }

        if (t == 0)
        {
            GameObject.FindGameObjectWithTag("MainCamera").
                GetComponent<GameControl>().GameWin();
        }
    }
}
