using UnityEngine;
using UnityEngine.UI; // Нужно для Image
using UnityEngine.SceneManagement; // Нужно для SceneManager
using System.Collections;

public class AnimationEventTrigger : MonoBehaviour
{
    public Image fadeImage; // Сюда ты подключаешь Image из Canvas
    public float fadeDuration = 1f; // Длительность затухания
    public string sceneToLoad = "GameScene";

    public void OnAnimationEnd()
    {
        StartCoroutine(FadeOut(sceneToLoad));
    }

    IEnumerator FadeOut(string sceneName)
    {
        float t = 0;
        Color c = fadeImage.color;
        
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = t / fadeDuration;
            fadeImage.color = c;
            Debug.Log(fadeImage.color);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
