using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public event Action<Transform> NewPhase;
    //

    [SerializeField]
    private ManagerOnce _managerOnce;

    [SerializeField]
    private Transform _arrowObjective;


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
        if (TutoActualPeriod < TutoPhases.Count - 1) TutoEvendEnd();
        else
        {
            _arrowObjective.gameObject.SetActive(false);
            _managerOnce.EndTuto();
        }
    }

    private void TutoEvendEnd()
    {
        TutoActualPeriod++;
        if (TutoActualPeriod == 1) firstRoomComplete.Invoke();
        if (TutoActualPeriod == 2) secondRoomComplete.Invoke();
        TutoManager.Instance.allDials.TutoStart();
        if (TutoActualPeriod >= TutoPhases.Count - 1) ScoreManager.Instance.TutoReinitialisation();
        if (TutoActualPeriod >= 1) firstRoomComplete.Invoke();
        if (TutoActualPeriod >= 4) secondRoomComplete.Invoke();
        ArrowNewPhase();
    }

    public void ArrowNewPhase()
    {
        NewPhase.Invoke(TutoPhases[TutoActualPeriod].transform);
        _arrowObjective.position = new Vector3(TutoPhases[TutoActualPeriod].transform.position.x, TutoPhases[TutoActualPeriod].transform.position.y + 2, TutoPhases[TutoActualPeriod].transform.position.z); 
    }

}
