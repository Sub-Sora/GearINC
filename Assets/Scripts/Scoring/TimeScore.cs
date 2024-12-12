using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScore : MonoBehaviour
{
    [SerializeField]
    private float _timeToLoosePoint;

    [SerializeField]
    private int _scoreloss;

    private void Start()
    {
        ScoreManager.Instance.startScoreTimer += TimerStarted;
    }

    private void TimerStarted()
    {
        InvokeRepeating("TooMuchTime", 0f, _timeToLoosePoint);
    }

    private void TooMuchTime()
    {
        ScoreManager.Instance.ChangeScore(-_scoreloss);
    }
}
