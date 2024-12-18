using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListJobButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _jobMenu;

    [SerializeField]
    private GameObject _levelJob;

    [SerializeField]
    private GameObject _allJob;

    [SerializeField]
    private GameObject _jobDescriptionTab;

    [SerializeField]
    private GameObject _levelJobButton;

    [SerializeField] 
    private GameObject _allJobButton;

    [SerializeField] 
    private GameObject _jobWorkSheets;

    [SerializeField]
    private GameObject _jobsDescription;

    private HapticButton _haptic;

    private void Start()
    {
        _haptic = GetComponent<HapticButton>();
    }

    public void OpenUIWindow()
    {
        if (_haptic != null) _haptic.hapticEvent.Invoke();
        _jobMenu.SetActive(true);
        _levelJobButton.SetActive(true);
        _allJobButton.SetActive(true);
    }

    public void LevelJobList()
    {
        if (_haptic != null) _haptic.hapticEvent.Invoke();
        _levelJob.SetActive(true);
        _allJob.SetActive(false);
        _jobDescriptionTab.SetActive(false);
        HideJobDescription();
    }

    public void AllJobList()
    {
        if (_haptic != null) _haptic.hapticEvent.Invoke();
        _levelJob.SetActive(false);
        _allJob.SetActive(true);
        _jobDescriptionTab.SetActive(false);
        HideJobDescription();
    }

    public void CloseWindow()
    {
        if (_haptic != null) _haptic.hapticEvent.Invoke();
        _levelJob.SetActive(false);
        _allJob.SetActive(false);
        _jobDescriptionTab.SetActive(false);
        HideJobDescription();
    }

    private void HideJobDescription()
    {
        for (int i = 0; i < _jobsDescription.transform.childCount; i++)
        {
            _jobsDescription.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void HideJobSheets()
    {
        for (int i = 0; i < _jobWorkSheets.transform.childCount; i++)
        {
            _jobWorkSheets.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
