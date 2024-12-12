using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int _initScore;

    public int _score;

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
    public ScoreModifier badPlacment;

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
        _score = _initScore;
        _starScore = GetComponent<StarScore>();
    }

    /// <summary>
    /// Fonction pour récupérer un int qui viendra modifier le score (mettre un score négatif pour en retirer)
    /// </summary>
    /// <param name="ScoreDeduction"></param>
    public void ChangeScore(int ScoreDeduction)
    {
        _score += ScoreDeduction;
        if (_score < 0) _score = 0;
        if (_score > _initScore) _score = _initScore;
    }

    public void StarsScore()
    {
        // Affiche la fenêtre de score
        _scoreWindow.SetActive(true);

        //Condition pour avoir 3 étoiles de score
        if (_score >= _threeStarScore)
        {
            _starScore.ThreeStar.Invoke();
        }
        //Condition pour avoir 2 étoiles de score
        if (_score >= _twoStarScore && _score < _threeStarScore)
        {
            _starScore.TwoStar.Invoke();
        }
        //Condition pour avoir 1 étoiles de score
        if (_score >= _oneStarScore && _score < _twoStarScore)
        {
            _starScore.OneStar.Invoke();
        }
        //Condition pour avoir 0 étoiles de score
        if (_score < _oneStarScore)
        {

        }
    }
}
