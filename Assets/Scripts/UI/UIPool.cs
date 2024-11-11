using System.Collections.Generic;
using UnityEngine;

public class UIPool : MonoBehaviour
{
    public List<UIJobName> JobName = new List<UIJobName>();

    [SerializeField]
    private GameObject _victory;

    private void Init(ManagerMain main)
    {
        main.UI = this;
    }

    public void Victory()
    {
        _victory.SetActive(true);
    }
}
