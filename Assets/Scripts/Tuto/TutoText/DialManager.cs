using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialManager : MonoBehaviour
{
    [HideInInspector]
    public string dialogue;
    [HideInInspector]
    public bool textUnder;

    [SerializeField]
    private GameObject _objectiveArrow;
    [SerializeField]
    private GameObject _scoreArrow;
    [SerializeField]
    private GameObject _optionsArrow;

    private int _currentIndex;
    private ScriptableDial _currentDial;

    public void StartTutoDial(ScriptableDial Dial)
    {
        _currentIndex = 0;
        _currentDial = Dial;
        dialogue = "";
        textUnder = false;

        ReadText();
    }

    public void ReadText()
    {
        _objectiveArrow.gameObject.SetActive(false);
        _optionsArrow.gameObject.SetActive(false);
        _scoreArrow.gameObject.SetActive(false);

        if (_currentIndex > _currentDial.GetLenght())
        {
            TutoManager.Instance.tutoText.HideText();
            //TutoManager.Instance.allDials.IsLastDial();
            if (TutoManager.Instance.allDials.IsLastDial())
            {
                TutoManager.Instance.TutoEnd();
            }
            //TutoManager.Instance.allDials.TutoStart();
        }
        else
        {
            dialogue = _currentDial.GetLineByIndex(_currentIndex).dialText;
            textUnder = _currentDial.GetLineByIndex(_currentIndex).showTextUper;
            TutoManager.Instance.tutoText.ShowText(dialogue, textUnder);

            if (_currentDial.GetLineByIndex(_currentIndex).tutoArrowObjective) _objectiveArrow.gameObject.SetActive(true);
            if (_currentDial.GetLineByIndex(_currentIndex).tutoArrowOptions) _optionsArrow.gameObject.SetActive(true);
            if (_currentDial.GetLineByIndex(_currentIndex).tutoArrowScore) _scoreArrow.gameObject.SetActive(true);

            _currentIndex++;
        }
    }
}
