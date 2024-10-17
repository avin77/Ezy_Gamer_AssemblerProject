using VContainer.Unity;
using UnityEngine;
using VContainer;
using ezygamers.CMS;

public class UIManager : MonoBehaviour
{
    private IObjectResolver container;

    [Inject]
    public void Construct(IObjectResolver container)
    {
        this.container = container;
    }

    //There will be different prefabs for each kind of UI -rohan37kumar
    public GameObject dropsUIPrefab;  // Prefab reference
    public GameObject questionPrefab;  // Prefab reference

    private LevelConfiggSO levelSO;     //private LevelSO to hold data -rohan37kumar
    private GameObject currentPrefab;
    private GameObject dropsUIInstance;


    //implemented all the logic for Question progression  -rohan37kumar
    private void OnEnable()
    {
        CMSGameEventManager.OnLoadQuestionData += UpdateUI;
    }

    private void OnDisable()
    {
        CMSGameEventManager.OnLoadQuestionData -= UpdateUI;
    }

    // New method to load a level and its questions at the start of the game -rohan37kumar
    public void LoadLevel(LevelConfiggSO levelData)
    {
        levelSO = levelData;
        CreateUI();

        //Trigger the loading of the first question in the level
        if (levelData.question != null && levelData.question.Count > 0)
        {
            CMSGameEventManager eventManager = container.Resolve<CMSGameEventManager>();
            eventManager.LoadNextQuestion(levelData.question[0]);  // Load the first question, can change index to preview particular question 
        }
    }

    //this method is called once at start
    private void CreateUI()
    {
        DestroyCurrentInstance();
        ChoosePrefab(levelSO.question[0]);
        dropsUIInstance = Instantiate(currentPrefab, transform);
        container.InjectGameObject(dropsUIInstance);
    }

    //Update the UI at every question Change -rohan37kumar
    private void UpdateUI(QuestionBaseSO questionData)
    {
        LoadDropsUI();
        var dragDropUI = dropsUIInstance.GetComponent<PrefabUIManager>();
        dragDropUI.LoadQuestionData(questionData);
    }

    // Method to load DropsUI dynamically and inject dependencies
    public void LoadDropsUI()
    {
        DestroyCurrentInstance();
        ChoosePrefab(levelSO.question[GameManager.CurrentIndex]);
        dropsUIInstance = Instantiate(currentPrefab, transform);
        container.InjectGameObject(dropsUIInstance);
    }

    //method to destroy previously loaded Prefab instance -rohan37kumar
    private void DestroyCurrentInstance()
    {
        if (dropsUIInstance != null)
        {
            Destroy(dropsUIInstance);
            dropsUIInstance = null;
        }
    }

    //simple function to choose which prefab to instantiate (learning or question)  -rohan37kumar
    private void ChoosePrefab(QuestionBaseSO question)
    {
        currentPrefab = question.contentType == ContentType.Learning ? dropsUIPrefab : questionPrefab;
        //TODO: Different types of Questions prefab mapping
    }
}