using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage;           // Black screen panel (UI Image)
    public TextMeshProUGUI tmpText;   // TextMeshPro text (for "You Lost!")
    public float fadeDuration = 1f;   // Duration of the fade in seconds

    private void Start()
    {
        tmpText.gameObject.SetActive(false); // Ensure the text is initially hidden
    }

    // Call this function when the player loses
    public void OnPlayerLose()
    {
        StartCoroutine(GameOverSequence());
    }

    private IEnumerator GameOverSequence()
    {
        // Start by fading the screen to black
        yield return StartCoroutine(FadeOutScreen());

        // After the screen is black, show the "You Lost" message and fade it in
        tmpText.gameObject.SetActive(true);
        yield return StartCoroutine(FadeInText());
    }

    // Fade the screen to black
    private IEnumerator FadeOutScreen()
    {
        float timeElapsed = 0f;
        Color startColor = fadeImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Target opacity to 1 (opaque)

        while (timeElapsed < fadeDuration)
        {
            fadeImage.color = Color.Lerp(startColor, targetColor, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = targetColor; // Ensure it reaches full opacity
    }

    // Fade in the "You Lost" text
    private IEnumerator FadeInText()
    {
        float timeElapsed = 0f;
        Color startColor = tmpText.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Target alpha 1 (fully visible)

        while (timeElapsed < fadeDuration)
        {
            tmpText.color = Color.Lerp(startColor, targetColor, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        tmpText.color = targetColor; // Ensure it reaches full opacity
    }
}
