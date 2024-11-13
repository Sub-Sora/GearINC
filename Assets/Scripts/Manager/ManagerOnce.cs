using UnityEngine;

public class ManagerOnce : MonoBehaviour
{ 
    public LevelManager Level;

    public AreasEnginesManager AreasEngines;

    public Objective Objective;

    public UIPool UI;

    public MachineControl Machine;

    public void Awake()
    {
        Objective = ManagerMain.Instance.Objective;
        SendMessage("Init", this);
    }
}