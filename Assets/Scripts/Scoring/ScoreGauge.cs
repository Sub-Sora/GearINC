using System.Collections;
using System.Collections.Generic;
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
        _slider.value = ScoreManager.instance._score;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = ScoreManager.instance._score;
    }
}
