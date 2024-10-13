using UnityEngine;
using TMPro;
using UnityEngine.UI;
using VContainer;
using ezygamers.CMS;

public class DragDropUIManager : MonoBehaviour
{
    public Image questionImage;
    public Text questionText;
    public Text hindiText;
    public AudioSource questionAudioSource;
    public Transform wordOptionsContainer;
    public GameObject wordOptionPrefab;  // Prefab for word options

    private CMSGameEventManager eventManager;

    [Inject]
    public void Construct(CMSGameEventManager eventManager)
    {
        this.eventManager = eventManager;
    }

    private void OnEnable()
    {
        // Subscribe to the event to load question data
        CMSGameEventManager.OnLoadQuestionData += LoadQuestionData;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event to prevent memory leaks
        CMSGameEventManager.OnLoadQuestionData -= LoadQuestionData;
    }

    // Method to load question data and populate the UI
    public void LoadQuestionData(QuestionBaseSO questionData)
    {
        // Load question text and image
        if (questionData.questionText.text != null&&questionText!=null)
        {
            questionText.text = questionData.questionText.text;
        }
        if (questionData.hindiText.text != null)
        {
            hindiText.text = questionData.hindiText.text;
        }
        if (questionData.questionImage.image != null)
        {
            questionImage.sprite = questionData.questionImage.image;
        }



        // Load audio if present
        if (questionData.questionAudio != null)
        {
            questionAudioSource.clip = questionData.questionAudio.audioClip;
        }

        // Clear existing word options
        if (wordOptionsContainer != null)
        {
            foreach (Transform child in wordOptionsContainer)
            {
                Destroy(child.gameObject);
            }

        }

        // Instantiate word options dynamically
        foreach (var wordOption in questionData.englishWordsOptions)
        {
            GameObject option = Instantiate(wordOptionPrefab, wordOptionsContainer);
            option.GetComponentInChildren<TextMeshProUGUI>().text = wordOption.text;

            // Implement drag-and-drop functionality if required
        }
    }
}