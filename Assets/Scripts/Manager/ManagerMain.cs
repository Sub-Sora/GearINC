using UnityEngine;

public class ManagerMain : MonoBehaviour
{
    private static ManagerMain _instance = null;
    public static ManagerMain Instance => _instance;

    public LevelManager Level;

    public AreasEnginesManager AreasEngines;

    public Objective Objective;

    private void Awake()
    {
        SendMessage("Init", this);
    }
}