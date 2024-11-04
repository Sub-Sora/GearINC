using UnityEngine;
using static Job;

public class Engine : Interactable
{
    public JobType Type;

    /// <summary>
    /// Ce lancera lorsque le joueur interragira avec
    /// </summary>
    public override void Interact(PlayerMain player)
    {
        Debug.Log(Type);
    }
}