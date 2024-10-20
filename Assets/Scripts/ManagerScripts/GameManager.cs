using UnityEngine;
using VContainer;
using ezygamers.cmsv1;
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


        Debug.Log(uiManager);
        Debug.Log("Game Started");
        // Load the first level's UI and questions
        ProgressBarSet();
        uiManager.LoadLevel(currentLevel);
    }

    //Methods for Level Progression -rohan37kumar
    private void OnAnswerSelected(string selectedAnswer)
    {
        bool isCorrect = AnswerChecker.CheckAnswer(currentLevel.question[CurrentIndex], selectedAnswer);

        if(isCorrect)
        {
            CorrectAnswerSelected();
            return;
        }
        WrongAnswerSelected();
    }

    //currently working on this -rohan37kumar
    private void WrongAnswerSelected()
    {
        //nudge or red logic
        uiManager.LoadWrongUI();
        Debug.Log("Wrong Answer");
        //called LoadNextLevelQuestion without incrementing the index...hence we reload the same level
        eventManager.LoadNextQuestion(currentLevel.question[CurrentIndex]);
    }

    private void CorrectAnswerSelected()
    {
        //acknowledge the user
        uiManager.LoadCorrectUI();
        Debug.Log("Correct Answer");
        MoveToNextQuestion();
    }


    private void MoveToNextQuestion()
    {
        CurrentIndex++;
        ProgressBar.value++;
        if (CurrentIndex < currentLevel.noOfSubLevel)
        {
            eventManager.LoadNextQuestion(currentLevel.question[CurrentIndex]);
        }
        else
        {
            EndGame();
        }
    }

    private void ProgressBarSet()
    {
        //code for Progress Bar Setup -rohan37kumar
        ProgressBar.maxValue = currentLevel.question.Count;
        ProgressBar.value = 0;
    }

    public void EndGame()
    {
        Debug.Log("Game Ended");
       // eventManager.EndGame();
    }



  
}
