using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    private AudioSource _audioSRC;
    [SerializeField]
    private bool _activate;

    private void Start()
    {
        _audioSRC = GetComponent<AudioSource>();
        SFXManager.Instance.playerStep += WalkingSound;
    }

    private void WalkingSound(bool WalkSFX)
    {
        if (WalkSFX && _activate)
        {
            if (!_audioSRC.isPlaying)
            {
                StartCoroutine("WalkingRandomPitch");
            }
        }
        else
        {
            StopAllCoroutines();
            _audioSRC.Stop();
        }
    }

    IEnumerator WalkingRandomPitch()
    {
        _audioSRC.pitch = Random.Range(0.6f, 0.8f);
        _audioSRC.Play();
        yield return new WaitForSeconds(0.1f);
    }
}
