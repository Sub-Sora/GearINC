using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class AllDials : MonoBehaviour
{
    [SerializeField]
    private ScriptableDial[] _dials;

    private void Start()
    {
        TutoStart();
    }

    public void TutoStart()
    {
        TutoManager.Instance.dialManager.StartTutoDial(_dials[0]);
    }
}
