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

    private void Start()
    {
        _onTuto += DisablePlayer;
    }

    private void DisablePlayer(bool OnTuto)
    {
        if (OnTuto) _playerControler.SetActive(false);
        else _playerControler.SetActive(true);
    }

    /// <summary>
    /// Vas afficher le text, paramètre, prendre le text, puis true si il doit s'afficher en bas, sinon false.
    /// </summary>
    /// <param name="text">Le texte à afficher</param>
    /// <param name="isUnder">Si il s'affiche en bas (true) ou en haut (false)</param>
    public void ShowText(string text, bool isUnder)
    {
        _onTuto(true);

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
