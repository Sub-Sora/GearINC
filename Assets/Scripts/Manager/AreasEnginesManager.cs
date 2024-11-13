using System.Collections.Generic;
using UnityEngine;

public class AreasEnginesManager : MonoBehaviour
{
    public List<AreaEngine> EngineList = new List<AreaEngine>();
    
    public ManagerOnce Main;

    private void Init(ManagerOnce main)
    {
        Main = main;
        main.AreasEngines = this;
    }

    /// <summary>
    /// Tout les AreaEngines vont �tre initi�s
    /// </summary>
    public void InitAllAreaEngine()
    {
        foreach (AreaEngine engine in EngineList)
        {
            engine.InitAreaEngine(this); ;
        }
    }
}