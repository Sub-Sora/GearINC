using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScore : MonoBehaviour
{
    private float _time;

    [SerializeField]
    private int _scoreloss;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _time = 0;
        _scoreManager = GetComponent<ScoreManager>();
    }

    private void Update()
    {
        _time += Time.deltaTime;

        float minutes = Mathf.FloorToInt(_time / 60);
        float seconds = Mathf.FloorToInt(_time % 60);

        if (minutes == 1 && seconds == 30)
        {
            TooMuchTime();
        }
    }

    private void TooMuchTime()
    {
        _scoreManager.MinusScore(_scoreloss);
    }
}
