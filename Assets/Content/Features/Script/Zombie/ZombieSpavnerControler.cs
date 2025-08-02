using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Random = System.Random;

public class ZombieSpavnerControler : MonoBehaviour
{
    [SerializeField] private WaveBarControler _victoryBarControler;
    
    [SerializeField] private Transform _targetPoint;
    
    [SerializeField] private GameObject[] _zombiePrefab;

    [SerializeField] private List<GameObject> _zombie;
    
    private Random _random = new Random();
    
    [SerializeField, Range(1, 3)] private int waveLevel = 1;
    private int wavePercent = 0;
    
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        UpdateVictoryBar();
        switch (waveLevel)
        {
            case 1:
                StartCoroutine(wave1());
                break;
            case 2:
                StartCoroutine(wave2());
                break;
            case 3:
                StartCoroutine(wave3());
                break;
        }
    }

    private void SpawnZombie(int id = -1)
    {
        GameObject temp = Instantiate(_zombiePrefab[id == -1 ? _random.Next(0, _zombiePrefab.Length) : id], transform.position, Quaternion.identity, transform);
        temp.GetComponent<ZombieAIControler>().Setup(_targetPoint, this);
        _zombie.Add(temp);
        _particleSystem.Play();
    }

    private void UpdateVictoryBar(int Add = 0)
    {
        wavePercent += Add;
        _victoryBarControler.ReLoadSlideBar(wavePercent);
    }


    IEnumerator wave1()
    {
        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(1);
            SpawnZombie(0);
            yield return new WaitForSeconds(_random.Next(4, 7));
        }

        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(1);
            SpawnZombie(_random.Next(0, 2));
            yield return new WaitForSeconds(_random.Next(4, 7));
        }

        yield return new WaitForSeconds(_random.Next(15, 20));
        
        for (int i = 0; i < 10; i++)
        {
            UpdateVictoryBar(5);
            SpawnZombie(_random.Next(1, 3));
            yield return new WaitForSeconds(_random.Next(7, 13));
        }
        
        yield return new WaitForSeconds(_random.Next(15, 20));
        
        for (int i = 0; i < 5; i++)
        {
            UpdateVictoryBar(6);
            SpawnZombie(_random.Next(0, 5));
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
            SpawnZombie(_random.Next(0, 1));
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
            SpawnZombie(_random.Next(0, 1) == 0 ? 1 : 3);
            yield return new WaitForSeconds(_random.Next(4, 6));
        }
        
        for (int i = 0; i < 30; i++)
        {
            UpdateVictoryBar(0);
            SpawnZombie(_random.Next(0, 6));
            if (i == 6)
            {
                for (int j = 0; j < 4; j++)
                {
                    yield return new WaitForSeconds(_random.Next(4, 10));
                    SpawnZombie(6);
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
            SpawnZombie(_random.Next(0, 4));
            yield return new WaitForSeconds(_random.Next(2, 4));
        }
        
        yield return new WaitForSeconds(_random.Next(10, 15));
        
        for (int i = 0; i < 50; i++)
        {
            UpdateVictoryBar(1);
            SpawnZombie(_random.Next(2, 5));
            yield return new WaitForSeconds(_random.Next(3, 5));
        }
        
        yield return new WaitForSeconds(_random.Next(15, 25));
        
        for (int i = 0; i < 30; i++)
        {
            UpdateVictoryBar(1);
            SpawnZombie(_random.Next(1, 5));
            if (i == 6)
            {
                for (int j = 0; j < 10; j++)
                {
                    yield return new WaitForSeconds(_random.Next(4, 10));
                    SpawnZombie(6);
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
