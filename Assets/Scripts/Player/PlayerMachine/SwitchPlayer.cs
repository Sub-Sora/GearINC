using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPlayer : MonoBehaviour
{
    [SerializeField]
    private Button _exitButton;

    [SerializeField]
    private GameObject _machineButton;

    [SerializeField]
    private GameObject _playerButton;

    [SerializeField]
    private GameObject _player;

    private void Start()
    {
        _exitButton.onClick.AddListener(ExitMachine);
    }

    private void EnterMachine()
    {
        _machineButton.SetActive(true);
        _playerButton.SetActive(false);
        _player.GetComponent<PlayerControls>().enabled = false;
    }

    private void ExitMachine()
    {
        _machineButton.SetActive(false);
        _playerButton.SetActive(true);
        _player.GetComponent<PlayerControls>().enabled = true;
    }
}
