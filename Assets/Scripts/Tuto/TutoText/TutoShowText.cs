using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class TutoShowText : MonoBehaviour
{
    [SerializeField]
    private PlayerControls _playerControler;

    [SerializeField]
    private GameObject _uperTutoText;

    [SerializeField]
    private GameObject _underTutoText;

    [SerializeField]
    private GameObject _underNextTextBtn, _upperTextBtn;
    private GameObject _actualnextBtn;

    [SerializeField]
    private float _textSpeed;

    private TextMeshProUGUI _text;
    private string _fullText;

    private void DisablePlayer(bool OnTuto)
    {
        if (OnTuto) _playerControler.enabled = false;
        else _playerControler.enabled = true;
    }

    /// <summary>
    /// Vas afficher le text, paramètre, prendre le text, puis false si il doit s'afficher en bas, sinon true.
    /// </summary>
    /// <param name="text">Le texte à afficher</param>
    /// <param name="isUnder">Si il s'affiche en bas (false) ou en haut (true)</param>
    public void ShowText(string text, bool isUper)
    {
        DisablePlayer(true);
        if (_actualnextBtn != null) _actualnextBtn.SetActive(false);

        if (!isUper)
        {
            _uperTutoText.SetActive(false);
            _underTutoText.SetActive(true);
            _actualnextBtn = _underNextTextBtn;
            _text = _underTutoText.GetComponentInChildren<TextMeshProUGUI>();
        }
        else
        {
            _underTutoText.SetActive(false);
            _uperTutoText.SetActive(true);
            _actualnextBtn = _upperTextBtn;
            _text = _uperTutoText.GetComponentInChildren<TextMeshProUGUI>();
        }
        _text.text = "";
        _fullText = text;
        StopAllCoroutines();
        StartCoroutine("AnimShowText");
    }

    IEnumerator AnimShowText()
    {
        for (int i = 0; i <= _fullText.Length; i++)
        {
            _text.text = _fullText.Substring(0, i);
            if (i >=  _fullText.Length) _actualnextBtn.SetActive(true);
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    /// <summary>
    /// Vas cacher le texte et rendre les mouvements au joueur
    /// </summary>
    public void HideText()
    {
        _underTutoText.SetActive(false);
        _uperTutoText.SetActive(false);
        DisablePlayer(false);
    }
}
