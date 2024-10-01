using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;
using ezygamers.CMS;
using TMPro;

public class LevelM : MonoBehaviour
{
    [SerializeField] List<LevelConfiggSO> levelConfigSOs;

    [SerializeField] Image questionImage;
    [SerializeField] TextMeshProUGUI questionText;
    int currentSublevel=0;

    private void Start()
    {
        LoadLevel(0);
    }
    void LoadLevel(int levelIndex)
    {
        var currentLevel = levelConfigSOs[levelIndex];
        if (currentSublevel < currentLevel.question.Count)
        {
            if (currentLevel.question[currentSublevel].contentType == ContentType.Learning)
            {
                questionImage.sprite = currentLevel.question[currentSublevel].questionImage.image;
            }
        }
        questionText.text = currentLevel.question[currentSublevel].questionText.text;
    }
}
