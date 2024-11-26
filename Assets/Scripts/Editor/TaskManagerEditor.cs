using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TaskManager))]
public class TaskManagerEditor : Editor
{
    string stringToEdit = "";
    public override void OnInspectorGUI()
    {
        // Cast du target pour accéder à l'instance TaskManager
        TaskManager taskManager = (TaskManager)target;

        foreach (Tasks task in taskManager.tasksInProgress)
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.Toggle(false);
            EditorGUILayout.LabelField(task.TasksName, EditorStyles.boldLabel);
            GUILayout.Button("Info");
            GUILayout.EndHorizontal();
            
        }

        stringToEdit = GUILayout.TextField(stringToEdit, 25);

        // Bouton pour ajouter une tâche
        if (GUILayout.Button("Ajouter une tâche"))
        {
            //Tasks newTask = CreateTaskExample(stringToEdit);
            //taskManager.AddTask(newTask);

            // Marque le TaskManager comme modifié pour que les changements soient sauvegardés
            EditorUtility.SetDirty(taskManager);
        }
    }

    /*private Tasks CreateTaskExample(string taskName)
    {
        if (taskName == null)
        {
            stringToEdit = "Nouvelle tâche";
        }
        // Création d'un GameObject temporaire avec un composant Tasks
        GameObject newTaskObject = new GameObject("NewTask");
        Tasks newTask = newTaskObject.AddComponent<Tasks>();
        newTask.TasksName = taskName;
        return newTask;
    }*/
}
