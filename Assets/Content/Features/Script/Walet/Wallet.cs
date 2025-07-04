using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private int _money;

    private void Awake()
    {
        UpdateMoneyText();
    }

    public bool TryBuy(int price)
    {
        if (_money >= price)
        {
            return true;
        }

        return false;
    }
    
    public void Buy(int price)
    {
        if (_money >= price)
        {
            _money -= price;
            UpdateMoneyText();
        }
    }

    public void Add(int amount)
    {
        _money += amount;
        UpdateMoneyText();
    }
    
    private void UpdateMoneyText()
    {
        _moneyText.text = $"{_money}$";
    }
}