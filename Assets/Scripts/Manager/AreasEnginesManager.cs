using System.Collections.Generic;
using UnityEngine;

public class AreasEnginesManager : MonoBehaviour
{
    public List<AreaEngine> EngineList = new List<AreaEngine>();
    
    public ManagerMain Main;

    private void Init(ManagerMain main)
    {
        Main = main;
        main.AreasEngines = this;
    }

    /// <summary>
    /// Tout les AreaEngines vont être initiés
    /// </summary>
    public void InitAllAreaEngine()
    {
        foreach (AreaEngine engine in EngineList)
        {
            engine.InitAreaEngine(this); ;
        }
    }
}