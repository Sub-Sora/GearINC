using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Button _interButton;

    private GameObject _interObj;

    private PlayerMain _main;

    private void Init(PlayerMain main)
    {
        _main = main;
        main.Interact = this;
    }

    private void Start()
    {
        _interButton.onClick.AddListener(InteractButton);
        _interObj = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>())
        {
            if (other.gameObject.GetComponent<Workstation>())
            {
                other.SendMessage("ShowJobView");
            }

            _interButton.gameObject.SetActive(true);
            _interObj = other.gameObject;
        }
    }

    public void ActiveInteractButton(GameObject other)
    {
        _interButton.gameObject.SetActive(true);
        _interObj = other;
    }

    public void DesactiveInteractButton()
    {
        _interButton.gameObject.SetActive(false);
        _interObj = null;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Workstation>())
        {
            other.SendMessage("HideJobView");
        }

        _interButton.gameObject.SetActive(false);
        _interObj = null;

    }

    /// <summary>
    /// Permet au joueur d'intéragir avec les éléments interactable
    /// </summary>
    public void InteractButton()
    {
        if (_interObj != null)
        {
            _interObj.SendMessage("Interact", _main);
        }
    }
}
