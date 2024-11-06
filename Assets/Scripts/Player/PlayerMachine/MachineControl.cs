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

    [SerializeField]
    //Take the current Engine come from
    private int _currentEngine;

    private NavMeshAgent _agent;

    [SerializeField]
    private InputActionReference _moveMachine;

    void Start()
    {
        if (_listEngine == null) Debug.LogError("No Engine List Added");
        _listEngine = _listEngineObj.GetComponent<AreasEnginesManager>().EngineList;
        _agent = GetComponent<NavMeshAgent>();
        _currentEngine = 1;
        InitializedPath();
    }

    private void InitializedPath()
    {
        _agent.SetDestination(_listEngine[_currentEngine].transform.position);
        _agent.isStopped = true;
    }

    private void Update()
    {
        if (_moveMachine.action.ReadValue<float>() == 1)
        {
            if (!_agent.pathPending && _agent.remainingDistance < 0.1f)
            {
                _currentEngine++;
                if (_currentEngine >= _listEngine.Count) _currentEngine = _listEngine.Count;
                NextDestination();
            }
        }

        if (_moveMachine.action.ReadValue<float>() == -1)
        {
            if (!_agent.pathPending && _agent.remainingDistance < 0.1f && _currentEngine >= 1)
            {
                _currentEngine--;
                if (_currentEngine <= 0) _currentEngine = 1;
                NextDestination();
            }

        }
    }

    private void OnMachine()
    {
        //Make the machine go to the next JobEngine
        if (_moveMachine.action.ReadValue<float>() == 1)
        {
            if (_currentEngine < _listEngine.Count)
            {
                _agent.SetDestination(_listEngine[_currentEngine].transform.position);
                _agent.isStopped = false;
            }
        }

        //Make the machine get back to the previous JobEngine
        if (_moveMachine.action.ReadValue<float>() == -1)
        {
            if (_currentEngine >= 0)
            {
                _agent.SetDestination(_listEngine[_currentEngine - 1].transform.position);
                _agent.isStopped = false;
            }
        }

        //Stop the machine when no button pressed
        if (_moveMachine.action.ReadValue<float>() == 0)
        {
            //_agent.ResetPath();
            _agent.isStopped = true;
        }
    }

    private void NextDestination()
    {
        if (_moveMachine.action.ReadValue<float>() == 1)
        {
            if (_currentEngine < _listEngine.Count)
            {
                if (_currentEngine >= _listEngine.Count) _currentEngine = _listEngine.Count;
                _agent.SetDestination(_listEngine[_currentEngine].transform.position);
                _agent.isStopped = false;
            }
        }

        if (_moveMachine.action.ReadValue<float>() == -1)
        {
            if (_currentEngine >= 0)
            {
                _agent.SetDestination(_listEngine[_currentEngine - 1].transform.position);
                _agent.isStopped = false;
            }
        }
    }
}
