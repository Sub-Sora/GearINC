using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MachineControl : MonoBehaviour
{
    [SerializeField]
    private GameObject _listEngineObj;

    private List<AreaEngine> _listEngine;

    //Take the current Engine come from
    private int _currentEngine;

    private NavMeshAgent _agent;

    [SerializeField]
    private Button _forwardButton;

    [SerializeField]
    private Button _backwardButton;

    void Start()
    {
        _listEngine =  _listEngineObj.GetComponent<AreasEnginesManager>().EngineList;
        if (_listEngine == null) Debug.LogError("No Engine List Added");
        _agent = GetComponent<NavMeshAgent>();
        _currentEngine = 0;

        if (_forwardButton == null) Debug.LogError("No Forward Button Linked");
        _forwardButton.onClick.AddListener(NextMachine);
        if (_backwardButton == null) Debug.LogError("No Backward Button Linked");
        _backwardButton.onClick.AddListener(PreviousMachine);
    }


    //Make the machine go to the next located JobEngine
    private void NextMachine()
    {
        if (_currentEngine < _listEngine.Count)
        {
            _agent.SetDestination(_listEngine[_currentEngine].transform.position);
        }

        if (!_agent.pathPending && _agent.remainingDistance < 0.1f) _currentEngine++;
        if (_currentEngine >= _listEngine.Count) _currentEngine = _listEngine.Count;
    }

    //Make the machine get back to the previous JobEngine
    private void PreviousMachine()
    {
        if (_currentEngine >= 0)
        {
            _agent.SetDestination(_listEngine[_currentEngine - 1].transform.position);
        }
        if (!_agent.pathPending && _agent.remainingDistance < 0.1f) _currentEngine--;
        if (_currentEngine < _listEngine.Count) _currentEngine = 0;
    }
}
