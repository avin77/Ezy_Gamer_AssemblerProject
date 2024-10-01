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

    public GameObject dropsUIPrefab;  // Prefab reference

    // Method to load DropsUI dynamically and inject dependencies
    public void LoadDropsUI()
    {
        
        var dropsUIInstance = Instantiate(dropsUIPrefab, transform);
       
        container.InjectGameObject(dropsUIInstance);
    }

    // New method to load a level and its questions
    public void LoadLevel(LevelConfiggSO levelData)
    {
        
        // Load the DropsUI (if not already loaded)

        LoadDropsUI();

        //Trigger the loading of the first question in the level
        if (levelData.question != null && levelData.question.Count > 0)
        {
            CMSGameEventManager eventManager = container.Resolve<CMSGameEventManager>();
            eventManager.LoadQuestion(levelData.question[0]);  // Load the first question
        }
    }
}