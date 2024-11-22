using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Tasks/Task")]
public class Tasks : ScriptableObject
{
    public bool TaskState;
    public string TaskDescription;
    public string TasksName;
}