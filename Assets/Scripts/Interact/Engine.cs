using UnityEngine;
using static Job;

public class Engine : Interactable
{
    public JobType Type;

    public override void Interact()
    {
        Debug.Log(Type);
    }
}