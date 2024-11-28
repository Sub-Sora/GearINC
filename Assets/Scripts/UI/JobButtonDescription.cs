using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobButtonDescription : MonoBehaviour
{
    //Prendre le job description de référence
    [SerializeField]
    private GameObject _jobDescription;

    //Onglet des descriptions de job
    [SerializeField]
    private GameObject _tabJobDescription;

    //Onglet des boutons des jobs du niveau
    [SerializeField]
    private GameObject _tabLvlJob;

    //Onglet des boutons des jobs au global
    [SerializeField]
    private GameObject _tabAllJob;

    private HapticButton _haptic;

    private void Start()
    {
        _haptic = GameObject.Find("Canvas").GetComponent<HapticButton>();
    }

    public void OpenJobDescription()
    {
        if (_haptic != null) _haptic.hapticEvent.Invoke();
        _tabJobDescription.SetActive(true);
        _jobDescription.SetActive(true);
        _tabLvlJob.SetActive(false);
        _tabAllJob.SetActive(false);
    }
}
