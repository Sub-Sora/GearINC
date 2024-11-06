using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInteract : MonoBehaviour
{
    private MachineControl _machControl;

    private Animator _animator;

    private AnimInteract _interact;

    private void Start()
    {
        _machControl = GetComponent<MachineControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Gérer le temps avec  animation, si trop court ou trop long, raté.
        if (_machControl.Agent.isStopped == true)
        {
            _animator = other.GetComponent<Animator>();
            _interact = other.GetComponent<AnimInteract>();
            StartCoroutine(StartWaitingCraft(5));
        }
    }

    private IEnumerator StartWaitingCraft(float time)
    {
        yield return new WaitForSeconds(time);
        _animator.Play("EngineAnim");
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
