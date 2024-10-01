using System;
using UnityEngine;
using ezygamers.CMS;
public class CMSGameEventManager
{
    // Event for loading level data (passing LevelConfiggSO)
    public static Action<LevelConfiggSO> OnLoadLevelData;

    // Event for loading question data (passing QuestionBaseSO)
    public static Action<QuestionBaseSO> OnLoadQuestionData;

    // Method to trigger the loading of a level
    public void LoadLevel(LevelConfiggSO levelData)
    {
        Debug.Log("Loading level data...");
        OnLoadLevelData?.Invoke(levelData);
    }

    // Method to trigger the loading of a question
    public void LoadQuestion(QuestionBaseSO questionData)
    {
        Debug.Log("Loading question data...");
        OnLoadQuestionData?.Invoke(questionData);
    }
}