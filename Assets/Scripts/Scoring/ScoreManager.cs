using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _initScore;

    [SerializeField]
    private int _threeStarScore;

    [SerializeField]
    private int _twoStarScore;

    [SerializeField]
    private int _oneStarScore;

    private void Start()
    {
        _initScore = 100;
    }

    /// <summary>
    /// Fonction pour r�cup�rer un int qui se d�duira du score
    /// </summary>
    /// <param name="ScoreDeduction"></param>
    public void MinusScore(int ScoreDeduction)
    {
        _initScore -= ScoreDeduction;
    }

    private void StarsScore()
    {
        //Condition pour avoir 3 �toiles de score
        if (_threeStarScore >= _initScore)
        {

        }
        //Condition pour avoir 2 �toiles de score
        if (_twoStarScore >= _initScore && _threeStarScore < _initScore)
        {

        }
        //Condition pour avoir 1 �toiles de score
        if (_oneStarScore >= _initScore && _twoStarScore < _initScore)
        {

        }
        //Condition pour avoir 0 �toiles de score
        if (_oneStarScore < _initScore)
        {

        }
    }
}
