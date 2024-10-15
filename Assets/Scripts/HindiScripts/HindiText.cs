using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HindiText : MonoBehaviour
{
    private Text newText;
    private void Start()
    {
        newText = this.gameObject.GetComponent<Text>();
        newText.text=HindiCorrector.Correct(newText.text);
    }
}
