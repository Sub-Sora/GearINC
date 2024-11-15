using UnityEngine;

public class ManagerOnce : MonoBehaviour
{ 
    public LevelManager Level;

    public AreasEnginesManager AreasEngines;

    public Objective Objective;

    public UIPool UI;

    public MachineControl Machine;

    public InitManager InitManager;
    
    public PlayerMain Player;

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
    }
}