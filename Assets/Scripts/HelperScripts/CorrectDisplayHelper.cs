using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectDisplayHelper : MonoBehaviour
{
    [SerializeField] private GameObject previousUI;
    [SerializeField] private Image correctImage;
    [SerializeField] private Text subLevelText;
    [SerializeField] private GameObject correctAnswerGroup;

    [SerializeField] private Image imageHolder;
    [SerializeField] private Text textHolder;


    public void DisplayCorrectUI()
    {
        imageHolder = correctImage;
        textHolder.text = subLevelText.text;
        
        Debug.Log("displaying correct UI");
        previousUI.SetActive(false);
        correctAnswerGroup.SetActive(true);
        StartCoroutine(WaitAndContinue());
        correctAnswerGroup.SetActive(false);
    }
    IEnumerator WaitAndContinue()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3);
    }


}