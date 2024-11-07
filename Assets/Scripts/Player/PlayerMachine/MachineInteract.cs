using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInteract : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _plMain;

    private MachineControl _machControl;

    private Animator _animator;

    private AnimInteract _interact;

    private IEnumerator _coroutine;

    private void Start()
    {
        _machControl = GetComponent<MachineControl>();
        _coroutine = StartWaitingCraft(0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Collider");

        //G�rer le temps avec  animation, si trop court ou trop long, rat�.
        if (_machControl.Agent.isStopped == true)
        {
            _animator = other.GetComponent<Animator>();
            _interact = other.GetComponent<AnimInteract>();
            StartCoroutine(_coroutine);
        }

        if (_machControl.Agent.isStopped == false)
        {
            _animator.StopPlayback();
            StopCoroutine(_coroutine);
            if (_animator && _interact != null)
            {
                if (_interact.AnimEnd == false && _interact.LateAnim == false) Complete();
                else Failed();
            }
            _animator = null;
            _interact = null;
        }
    }

    private IEnumerator StartWaitingCraft(float time)
    {
        yield return new WaitForSeconds(time);
        _animator.SetBool("isPlay", true);
    }

    private void Complete()
    {

    }

    private void Failed()
    {
        
    }
}
