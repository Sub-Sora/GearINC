using UnityEngine;
using UnityEditor;

public class TaskManagerWindow : EditorWindow
{
    private string taskName = "Nouvelle T�che"; // Nom par d�faut de la t�che
    private string taskDescription = "Description de la t�che"; // Description par d�faut

    [MenuItem("Window/Task Manager")]
    public static void ShowWindow()
    {
        TaskManagerWindow window = GetWindow<TaskManagerWindow>("Task Manager");
        window.Show();
    }

    private void OnGUI()
    {
        // Interface pour saisir les informations de la t�che
        EditorGUILayout.LabelField("Gestion des t�ches", EditorStyles.boldLabel);

        taskName = EditorGUILayout.TextField("Nom de la t�che", taskName);
        taskDescription = EditorGUILayout.TextField("Description", taskDescription);

        // Ajouter une t�che
        if (GUILayout.Button("Cr�er une nouvelle t�che"))
        {
            CreateNewTask();
        }
    }

    private void CreateNewTask()
    {
        // Cr�er une nouvelle instance de Task en tant qu'asset
        Tasks newTask = ScriptableObject.CreateInstance<Tasks>();

        // Remplir les propri�t�s de la t�che
        newTask.TasksName = taskName;
        newTask.TaskDescription = taskDescription;
        newTask.TaskState = false;

        // Cr�er un dossier "Assets/Tasks" si ce n'est pas d�j� fait
        string taskFolder = "Assets/Tasks";
        if (!AssetDatabase.IsValidFolder(taskFolder))
        {
            AssetDatabase.CreateFolder("Assets", "Tasks");
        }

        // Sauvegarder l'asset de la t�che
        AssetDatabase.CreateAsset(newTask, $"Assets/Tasks/{taskName}.asset");
        AssetDatabase.SaveAssets();

        // S�lectionner la t�che dans l'�diteur pour un acc�s facile
        Selection.activeObject = newTask;

        // R�initialiser les champs pour la cr�ation d'une nouvelle t�che
        taskName = "Nouvelle T�che";
        taskDescription = "Description de la t�che";
    }
}
