using TMPro;
using UnityEngine;

public class BeginningTimer : MonoBehaviour
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

    public void TriggerGameStart()
    {
        GameManager.Instance.StartGame();
    }
}
