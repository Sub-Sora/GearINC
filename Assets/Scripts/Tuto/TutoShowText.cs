using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TutoShowText : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerMvmnt;

    [SerializeField]
    private GameObject _uperTutoText;

    [SerializeField]
    private GameObject _underTutoText;

    private TextMeshProUGUI _text;

    private delegate void TutoActivate(bool OnTuto);
    private TutoActivate _onTuto;

    private void Start()
    {
        
    }

    private void DisablePlayer(bool OnTuto)
    {
        if (OnTuto) _playerMvmnt.SetActive(false);
        else _playerMvmnt.SetActive(true);
    }

    private void ShowText()
    {
        _onTuto(true);
    }

    public void ShowText(string text, bool isUnder)
    {
        if (isUnder)
        {
            _underTutoText.SetActive(true);
            _text = _underTutoText.GetComponentInChildren<TextMeshProUGUI>();
            _text.text = text;
        }
        else
        {
            _uperTutoText.SetActive(true);
            _text = _underTutoText.GetComponentInChildren<TextMeshProUGUI>();
            _text.text = text;
        }
    }
}
