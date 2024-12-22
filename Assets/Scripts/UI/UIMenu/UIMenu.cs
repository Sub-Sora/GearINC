using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField]
    private Button _menuButton;

    private HapticButton _haptic;

    private void Start()
    {
        _haptic = GameObject.Find("Canvas").GetComponent<HapticButton>();
        _menuButton.onClick.AddListener(MenuButtonPressed);
    }

    public void MenuButtonPressed()
    {
        if (_haptic != null) _haptic.hapticEvent.Invoke();
        GetComponent<Animator>().SetBool("ButtonPressed", true);
    }

    // Vas fermer le menu lors de la selection des options ou jobs
    public void ButtonSelected()
    {
        GetComponent<Animator>().SetBool("ButtonPressed", true);
    }
}
