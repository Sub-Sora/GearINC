using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TaskManager))]
public class TaskManagerEditor : Editor
{
    string stringToEdit = "";
    public override void OnInspectorGUI()
    {
        // Cast du target pour acc�der � l'instance TaskManager
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

        // Bouton pour ajouter une t�che
        if (GUILayout.Button("Ajouter une t�che"))
        {
            //Tasks newTask = CreateTaskExample(stringToEdit);
            //taskManager.AddTask(newTask);

            // Marque le TaskManager comme modifi� pour que les changements soient sauvegard�s
            EditorUtility.SetDirty(taskManager);
        }
    }

    /*private Tasks CreateTaskExample(string taskName)
    {
        if (taskName == null)
        {
            stringToEdit = "Nouvelle t�che";
        }
        // Cr�ation d'un GameObject temporaire avec un composant Tasks
        GameObject newTaskObject = new GameObject("NewTask");
        Tasks newTask = newTaskObject.AddComponent<Tasks>();
        newTask.TasksName = taskName;
        return newTask;
    }*/
}
