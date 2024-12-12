using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPlayer : Interactable
{
    [SerializeField]
    private AreasEnginesManager _allArea;

    [SerializeField]
    private Button _exitButton;

    [SerializeField]
    private GameObject _machineButton;

    [SerializeField]
    private GameObject _playerButton;

    [SerializeField]
    private CinemachineVirtualCamera _playerCam;

    [SerializeField]
    private CinemachineVirtualCamera _robotCam;

    private PlayerControls _player;

    private void Start()
    {
        _exitButton.onClick.AddListener(ExitMachine);

        if (_allArea.Main.NewGameplayIsAdd)
        {
            _allArea.Main.Event.ConceptionIsBlocked += ExitMachine;
        }
    }

    /// <summary>
    /// Ce lancera lorsque le joueur interragira avec
    /// </summary>
    public override void Interact(PlayerMain player)
    {
        if (_allArea.Main.NewGameplayIsAdd)
        {
            if (!_allArea.Main.Event.EngineIsBroken && !_allArea.Main.Event.ElecIsBroken)
            {

            }
        }
        else
        {
            _player = player.GetComponent<PlayerControls>();
            EnterMachine();
        }
    }

    /// <summary>
    /// Permet de contr�ler la machine
    /// </summary>
    private void EnterMachine()
    {
        if (_allArea.CheckAreaEngineReady(_allArea.Main.Machine._interact._isHolding))
        {
            _machineButton.SetActive(true);
            _playerButton.SetActive(false);
            _player.enabled = false;
            _robotCam.Priority = 20;
            _playerCam.Priority = 0;
        }
    }

    /// <summary>
    /// Permet de contr�ler l'humain
    /// </summary>
    public void ExitMachine()
    {
        _machineButton.SetActive(false);
        _playerButton.SetActive(true);
        _player.enabled = true;
        _playerCam.Priority = 20;
        _robotCam.Priority = 0;
    }
}
