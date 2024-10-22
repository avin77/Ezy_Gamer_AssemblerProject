using ezygamers.cmsv1;
using ezygamers.dragndropv1;
using System.Collections.Generic;
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

    public static void SetOptionsData(List<ImageOption> imageOptions, List<OptionContainer> OptionHolders, List<DropHandler> dropHandlers)
    {
        if (imageOptions != null && OptionHolders != null)
        {
            int count = Mathf.Min(imageOptions.Count, OptionHolders.Count);
            for (int i = 0; i < count; i++)
            {
                QuestionUIHelper.SetImage(OptionHolders[i].image, imageOptions[i].sprite);
                dropHandlers[i].OptionID = imageOptions[i].optionID;
            }
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
            //audioSource.Play();
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

