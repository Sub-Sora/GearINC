using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MachineControl : MonoBehaviour
{
    public MachineInteract _interact;

    private List<AreaEngine> _listEngine = new List<AreaEngine>();

    //Take the current Engine come from
    private int _currentEngine;

    [HideInInspector]
    public NavMeshAgent Agent;

    [SerializeField]
    private InputActionReference _moveMachine;

    private int _moving;

    /// <summary>
    /// Vas initialiser un passage pour l'agent pour �viter des erreurs de d�marage
    /// </summary>
    public void InitializedPath(List<AreaEngine> engineList)
    {
        Agent = GetComponent<NavMeshAgent>();
        _listEngine = engineList;
        _interact = GetComponent<MachineInteract>();
        _currentEngine = 0;
        Agent.SetDestination(_listEngine[_currentEngine].transform.GetChild(0).position);
        Agent.isStopped = true;
        _interact.InitializedPath(engineList);
    }

    /// <summary>
    /// Va permettre � l'agent de continuer son trajet lorsqu'il arrive � un engine
    /// </summary>
    private void Update()
    {
        if (_moving == 1)
        {
            if (!Agent.pathPending && Agent.remainingDistance < 0.1f)
            {
                _currentEngine++;
                if (_currentEngine >= _listEngine.Count) _currentEngine = _listEngine.Count;
                NextDestination();
            }
        }

        if (_moving == -1)
        {
            if (!Agent.pathPending && Agent.remainingDistance < 0.1f && _currentEngine >= 1)
            {
                _currentEngine--;
                if (_currentEngine <= 0) _currentEngine = 1;
                NextDestination();
            }
        }
    }

    public void OnMachine(int Move)
    {
        // Am�ne l'agent vers la machine suivante
        if (Move == 1)
        {
            _moving = Move;
            if (_currentEngine < _listEngine.Count)
            {
                Agent.SetDestination(_listEngine[_currentEngine].transform.GetChild(0).position);
                Agent.isStopped = false;
                _interact.StartMoving();
            }
        }

        // Am�ne l'agent vers la machine pr�cedente
        if (Move == -1)
        {
            _moving = Move;
            if (_currentEngine > 0)
            {
                Agent.SetDestination(_listEngine[_currentEngine - 1].transform.GetChild(0).position);
                Agent.isStopped = false;
                _interact.StartMoving();
            }
        }

        //Arr�te l'agent quand aucune touche n'es press�
        if (Move == 0)
        {
            _moving = Move;
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
        if (_moving == 1)
        {
            if (_currentEngine < _listEngine.Count)
            {
                if (_currentEngine >= _listEngine.Count) _currentEngine = _listEngine.Count;
                Agent.SetDestination(_listEngine[_currentEngine].transform.GetChild(0).position);
                Agent.isStopped = false;
            }
        }

        // Condition pour v�rifier que l'agent recul et donc aller � la machine pr�cedente
        if (_moving == -1)
        {
            if (_currentEngine >= 0)
            {
                Agent.SetDestination(_listEngine[_currentEngine - 1].transform.GetChild(0).position);
                Agent.isStopped = false;
            }
        }
    }
}
