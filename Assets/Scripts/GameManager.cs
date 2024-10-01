using UnityEngine;
using VContainer;
using ezygamers.CMS;

public class GameManager : MonoBehaviour
{
    private CMSGameEventManager eventManager;  // Reference to CMSGameEventManager
    private  UIManager uiManager;               // Reference to UIManager

    [SerializeField]
    private LevelConfiggSO currentLevel;  // ScriptableObject containing level data

    [Inject]
    public void Construct(CMSGameEventManager eventManager, UIManager uiManager)
    {
        this.eventManager = eventManager;
        this.uiManager = uiManager;
    }
  
      

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        if (uiManager == null)
        {
            Debug.LogError("UIManager not injected!");
            return;
        }
        Debug.Log(uiManager);
        Debug.Log("Game Started");
        // Load the first level's UI and questions
         uiManager.LoadLevel(currentLevel);
    }

    public void EndGame()
    {
        Debug.Log("Game Ended");
       // eventManager.EndGame();
    }



  
}
