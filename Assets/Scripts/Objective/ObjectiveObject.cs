using System.Collections.Generic;
using UnityEngine;
using static Job;

[CreateAssetMenu(fileName = "Objective", menuName = "NewAssets/Create new Objective")]

public class ObjectiveObject : ScriptableObject
{ 
    // Faire en sorte que les types demand�s soient pr�sent dans all job
    public List<JobType> TypesNeeded = new List<JobType>();
    public List<JobType> AllJob = new List<JobType>();
    public string ObjectiveName;
    public Sprite ObjectiveIcone;
    public Mesh ObjectiveMesh;
    public ObjectiveObject NextObjective;
}