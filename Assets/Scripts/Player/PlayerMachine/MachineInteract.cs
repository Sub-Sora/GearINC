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

    public AreaEngine CurrentEngine;

    [SerializeField]
    private PlayerMain _plMain;

    private MachineControl _machControl;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private AnimInteract _interact;

    [SerializeField]
    private Transform _ressourceParent;

    private IEnumerator _coroutine;

    public Ressource Ressource;

    public bool _isHolding;

    private bool _waitAreaEngineAnimation;

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
        if (other.TryGetComponent(out AreaEngine areaEngine))
        {
            if (areaEngine.EngineId == _currentEngineID)
            {
                CurrentEngine = areaEngine;
            }
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
            _waitAreaEngineAnimation = false;

            if (CurrentEngine.isHolding && CurrentEngine.Ressource.RessourceState > -1 && CurrentEngine.EngineId + 1 == CurrentEngine.Ressource.RessourceState)
            {
                GetRessource(CurrentEngine.Ressource);
                CurrentEngine.LoseRessource();
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
        if (!_waitAreaEngineAnimation)
        {
            _waitAreaEngineAnimation = true;
            if (_animator == null && _interact == null)
            {
                _animator = CurrentEngine.GetComponentInParent<Animator>();
                _interact = CurrentEngine.GetComponentInParent<AnimInteract>();
            }

            bool isRessourceStateCorrect = false;
            if (_isHolding)
            {
                if (CurrentEngine.EngineId == Ressource.RessourceState)
                {
                    isRessourceStateCorrect = true;
                }
            }
            else
            {
                if (CurrentEngine.EngineId == CurrentEngine.Ressource.RessourceState)
                {
                    isRessourceStateCorrect = true;
                }
            }

            if (_animator != null && _interact != null && isRessourceStateCorrect)
            {
                if (!CurrentEngine.isHolding && _isHolding)
                {
                    CurrentEngine.GetRessource(Ressource);
                    LoseRessource();
                }

                if (CurrentEngine.isHolding)
                {
                    StartCoroutine(StartWaitingCraft(0.5f));
                }
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
        Ressource.RessourceAsset.transform.SetParent(_ressourceParent, false);
        ChangeEngineTarget(Ressource.RessourceState);
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

    public void RessourceComplete()
    {
        _waitAreaEngineAnimation = false;
    }
}
