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