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
    /// Vas initialiser un passage pour l'agent pour éviter des erreurs de démarage
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
    /// Va permettre à l'agent de continuer son trajet lorsqu'il arrive à un engine
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
        // Amène l'agent vers la machine suivante
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

        // Amène l'agent vers la machine précedente
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

        //Arrête l'agent quand aucune touche n'es pressé
        if (Move == 0)
        {
            _moving = Move;
            Agent.isStopped = true;
            _interact.StopMoving();
        }
    }

    /// <summary>
    /// Fonction appelé lors de l'update pour permettre à l'agent de continuer sa route quand il atteint une machine
    /// </summary>
    private void NextDestination()
    {
        // Condition pour vérifier que l'agent avance et donc aller à la machine suivante
        if (_moving == 1)
        {
            if (_currentEngine < _listEngine.Count)
            {
                if (_currentEngine >= _listEngine.Count) _currentEngine = _listEngine.Count;
                Agent.SetDestination(_listEngine[_currentEngine].transform.GetChild(0).position);
                Agent.isStopped = false;
            }
        }

        // Condition pour vérifier que l'agent recul et donc aller à la machine précedente
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
