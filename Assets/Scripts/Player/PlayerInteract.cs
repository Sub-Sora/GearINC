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
            _interButton.gameObject.SetActive(true);
            _interObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _interButton.gameObject.SetActive(false);
        _interObj = null;

    }

    public void InteractButton()
    {
        Debug.Log("button");
        if (_interObj != null)
        {
            _interObj.SendMessage("Interact", _main);
        }
    }
}
