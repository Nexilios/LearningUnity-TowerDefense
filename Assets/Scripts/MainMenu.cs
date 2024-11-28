using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";
    public SceneFader sceneFader;
    
    public void Play()
    {
        sceneFader.FadeToScene(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Closing application");
        Application.Quit();
    }
}
