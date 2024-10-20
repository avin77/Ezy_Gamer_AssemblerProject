using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectDisplayHelper : MonoBehaviour
{
    [SerializeField] private Image correctTickImage;
    [SerializeField] private Image correctAnswerImage;
    [SerializeField] private Text correctWord;
    //[SerializeField] private GameObject previousUI;

    private readonly float popUpDuration = 0.3f;
    private readonly float displayDuration = 1.5f;
    private readonly float scaleMultiplier = 1.2f;

    public void DisplayCorrectUI()
    {
        //previousUI.SetActive(false);
        Debug.Log("starting coroutine");
        StartCoroutine(AnimateUISequence());
    }

    private IEnumerator AnimateUISequence()
    {
        // Reset all UI elements
        correctTickImage.gameObject.SetActive(false);
        correctAnswerImage.gameObject.SetActive(false);
        correctWord.gameObject.SetActive(false);

        // Animate tick mark
        yield return StartCoroutine(AnimateElement(correctTickImage.gameObject));

        // Animate correct answer image
        yield return StartCoroutine(AnimateElement(correctAnswerImage.gameObject));

        // Animate correct word
        yield return StartCoroutine(AnimateElement(correctWord.gameObject));

        // Keep everything visible for the display duration
        yield return new WaitForSeconds(displayDuration);

        // Hide everything
        correctTickImage.gameObject.SetActive(false);
        correctAnswerImage.gameObject.SetActive(false);
        correctWord.gameObject.SetActive(false);
    }

    private IEnumerator AnimateElement(GameObject element)
    {
        element.SetActive(true);
        RectTransform rectTransform = element.GetComponent<RectTransform>();

        // Reset scale
        rectTransform.localScale = Vector3.zero;

        float elapsedTime = 0f;
        while (elapsedTime < popUpDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / popUpDuration;

            // Pop up animation
            float scaleFactor = progress <= 0.5f ?
                Mathf.Lerp(0, scaleMultiplier, progress * 2) :
                Mathf.Lerp(scaleMultiplier, 1, (progress - 0.5f) * 2);

            rectTransform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
            yield return null;
        }

        // Ensure final scale is exactly 1
        rectTransform.localScale = Vector3.one;
    }
}