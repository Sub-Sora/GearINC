using UnityEngine;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour
{
    public List<Tasks> tasksInProgress; // Liste des t�ches

    // M�thode pour ajouter une t�che � la liste
    public void AddTask(Tasks task)
    {
        if (tasksInProgress == null)
            tasksInProgress = new List<Tasks>(); // Initialiser la liste si n�cessaire

        if (task != null && !tasksInProgress.Contains(task))
        {
            tasksInProgress.Add(task);
            Debug.Log($"T�che ajout�e : {task.TasksName}");
        }
        else
        {
            Debug.LogWarning("La t�che est d�j� dans la liste ou est invalide.");
        }
    }
}