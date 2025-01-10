using System.Collections.Generic;
using UnityEngine;

public class TutoManager : MonoBehaviour
{

    // EVENTS //
    public delegate void TutoEvents();
    public TutoEvents firstRoomComplete, secondRoomComplete, activeDial;
    //

    // PHASES //
    public List<GameObject> TutoPhases = new List<GameObject>();
    public List<GameObject> TutoWorkstations = new List<GameObject>();
    public int TutoActualPeriod;
    //

    [SerializeField]
    private ManagerOnce _managerOnce;


    // DIAL //
    [HideInInspector]
    public TutoShowText tutoText;
    [HideInInspector]
    public DialManager dialManager;
    [HideInInspector]
    public AllDials allDials;
    //

    // SINGLETON //
    public static TutoManager instance = null;
    public static TutoManager Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else instance = this;

        tutoText = GetComponent<TutoShowText>();
        dialManager = GetComponent<DialManager>();
        allDials = GetComponent<AllDials>();

        TutoActualPeriod = 0;
    }
    public void IngrementPeriod()
    {
        if (TutoActualPeriod < TutoPhases.Count - 1) TutoActualPeriod++;
        else _managerOnce.EndTuto();
    }

}
