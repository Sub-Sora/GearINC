using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StarScore : MonoBehaviour
{
    public delegate void StarDelegate();
    public StarDelegate OneStar, TwoStar, ThreeStar;

    [SerializeField]
    private GameObject _firstStarImage;

    [SerializeField]
    private GameObject _secondStarImage;

    [SerializeField]
    private GameObject _thirdStarImage;

    private List<GameObject> _stars = new List<GameObject>();

    private void Start()
    {
        OneStar += OneStarAnim;
        TwoStar += TwoStarAnim;
        ThreeStar += ThreeStarAnim;
    }

    private void OneStarAnim()
    {
        _firstStarImage.transform.DOScale(1, 1).SetEase(Ease.OutBounce);
    }

    private void TwoStarAnim()
    {
        _stars.Clear();

        _stars.Add(_firstStarImage);
        _stars.Add(_secondStarImage);

        StartCoroutine(StarAnimCoroutine());
    }

    private void ThreeStarAnim()
    {
        _stars.Clear();

        _stars.Add(_firstStarImage);
        _stars.Add(_secondStarImage);
        _stars.Add(_thirdStarImage);

        StartCoroutine(StarAnimCoroutine());
    }

    IEnumerator StarAnimCoroutine()
    {
        for (int i = 0; i < _stars.Count; i++)
        {
            Tween StarTween = _stars[i].transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce);
            yield return StarTween.WaitForCompletion();
        }

        yield return null;
    }
}
