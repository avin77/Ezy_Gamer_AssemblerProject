using UnityEngine;
using TMPro;
using UnityEngine.UI;
using VContainer;
using ezygamers.CMS;
using System.Collections.Generic;

public class DragDropUIManager : MonoBehaviour
{
    public Image QuestionImage;
    public Text QuestionText;
    public AudioSource QuestionAudioSource;
    public List<Image> ImgOptions;
    //public Text hindiText;
    //public Transform wordOptionsContainer;
    //public GameObject wordOptionPrefab;  // Prefab for word options

    private CMSGameEventManager eventManager;

    [Inject]
    public void Construct(CMSGameEventManager eventManager)
    {
        this.eventManager = eventManager;
    }

    // Method to load question data and populate the UI based on the type of Question
    public void LoadQuestionData(QuestionBaseSO questionData)
    {
        ResetUI();  // Reset the UI before loading new data

        if (questionData.contentType == ContentType.Learning)
        {
            LoadLearningContent(questionData);
        }
        else if (questionData.contentType == ContentType.Question)
        {
            LoadQuestionContent(questionData);
        }
        
    }

    private void LoadLearningContent(QuestionBaseSO questionData)
    {
        QuestionUIHelper.SetImage(QuestionImage, questionData.questionImage.image);
        QuestionUIHelper.SetText(QuestionText, questionData.hindiText.text, questionData.questionText.text);
        QuestionUIHelper.SetAudio(QuestionAudioSource, questionData.questionAudio.audioClip);
    }

    private void LoadQuestionContent(QuestionBaseSO questionData)
    {
        QuestionUIHelper.SetText(QuestionText, questionData.hindiText.text, questionData.questionText.text);

        if (questionData.imageOptions != null && ImgOptions != null)
        {
            int count = Mathf.Min(questionData.imageOptions.Count, ImgOptions.Count);
            for (int i = 0; i < count; i++)
            {
                QuestionUIHelper.SetImage(ImgOptions[i], questionData.imageOptions[i].sprite);
            }
        }

        QuestionUIHelper.SetAudio(QuestionAudioSource, questionData.questionAudio.audioClip);
    }

    private void ResetUI()
    {
        QuestionUIHelper.ResetImage(QuestionImage);
        QuestionUIHelper.ResetText(QuestionText);
        QuestionUIHelper.ResetAudio(QuestionAudioSource);

        foreach (var imgOption in ImgOptions)
        {
            QuestionUIHelper.ResetImage(imgOption);
        }
    }
}