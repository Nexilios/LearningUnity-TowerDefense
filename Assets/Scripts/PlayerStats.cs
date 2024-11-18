using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static event Action OnMoneyChanged;
    public static event Action OnLivesChanged;
    
    public int startLives = 20;
    public int startMoney = 400;
    
    private static int _lives;
    private static int _money;

    public static int Rounds;
    
    public static int Lives
    {
        get => _lives;
        set
        {
            if (_lives == value || value < 0) return;
            
            _lives = value;
            OnLivesChanged?.Invoke();
        }
    }
    
    public static int Money
    {
        get => _money;
        set
        {
            if (_money == value || value < 0) return;
            
            _money = value;
            OnMoneyChanged?.Invoke();
        }
    }
    
    void Start()
    {
        Lives = startLives;
        Money = startMoney;
        Rounds = 0;
    }
}
