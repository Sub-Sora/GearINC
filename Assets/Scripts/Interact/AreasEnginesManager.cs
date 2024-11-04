using System.Collections.Generic;
using UnityEngine;

public class AreasEnginesManager : MonoBehaviour
{
    public List<AreaEngine> EngineList = new List<AreaEngine>();

    /// <summary>
    /// Tout les areaEngines vont �tre initi�s
    /// </summary>
    private void Awake()
    {
        BroadcastMessage("Init", this);
    }
}