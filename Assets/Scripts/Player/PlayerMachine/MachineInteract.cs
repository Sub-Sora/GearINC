using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInteract : MonoBehaviour
{
    [SerializeField]
    private ManagerMain _main;

    [SerializeField]
    private List<AreaEngine> _listEngine;

    [SerializeField]
    private int _currentEngine;

    [SerializeField]
    private PlayerMain _plMain;

    private MachineControl _machControl;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private AnimInteract _interact;

    private IEnumerator _coroutine;

    [SerializeField]
    private Ressource _ressource;

    private void Start()
    {
        _machControl = GetComponent<MachineControl>();
        _coroutine = StartWaitingCraft(0.5f);
    }

    public void InitializedPath(List<AreaEngine> engineList)
    {
        _listEngine = engineList;
    }

    private void OnTriggerEnter(Collider other)
    {
        _animator = other.GetComponent<Animator>();
        _interact = other.GetComponent<AnimInteract>();
        _currentEngine = _listEngine.IndexOf(other.gameObject.GetComponent<AreaEngine>());
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
            if (_listEngine[_currentEngine].Ressource !=null)
            {
                _ressource = _listEngine[_currentEngine].Ressource;
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
        Debug.Log("is stopped");
        if (_ressource.RessourceState == _currentEngine)
        {
            Debug.Log("enter ressources condition");
            if (_animator != null && _interact != null)
            {
                _listEngine[_currentEngine].Ressource = _ressource;
                StartCoroutine(_coroutine);
            }
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
        _ressource = null;
        _animator.SetBool("isPlay", true);
    }

    /// <summary>
    /// Lorsque le joueur bouge au bon moment de la fin de l'anim
    /// </summary>
    private void Complete()
    {
        _listEngine[_currentEngine].Ressource.RessourceState ++;
    }

    /// <summary>
    /// Lorsque le joueur bouge au mauvais moment de la fin de l'anim
    /// </summary>
    private void Failed()
    {
        
    }
}
