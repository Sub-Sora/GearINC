using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Tasks))]

public class TasksAtWork : Editor
{
    private SerializedProperty _tasksInProgressProperty;
    string stringToEdit = "";

    private void OnEnable()
    {
        _tasksInProgressProperty = serializedObject.FindProperty("TasksInProgress");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("Tache en cours", EditorStyles.boldLabel);
        foreach(SerializedProperty task in _tasksInProgressProperty)
        {
            EditorGUILayout.LabelField(task.stringValue, EditorStyles.boldLabel);
        }

       stringToEdit = GUILayout.TextField(stringToEdit, 25);

        if (GUILayout.Button("Ajouter un élément"))
        {
            _tasksInProgressProperty.arraySize++; // Augmente la taille de la liste
            _tasksInProgressProperty.GetArrayElementAtIndex(_tasksInProgressProperty.arraySize - 1).stringValue = stringToEdit; // Initialise le nouvel élément à la première valeur de l'enum
        }

        serializedObject.ApplyModifiedProperties();
    }
}
