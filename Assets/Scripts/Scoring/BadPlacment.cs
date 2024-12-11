using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPlacment : MonoBehaviour
{
    [SerializeField]
    private int _scoreloss;

    private void Start()
    {
        ScoreManager.Instance.badPlacment += WrongPlacment;
    }

    private void WrongPlacment()
    {
        ScoreManager.Instance.ChangeScore(-_scoreloss);
    }
}
