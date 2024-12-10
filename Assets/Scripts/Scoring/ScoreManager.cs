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

    private StarScore _starScore;

    private void Start()
    {
        _initScore = 100;
        _starScore = GetComponent<StarScore>();
    }

    /// <summary>
    /// Fonction pour récupérer un int qui viendra modifier le score
    /// </summary>
    /// <param name="ScoreDeduction"></param>
    public void ChangeScore(int ScoreDeduction)
    {
        _initScore += ScoreDeduction;
    }

    private void StarsScore()
    {
        //Condition pour avoir 3 étoiles de score
        if (_threeStarScore >= _initScore)
        {
            _starScore.OneStar.Invoke();
        }
        //Condition pour avoir 2 étoiles de score
        if (_twoStarScore >= _initScore && _threeStarScore < _initScore)
        {
            _starScore.TwoStar.Invoke();
        }
        //Condition pour avoir 1 étoiles de score
        if (_oneStarScore >= _initScore && _twoStarScore < _initScore)
        {
            _starScore.OneStar.Invoke();
        }
        //Condition pour avoir 0 étoiles de score
        if (_oneStarScore < _initScore)
        {

        }
    }
}
