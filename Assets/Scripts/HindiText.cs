using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HindiText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI newText;
    private void Start()
    {
        newText.text=Unicode.UnicodeToKrutiDev(newText.text);
    }
}
