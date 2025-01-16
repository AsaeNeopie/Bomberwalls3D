using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetText : MonoBehaviour
{
    TMP_Text _timerText;

    private void Awake()
    {
        TryGetComponent(out _timerText);
    }
    public void setNewText(string text)
    {
        _timerText.text = text;
    }
}
