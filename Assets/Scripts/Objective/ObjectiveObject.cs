using System.Collections.Generic;
using UnityEngine;
using static Job;

[CreateAssetMenu(fileName = "Objective", menuName = "NewAssets/Create new Objective")]

public class ObjectiveObject : ScriptableObject
{
    public List<JobType> TypesNeeded = new List<JobType>();
}