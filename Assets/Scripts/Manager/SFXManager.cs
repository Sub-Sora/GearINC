using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SFXManager : MonoBehaviour
{
    private static SFXManager instance = null;
    public static SFXManager Instance => instance;

    [HideInInspector]
    public UnityEvent SFXRessourcesEvent;
    private AudioSource RessoucesSound;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else instance = this;

        DontDestroyOnLoad(this.gameObject);

        if (SFXRessourcesEvent != null) SFXRessourcesEvent = new UnityEvent();
        SFXRessourcesEvent.AddListener(PlayRessourceSound);
    }

    private void PlayRessourceSound()
    {
        RessoucesSound.Play();
    }
}
