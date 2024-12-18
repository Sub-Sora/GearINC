using System.Collections.Generic;
using UnityEngine;
using static Job;

public class PlayerJob : PlayerJobParent
{
    public GameObject EnginePut;
    public GameObject LastJob;
    public List<PlayerJobParent> Skins = new List<PlayerJobParent>();

    private void Init(PlayerMain main)
    {
        main.Job = this;
    }
}