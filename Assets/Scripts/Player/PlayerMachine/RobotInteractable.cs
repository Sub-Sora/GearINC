using UnityEngine;

public class RobotInteractable : Interactable
{
    [SerializeField]
    private MachineInteract _machine;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Interact(PlayerMain player)
    {
        if (player.IsTuto)
        {
            if (gameObject == TutoManager.Instance.TutoPhases[TutoManager.Instance.TutoActualPeriod])
            {
                TutoManager.Instance.IngrementPeriod();
            }
            else
            {
                return;
            }
        }

        if (!_machine._isHolding)
        {
            _machine.GetRessource(player.Ressource.RessourceHold);
            player.Ressource.LoseRessource();
            _animator.SetBool("GetRessource", true);
        }
    }
}