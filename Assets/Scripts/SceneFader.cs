using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public AnimationCurve fadeCurve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }
    
    IEnumerator FadeIn()
    {
        float time = 1f;

        while (time > 0f)
        {
           time -= Time.deltaTime;
           float alpha = fadeCurve.Evaluate(time);
           fadeImage.color = new Color(0f, 0f, 0f, alpha);
           yield return 0;
        }
    }
    
    IEnumerator FadeOut(string sceneName)
    {
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime;
            float alpha = fadeCurve.Evaluate(time);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }
        
        SceneManager.LoadScene(sceneName);
    }
}
