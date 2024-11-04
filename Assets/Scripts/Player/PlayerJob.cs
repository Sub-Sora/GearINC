using UnityEngine;
using static Job;

public class PlayerJob : MonoBehaviour
{
    public JobType Job;
    public GameObject EnginePut;

    private void Init(PlayerMain main)
    {
        main.Job = this;
    }
}