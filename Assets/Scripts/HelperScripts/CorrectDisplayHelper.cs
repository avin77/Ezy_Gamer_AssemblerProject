using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectDisplayHelper : MonoBehaviour
{
    //[SerializeField] private Sprite correctTickImage;

    [SerializeField] private Image correctAnswerImage;
    [SerializeField] private Text correctWord;

    [SerializeField] private GameObject previousUI;

    public void DisplayCorrectUI()
    {
        previousUI.SetActive(false);

        //display correct tick mark and correct images

    }

}
