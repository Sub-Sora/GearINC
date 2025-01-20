using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confettis : MonoBehaviour
{
    [SerializeField]
    private GameObject _confettis;
    [SerializeField]
    private AudioSource _confettisAudio;

    private void Start()
    {
        if (_confettis != null) ScoreManager.Instance.GameOverConfet += PlayConfettis;
        if (_confettisAudio != null) ScoreManager.Instance.GameOverEvnt += PlayConfettisSound;

    }

    private void PlayConfettis()
    {
        _confettis.SetActive(true);
    }

    private void PlayConfettisSound()
    {
        _confettisAudio.Play();
    }
}
