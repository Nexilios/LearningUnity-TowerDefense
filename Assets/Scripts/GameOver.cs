using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public SceneFader sceneFader;
    public string menuScene = "MainMenu"; 

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        sceneFader.FadeToScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeToScene(menuScene);
    }
}
