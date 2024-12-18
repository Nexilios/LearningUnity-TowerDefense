using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    void Start()
    {
        UpdateMoneyUI();
    }
    
    void OnEnable()
    {
        PlayerStats.OnMoneyChanged += UpdateMoneyUI;
    }

    void OnDisable()
    {
        PlayerStats.OnMoneyChanged -= UpdateMoneyUI;
    }
    
    void UpdateMoneyUI()
    {
        moneyText.text = "$" + PlayerStats.Money;
    }
}
