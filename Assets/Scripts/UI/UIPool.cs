using System.Collections.Generic;
using UnityEngine;

public class UIPool : MonoBehaviour
{
    public List<UIJobName> JobName = new List<UIJobName>();

    private void Init(ManagerMain main)
    {
        main.UI = this;
    }
}
