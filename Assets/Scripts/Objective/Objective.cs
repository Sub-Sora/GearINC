using UnityEngine;

public class Objective : MonoBehaviour
{
    public ObjectiveObject Object;

    private void Init(ManagerMain main)
    {
        main.Objective = this;
    }
}