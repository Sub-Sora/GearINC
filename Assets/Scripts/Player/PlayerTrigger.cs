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
            if (other.GetComponent<Workstation>())
            {
                other.SendMessage("ShowJobView");
            }
            else if (other.GetComponent<AreaEngine>() && _main.Ressource.RessourceHold.RessourceState == 0)
            {
                AreaEngine engineTrigger = other.GetComponent<AreaEngine>();
                if (engineTrigger.EngineId == 0)
                {
                    other.GetComponent<AreaEngine>().Ressource = _main.Ressource.RessourceHold;
                    _main.Ressource.RessourceHold = null;
                    engineTrigger.isHolding = true;
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