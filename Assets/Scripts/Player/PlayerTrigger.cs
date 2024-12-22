using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlayerTrigger : MonoBehaviour
{
    private PlayerMain _main;
    private List<GameObject> _allInteractObject = new List<GameObject>();

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
            else if (engineTrigger != null)
            {
                if (engineTrigger.isHolding)
                {
                    if (engineTrigger.Ressource.RessourceState == -1 && !_main.Holding.IsHolding)
                    {
                        _main.Ressource.GetRessource(engineTrigger.Ressource);
                        engineTrigger.LoseRessource();
                    }
                }
            }

            GameObject interactObject = other.gameObject;
            _allInteractObject.Add(interactObject);
            _main.Interact.ActiveInteractButton(interactObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Workstation>())
        {
            other.SendMessage("HideJobView");
        }

        _allInteractObject.Remove(other.gameObject);
        if (_allInteractObject.Count == 0)
        {
            _main.Interact.DesactiveInteractButton();
        }
        else
        {
            _main.Interact.ChangeInteractObject(_allInteractObject.Last());
        }
    }
}