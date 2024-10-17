using UnityEngine;
using UnityEngine.UI;

public class QuestionUIHelper
{
    public static void SetText(Text uiTextComponent, string hindiText, string englishText)
    {
        if (uiTextComponent != null)
        {
            uiTextComponent.text = string.IsNullOrEmpty(hindiText) ? englishText : $"{hindiText}\n{englishText}";
        }
    }

    public static void SetImage(Image uiImageComponent, Sprite imageSprite)
    {
        if (uiImageComponent != null && imageSprite != null)
        {
            uiImageComponent.sprite = imageSprite;
        }
    }

    public static void SetAudio(AudioSource audioSource, AudioClip audioClip)
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    public static void ResetImage(Image uiImageComponent)
    {
        if (uiImageComponent != null)
        {
            uiImageComponent.sprite = null;
        }
    }

    public static void ResetAudio(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = null;
        }
    }

    public static void ResetText(Text uiTextComponent)
    {
        if (uiTextComponent != null)
        {
            uiTextComponent.text = string.Empty;
        }
    }
}

