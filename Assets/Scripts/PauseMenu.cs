using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public GameObject pauseMenuUI;
   public SceneFader sceneFader;
   public string menuScene = "MainMenu";
   
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
      {
         Toggle();
      }
   }

   public void Toggle()
   {
      pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

      Time.timeScale = pauseMenuUI.activeSelf ? 0f : 1f;
   }

   public void Retry()
   {
      Toggle();
      sceneFader.FadeToScene(SceneManager.GetActiveScene().name);
   }

   public void Menu()
   {
      Toggle();
      sceneFader.FadeToScene(menuScene);
   }
}
