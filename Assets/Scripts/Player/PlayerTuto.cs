using UnityEngine;
using UnityEngine.VFX;

public class PlayerTuto : MonoBehaviour
{
    [SerializeField]
    private Transform _arrowTransform;

    private Transform _newObjective;
    private PlayerMain _main;

    private void Start()
    {
        TutoManager.Instance.NewPhase += ChangeObjective;
        TutoManager.Instance.ArrowNewPhase();
    }

    private void Init(PlayerMain main)
    {
        _main = main;
    }

    private void Update()
    {
        if (_main.IsTuto)
        {
            _arrowTransform.LookAt(_newObjective);
        }
        else if (_arrowTransform.gameObject.activeSelf)
        {
            _arrowTransform.gameObject.SetActive(false);
        }
    }

    private void ChangeObjective(Transform newObjective)
    {
        _newObjective = newObjective;
    }
}