using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Tasks))]

public class TasksAtWork : Editor
{
    private SerializedProperty _tasksInProgressProperty;
    string stringToEdit = "";
    private int leftPosition = Screen.width / 2;
    private int topPosition = Screen.height / 2;
    private int boxHeight = 20;
    private float newBoxWidth;
    private GUIStyle myStyle = new GUIStyle();
    Vector2 sizeOfLabel;

    void Start()
    {
        myStyle.alignment = TextAnchor.MiddleCenter;
        //any other styles
    }
    private void OnEnable()
    {
        _tasksInProgressProperty = serializedObject.FindProperty("TasksInProgress");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("Tache en cours", EditorStyles.boldLabel);
        for (int i = 0;  i < _tasksInProgressProperty.arraySize; ++i)
        {
            EditorGUILayout.LabelField(_tasksInProgressProperty.GetArrayElementAtIndex(i).stringValue, EditorStyles.boldLabel);

            //Calculates the size of your label text with myStyle
            sizeOfLabel = myStyle.CalcSize(new GUIContent(_tasksInProgressProperty.GetArrayElementAtIndex(i).stringValue));

            //sizeOfLabel.x will get the length. +6 can be adjusted for padding	
            newBoxWidth = sizeOfLabel.x + 6;

            //The background box behind the label, just for the example.
            GUI.Box(new Rect(leftPosition - newBoxWidth / 2, topPosition + 15 * i, newBoxWidth, boxHeight), "");

            //The label text, this example is centered
            GUI.Label(new Rect(leftPosition - newBoxWidth / 2, topPosition + 15 * i, newBoxWidth, boxHeight), _tasksInProgressProperty.GetArrayElementAtIndex(i).stringValue, myStyle);

            //The button, drawn to the right of wherever the label ends.
            GUI.Button(new Rect(leftPosition + newBoxWidth / 2, topPosition + 15 * i, 25, boxHeight), "");
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
