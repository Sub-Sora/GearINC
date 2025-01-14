using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    private AudioSource _audioSRC;

    private void Start()
    {
        _audioSRC = GetComponent<AudioSource>();
        SFXManager.Instance.playerStep += WalkingSound;
    }

    private void WalkingSound(bool WalkSFX)
    {
        if (WalkSFX)
        {
            if (!_audioSRC.isPlaying)
            {
                _audioSRC.pitch = Random.Range(0.6f, 0.9f);
                _audioSRC.Play();
            }
        }
        else
        {
            _audioSRC.Stop();
        }
    }
}
