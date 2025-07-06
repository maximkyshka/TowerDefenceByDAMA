using UnityEngine;
using UnityEngine.UI;

public class VictoryBarControler : MonoBehaviour
{
    [SerializeField] private GameObject _zombieSpavner;
    [SerializeField] private Slider _slider;
    [SerializeField] private int _pointCount;

    private void Awake()
    {
        _pointCount = _zombieSpavner.GetComponent<ZombieSpavnerControler>().GetPointCount();
    }

    public void ReLoadSlideBar(int MaxPoint)
    {
        if (MaxPoint != 0)
        {
            _slider.value = MaxPoint / (float)_pointCount;
            Debug.Log(MaxPoint / (float)_pointCount);
        }
    }
}
