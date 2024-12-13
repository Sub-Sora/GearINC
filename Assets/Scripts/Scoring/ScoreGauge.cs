using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGauge : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = ScoreManager.instance._initScore;
        _slider.value = ScoreManager.instance._initScore;
        ScoreManager.Instance.ScoreActual += GaugeUpdate;
    }

    private void GaugeUpdate(int actualScore)
    {
        _slider.DOValue(actualScore, 0.3f);
    }
}
