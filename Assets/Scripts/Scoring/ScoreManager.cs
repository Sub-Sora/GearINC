using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int _initScore;

    private int _score;

    [SerializeField]
    private int _threeStarScore;

    [SerializeField]
    private int _twoStarScore;

    [SerializeField]
    private int _oneStarScore;

    [SerializeField]
    private GameObject _scoreWindow;

    private StarScore _starScore;

    private void Start()
    {
        _score = _initScore;
        _starScore = GetComponent<StarScore>();
    }

    /// <summary>
    /// Fonction pour récupérer un int qui viendra modifier le score
    /// </summary>
    /// <param name="ScoreDeduction"></param>
    public void ChangeScore(int ScoreDeduction)
    {
        _score += ScoreDeduction;
        if (_score < 0) _score = 0;
        if (_score > _initScore) _score = _initScore;
    }

    private void StarsScore()
    {
        // Affiche la fenêtre de score
        _scoreWindow.SetActive(true);

        //Condition pour avoir 3 étoiles de score
        if (_threeStarScore >= _initScore)
        {
            _starScore.ThreeStar.Invoke();
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
