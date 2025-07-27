using UnityEngine;

public class MoneyBox : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int _minMoney;
    [SerializeField, Range(0, 100)] private int _maxMoney;
    
    [SerializeField, Range(0, 25)] private float _time;
    
    [SerializeField] private GameObject _money;

    
    void Start()
    {
        InvokeRepeating(nameof(SpavnMoney), 15, _time);
    }

    void SpavnMoney()
    {
        Instantiate(_money, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
    }
}
