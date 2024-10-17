using UnityEngine;
using VContainer;
using ezygamers.CMS;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private CMSGameEventManager eventManager;  // Reference to CMSGameEventManager
    private  UIManager uiManager;               // Reference to UIManager

    [SerializeField]
    private LevelConfiggSO currentLevel;  // ScriptableObject containing level data
    [SerializeField]
    private Slider ProgressBar; //ProgressBar for each level -rohan37kumar

    public static int CurrentIndex; //value for the Current Index of Question Loaded.

    [Inject]
    public void Construct(CMSGameEventManager eventManager, UIManager uiManager)
    {
        this.eventManager = eventManager;
        this.uiManager = uiManager;
    }

    private void OnEnable()
    {
        CMSGameEventManager.OnAnswerSelected += OnAnswerSelected;
    }

    private void OnDisable()
    {
        CMSGameEventManager.OnAnswerSelected -= OnAnswerSelected;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        CurrentIndex = 0;
        if (uiManager == null)
        {
            Debug.LogError("UIManager not injected!");
            return;
        }

        //code for Progress Bar Setup -rohan37kumar
        ProgressBar.maxValue = currentLevel.question.Count;
        ProgressBar.value = 0;

        Debug.Log(uiManager);
        Debug.Log("Game Started");
        // Load the first level's UI and questions
        uiManager.LoadLevel(currentLevel);
    }

    //Methods for Level Progression -rohan37kumar
    private void OnAnswerSelected(string selectedAnswer)
    {
        bool isCorrect = CheckAnswer(selectedAnswer);

        if(!isCorrect)
        {
            return;
        }
        MoveToNextQuestion();
    }

    private void MoveToNextQuestion()
    {
        CurrentIndex++;
        ProgressBar.value++;
        if (CurrentIndex < currentLevel.question.Count)
        {
            eventManager.LoadNextQuestion(currentLevel.question[CurrentIndex]);
        }
        else
        {
            EndGame();
        }
    }
    private bool CheckAnswer(string selectedAnswer)
    {
        //TODO: checking logic to be implemented...
        return true;
    }

    public void EndGame()
    {
        Debug.Log("Game Ended");
       // eventManager.EndGame();
    }



  
}
