using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _audioMix;

    [SerializeField]
    private Slider _musicSlider;

    [SerializeField]
    private Slider _sfxSlider;

    private void Start()
    {
        SetMusicVolume();
        SetSFXVolume();
    }

    public void SetMusicVolume()
    {
        float volume = _musicSlider.value;
        _audioMix.SetFloat("music", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume()
    {
        float volume = _sfxSlider.value;
        _audioMix.SetFloat("sfx", Mathf.Log10(volume)*20);
    }
}
