using UnityEngine;

public class ManagerOnce : MonoBehaviour
{
    [Header("Base Game")]
    public LevelManager Level;

    public AreasEnginesManager AreasEngines;

    public Objective Objective;

    public UIPool UI;

    public MachineControl Machine;

    public InitManager InitManager;
    
    public PlayerMain Player;

    public EventManager Event;

    [Header("New Gameplay")]
    public bool NewGameplayIsAdd;

    [Header("Tuto")]
    public bool Tuto;

    public void Awake()
    {
        // Permet de lancer le jeu en version de test
        if (ManagerMain.Instance != null)
        {
            Objective = ManagerMain.Instance.Objective;
        }
        
        SendMessage("Init", this);
        Player = FindAnyObjectByType<PlayerMain>();
        Machine = FindAnyObjectByType<MachineControl>();
        if (Tuto)
        {
            Player.IsTuto = true;
        }
    }

    public void EndTuto()
    {
        Tuto = false;
        Player.IsTuto = false;
    }
}