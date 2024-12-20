using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TutoShowText : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerControler;

    [SerializeField]
    private GameObject _uperTutoText;

    [SerializeField]
    private GameObject _underTutoText;

    private TextMeshProUGUI _text;

    private delegate void TutoActivate(bool OnTuto);
    private TutoActivate _onTuto;

    private void DisablePlayer(bool OnTuto)
    {
        if (OnTuto) _playerControler.SetActive(false);
        else _playerControler.SetActive(true);
    }

    private void ShowText()
    {
        _onTuto(true);
    }

    /// <summary>
    /// Vas afficher le text, paramètre, prendre le text, puis true si il doit s'afficher en bas, sinon false.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="isUnder"></param>
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
