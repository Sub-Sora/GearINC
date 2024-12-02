using UnityEngine;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour
{
    public List<Tasks> tasksInProgress; // Liste des tâches

    // Méthode pour ajouter une tâche à la liste
    public void AddTask(Tasks task)
    {
        if (tasksInProgress == null)
            tasksInProgress = new List<Tasks>(); // Initialiser la liste si nécessaire

        if (task != null && !tasksInProgress.Contains(task))
        {
            tasksInProgress.Add(task);
            Debug.Log($"Tâche ajoutée : {task.TasksName}");
        }
        else
        {
            Debug.LogWarning("La tâche est déjà dans la liste ou est invalide.");
        }
    }
}