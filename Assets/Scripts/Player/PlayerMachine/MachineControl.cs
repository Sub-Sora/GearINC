using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MachineControl : MonoBehaviour
{
    public MachineInteract _interact;

    [SerializeField]
    private float _rotationSpeed = 5f;
    private bool _isRotated;
    [SerializeField]
    private float _rotationThreshold;

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
                MovingToPoint(true);
                _interact.StartMoving();
            }
        }

        // Am�ne l'agent vers la machine pr�cedente
        if (Move == -1)
        {
            _moving = Move;
            if (_currentEngine > 0)
            {
                MovingToPoint(false);
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
                MovingToPoint(true);
            }
        }

        // Condition pour v�rifier que l'agent recul et donc aller � la machine pr�cedente
        if (_moving == -1)
        {
            if (_currentEngine >= 0)
            {
                MovingToPoint(false);
            }
        }
    }

    /// <summary>
    /// Fonction pour avancer ou reculer (True avancer, False reculer)
    /// </summary>
    /// <param name="isForward">True avancer, False reculer</param>
    private void MovingToPoint(bool isForward)
    {
        //// Calcule la direction vers la cible
        //Vector3 directionToTarget = (_listEngine[_currentEngine].transform.position - transform.position).normalized;
        //Quaternion targetRotation = Quaternion.LookRotation(new Vector3(directionToTarget.x, 0, directionToTarget.z));

        //// V�rifie si une rotation est n�cessaire
        //float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);

        //if (angleDifference > _rotationThreshold)
        //{
        //    // Arr�te l'agent et effectue la rotation
        //    Agent.isStopped = true;
        //    _isRotated = false;
        //    RotateRobot(_listEngine[_currentEngine].transform.position);
        //}
        //else
        //{
        //    // Pas de rotation n�cessaire, se d�place directement
        //    _isRotated = true;
        //}

        //if (_isRotated)
        //{
        //    if (isForward)
        //    {
        //        Agent.SetDestination(_listEngine[_currentEngine].transform.GetChild(0).position);
        //        Agent.isStopped = false;
        //    }
        //    else
        //    {
        //        Agent.SetDestination(_listEngine[_currentEngine - 1].transform.GetChild(0).position);
        //        Agent.isStopped = false;
        //    }
        //}
        if (isForward)
        {
            Agent.SetDestination(_listEngine[_currentEngine].transform.GetChild(0).position);
            Agent.isStopped = false;
        }
        else
        {
            Agent.SetDestination(_listEngine[_currentEngine - 1].transform.GetChild(0).position);
            Agent.isStopped = false;
        }
    }

    //private void RotateRobot(Vector3 destination)
    //{
    //    // Calcule la direction vers la cible
    //    Vector3 direction = (destination - transform.position).normalized;
    //    Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

    //    // Continue de tourner jusqu'� ce que l'agent soit align�
    //    while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
    //    {
    //        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    //    }

    //    //transform.rotation = targetRotation;
    //    _isRotated = true;
    //}
}
