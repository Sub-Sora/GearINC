using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInteract : MonoBehaviour, IRessourceHolder
{
    [SerializeField]
    private ManagerOnce _main;

    [SerializeField]
    private List<AreaEngine> _listEngine = new List<AreaEngine>();

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

    public bool _isHolding;

    private void Start()
    {
        _machControl = GetComponent<MachineControl>();
        _coroutine = StartWaitingCraft(0.5f);
    }

    /// <summary>
    /// Ce lance à l'initialisation
    /// </summary>
    /// <param name="engineList"></param>
    public void InitializedPath(List<AreaEngine> engineList)
    {
        _listEngine = engineList;
    }

    private void OnTriggerEnter(Collider other)
    {
        //_animator = other.GetComponent<Animator>();
        _animator = other.GetComponentInParent<Animator>();
        //_interact = other.GetComponent<AnimInteract>();
        _interact = other.GetComponentInParent<AnimInteract>();
        //_currentEngine = _listEngine.IndexOf(other.gameObject.GetComponent<AreaEngine>());
        _currentEngine = _listEngine.IndexOf(other.gameObject.GetComponentInParent<AreaEngine>());
    }

    /// <summary>
    /// Fonction qui s'active lorsque le joueur bouge en contact d'une machine posé
    /// </summary>
    public void StartMoving()
    {
        if (_animator != null && _interact != null)
        {
            StopAllCoroutines();

            if (_listEngine[_currentEngine].isHolding && _listEngine[_currentEngine].Ressource.RessourceState > -1)
            {
                GetRessource(_listEngine[_currentEngine].Ressource);
                _listEngine[_currentEngine].LoseRessource();
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
            if (!_listEngine[_currentEngine].isHolding && _isHolding)
            {
                _listEngine[_currentEngine].GetRessource(_ressource);
                LoseRessource();
            }

            if (_listEngine[_currentEngine].isHolding)
            {
                StartCoroutine(StartWaitingCraft(0.5f));
            }
        }
    }

    /// <summary>
    /// Coroutine qui vas attendre "time" temps avant de lancer l'animation à l'arrêt du joueur
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
        if (_listEngine[_currentEngine].VerifyEngine())
        {
            _listEngine[_currentEngine].Ressource.RessourceState++;
        }
        else
        {
            _listEngine[_currentEngine].Ressource.RessourceState = -1;
        }
    }

    public void GetRessource(Ressource ressource)
    {
        _ressource = ressource;
        _isHolding = true;
        _ressource.RessourceAsset.transform.parent = transform;
    }

    public void LoseRessource()
    {
        _ressource = null;
        _isHolding = false;
    }

    /// <summary>
    /// Lorsque le joueur bouge au mauvais moment de la fin de l'anim
    /// </summary>
    private void Failed()
    {
        
    }
}
