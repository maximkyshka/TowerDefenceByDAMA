using UnityEngine;
using UnityEngine.UI;

public class WaveBarControler : MonoBehaviour
{
    [SerializeField] private GameObject _zombieSpavner;
    [SerializeField] private Slider _slider;
    private int _point = 0;

    private void Start()
    {
        _slider.onValueChanged.AddListener(delegate { sliderRefresh(); });
        sliderRefresh();
    }

    private void sliderRefresh()
    {
        _slider.value = _point;
    }

    public void ReLoadSlideBar(int Point)
    {
        _point = Point;
        sliderRefresh();
    }
}
