using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int _initScore;

    private int _score;

    [HideInInspector]
    public bool IsWin;

    [SerializeField]
    private int _threeStarScore;

    [SerializeField]
    private int _twoStarScore;

    [SerializeField]
    private int _oneStarScore;

    [SerializeField]
    private GameObject _scoreWindow;

    private StarScore _starScore;

    //Events de score
    public delegate void ScoreModifier();
    public ScoreModifier BadPlacment, startScoreTimer;

    public delegate void ScoreEvent (int score);
    public ScoreEvent ScoreActual;

    // Events niveau termin�
    public delegate void GameOverEvent();
    public GameOverEvent GameOverEvnt, GameOverAnim, GameOverConfet;

    //SINGLETON
    public static ScoreManager instance = null;
    public static ScoreManager Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        IsWin = true;
        _score = _initScore;
        _starScore = GetComponent<StarScore>();
    }

    /// <summary>
    /// Fonction pour r�cup�rer un int qui viendra modifier le score (mettre un score n�gatif pour en retirer)
    /// </summary>
    /// <param name="ScoreDeduction"></param>
    public void ChangeScore(int ScoreDeduction)
    {
        _score += ScoreDeduction;
        if (_score < 0) _score = 0;
        if (_score > _initScore) _score = _initScore;
        ScoreActual(_score);

        if (_score >= _oneStarScore) IsWin = true;
        else IsWin = false;
    }

    public void TutoReinitialisation()
    {
        _score = _initScore;
        ScoreActual(_score);
    }

    public void StarsScore()
    {
        // Affiche la fen�tre de score
        _scoreWindow.SetActive(true);

        //Condition pour avoir 3 �toiles de score
        if (_score >= _threeStarScore)
        {
            _starScore.ThreeStar.Invoke();
        }
        //Condition pour avoir 2 �toiles de score
        if (_score >= _twoStarScore && _score < _threeStarScore)
        {
            _starScore.TwoStar.Invoke();
        }
        //Condition pour avoir 1 �toiles de score
        if (_score >= _oneStarScore && _score < _twoStarScore)
        {
            _starScore.OneStar.Invoke();
        }
        //Condition pour avoir 0 �toiles de score
        if (_score < _oneStarScore)
        {
            IsWin = false;
        }
    }
}
