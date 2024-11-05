using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
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
    private InputActionReference _machineControl;

    void Start()
    {
        _listEngine = _listEngineObj.GetComponent<AreasEnginesManager>().EngineList;
        if (_listEngine == null) Debug.LogError("No Engine List Added");
        _agent = GetComponent<NavMeshAgent>();
        _currentEngine = 1;

    }


    //Make the machine go to the next located JobEngine
    private void NextMachine()
    {
        NavMeshPath path = new NavMeshPath();
        if (_currentEngine < _listEngine.Count)
        {
            //_agent.SetDestination(_listEngine[_currentEngine].transform.position);
            _agent.Move(_agent.velocity);

            _agent.CalculatePath(_listEngine[_currentEngine].transform.position, path);
            _agent.SetPath(path);
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
