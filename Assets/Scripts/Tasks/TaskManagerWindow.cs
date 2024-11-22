using UnityEngine;
using UnityEditor;

public class TaskManagerWindow : EditorWindow
{
    private string taskName = "Nouvelle Tâche"; // Nom par défaut de la tâche
    private string taskDescription = "Description de la tâche"; // Description par défaut

    [MenuItem("Window/Task Manager")]
    public static void ShowWindow()
    {
        TaskManagerWindow window = GetWindow<TaskManagerWindow>("Task Manager");
        window.Show();
    }

    private void OnGUI()
    {
        // Interface pour saisir les informations de la tâche
        EditorGUILayout.LabelField("Gestion des tâches", EditorStyles.boldLabel);

        taskName = EditorGUILayout.TextField("Nom de la tâche", taskName);
        taskDescription = EditorGUILayout.TextField("Description", taskDescription);

        // Ajouter une tâche
        if (GUILayout.Button("Créer une nouvelle tâche"))
        {
            CreateNewTask();
        }
    }

    private void CreateNewTask()
    {
        // Créer une nouvelle instance de Task en tant qu'asset
        Tasks newTask = ScriptableObject.CreateInstance<Tasks>();

        // Remplir les propriétés de la tâche
        newTask.TasksName = taskName;
        newTask.TaskDescription = taskDescription;
        newTask.TaskState = false;

        // Créer un dossier "Assets/Tasks" si ce n'est pas déjà fait
        string taskFolder = "Assets/Tasks";
        if (!AssetDatabase.IsValidFolder(taskFolder))
        {
            AssetDatabase.CreateFolder("Assets", "Tasks");
        }

        // Sauvegarder l'asset de la tâche
        AssetDatabase.CreateAsset(newTask, $"Assets/Tasks/{taskName}.asset");
        AssetDatabase.SaveAssets();

        // Sélectionner la tâche dans l'éditeur pour un accès facile
        Selection.activeObject = newTask;

        // Réinitialiser les champs pour la création d'une nouvelle tâche
        taskName = "Nouvelle Tâche";
        taskDescription = "Description de la tâche";
    }
}
