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
    private int _currentEngineID;

    public GameObject CurrentEngine;

    [SerializeField]
    private PlayerMain _plMain;

    private MachineControl _machControl;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private AnimInteract _interact;

    private IEnumerator _coroutine;

    public Ressource Ressource;

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
        Debug.Log("trigger");
        //_animator = other.GetComponent<Animator>();
        _animator = other.GetComponentInParent<Animator>();
        //_interact = other.GetComponent<AnimInteract>();
        _interact = other.GetComponentInParent<AnimInteract>();
        //_currentEngine = _listEngine.IndexOf(other.gameObject.GetComponent<AreaEngine>());
        if (other.TryGetComponent(out AreaEngine areaEngine))
        {
            CurrentEngine = other.gameObject;
            areaEngine.RessourceComplete += ChangeEngineTarget;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == CurrentEngine)
        {
            CurrentEngine = null;
        }
    }

    /// <summary>
    /// Fonction qui s'active lorsque le joueur bouge en contact d'une machine posé
    /// </summary>
    public void StartMoving()
    {
        if (_animator != null && _interact != null)
        {
            StopAllCoroutines();

            if (_listEngine[_currentEngineID].isHolding && _listEngine[_currentEngineID].Ressource.RessourceState > -1 && _listEngine[_currentEngineID].EngineId + 1 == _listEngine[_currentEngineID].Ressource.RessourceState)
            {
                GetRessource(_listEngine[_currentEngineID].Ressource);
                _listEngine[_currentEngineID].LoseRessource();
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
        bool isRessourceStateCorrect = false;
        if (_isHolding)
        {
            if (_listEngine[_currentEngineID].EngineId == Ressource.RessourceState)
            {
                isRessourceStateCorrect = true;
            }
        }
        else
        {
            if (_listEngine[_currentEngineID].EngineId == _listEngine[_currentEngineID].Ressource.RessourceState)
            {
                isRessourceStateCorrect = true;
            }
        }

        if (_animator != null && _interact != null && isRessourceStateCorrect)
        {
            if (!_listEngine[_currentEngineID].isHolding && _isHolding)
            {
                _listEngine[_currentEngineID].GetRessource(Ressource);
                LoseRessource();
            }

            if (_listEngine[_currentEngineID].isHolding)
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
    private void ChangeEngineTarget(int newEngineID)
    {
        _currentEngineID = newEngineID;
    }

    public void GetRessource(Ressource ressource)
    {
        Ressource = ressource;
        _isHolding = true;
        Ressource.RessourceAsset.transform.parent = transform;
    }

    public void LoseRessource()
    {
        Ressource = null;
        _isHolding = false;
    }

    /// <summary>
    /// Lorsque le joueur bouge au mauvais moment de la fin de l'anim
    /// </summary>
    private void Failed()
    {
        
    }
}
