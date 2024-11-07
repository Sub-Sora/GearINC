using UnityEngine;
using UnityEngine.UI;

public class SwitchPlayer : Interactable
{
    [SerializeField]
    private Button _exitButton;

    [SerializeField]
    private GameObject _machineButton;

    [SerializeField]
    private GameObject _playerButton;

    private PlayerControls _player;

    private void Start()
    {
        _exitButton.onClick.AddListener(ExitMachine);
    }

    /// <summary>
    /// Ce lancera lorsque le joueur interragira avec
    /// </summary>
    public override void Interact(PlayerMain player)
    {
        _player = player.GetComponent<PlayerControls>();
        EnterMachine();
    }

    /// <summary>
    /// Permet de contrôler la machine
    /// </summary>
    private void EnterMachine()
    {
        _machineButton.SetActive(true);
        _playerButton.SetActive(false);
        _player.enabled = false;
    }

    /// <summary>
    /// Permet de contrôler l'humain
    /// </summary>
    private void ExitMachine()
    {
        _machineButton.SetActive(false);
        _playerButton.SetActive(true);
        _player.enabled = true;
    }
}
