using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TypeTower;

public class UITowerItem : MonoBehaviour
{
    [SerializeField] private TowerUIData _settings;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _priceText;
    
    private Wallet _wallet;
    private TowerSelector _towerSelector;

    private void Awake()
    {
        _wallet = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Wallet>();
        _towerSelector = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TowerSelector>();
        UpdateUI();
    }
    
    public void UpdateUI()
    {
        if(_settings != null)
        {
            gameObject.name = _settings.Name;
            _image.sprite = _settings.Image;
            _priceText.text = $"{_settings.Price}$";
        }
        else
        {
            gameObject.name = "Empty";
            gameObject.SetActive(false);
        }
    }

    public void Buy()
    {
        if (_towerSelector.SelectedTower == Tower.None && 
            _wallet.TryBuy(_settings.Price))
        {
            _wallet.Buy(_settings.Price);
            _towerSelector.SelectTower(_settings.Tower);
        }
    }
}