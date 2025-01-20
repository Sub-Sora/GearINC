using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class AllDials : MonoBehaviour
{
    [SerializeField]
    private ScriptableDial[] _dials;

    private int _currentIndex = 0;

    private void Start()
    {
        _currentIndex = 0;
        TutoManager.Instance.activeDial += TutoStart;
    }

    public void TutoStart()
    {
        if (_currentIndex <= _dials.Length)
        {
            TutoManager.Instance.dialManager.StartTutoDial(_dials[_currentIndex]);
            _currentIndex++;
        }
        else Debug.LogError("Pas plus d'élément dans la liste");
    }

    public bool IsLastDial()
    {
        bool isTheLast = false;
        if (_currentIndex == _dials.Length)
        {
            isTheLast = true;
        }
        Debug.Log(isTheLast + "last");
        return isTheLast;
    }
}
