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
    /// Tout les AreaEngines vont être initiés
    /// </summary>
    public void InitAllAreaEngine()
    {
        foreach (AreaEngine engine in EngineList)
        {
            engine.InitAreaEngine(this); ;
        }
    }

    public bool CheckAreaEngineReady(bool robotIsHolding)
    {
        bool ressourceIsPut = false;
        if (robotIsHolding)
        {
            ressourceIsPut = true;
        }

        foreach (AreaEngine engine in EngineList)
        {
            if (engine.Engine == null)
            { 
                return false;
            }

            if (engine.isHolding) 
            {
                ressourceIsPut = true;
            }
        }

        return ressourceIsPut;
    }
}