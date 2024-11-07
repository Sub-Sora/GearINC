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
        _animator = other.GetComponent<Animator>();
        _interact = other.GetComponent<AnimInteract>();
        if (_machControl.Agent.isStopped == true)
    }

    /// <summary>
    /// Fonction qui s'active lorsque le joueur bouge en contact d'une machine posé
    /// </summary>
    public void StartMoving()
    {
        if (_animator != null && _interact != null)
        {
            //_animator.StopPlayback();
            StopCoroutine(_coroutine);
            if (_animator.GetBool("isPlay") == true)
            {
                if (_interact.AnimEnd == false && _interact.LateAnim == false) Complete();
                else Failed();
            }
            _animator = null;
            _interact = null;
        }
    }

    /// <summary>
    /// Fonction qui s'active lorsque le joueur se stop en contact d'une machine posé
    /// </summary>
    public void StopMoving()
    {
        if (_animator != null && _interact != null)
        {
            Debug.Log("Machine stopped");
            StartCoroutine(_coroutine);
        }
            
    }

    /// <summary>
    /// Coroutine qui vas attendre "time" temps avant de lancer l'aniamtion à l'arrêt du joueur
    /// </summary>
    /// <param name="time">Temps avant du lancement de l'animation</param>
    /// <returns></returns>
    private IEnumerator StartWaitingCraft(float time)
    {
        yield return new WaitForSeconds(time);
        _animator.SetBool("isPlay", true);
    }

    /// <summary>
    /// Lorsque le joueur bouge au bon moment de la fin de l'anim
    /// </summary>
    private void Complete()
    {

    }

    /// <summary>
    /// Lorsque le joueur bouge au mauvais moment de la fin de l'anim
    /// </summary>
    private void Failed()
    {
        
    }
}
