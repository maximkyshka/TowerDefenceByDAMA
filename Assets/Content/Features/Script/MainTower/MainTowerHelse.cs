using UnityEngine;
using UnityEngine.UI;

public class MainTowerHelse : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    [SerializeField, Range(0, 100)] private int _health;
    
    private Transform Cam;
    
    void Start()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _slider.transform.LookAt(Cam);
        _slider.value = _health;
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            _health -= 2;
            _slider.value = _health;
            other.GetComponent<ZombieHealth>().TakeDamage(25, false);
            
            if (_health <= 0)
            {
                Cam.GetComponent<GameControl>().GameOver();
            }
        }
    }
}
