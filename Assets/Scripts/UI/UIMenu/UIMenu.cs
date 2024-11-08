using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField]
    private Button _menuButton;

    private void Start()
    {
        _menuButton.onClick.AddListener(MenuButtonPressed);
    }

    public void MenuButtonPressed()
    {
        GetComponent<Animator>().SetBool("ButtonPressed", true);
    }
}
