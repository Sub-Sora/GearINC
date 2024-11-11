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
            else if (_main.Ressource.IsHolding)
            {
                AreaEngine engineTrigger = other.GetComponent<AreaEngine>();
                if (engineTrigger && _main.Ressource.RessourceHold.RessourceState == 0)
                {
                    if (engineTrigger.EngineId == 0)
                    {
                        engineTrigger.Ressource = _main.Ressource.RessourceHold;
                        _main.Ressource.RessourceHold = null;
                        _main.Ressource.IsHolding = false;
                        engineTrigger.isHolding = true;
                        engineTrigger.Ressource.RessourceAsset.transform.parent = engineTrigger.transform;
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