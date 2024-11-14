using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static event Action OnMoneyChanged;
    
    public int startMoney = 400;
    
    private static int _money;
    public static int Money
    {
        get => _money;
        set
        {
            if (_money == value) return;
            
            _money = value;
            OnMoneyChanged?.Invoke();
        }
    }

    
    void Start()
    {
        Money = startMoney;
    }
}
