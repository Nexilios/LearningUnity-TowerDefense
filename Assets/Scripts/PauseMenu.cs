using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public GameObject pauseMenuUI;

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
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void Menu()
   {
      Debug.Log("Go to menu");
   }
}
