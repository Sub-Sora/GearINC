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

    // PHASES //

    public List<GameObject> TutoPhases = new List<GameObject>();

    public List<GameObject> TutoWorkstations = new List<GameObject>();

    public int TutoActualPeriod;

    [SerializeField]
    private ManagerOnce _managerOnce;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else instance = this;

        TutoActualPeriod = 0;
    }

    public void IngrementPeriod() 
    {
        if (TutoActualPeriod < TutoPhases.Count - 1) TutoActualPeriod++;
        else _managerOnce.EndTuto();
    }
}
