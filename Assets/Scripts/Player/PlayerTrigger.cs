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
        Debug.Log(other.name);
        if (other.GetComponent<Interactable>())
        {
            if (_main.IsTuto)
            {
                if (other.gameObject != TutoManager.Instance.TutoPhases[TutoManager.Instance.TutoActualPeriod])
                {
                    return;
                }
            }
            
            AreaEngine engineTrigger = other.GetComponent<AreaEngine>();
            if (other.GetComponent<Workstation>())
            {
                other.SendMessage("ShowJobView");
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