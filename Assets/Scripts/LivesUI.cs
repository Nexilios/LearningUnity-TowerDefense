using System;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    void Start()
    {
        UpdateLivesText();
    }
    
    void OnEnable()
    {
        PlayerStats.OnLivesChanged += UpdateLivesText;
    }

    void OnDisable()
    {
        PlayerStats.OnLivesChanged -= UpdateLivesText;
    }

    void UpdateLivesText()
    {
        livesText.text = PlayerStats.Lives + " LIVES";
    }
}
