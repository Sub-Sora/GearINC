using System.Collections.Generic;
using UnityEngine;

public class TutoManager : MonoBehaviour
{

    // EVENTS //
    public delegate void TutoEvents();
    public TutoEvents firstRoomComplete, secondRoomComplete;
    //

    public List<GameObject> TutoPhases = new List<GameObject>();

    public int TutoActualPeriod;

    // DIAL //
    public TutoShowText tutoText;
    public DialManager dialManager;
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

        TutoActualPeriod = 1;
    }
}
