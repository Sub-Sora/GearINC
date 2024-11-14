using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPlacment : MonoBehaviour
{
    [SerializeField]
    private int _scoreloss;

    [SerializeField]
    private GameObject _scoreManagerObj;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = _scoreManagerObj.GetComponent<ScoreManager>();
    }

    private void WrongPlacment()
    {
        _scoreManager.MinusScore(_scoreloss);
    }
}
