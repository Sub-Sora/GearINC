using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MachineControl : MonoBehaviour
{

    private List<AreaEngine> _listEngine;

    [SerializeField]
    //Take the current Engine come from
    private int _currentEngine;

    public NavMeshAgent Agent;

    [SerializeField]
    private InputActionReference _moveMachine;

    private MachineInteract _interact;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
      //  InitializedPath();
    }

    /// <summary>
    /// Vas initialiser un passage pour l'agent pour �viter des erreurs de d�marage
    /// </summary>
    public void InitializedPath(List<AreaEngine> engineList)
    {
        _listEngine = engineList;
        _interact = GetComponent<MachineInteract>();
        _currentEngine = 1;
        Agent.SetDestination(_listEngine[_currentEngine].transform.position);
        Agent.isStopped = true;

    }

    /// <summary>
    /// Va permettre � l'agent de continuer son trajet lorsqu'il arrive � un engine
    /// </summary>
    private void Update()
    {
        if (_moveMachine.action.ReadValue<float>() == 1)
        {
            if (!Agent.pathPending && Agent.remainingDistance < 0.1f)
            {
                _currentEngine++;
                if (_currentEngine >= _listEngine.Count) _currentEngine = _listEngine.Count;
                NextDestination();
            }
        }

        if (_moveMachine.action.ReadValue<float>() == -1)
        {
            if (!Agent.pathPending && Agent.remainingDistance < 0.1f && _currentEngine >= 1)
            {
                _currentEngine--;
                if (_currentEngine <= 0) _currentEngine = 1;
                NextDestination();
            }

        }
    }

    private void OnMachine()
    {
        // Am�ne l'agent vers la machine suivante
        if (_moveMachine.action.ReadValue<float>() == 1)
        {
            if (_currentEngine < _listEngine.Count)
            {
                Agent.SetDestination(_listEngine[_currentEngine].transform.position);
                Agent.isStopped = false;
                _interact.StartMoving();
            }
        }

        // Am�ne l'agent vers la machine pr�cedente
        if (_moveMachine.action.ReadValue<float>() == -1)
        {
            if (_currentEngine >= 0)
            {
                Agent.SetDestination(_listEngine[_currentEngine - 1].transform.position);
                Agent.isStopped = false;
                _interact.StartMoving();
            }
        }

        //Arr�te l'agent quand aucune touche n'es press�
        if (_moveMachine.action.ReadValue<float>() == 0)
        {
            Agent.isStopped = true;
            _interact.StopMoving();
        }
    }

    /// <summary>
    /// Fonction appel� lors de l'update pour permettre � l'agent de continuer sa route quand il atteint une machine
    /// </summary>
    private void NextDestination()
    {
        // Condition pour v�rifier que l'agent avance et donc aller � la machine suivante
        if (_moveMachine.action.ReadValue<float>() == 1)
        {
            if (_currentEngine < _listEngine.Count)
            {
                if (_currentEngine >= _listEngine.Count) _currentEngine = _listEngine.Count;
                Agent.SetDestination(_listEngine[_currentEngine].transform.position);
                Agent.isStopped = false;
            }
        }

        // Condition pour v�rifier que l'agent recul et donc aller � la machine pr�cedente
        if (_moveMachine.action.ReadValue<float>() == -1)
        {
            if (_currentEngine >= 0)
            {
                Agent.SetDestination(_listEngine[_currentEngine - 1].transform.position);
                Agent.isStopped = false;
            }
        }
    }
}
