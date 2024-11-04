using System.Collections.Generic;
using UnityEngine;

public class AreasEnginesManager : MonoBehaviour
{
    public List<AreaEngine> EngineList = new List<AreaEngine>();

    public Objective Objective;

    /// <summary>
    /// Tout les AreaEngines vont �tre initi�s
    /// </summary>
    private void Awake()
    {
        BroadcastMessage("Init", this);
    }
}