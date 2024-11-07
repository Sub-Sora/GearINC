using System.Collections.Generic;
using UnityEngine;
using static Job;

[CreateAssetMenu(fileName = "Objective", menuName = "NewAssets/Create new Objective")]

public class ObjectiveObject : ScriptableObject
{ 
    // Faire en sorte que les types demander soient présent dans all job
    public List<JobType> TypesNeeded = new List<JobType>();
    public List<JobType> AllJob = new List<JobType>();
    public string ObjectiveName;
}