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
    /// Fonction pour récupérer un int qui se déduira du score
    /// </summary>
    /// <param name="ScoreDeduction"></param>
    public void MinusScore(int ScoreDeduction)
    {
        _initScore -= ScoreDeduction;
    }

    private void StarsScore()
    {
        //Condition pour avoir 3 étoiles de score
        if (_threeStarScore >= _initScore)
        {

        }
        //Condition pour avoir 2 étoiles de score
        if (_twoStarScore >= _initScore && _threeStarScore < _initScore)
        {

        }
        //Condition pour avoir 1 étoiles de score
        if (_oneStarScore >= _initScore && _twoStarScore < _initScore)
        {

        }
        //Condition pour avoir 0 étoiles de score
        if (_oneStarScore < _initScore)
        {

        }
    }
}
