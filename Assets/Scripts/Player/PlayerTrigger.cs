using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private PlayerMain _main;

    private void Init(PlayerMain main)
    {
        _main = main;
        main.Trigger = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Interactable>())
        {
            AreaEngine engineTrigger = other.GetComponent<AreaEngine>();
            if (other.GetComponent<Workstation>())
            {
                other.SendMessage("ShowJobView");
            }
            else if (_main.Ressource.IsHolding)
            {
                if (engineTrigger && _main.Ressource.RessourceHold.RessourceState == 0)
                {
                    if (engineTrigger.EngineId == 0)
                    {
                        engineTrigger.GetRessource(_main.Ressource.RessourceHold);
                        _main.Ressource.LoseRessource();
                    }
                }
            }
            else if (engineTrigger != null)
            {
                if (engineTrigger.isHolding)
                {
                    if (engineTrigger.Ressource.RessourceState == -1)
                    {
                        _main.Ressource.GetRessource(engineTrigger.Ressource);
                        engineTrigger.LoseRessource();
                    }
                }
            }
            
            _main.Interact.ActiveInteractButton(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Workstation>())
        {
            other.SendMessage("HideJobView");
        }

        _main.Interact.DesactiveInteractButton();
    }
}