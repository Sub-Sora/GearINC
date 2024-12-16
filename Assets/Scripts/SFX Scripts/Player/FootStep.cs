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
            _audioSRC.Play();
        }
        else _audioSRC.Stop();
    }
}
