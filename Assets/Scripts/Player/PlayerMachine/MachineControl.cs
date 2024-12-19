using System;
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

    private int _moving;
    private bool _isMoving;

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
            if (_isMoving && !Agent.pathPending && Agent.remainingDistance < 0.1f)
            {
                _isMoving = false;
                _currentEngine++;
                if (_currentEngine >= _listEngine.Count) _currentEngine = _listEngine.Count;
                NextDestination();
            }
        }

        if (_moving == -1)
        {
            if (_isMoving && !Agent.pathPending && Agent.remainingDistance < 0.1f && _currentEngine >= 1)
            {
                _isMoving = false;
                _currentEngine--;
                if (_currentEngine <= 0) _currentEngine = 0;
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
            _isMoving = false;
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
        if (_isMoving) return;

        Vector3 targetPosition;
        if (isForward)
        {
            targetPosition = _listEngine[_currentEngine].transform.GetChild(0).position;
        }
        else
        {
            targetPosition = _listEngine[_currentEngine - 1].transform.GetChild(0).position;
        }

        // Lancer la coroutine pour tourner, puis avancer/reculer
        StartCoroutine(RotateTowards(targetPosition, () =>
        {
            // Avancer/reculer apr�s la rotation
            Agent.SetDestination(targetPosition); 
            Agent.isStopped = false;
            _isMoving = true;
        }));
    }

    private IEnumerator RotateTowards(Vector3 targetPosition, Action onComplete)
    {
        // Calculer la direction cible en ignorant les diff�rences d'altitude
        Vector3 targetDirection = (targetPosition - transform.position);
        // Ignorer l'axe vertical
        targetDirection.y = 0; 
        targetDirection.Normalize();
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        // V�rifier si l'entit� est d�j� align�e
        if (Quaternion.Angle(transform.rotation, targetRotation) <= 1f)
        {
            // Si d�j� align�, ex�cuter directement la suite
            onComplete?.Invoke(); 
            yield break; 
        }

        // Effectuer la rotation progressivement
        while (Quaternion.Angle(transform.rotation, targetRotation) > 1f)
        {
            // Ajuste la vitesse ici
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);
            // Stop la rotation si la touche n'ai plus press�
            if (_moving == 0)
            {
                yield break;
            }
            yield return null; // Attendre le prochain frame
        }

        

        // Une fois la rotation termin�e, d�clencher la suite
        onComplete?.Invoke();
    }
}
