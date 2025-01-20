using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHpText : MonoBehaviour
{
    TMP_Text _hpText;
    [SerializeField] PlayerHealth _playerHealth;
    public void Start()
    {
        _playerHealth.OnHealthChanged += updateText;
        TryGetComponent(out _hpText);
    }

    public void updateText(int hp)
    {       
        _hpText.text = "x" + hp.ToString();
    }
}
