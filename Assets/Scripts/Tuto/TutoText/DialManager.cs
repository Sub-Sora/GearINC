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

    private int _currentIndex;
    private ScriptableDial _currentDial;

    public void StartTutoDial(ScriptableDial Dial)
    {
        _currentIndex = 0;
        _currentDial = Dial;
        dialogue = "";
        textUnder = true;

        ReadText();
    }

    public void ReadText()
    {
        dialogue = _currentDial.GetLineByIndex(_currentIndex).dialText;
        textUnder = _currentDial.GetLineByIndex(_currentIndex).showTextUnder;
        TutoManager.Instance.tutoText.ShowText(dialogue, textUnder);
        _currentIndex++;
    }
}
