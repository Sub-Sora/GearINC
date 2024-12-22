using System.Collections.Generic;
using UnityEngine;

public class TutoManager : MonoBehaviour
{

    // EVENTS //
    public delegate void TutoEvents();
    public TutoEvents firstRoomComplete, secondRoomComplete;

    // SINGLETON //
    public static TutoManager instance = null;
    public static TutoManager Instance => instance;

    public Dictionary<Workstation, AreaEngine> TutoEngineAndWorkstation = new Dictionary<Workstation, AreaEngine>();

    public int TutoActualPeriod;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else instance = this;

        TutoActualPeriod = 1;
    }
}
