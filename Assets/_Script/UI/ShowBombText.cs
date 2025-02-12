using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowBombText : MonoBehaviour
{
    TMP_Text _bombText;
    [SerializeField] PlayerBombing _playerBombing;
    int _bombInInvenotory;
    public void Start()
    {
        _playerBombing.OnBombPickedUp += updateMoreText;
        _playerBombing.OnBombDropped += updateLessText;
        TryGetComponent(out _bombText);
    }

    public void updateMoreText()
    {
        _bombInInvenotory++;
        _bombText.text = "x" + _bombInInvenotory.ToString();
    }
    public void updateLessText()
    {
        _bombInInvenotory--;
        _bombText.text = "x" + _bombInInvenotory.ToString();
    }
}
